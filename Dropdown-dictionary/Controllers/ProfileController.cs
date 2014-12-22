﻿using System.Collections.Generic;
using System.Web.Mvc;
using Dropdowns.Models;

namespace Dropdowns.Controllers
{
    public class ProfileController : Controller
    {
        //
        // 1. Action method for displaying the 'User Profile' page
        //
        public ActionResult UserProfile()
        {
            // Get existing user profile object from the session or create a new one
            var model = Session["UserProfileModel"] as UserProfileModel ?? new UserProfileModel();

            // Create a list of SelectListItems from States so these can be rendered on the page
            // under the drop down
            model.States = GetStatesFromDB();

            return View(model);
        }

        //
        // 2. Action method for handling user-entered data when 'Update' button is pressed.
        //
        [HttpPost]
        public ActionResult UserProfile(UserProfileModel model)
        {
            // Set these states on the model. We need to do this because
            // only the value selected in the DropDownList is posted back, not the whole
            // list of states
            model.States = GetStatesFromDB();

            // In case everything is fine - i.e. both "FirstName" and "State" are entered/selected,
            // redirect user to the "ViewProfile" page, and pass the user object along via Session
            if (ModelState.IsValid)
            {
                Session["UserProfileModel"] = model;
                return RedirectToAction("ViewProfile");
            }

            // Something is not right - so render the registration page again,
            // keeping the data user has entered by supplying the model.
            return View(model);
        }

        //
        // 3. Action method for displaying 'ViewProfile' page
        //
        public ActionResult ViewProfile()
        {
            // Get user profile information from the session
            var model = Session["UserProfileModel"] as UserProfileModel;

            // Get a description of the currently selected State
            var allStates = GetStatesFromDB();
            model.StateName = allStates[model.State];

            // Display ViewProfile.html page that shows FirstName, Last Name and selected State.
            return View(model);
        }

        /// <summary>
        /// Simulates retrieval of country's states from a DB.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetStatesFromDB()
        {
            return new Dictionary<string, string>
            {
                {"AK", "Alaska"},
                {"AL", "Alabama"},
                {"AR", "Arkansas"},
                {"AZ", "Arizona"},
                {"CA", "California"},
                {"CO", "Colorado"},
                {"CT", "Connecticut"},
                {"DC", "District Of Columbia"},
                {"DE", "Delaware"},
                {"FL", "Florida"},
                {"GA", "Georgia"},
                {"HI", "Hawaii"},
                {"IA", "Iowa"},
                {"ID", "Idaho"},
                {"IL", "Illinois"},
                {"IN", "Indiana"},
                {"KS", "Kansas"},
                {"KY", "Kentucky"},
                {"LA", "Louisiana"},
                {"MA", "Massachusetts"},
                {"MD", "Maryland"},
                {"ME", "Maine"},
                {"MI", "Michigan"},
                {"MN", "Minnesota"},
                {"MO", "Missouri"},
                {"MS", "Mississippi"},
                {"MT", "Montana"},
                {"NC", "North Carolina"},
                {"ND", "North Dakota"},
                {"NE", "Nebraska"},
                {"NH", "New Hampshire"},
                {"NJ", "New Jersey"},
                {"NM", "New Mexico"},
                {"NV", "Nevada"},
                {"NY", "New York"},
                {"OH", "Ohio"},
                {"OK", "Oklahoma"},
                {"OR", "Oregon"},
                {"PA", "Pennsylvania"},
                {"RI", "Rhode Island"},
                {"SC", "South Carolina"},
                {"SD", "South Dakota"},
                {"TN", "Tennessee"},
                {"TX", "Texas"},
                {"UT", "Utah"},
                {"VA", "Virginia"},
                {"VT", "Vermont"},
                {"WA", "Washington"},
                {"WI", "Wisconsin"},
                {"WV", "West Virginia"},
                {"WY", "Wyoming"}
            };
        }
    }
}