using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IS403_Project1.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "User Email")]
        public string Email { get; set; }

        [Display(Name = "Count of Surveys Created")]
        public int CountOfSurveysCreated { get; set; }

        [Display(Name = "Number of Surveys Completed")]
        public int CountOfSurveysCompleted { get; set; }
    }
}