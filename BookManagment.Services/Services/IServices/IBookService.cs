using BookManagment.Domain.Entities;
using BookManagment.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Services.Services.IServices
{
   public  interface IBookService
    {
        IList<BooksViewModel> GetAll();
        Book GetById(string  BookId);
        bool Delete(string BookID);
        bool Create(Book Book);
        bool Update(Book Book);
    }
}
