using System;
using System.Web.Mvc;

namespace TestSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            throw new InvalidOperationException("Intentional exception throw");
        }

    }
}
