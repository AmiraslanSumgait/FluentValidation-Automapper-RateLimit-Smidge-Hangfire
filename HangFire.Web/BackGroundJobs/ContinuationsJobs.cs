using System.Diagnostics;

namespace HangFire.Web.BackGroundJobs
{
    public class ContinuationsJobs
    {
        public static void WriteWatermarkStatusJob(string id, string fileName)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine($"{fileName} : resim'e watermark eklenmiştir."));
        }
    }
}
