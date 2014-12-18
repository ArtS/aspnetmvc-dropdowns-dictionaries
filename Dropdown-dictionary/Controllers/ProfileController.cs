using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Dropdowns.Models;

namespace Dropdowns.Controllers
{
    public class ProfileController : Controller
    {
        //
        // 1. Action method for displaying a 'User Profile' page
        //
        public ActionResult UserProfile()
        {
            // Get existing user profile object from the session or create a new one
            var model = Session["UserProfileModel"] as UserProfileModel ?? new UserProfileModel();

            // Create a list of SelectListItems from Industries so these can be rendered on the page
            // under the drop down
            model.Industries = GetSelectListItems();

            return View(model);
        }

        //
        // 2. Action method for handling user-entered data when 'Update' button is pressed.
        //
        [HttpPost]
        public ActionResult UserProfile(UserProfileModel model)
        {
            // Set these states on the model. We need to do this because
            // only selected in the DropDownList value is posted back, not the whole
            // list of states
            model.Industries = GetSelectListItems();

            // In case everything is fine - i.e. both "FirstName" and "Industry" are entered/selected,
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

            // Get a description of the currently selected industry from the
            // [Display] attribute of the Industry enum
            model.IndustryName = GetIndustryName(model.title);

            // Or uncomment to use the generic implementation
            // model.IndustryName = GetEnumDisplayName(model.Industry);

            // Display ViewProfile.html page that shows FirstName, Last Name and selected Industry.
            return View(model);
        }

        /// <summary>
        /// Converts Industry enum to a list of SelectListItems
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();

            // Get all values of the Industry enum
            var enumValues = Enum.GetValues(typeof(Industry)) as Industry[];
            if (enumValues == null)
                return null;

            foreach (var enumValue in enumValues)
            {
                // Create a new SelectListItem element and set its
                // Value and Text to the enum value and description.
                selectList.Add(new SelectListItem
                {
                    Value = enumValue.ToString(),
                    Text = GetIndustryName(enumValue)
                });
            }

            return selectList;
        }

        /// <summary>
        /// So we can show nicely formatted text in the UI this function retrieves the
        /// value from [Display(Name="Editorial & Writing")] attribute.
        /// </summary>
        /// <param name="value">Value from Industry enum</param>
        /// <returns>Value of the "Name" property on Display attribute</returns>
        private string GetIndustryName(Industry value)
        {
            // Get the MemberInfo object for the supplied enum value
            var memberInfo = value.GetType().GetMember(value.ToString());
            if (memberInfo.Length != 1)
                return null;

            // Get DisplayAttibute on the supplied enum value
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
            if (displayAttribute == null || displayAttribute.Length != 1)
                return null;

            return displayAttribute[0].Name;
        }

        /// <summary>
        /// Generic function that obtains value .Neme property of [Display] attribute
        /// on a supplied enum value. Can be used with any enum, not just 'Industry'
        /// in this example
        /// </summary>
	    private string GetEnumDisplayName<T>(T value) where T: struct
	    {
	        // Get the MemberInfo object for supplied enum value
	        var memberInfo = value.GetType().GetMember(value.ToString());
	        if (memberInfo.Length != 1)
		    return null;

	        // Get DisplayAttibute on the supplied enum value
	        var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
	        if (displayAttribute == null || displayAttribute.Length != 1)
		    return null;

	        return displayAttribute[0].Name;
	    }
    }
}