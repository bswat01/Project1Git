using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project1Git.Models;

namespace Project1Git.DAL
{
    public class ContextMissionary : DbContext
    {
        public ContextMissionary()
            : base("MissionaryContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<MissionQuestion> MissionQuestions { get; set; }
        public DbSet<Mission> Missions { get; set; }
    }
}