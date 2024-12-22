using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School5FactoryPractice.Data
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<HomeworkSubscription> HomeworkSubs => Set<HomeworkSubscription>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SchoolApp.db");
        }
    }
}
