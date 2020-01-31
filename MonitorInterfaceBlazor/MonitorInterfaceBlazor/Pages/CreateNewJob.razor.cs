using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonitorInterfaceBlazor.Constants;
using MonitorInterfaceBlazor.Models;
using System.Text;
using Microsoft.JSInterop;
using System.Net.Http;

namespace MonitorInterfaceBlazor.Pages
{
    public class CreateNewJobBase : ComponentBase
    {
        public RuntimeCheckboxInit init = new RuntimeCheckboxInit();
        public NewJob newJob = new NewJob();
        public Month month = new Month();
        public Day day = new Day();
        public Hour hour = new Hour();
        public Minute minute = new Minute();
        public Issue issue = new Issue();
        public Mail mail = new Mail();
        public Sql sql = new Sql();
        public SendSlack sendSlack = new SendSlack();
        public SlackChannel slackChannel = new SlackChannel();
        public SendMail sendMail = new SendMail();
        public DbSchema dbSchema = new DbSchema();
        public Status status = new Status();
        public Results[] results;       

        [Parameter] public string sqlStatement { get; set; }
        [Parameter] public string sendSlackSelect { get; set; } = "Y";
        [Parameter] public string slackChannelSelect { get; set; } = "#alerts";
        [Parameter] public string sendMailSelect { get; set; } = "Y";
        [Parameter] public string dbSchemaSelect { get; set; } = "MerchDev";
        [Parameter] public string statusSelect { get; set; } = "Y";
        [Parameter] public string SlackUrlString { get; set; }
        [Parameter] public string SlackUserString { get; set; } = "Monitor Service";
        [Parameter] public string FromMailString { get; set; } = MailEndpoints.FromMail;

        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] HttpClient HttpClient { get; set; }
        [Inject] IJSRuntime JsRunTime { get; set; }

        protected override void OnInitialized()
        {
            try
            {
                InitializeData.GetDayChecklist();
                InitializeData.GetMonthChecklist();
                InitializeData.GetHourChecklist();
                InitializeData.GetMinuteChecklist();
                InitializeData.GetDbSchemaDropdown();
                InitializeData.GetSendMailDropdown();
                InitializeData.GetSendSlackDropdown();
                InitializeData.GetSlackChannelDropdown();
                InitializeData.GetStatusDropdown();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async void AddJob()
        {
            bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Add this new job now?");
            if (confirmed)
            {
                string monthSql = "";
                string daySql = "";
                string hourSql = "";
                string minuteSql = "";

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
                    string insertSql = "insert into " + OracleTableNames.JobService + "(run_day, run_hour, job_name, db_schema, job_clob, job_header, " +
                                       "run_min, job_active, run_mth, email_subject, slack_channel, slack_url, mailfrom, mailto, slack_user, sendmail, sendslack, last_updated) " +
                                       " values ('" + daySql + "','" + hourSql + "','" + newJob.NewJobName.Replace("'", "''") + "','" + dbSchemaSelect + "','" + sql.SqlStatement.Replace("'", "''") +
                                       "','" + issue.IssueDescription.Replace("'", "''") + "','" + minuteSql + "','" + statusSelect + "','" + monthSql + "','" + mail.MailSubject.Replace("'", "''") +
                                       "','" + slackChannelSelect + "','" + SlackUrlString + "','" + FromMailString + "','" + mail.MailTo.Replace("'", "''") + "','" + SlackUserString + "','" + sendMailSelect +
                                       "','" + sendSlackSelect.Replace("'", "''") + "','" + DateTime.Now + "')";
                    string newTaskId = "update " + OracleTableNames.JobService + " set task_id = (select max(nvl(to_number(task_id),0)) + 1 from " + OracleTableNames.JobService + ") where task_id is null";
                    await SendNewJob(insertSql);
                    await SendNewTaskId(newTaskId);

                    //await JsRunTime.InvokeAsync<string>("confirm", "New job successfully added!");
                    NavigationManager.NavigateTo("/");
                }
                catch (Exception ex)
                {
                    await JsRunTime.InvokeAsync<string>("confirm", "Could not add new job, make sure all fields are complete.");
                    Console.WriteLine("Problems creating new job, make sure all fields are complete.", ex.Message);
                }
            }
        }

        private async Task SendNewJob(string sqlJob)
        {
            var sqlString = new StringContent(sqlJob, Encoding.UTF8, "text/plain");
            await HttpClient.PostAsync(ServiceEndpoints.EXECUTE_SQL_POST, sqlString);
        }

        private async Task SendNewTaskId(string sqlTask)
        {
            var sqlString = new StringContent(sqlTask, Encoding.UTF8, "text/plain");
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

        public async void ValidateSql(string sqlState)
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            sqlState = sql.SqlStatement;
            sqlState = sqlState.Replace("\t", " ").Replace("\n", " ").Replace("\r", " ");
            pairs.Add(dbSchemaSelect, sqlState);
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

        public void BackToIndex()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
