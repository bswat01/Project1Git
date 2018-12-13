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
        public string missionName { get; set; }
        public string missionPresidentName { get; set; }
        public string missionAddress { get; set; }
        public string Language { get; set; }
        public string Climate { get; set; }
        public string DominateReligion { get; set; }
        public string Flag { get; set; }
    }
}