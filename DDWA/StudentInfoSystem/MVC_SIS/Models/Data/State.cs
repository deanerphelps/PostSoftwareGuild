using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State
    {
        [Required]
        public string StateAbbreviation { get; set; }
        [Required]
        public string StateName { get; set; }
    }
}