using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project1Git.Models
{
    public class MissionName
    {
        [Required(ErrorMessage ="Please Select a mission")]
        public string Mission_Name { get; set; }
    }
}