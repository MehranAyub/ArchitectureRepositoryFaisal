using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
   public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options)
         : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
