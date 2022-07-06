using HangFire.Web.BackGroundJobs;
using HangFire.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HangFire.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
  
        public IActionResult SignUp()
        {
            //istifadeci qeydiyyat proesesi bu metodda bas verir
            //Yeni qeydiyyatdan kecen userin  userid sini al
           FireAndForgetJobs.EmailSendToUserJob("1234", "Saytimiza xos geldiniz");
            return View();
        }
        public IActionResult PictureSave()
        {
            BackGroundJobs.RecurringJobs.ReportingJob();
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> PictureSave(IFormFile picture)
        {
            string newFileName = String.Empty;
            if (picture != null && picture.Length > 0)
            {
                newFileName=Guid.NewGuid().ToString()+Path.GetExtension(picture.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", newFileName);
                using(var stream=new FileStream(path, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }
                string jobId = BackGroundJobs.DelayedJobs.AddWaterMarkJob(newFileName,"www.mysite.com");
                BackGroundJobs.ContinuationsJobs.WriteWatermarkStatusJob(jobId, newFileName);
            }
            return View();
        }
    }
}