using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagment.Repository.DbBook;

namespace BookManagment.Repository.Initializer
{
    public class DBInitializer : CreateDatabaseIfNotExists<DBEntities>
    {
        public DBInitializer()
        {
        }
        protected override void Seed(DBEntities context)
        {
           
            base.Seed(context);
            context.SaveChanges();       
        }
    }
}
