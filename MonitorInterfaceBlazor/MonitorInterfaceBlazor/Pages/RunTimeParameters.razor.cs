using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;
using MonitorInterfaceBlazor.Models;
using MonitorInterfaceBlazor.Constants;
using System.Text;
using Microsoft.JSInterop;
using System.Net.Http;
using MonitorInterfaceBlazor.Services;

namespace MonitorInterfaceBlazor.Pages
{
    public class RunTimeParametersBase : ComponentBase
    {
        public RuntimeCheckboxInit init = new RuntimeCheckboxInit();
        public Results[] results;

        [Parameter] public string jobSelected { get; set; }

        [Inject] HttpClient HttpClient { get; set; }
        [Inject] IJSRuntime JsRunTime { get; set; }
        [Inject] IModalService Modal { get; set; }

        [CascadingParameter] ModalParameters Parameters { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            try
            {
                jobSelected = Parameters.Get<string>("jobSelected");

                await GetData();
                InitializeData.GetMonthChecklist();
                InitializeData.GetDayChecklist();
                InitializeData.GetHourChecklist();
                InitializeData.GetMinuteChecklist();

                GetMonthParams();
                GetDayParams();
                GetHourParams();
                GetMinuteParams();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Cancel()
        {
            Modal.Cancel();
        }

        private async Task GetData()
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

        public void GetMonthParams()
        {
            foreach (var item in results.Where(i => i.JOB_NAME == jobSelected))
            {
                var getMonths = from val in item.RUN_MTH.ToString().Split(',') select int.Parse(val);
                try
                {
                    foreach (int month in getMonths)
                    {
                        InitializeData.Months[month].IsMonthChecked = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving current month selections.", ex.Message);
                }
            }
        }

        public void GetDayParams()
        {
            foreach (var item in results.Where(i => i.JOB_NAME == jobSelected))
            {
                var getDays = from val in item.RUN_DAY.ToString().Split(',') select val;
                foreach (var day in getDays)
                {
                    if (day.ToString() == "Sunday")
                    {
                        InitializeData.Days[1].IsDayChecked = true;
                    }
                    else if (day.ToString() == "Monday")
                    {
                        InitializeData.Days[2].IsDayChecked = true;
                    }
                    else if (day.ToString() == "Tuesday")
                    {
                        InitializeData.Days[3].IsDayChecked = true;
                    }
                    else if (day.ToString() == "Wednesday")
                    {
                        InitializeData.Days[4].IsDayChecked = true;
                    }
                    else if (day.ToString() == "Thursday")
                    {
                        InitializeData.Days[5].IsDayChecked = true;
                    }
                    else if (day.ToString() == "Friday")
                    {
                        InitializeData.Days[6].IsDayChecked = true;
                    }
                    else if (day.ToString() == "Saturday")
                    {
                        InitializeData.Days[7].IsDayChecked = true;
                    }
                }
            }
        }
        public void GetHourParams()
        {
            foreach (var item in results.Where(i => i.JOB_NAME == jobSelected))
            {
                var getHours = from val in item.RUN_HOUR.ToString().Split(',') select int.Parse(val);
                try
                {
                    foreach (int hour in getHours)
                    {
                        InitializeData.Hours[hour].IsHourChecked = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving current hour selections.", ex.Message);
                }
            }
        }

        public void GetMinuteParams()
        {
            foreach (var item in results.Where(i => i.JOB_NAME == jobSelected))
            {
                var getMinutes = from val in item.RUN_MIN.ToString().Split(',') select int.Parse(val);
                try
                {
                    foreach (int minute in getMinutes)
                    {
                        InitializeData.Minutes[minute].IsMinuteChecked = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving current minute selections.", ex.Message);
                }
            }
        }

        public async void SaveChanges()
        {
            string monthSql = "";
            string daySql = "";
            string hourSql = "";
            string minuteSql = "";
            bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Are you sure you want to save changes?");
            if (confirmed)
            {
                foreach (var item in results.Where(i => i.JOB_NAME == jobSelected))
                {
                    foreach (var month in InitializeData.Months.Where(m => m.IsMonthChecked == true && m.MonthId != 0))
                    {
                        monthSql += month.MonthId.ToString() + ",";
                    }
                    monthSql = monthSql.TrimEnd(',');
                    foreach (var day in InitializeData.Days.Where(d => d.IsDayChecked == true && d.DayId != 0))
                    {
                        daySql += ConvertDays(day.DayName) + ",";
                    }
                    daySql = daySql.TrimEnd(',');
                    foreach (var hour in InitializeData.Hours.Where(h => h.IsHourChecked == true && h.HourId < 24))
                    {
                        hourSql += hour.HourName + ",";
                    }
                    hourSql = hourSql.TrimEnd(',');
                    foreach (var minute in InitializeData.Minutes.Where(m => m.IsMinuteChecked == true && m.MinuteId < 60))
                    {
                        minuteSql += minute.MinuteName + ",";
                    }
                    minuteSql = minuteSql.TrimEnd(',');

                    try
                    {
                        string insertSql = "update " + OracleTableNames.JobService +
                                        " set run_day = '" + daySql + "'," +
                                            "run_hour = '" + hourSql + "'," +
                                            "job_name = '" + item.JOB_NAME.Replace("'", "''") + "'," +
                                            "db_schema = '" + item.DB_SCHEMA + "'," +
                                            "job_clob  = '" + item.JOB_CLOB.Replace("'", "''") + "'," +
                                            "job_header = '" + item.JOB_HEADER.Replace("'", "''") + "'," +
                                            "run_min = '" + minuteSql + "'," +
                                            "job_active = '" + item.JOB_ACTIVE + "'," +
                                            "run_mth = '" + monthSql + "'," +
                                            "email_subject = '" + item.EMAIL_SUBJECT.Replace("'", "''") + "'," +
                                            "slack_channel = '" + item.SLACK_CHANNEL + "'," +
                                            "slack_url = '" + item.SLACK_URL + "'," +
                                            "mailfrom = '" + item.MAILFROM + "'," +
                                            "mailto = '" + item.MAILTO.Replace("'", "''") + "'," +
                                            "slack_user = '" + item.SLACK_USER + "'," +
                                            "sendmail = '" + item.SENDMAIL + "'," +
                                            "sendslack = '" + item.SENDSLACK.Replace("'", "''") + "'," +
                                            "last_updated = '" + DateTime.Now + "'" +
                                        "where task_id = '" + item.TASK_ID + "'";
                        await EditCurrentJob(insertSql);
                        await GetData();
                        
                        //StateHasChanged();
                        Modal.Close(ModalResult.Ok<Results[]>(results));
                    }
                    catch (Exception ex)
                    {
                        await JsRunTime.InvokeAsync<string>("confirm", "Error saving changes. Make sure all parameters are complete (Month, Day, Hour, Minute)");
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

        private string ConvertDays(string day)
        {
            switch (day)
            {
                case "Mon":
                    return "Monday";
                case "Tue":
                    return "Tuesday";
                case "Wed":
                    return "Wednesday";
                case "Thu":
                    return "Thursday";
                case "Fri":
                    return "Friday";
                case "Sat":
                    return "Saturday";
                case "Sun":
                    return "Sunday";
            }
            return "Monday";
        }

        public void ResetParams()
        {
            foreach (var month in InitializeData.Months) month.IsMonthChecked = false;
            foreach (var day in InitializeData.Days) day.IsDayChecked = false;
            foreach (var hour in InitializeData.Hours) hour.IsHourChecked = false;
            foreach (var minute in InitializeData.Minutes) minute.IsMinuteChecked = false;
        }
    }
}
