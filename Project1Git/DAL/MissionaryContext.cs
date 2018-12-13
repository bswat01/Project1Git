using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project1Git.Models;

namespace Project1Git.DAL
{
    public class MissionaryContext : DbContext
    {
        public MissionaryContext()
            : base("MissionaryContext")
        {

        }
        DbSet<MissionName> MissionNames { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<MissionQuestions> MissionQuestions { get; set; }
    }
}