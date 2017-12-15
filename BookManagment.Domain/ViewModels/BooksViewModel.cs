using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Domain.ViewModels
{
    public class BooksViewModel
    {
        public string Id { get; set; }
        public string name { get; set; }
        public int numberOfPages { get; set; }
        public Nullable<DateTime> dateOfPublication { get; set; }
        public Nullable<DateTime> createDate { get; set; }
        public Nullable<DateTime> updateDate { get; set; }
        
        public string[] authors { get; set; }
    }
}
