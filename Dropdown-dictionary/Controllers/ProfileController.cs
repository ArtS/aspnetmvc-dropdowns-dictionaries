using System;
using System.Collections.Generic;
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

            // Simulate getting states from a database
            model.States = GetStatesFromDB();

            return View(model);
        }

        //
        // 2. Action method for handling user-entered data when 'Update' button is pressed.
        //
        [HttpPost]
        public ActionResult UserProfile(UserProfileModel model)
        {
            // Set States on the model. We need to do this because only the value selected
            // in the DropDownList is posted back, not the whole list of states
            model.States = GetStatesFromDB();

            // In case everything is fine - i.e. "FirstName", "LastName" and "State" are entered/selected,
            // redirect a user to the "ViewProfile" page, and pass the user object along via Session
            if (ModelState.IsValid)
            {
                Session["UserProfileModel"] = model;
                return RedirectToAction("ViewProfile");
            }

            // Something is not right - re-render the registration page, keeping user-entered data
            // and display validation errors
            return View(model);
        }

        //
        // 3. Action method for displaying 'ViewProfile' page
        //
        public ActionResult ViewProfile()
        {
            // Get user profile information from the session
            var model = Session["UserProfileModel"] as UserProfileModel;
            if (model == null)
                return RedirectToAction("UserProfile");

            // Get a human-readable description of a currently selected State
            var allStates = GetStatesFromDB();
            model.StateName = allStates[new Guid(model.State)];

            // Display View Profile page that shows FirstName, Last Name and a selected State.
            return View(model);
        }

        /// <summary>
        /// Simulates retrieval of country's states from a DB.
        /// </summary>
        /// <returns>Dictionary of US states</returns>
        private Dictionary<Guid, string> GetStatesFromDB()
        {
            return new Dictionary<Guid, string>
            {
                {new Guid("5c1409cf-fecb-4e5a-bb96-511b9ad187ab"), "Alaska"},
                {new Guid("a63974c1-742f-4adf-a93e-539ca2557313"), "Alabama"},
                {new Guid("e5be7004-893f-4f5f-9a3a-17c9781c8aad"), "Arkansas"},
                {new Guid("bdabaf43-097a-49db-85db-9d284c450980"), "Arizona"},
                {new Guid("b667d783-766a-4ed3-a13b-7f340b6d9343"), "California"},
                {new Guid("33952221-2b60-4e68-9790-c4ff9c821e2f"), "Colorado"},
                {new Guid("94f3695d-de6f-4f53-bfa4-89c110337ed0"), "Connecticut"},
                {new Guid("841145b4-f834-459d-a1f9-bfafc572b070"), "District Of Columbia"},
                {new Guid("5ffe0cb7-f716-4514-8c28-0d7a6b1bf35a"), "Delaware"},
                {new Guid("6cd80e99-81ba-468a-988a-0bec1b516eaa"), "Florida"},
                {new Guid("230e0073-2762-4d7b-a06f-76fd8e4b2c07"), "Georgia"},
                {new Guid("8a7dc236-2384-4ed7-a2a8-15632dde73d4"), "Hawaii"},
                {new Guid("759b9be7-b24e-474b-a2a9-5981f7995fdd"), "Iowa"},
                {new Guid("3d8ea3f7-eceb-4237-ada3-d1203e7fa882"), "Idaho"},
                {new Guid("d95502d4-8135-47cc-90fd-020e6d5d5296"), "Illinois"},
                {new Guid("bd43d064-246a-4d37-8d0e-30e4891b3a4d"), "Indiana"},
                {new Guid("b0e4fe85-6a42-4784-b109-663207a5674b"), "Kansas"},
                {new Guid("ac86c305-cdfa-4e2f-b0f1-e4526449d0a5"), "Kentucky"},
                {new Guid("06c192ba-d46c-4a1f-ac02-a768ae725ce8"), "Louisiana"},
                {new Guid("ccd81eb9-2ba0-4aaa-b268-1e8dd7e31700"), "Massachusetts"},
                {new Guid("27bd93dd-4173-4384-aacb-e77cdd9cbaf4"), "Maryland"},
                {new Guid("0ff910e4-528c-4a86-9d17-e6e40f701b41"), "Maine"},
                {new Guid("fd92c633-82ad-4763-b4a2-e824901f3df5"), "Michigan"},
                {new Guid("a6d70895-2fd6-43fe-9bbd-75a5d4883b99"), "Minnesota"},
                {new Guid("3bd8a4ac-b699-4341-b8d6-1f72cdc7a0c2"), "Missouri"},
                {new Guid("b981a105-971c-4478-9527-ad38dc043af0"), "Mississippi"},
                {new Guid("8b6e0fe2-1e76-4a32-9c50-e53edda9d279"), "Montana"},
                {new Guid("5431f55b-2ade-4507-bf95-4e23f9acdc9d"), "North Carolina"},
                {new Guid("79fe78b4-b2b4-418b-94b0-da63d0ba4e27"), "North Dakota"},
                {new Guid("65e0f886-7a1c-4e98-afb8-98ed4fb8fe83"), "Nebraska"},
                {new Guid("54ff66e7-eacf-4f56-b4fd-6dce87ffbe05"), "New Hampshire"},
                {new Guid("961e4cde-ae91-4ffa-b60b-ae05c34222fb"), "New Jersey"},
                {new Guid("4e4afc77-8017-41a2-81a9-a2d5541715ab"), "New Mexico"},
                {new Guid("34ae5e31-2cea-43f5-a8a5-1821ac1ca0d4"), "Nevada"},
                {new Guid("9207311f-a607-4f67-94b6-23d5d01a93a6"), "New York"},
                {new Guid("f16f15ca-bc9d-4fba-b442-b7082bf4a32b"), "Ohio"},
                {new Guid("6858b5da-fa05-4146-b138-3f786dc261d2"), "Oklahoma"},
                {new Guid("2f195592-5f08-4227-afa8-c5b0fd304730"), "Oregon"},
                {new Guid("ac9341d3-f22c-49d4-8f13-232e7268d6e6"), "Pennsylvania"},
                {new Guid("99cce143-2f3b-46cf-a233-223ca8000fad"), "Rhode Island"},
                {new Guid("d7bf458a-b278-459c-9e5d-a2221ce8b883"), "South Carolina"},
                {new Guid("6b3e2346-5f1d-41d2-a8aa-c12397043735"), "South Dakota"},
                {new Guid("ef0f113e-110c-4823-ae52-8acc74531293"), "Tennessee"},
                {new Guid("4fdbde48-4c6b-4975-82bd-aa893f87e86a"), "Texas"},
                {new Guid("4cae3586-aa84-4e3e-b925-ec8de2cb2e75"), "Utah"},
                {new Guid("2d586203-8ee4-4bc0-aa6d-16aead0cddd0"), "Virginia"},
                {new Guid("f7ee27f3-0272-4e64-bd4e-0c4f2694359b"), "Vermont"},
                {new Guid("a312cdb2-eb89-4a16-92fd-9d439b1bf780"), "Washington"},
                {new Guid("669019b2-92f2-470b-8250-2425fcb6006c"), "Wisconsin"},
                {new Guid("b177e26d-3a39-457d-9ff5-2f94476486ab"), "West Virginia"},
                {new Guid("290f93ea-8809-4aa9-86da-a399b6102e59"), "Wyoming"}
            };
        }
    }
}
