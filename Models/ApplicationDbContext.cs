using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("DefaultConnection")
        {

        }

        public DbSet<Formation> Formations { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
    }
}