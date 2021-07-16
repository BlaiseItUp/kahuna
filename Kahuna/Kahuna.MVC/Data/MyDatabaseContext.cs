using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kahuna.MVC.Data
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
    : base(options)
        {
        }

        //Model class item
        //public DbSet<DotNetCoreSqlDb.Models.Todo> Todo { get; set; }
    }
}
