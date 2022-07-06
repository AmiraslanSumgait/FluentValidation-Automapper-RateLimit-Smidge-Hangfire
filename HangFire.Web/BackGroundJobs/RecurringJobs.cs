using Hangfire;
using System.Diagnostics;

namespace HangFire.Web.BackGroundJobs
{
    public class RecurringJobs
    {
        public static void ReportingJob()
        {
           RecurringJob.AddOrUpdate("reportjob1", () => EmailReport(), Cron.Minutely);
        }

        public static void EmailReport()
        {
            Debug.WriteLine("Rapor, email olarak gönderildi");
        }
    }
}
