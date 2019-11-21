using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// This is a really helpful comment that McKay wrote and pushed to github
// Matt's comment. Slightly shorter and sexier than McKay's.

// This website is for being able to swap surveys. 
// You can take more surveys to make yours show up on others' pages.

// Authors
    // Mckay Dalling, Matthew Gardner, Parker Pixton, and Landon Williams
namespace IS403_Project1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // Random comment
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TakeSurvey()
        {
            return View();
        }

    
    }
}