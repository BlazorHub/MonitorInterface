using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonitorInterfaceBlazor.Models;
using MonitorInterfaceBlazor.Constants;
using Microsoft.JSInterop;
using System.Text;
using System.Net.Http;
using MonitorInterfaceBlazor.Services;

namespace MonitorInterfaceBlazor.Pages
{
    public class IndexBase : ComponentBase
    {
        public Results[] results;
        public Sql sql = new Sql();
        public DbSchema dbSchema = new DbSchema();
        public Status status = new Status();

        [Parameter] public string jobSelected { get; set; } = "BCH1 - Events SPT - Minutes Issue time Off < Time on";
        [Parameter] public string sqlStatement { get; set; }
        [Parameter] public bool IsDisabled { get; set; } = true;
        [Parameter] public string SlackUrlString { get; set; }
        [Parameter] public string SlackUserString { get; set; } = "Monitor Service";
        [Parameter] public string FromMailString { get; set; } = MailEndpoints.FromMail;

        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] HttpClient HttpClient { get; set; }
        [Inject] IJSRuntime JsRunTime { get; set; }
        [Inject] public IModalService Modal { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {                
                InitializeData.GetSendSlackDropdown();
                InitializeData.GetSlackChannelDropdown();
                InitializeData.GetSendMailDropdown();
                InitializeData.GetDbSchemaDropdown();
                InitializeData.GetStatusDropdown();
                await GetData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        protected async Task GetData()
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

        public async void SaveChanges()
        {
            bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Are you sure you want to save changes?");
            if (confirmed)
            {
                foreach (var item in results.Where(i => i.JOB_NAME == jobSelected))
                {
                    try
                    {
                        string insertSql = "update " + OracleTableNames.JobService + 
                                        " set run_day = '" + item.RUN_DAY + "'," +
                                            "run_hour = '" + item.RUN_HOUR + "'," +
                                            "job_name = '" + item.JOB_NAME.Replace("'", "''") + "'," +
                                            "db_schema = '" + item.DB_SCHEMA + "'," +
                                            "job_clob  = '" + item.JOB_CLOB.Replace("'", "''") + "'," +
                                            "job_header = '" + item.JOB_HEADER.Replace("'", "''") + "'," +
                                            "run_min = '" + item.RUN_MIN + "'," +
                                            "job_active = '" + item.JOB_ACTIVE + "'," +
                                            "run_mth = '" + item.RUN_MTH + "'," +
                                            "email_subject = '" + item.EMAIL_SUBJECT.Replace("'", "''") + "'," +
                                            "slack_channel = '" + item.SLACK_CHANNEL + "'," +
                                            "slack_url = '" + SlackUrlString + "'," +
                                            "mailfrom = '" + FromMailString + "'," +
                                            "mailto = '" + item.MAILTO.Replace("'", "''") + "'," +
                                            "slack_user = '" + SlackUserString + "'," +
                                            "sendmail = '" + item.SENDMAIL + "'," +
                                            "sendslack = '" + item.SENDSLACK.Replace("'", "''") + "'," +
                                            "last_updated = '" + DateTime.Now + "'" +
                                        "where task_id = '" + item.TASK_ID + "'";
                        await EditCurrentJob(insertSql);

                        NavigationManager.NavigateTo("/");
                    }
                    catch (Exception ex)
                    {
                        await JsRunTime.InvokeAsync<string>("confirm", "Could not save changes, make sure all fields are complete.");
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private async Task EditCurrentJob(string sqlStatement)
        {
            var sqlString = new StringContent(sqlStatement, Encoding.UTF8, "text/plain");
            await HttpClient.PostAsync(ServiceEndpoints.EXECUTE_SQL_POST, sqlString);
        }

        public void Override()
        {
            IsDisabled = false;
        }

        public void AddNewJob()
        {
            NavigationManager.NavigateTo("/CreateNewJob");
        }

        public async void DeleteJob()
        {
            bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Are you sure you want to delete this job?");
            if (confirmed)
            {
                foreach (var item in results.Where(i => i.JOB_NAME == jobSelected))
                {
                    try
                    {
                        string insertSql = "delete " + OracleTableNames.JobService + " where task_id = '" + item.TASK_ID + "'";
                        await ExecuteDeleteJob(insertSql);                     
                        await GetData();
                        StateHasChanged();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private async Task ExecuteDeleteJob(string sqlStatement)
        {
            var sqlString = new StringContent(sqlStatement, Encoding.UTF8, "text/plain");
            await HttpClient.PostAsync(ServiceEndpoints.EXECUTE_SQL_POST, sqlString);
        }

        public async void ValidateSql(string sqlState)
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            foreach (var item in results.Where(i => i.JOB_NAME == jobSelected))
            {
                sqlState = item.JOB_CLOB;
                sqlState = sqlState.Replace("\t", " ").Replace("\n", " ").Replace("\r", " ");
                pairs.Add(item.DB_SCHEMA, sqlState);
                FormUrlEncodedContent formContent = new FormUrlEncodedContent(pairs);

                try
                {
                    var IsValid = await HttpClient.PostAsync(ServiceEndpoints.VALIDATE_SQL_POST, formContent);
                    if (IsValid.IsSuccessStatusCode)
                    {
                        await JsRunTime.InvokeAsync<string>("confirm", "Valid Sql Statement");
                    }
                    else
                    {
                        await JsRunTime.InvokeAsync<string>("confirm", "Invalid Sql Statement");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error", ex.Message);
                }
            }            
        }

        

        public void ShowRunTimeParameters(string jobSelect)
        {
            var parameters = new ModalParameters();
            parameters.Add("jobSelected", jobSelect);

            Modal.Show<RunTimeParameters>("Run Time Parameters", parameters);
        }

        public void ShowServiceManager()
        {
            Modal.Show<ServiceManager>("Service Downtime");
        }
    }
}
