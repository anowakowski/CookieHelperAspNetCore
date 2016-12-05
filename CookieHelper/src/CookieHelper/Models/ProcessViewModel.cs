using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookieHelper.Models
{
    public class ProcessViewModel
    {
        [Display(Name="process name: ")]
        public string Name { get; set; }
    }
}
