using IS403_Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS403_Project1.Controllers
{
    public class SurveyController : Controller
    {
        // Add a list of surveys
        public static List<Survey> listOfSurveys = new List<Survey>()
        {
            new Survey{SurveyID = 1, UserID = 1, Name = "First Survey", SurveyURL = "https://survey.com/", IsActive = true },
            new Survey{SurveyID = 2, UserID = 1, Name = "Second Survey", SurveyURL = "https://survey.com/", IsActive = true },
            new Survey{SurveyID = 3, UserID = 1, Name = "Third Survey", SurveyURL = "https://survey.com/", IsActive = true }
        };
        
        //Have a count of list of surveys
        public static int iNumSurveys = listOfSurveys.Count();
        Random rnd = new Random();



        // GET: Survey
        // This will list all of the surveys
        public ActionResult Index()
        {
            return View(listOfSurveys);
        }

        // This method returns a form to create a new survey
        public ActionResult Create()
        {
            // Create the viewbag for the users
            ViewBag.Users = UserController.listOfUsers;

            return View();
        }

        public ActionResult SurveysToComplete ()
        {
            // Recount the number of surveys
            iNumSurveys = listOfSurveys.Count();

            // Select random surveys
            int rndSurvey1 = rnd.Next(0, iNumSurveys);
            int rndSurvey2;
            do // loop ensures the same survey is not listed twice
            {
              rndSurvey2 = rnd.Next(0, iNumSurveys);
            }
            while (rndSurvey1 == rndSurvey2);


            // Add the surveys names to the viewbag for the user to take
            ViewBag.RndSurvey1Name = listOfSurveys[rndSurvey1].Name;
            ViewBag.RndSurvey2Name = listOfSurveys[rndSurvey2].Name;

            // Send only the urls to open in new windows
            ViewBag.RndSurvey1URL = listOfSurveys[rndSurvey1].SurveyURL;
            ViewBag.RndSurvey2URL = listOfSurveys[rndSurvey2].SurveyURL;

            return View();
        }

        // This method adds the survey to the list of surveys
        [HttpPost]
        public ActionResult Create(Survey survey)
        {
            // Make sure the model is valid
            if (ModelState.IsValid)
            {
                // add the received survey to the list of surveys
                listOfSurveys.Add(survey); 

                return RedirectToAction("SurveysToComplete");
            } else

            {
                // Return back the model to the view with errors
                // Create the viewbag for the users
                ViewBag.Users = UserController.listOfUsers;

                return View(survey);
            }
        }

        // This method returns a form to edit a certain survey
        public ActionResult Edit(int id)
        {
            // Find the right survey
            int index = listOfSurveys.FindIndex(x => x.SurveyID == id);

            // Create the viewbag for the users
            ViewBag.Users = UserController.listOfUsers;

            // Pass that survey to the index
            return View(listOfSurveys[index]);
        }

        // This method edits the survey
        [HttpPost]
        public ActionResult Edit(Survey survey)
        {
            // Make sure the model is valid
            if (ModelState.IsValid)
            {
                // Find the survey
                int index = listOfSurveys.FindIndex(x => x.SurveyID == survey.SurveyID);

                // Edit the survey
                listOfSurveys[index] = survey;

                // Return the list index view
                return View("Index", listOfSurveys);
            } else
            {
                // Create the viewbag for the users
                ViewBag.Users = UserController.listOfUsers;

                // Return the model to the edit view with errors
                return View(survey);
            }
        }

		[HttpGet]
		public ActionResult Delete(int id)
		{
            // Find the right survey
            int index = listOfSurveys.FindIndex(x => x.SurveyID == id);

            // Pass the index to the listOfSurveys to delete
			listOfSurveys.Remove(listOfSurveys[index]);
			return View("Index", listOfSurveys);
		}

		[HttpGet]
		public ActionResult ShowActiveOnly()
		{
			List<Survey> tempList = new List<Survey>();
			foreach (var item in listOfSurveys)
			{
				if (item.IsActive)
				{
					tempList.Add(item);
				}
			}
			return View("Index", tempList);
		}

		public ActionResult ShowInactiveOnly()
		{
			List<Survey> tempList = new List<Survey>();
			foreach (var item in listOfSurveys)
			{
				if (!item.IsActive)
				{
					tempList.Add(item);
				}
			}
			return View("Index", tempList);
		}
    }
}