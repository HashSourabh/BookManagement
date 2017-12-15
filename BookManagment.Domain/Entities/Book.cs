using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Domain.Entities
{
   public  class Book
    {
        public string Id { get; set; }
        public string name { get; set; }
        public int numberOfPages { get; set; }
        public Nullable< DateTime> dateOfPublication { get; set; }
        public Nullable<DateTime> createDate { get; set; }
        public Nullable<DateTime> updateDate { get; set; }
        public string author { get; set; }
       
        [NotMapped]
        public string[] authors { get; set; }


    }
}
