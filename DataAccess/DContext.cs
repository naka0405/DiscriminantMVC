using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;


namespace DataAccess
{
    public class DContext : DbContext
    {
        public DContext() : base("Connect")
        {

        }
        public DbSet<Equation> Equations { get; set; }
    }
   
}
