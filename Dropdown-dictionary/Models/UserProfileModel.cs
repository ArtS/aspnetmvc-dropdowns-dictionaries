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

        // This property holds user-selected industry
        [Required]
        [Display(Name = "Industry")]
        public Industry Industry { get; set; }

        // This property holds all available industries for selection
        public IEnumerable<SelectListItem> Industries { get; set; }

        // This stored human-readable name of the industry
        public string IndustryName { get; set; }
    }
}