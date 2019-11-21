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
        [RegularExpression(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]
                            {1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)", ErrorMessage = "The url must be in the form" +
                            " of https://YOURURL.COM")]
        [Display(Name = "Survey URL")]
        public string SurveyURL { get; set; }

        [Display(Name = "Is the survey currently active?")]
        public Boolean IsActive { get; set; }
    }
}