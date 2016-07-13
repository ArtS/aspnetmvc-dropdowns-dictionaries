using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Dropdowns.Controllers;

namespace Dropdowns.Models
{
    public class UserProfileModel
    {
        public SelectList list;

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        // This property holds user-selected state
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        // This property holds all available states for selection
        public Dictionary<Guid, string> States { get; set; }

        // Property to store human-readable state name
        public string StateName { get; set; }

        public string Country { get; set; }
    }
}