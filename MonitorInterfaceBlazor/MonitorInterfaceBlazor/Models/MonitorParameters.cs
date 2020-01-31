namespace MonitorInterfaceBlazor.Models
{
    public class NewJob
    {
        public string NewJobName { get; set; }
    }

    public class Month
    {
        public int MonthId { get; set; }
        public string MonthName { get; set; }
        public bool IsMonthChecked { get; set; }
    }

    public class Day
    {
        public int DayId { get; set; }
        public string DayName { get; set; }
        public bool IsDayChecked { get; set; }
    }

    public class Hour
    {
        public int HourId { get; set; }
        public string HourName { get; set; }
        public bool IsHourChecked { get; set; }
    }

    public class Minute
    {
        public int MinuteId { get; set; }
        public string MinuteName { get; set; }
        public bool IsMinuteChecked { get; set; }
    }

    public class Issue
    {
        public string IssueDescription { get; set; }
    }

    public class SlackChannel
    {
        public int SlackChannelId { get; set; }
        public string SlackChannelName { get; set; }
        public bool IsSendSlackChannelSelected { get; set; }
    }

    public class SendSlack
    {
        public int SendSlackId { get; set; }
        public string SendSlackName { get; set; }
        public bool IsSendSlackSelected { get; set; }
    }

    public class Mail
    {
        public string MailTo { get; set; }
        public string MailSubject { get; set; }
    }

    public class SendMail
    {
        public int SendMailId { get; set; }
        public string SendMailName { get; set; }
        public bool IsSendMailSelected { get; set; }
    }

    public class Sql
    {
        public string SqlStatement { get; set; }
    }

    public class DbSchema
    {
        public int DbSchemaId { get; set; }
        public string DbSchemaName { get; set; }
        public bool IsDbSchemaSelected { get; set; }
    }

    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsStatusSelected { get; set; }
    }
}
