using Microsoft.AspNetCore.Mvc;
using INTIME.Web.Controllers;

namespace INTIME.Web.Public.Controllers
{
    public class AboutController : INTIMEControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}