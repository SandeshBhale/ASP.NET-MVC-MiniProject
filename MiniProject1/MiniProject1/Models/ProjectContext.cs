using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniProject1.Models
{
    public class ProjectContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientProject> Projects { get; set; }
        public DbSet<ClientProjectUser> ClientProjectUsers { get; set; }
    }
}