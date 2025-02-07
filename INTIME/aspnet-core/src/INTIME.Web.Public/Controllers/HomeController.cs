using Microsoft.AspNetCore.Mvc;
using INTIME.Web.Controllers;

namespace INTIME.Web.Public.Controllers
{
    public class HomeController : INTIMEControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}