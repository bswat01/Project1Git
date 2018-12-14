using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1Git.Models
{
    [Table("MissionQuestions")]
    public class MissionQuestion
    {
        [Key]
        public int missionquestionID { get; set; }

        [Required]
        public virtual int missionID { get; set; }

        [Required]
        public virtual int userID { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string question { get; set; }

        
        [Display(Name = "Answer")]
        public string answer { get; set; }

        public virtual Mission Missions { get; set; }
        public virtual User Users { get; set; }
    }
}