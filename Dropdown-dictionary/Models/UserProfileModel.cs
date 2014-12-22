using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dropdowns.Models
{
    public class UserProfileModel
    {
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
        public Dictionary<string, string> States { get; set; }

        // Property to store human-readable state name
        public string StateName { get; set; }
    }
}