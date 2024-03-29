﻿using IS403_Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS403_Project1.Controllers
{
    public class UserController : Controller
    {
        // Make a list of the users
        public static List<User> listOfUsers = new List<User>();

        // GET: User
        // This will list all of the users
        public ActionResult Index()
        {
            // Recount surveys for the list of users
            foreach (User item in UserController.listOfUsers)
            {
                // Count the surveys that they have created
                int iCount = SurveyController.listOfSurveys.Count(x => x.UserID == item.UserID);

                // Find the user
                int index = UserController.listOfUsers.FindIndex(x => x.UserID == item.UserID);

                // Update their record to show how many surveys they have created
                UserController.listOfUsers[index].CountOfSurveysCreated = iCount;
            }
            return View(listOfUsers);
        }

        // This method returns a form to create a new survey
        public ActionResult Create()
        {
            return View();
        }

        // This method adds the user to the list of users
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Make sure the model is valid
            if (ModelState.IsValid)
            {
                // add the received user to the list of user
                listOfUsers.Add(user);

                // Forward them to the list index view
                return View("Index", listOfUsers);
            }
            else
            {
                // Return back the model to the view with errors
                return View(user);
            }
        }
        // This method returns a form to edit a certain user
        public ActionResult Edit(int id)
        {
            // Find the right user
            int index = listOfUsers.FindIndex(x => x.UserID == id);

            // Pass that survey to the index
            return View(listOfUsers[index]);
        }

        // This method edits the user
        [HttpPost]
        public ActionResult Edit(User user)
        {
            // Make sure the model is valid
            if (ModelState.IsValid)
            {
                // Find the user
                int index = listOfUsers.FindIndex(x => x.UserID == user.UserID);

                // Edit the user
                listOfUsers[index] = user;

                // Return the list index view
                return View("Index", listOfUsers);
            }
            else
            {
                // Return the model to the edit view with errors
                return View(user);
            }
        }

		[HttpGet]
		public ActionResult Delete(int id)
		{
            // Find the right user
            int index = listOfUsers.FindIndex(x => x.UserID == id);

            // Pass the index to the listOfUsers to delete
			listOfUsers.Remove(listOfUsers[id]);
			return View("Index", listOfUsers);
		}
	}
}