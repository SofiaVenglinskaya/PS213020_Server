using Microsoft.EntityFrameworkCore;
using PS213020_Server.DataAccess.Core.Interface.Context;
using PS213020_Server.DataAccess.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS213020_Server.DataAccess.DbContext
{
    public class RubicContext : Microsoft.EntityFrameworkCore.DbContext, IRubicContext
    {
        public RubicContext(DbContextOptions<RubicContext> options)
            : base(options)
        {

        }
        public DbSet<UserRto> Users { get; set; }
        public DbSet<UserRoleRto> UserRoles { get; set; }

    }
    
}
