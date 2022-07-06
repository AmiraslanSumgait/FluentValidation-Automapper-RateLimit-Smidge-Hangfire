using HangFire.Web.Services;

namespace HangFire.Web.BackGroundJobs;


public class FireAndForgetJobs
{
    public static void EmailSendToUserJob(string userId,string message)
    {
        Hangfire.BackgroundJob.Enqueue<IEmailSender>(x => x.Sender(userId, message));
     
    }
}
