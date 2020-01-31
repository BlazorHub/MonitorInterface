namespace MonitorInterfaceBlazor.Models
{
    public class Results
    {
        public string RUN_MTH { get; set; }
        public string RUN_DAY { get; set; }
        public string RUN_HOUR { get; set; }
        public string RUN_MIN { get; set; }
        public string JOB_NAME { get; set; }
        public string JOB_ACTIVE { get; set; }
        public string DB_PROC { get; set; }
        public string DB_SCHEMA { get; set; }
        public string JOB_CLOB { get; set; }
        public string JOB_SUBJECT { get; set; }
        public string JOB_HEADER { get; set; }
        public string EMAIL_SUBJECT { get; set; }
        public string TASK_ID { get; set; }
        public string SLACK_CHANNEL { get; set; }
        public string SLACK_URL { get; set; }
        public string MAILFROM { get; set; }
        public string MAILTO { get; set; }
        public string SLACK_USER { get; set; }
        public string UPDATE_QRY { get; set; }
        public string UPDATE_STMNT { get; set; }
        public string SENDMAIL { get; set; }
        public string SENDSLACK { get; set; }
        public bool IsJobSelected { get; set; }
        public string ScheduledDownTime { get; set; }
        public string SERVICE_SUSPEND_START { get; set; }
        public string SERVICE_SUSPEND_STOP { get; set; }
    }
}
