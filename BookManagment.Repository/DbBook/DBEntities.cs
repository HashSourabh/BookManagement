using BookManagment.Repository.Initializer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagment.Domain.Entities;
//using Travel.Model.Entities;

namespace BookManagment.Repository.DbBook
{
    public sealed class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
            Database.SetInitializer(new DBInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DBEntities>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
     

    }
}
