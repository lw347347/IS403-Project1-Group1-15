using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IS403_Project1.Models
{
    public class Survey
    {
        [Required]
        public int SurveyID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Survey Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Survey URL")]
        public string SurveyURL { get; set; }

        [Display(Name = "Is the survey currently active?")]
        public Boolean IsActive { get; set; }
    }
}