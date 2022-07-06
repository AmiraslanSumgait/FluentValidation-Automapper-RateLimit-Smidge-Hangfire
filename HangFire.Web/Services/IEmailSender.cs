namespace HangFire.Web.Services
{
    public interface IEmailSender
    {
        Task Sender(string userId, string message);
    }
}
