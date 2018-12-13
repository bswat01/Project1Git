using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1Git.Models
{
    [Table("Missions")]
    public class Mission
    {
        [Key]
        public int missionID { get; set; }
        [Required]
        [Display(Name = "Mission Name")]
        public string missionName { get; set; }

        [Required]
        [Display(Name = "Mission President's Name")]
        public string missionPresidentName { get; set; }

        [Required]
        [Display(Name = "Mission Address")]
        public string missionAddress { get; set; }

        [Required]
        [Display(Name = "Mission Language")]
        public string Language { get; set; }

        [Required]
        [Display(Name = "Mission Climate")]
        public string Climate { get; set; }

        [Required]
        [Display(Name = "Mission's Dominate Religion")]
        public string DominateReligion { get; set; }

        [Required]
        [Display(Name = "Mission Flag ")]
        public string Flag { get; set; }
    }
}