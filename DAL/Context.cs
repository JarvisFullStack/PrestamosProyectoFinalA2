
using Entities;
using System;
using System.Data.Entity;

namespace DAL
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public Context() : base("ConStr")
        {

        }

       
    }
}
