using CookieHelper.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookieHelper.Models
{
    public class ProcessViewModel
    {
        [Display(Name = "process name: ")]
        [Required(ErrorMessage = "process name cant be empty")]
        public string Name { get; set; }

        [Display(Name = "Additional element for a process")]
        public string AdditionalProcessElements { get; set; }

        public ProcessType ProcessTypeName { get; set; }
    }
}
