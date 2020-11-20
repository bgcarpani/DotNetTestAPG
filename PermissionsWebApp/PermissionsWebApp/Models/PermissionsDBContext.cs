using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PermissionsWebApp.Models
{
    public class PermissionsDBContext:DbContext
    {
        public PermissionsDBContext(): base("DefaultConnection")
        {

        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
    }
}