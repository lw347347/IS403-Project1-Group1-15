﻿using IS403_Project1.Models;
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
        public static List<Survey> listOfSurveys = new List<Survey>();

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

        // This method adds the survey to the list of surveys
        [HttpPost]
        public ActionResult Create(Survey survey)
        {
            // Make sure the model is valid
            if (ModelState.IsValid)
            {
                // add the received survey to the list of surveys
                listOfSurveys.Add(survey);

                // Recount surveys for the list of users
                foreach(User item in UserController.listOfUsers)
                {
                    // Count the surveys that they have created
                    int iCount = listOfSurveys.Count(x => x.UserID == item.UserID);
                    
                    // Find the user
                    int index = UserController.listOfUsers.FindIndex(x => x.UserID == item.UserID);

                    // Update their record to show how many surveys they have created
                    UserController.listOfUsers[index].CountOfSurveysCreated = iCount;
                }


                // Forward them to the list index view
                return View("Index", listOfSurveys);
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
    }
}