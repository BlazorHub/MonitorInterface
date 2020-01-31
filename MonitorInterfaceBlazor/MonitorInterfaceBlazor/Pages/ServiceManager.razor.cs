using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MonitorInterfaceBlazor.Constants;
using MonitorInterfaceBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MonitorInterfaceBlazor.Services;
using System.Text;

namespace MonitorInterfaceBlazor.Pages
{
    public class ServiceManagerBase : ComponentBase
    {
        public Results[] results;
        public List<NewJob> NewJobs { get; set; }

        [Parameter] public bool IsDisabled { get; set; } = true;
        [Parameter] public string Message { get; set; } 
        [Parameter] public string SelectMessage { get; set; } = "Select All";
        [Parameter] public string FontColor { get; set; } = "green";
        [Parameter] public DateTime? Date1 { get; set; } = DateTime.Now;
        [Parameter] public DateTime? Date2 { get; set; } = DateTime.Now;

        [Inject] HttpClient HttpClient { get; set; }
        [Inject] IJSRuntime JsRunTime { get; set; }
        [Inject] IModalService Modal { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetData();
            GetStatus();      
        }

        public async Task GetData()
        {
            try
            {
                results = await HttpClient.GetJsonAsync<Results[]>(ServiceEndpoints.GET_RESULTS);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving data from Oracle.", ex.Message);
            }
        }      
        
        public void GetStatus()
        {
            var count = 0;
            
            foreach(var item in results)
            {
                if(item.SERVICE_SUSPEND_START != null && item.SERVICE_SUSPEND_STOP != null)
                {
                    count++;
                    item.ScheduledDownTime = item.SERVICE_SUSPEND_START + " to " + item.SERVICE_SUSPEND_STOP;
                }
                else
                {
                    item.ScheduledDownTime = "No Down Time Scheduled";
                }
            }
            foreach (var items in results)
            {
                if (count > 1)
                {
                    FontColor = "red";
                    Message = "Overrides established  " + items.SERVICE_SUSPEND_START + " to " + items.SERVICE_SUSPEND_STOP + "\n";
                    IsDisabled = true;
                }
                else if (count == 1)
                {
                    FontColor = "red";
                    Message = "Overrides established  " + items.SERVICE_SUSPEND_START + " to " + items.SERVICE_SUSPEND_STOP;
                    IsDisabled = true;
                }
                else
                {
                    FontColor = "green";
                    Message = "There are no Override Times currently established";
                }
            }
        }

        public void SetService()
        {
            IsDisabled = false;
        }   

        public async void SaveChanges()
        {                        
            if(Date1 < Date2)
            {
                bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Are you sure you want to make these changes?");
                if(confirmed)
                {
                    string tasks = "";
                    foreach (var item in results.Where(i => i.IsJobSelected == true))
                    {
                        tasks += "'" + item.TASK_ID + "'" + ",";                        
                        item.ScheduledDownTime = Date1.ToString() + " - " + Date2.ToString(); 
                    }
                    tasks = tasks.TrimEnd(',');
                    string insertSql = "update " + OracleTableNames.JobService + " set service_suspend_start = to_date('" + Date1.ToString() + "','MM/DD/YYYY HH:MI:SS AM')," +
                                            " service_suspend_stop = to_date('" + Date2.ToString() + "','MM/DD/YYYY HH:MI:SS AM')  where task_id in (" + tasks + ")";
                    var sqlString = new StringContent(insertSql, Encoding.UTF8, "text/plain");
                    await HttpClient.PostAsync(ServiceEndpoints.EXECUTE_SQL_POST, sqlString);
                    await GetData();
                    GetStatus();
                    ClearSelected();
                    Date1 = DateTime.Now;
                    Date2 = DateTime.Now;
                }                
                else
                {
                    GetStatus();
                    Date1 = DateTime.Now;
                    Date2 = DateTime.Now;
                }
            }
            else
            {
                FontColor = "red";
                Message = "Start Time must be less than End Time";
                GetStatus();
            }
            await GetData();
            GetStatus();
            StateHasChanged();
        }

        public async void ClearDowntimes()
        {
            string sqlStatement = "";
            string taskString = "";
            bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Do you want to Activate Service Monitoring for the selected jobs?");
            if(confirmed)
            {
                foreach (var item in results.Where(i => i.IsJobSelected == true))
                {
                    item.ScheduledDownTime = null;
                    taskString += "'" + item.TASK_ID + "'" + ","; 
                }
                taskString = taskString.TrimEnd(',');
                if(taskString == "")
                {
                    FontColor = "red";
                    Message = "Please check the job(s) you want to clear";
                }
                sqlStatement = "update " + OracleTableNames.JobService + " set service_suspend_start = NULL, service_suspend_stop = null where task_id in (" + taskString + ")";
                var sqlString = new StringContent(sqlStatement, Encoding.UTF8, "text/plain");
                await HttpClient.PostAsync(ServiceEndpoints.EXECUTE_SQL_POST, sqlString);
                await GetData();
                GetStatus();
                ClearSelected();
                Date1 = DateTime.Now;
                Date2 = DateTime.Now;
            }           
            else
            {
                GetStatus();
            }
            StateHasChanged();
        }

        public void Exit()
        {
            Modal.Cancel();
        }

        public void SelectAll()
        {
            if (SelectMessage == "Deselect All")
            {
                ClearSelected();                
            }
            else
            {
                foreach (var item in results)
                {
                    item.IsJobSelected = true;
                    SelectMessage = "Deselect All";
                }
            }
            
        }

        public void ClearSelected()
        {
            foreach(var item in results)
            {                
                item.IsJobSelected = false;
                SelectMessage = "Select All";
            }
        }

        public void JobChecked(string jobName)
        {
            foreach(var items in results.Where(i => i.JOB_NAME == jobName))
            {
                if(items.IsJobSelected == false)
                {
                    items.IsJobSelected = true;
                }
                else
                {
                    items.IsJobSelected = false;
                }
            }
        }
    }
}
