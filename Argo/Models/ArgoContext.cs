using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Argo.Models
{
    public class ArgoContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bus> Buses { get; set; }
    }
}