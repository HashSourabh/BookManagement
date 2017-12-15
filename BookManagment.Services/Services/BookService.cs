using BookManagment.Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagment.Domain.Entities;
using BookManagment.Repository.DbBook;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BookManagment.Domain.ViewModels;
using System.Text.RegularExpressions;


namespace BookManagment.Services.Services
{
    public class BookService : IBookService
    {
        // private DBEntities _context;

        private DBEntities _context = new DBEntities();

        public bool Create(Book Books)
        {
            try
            {
                string GId = Guid.NewGuid().ToString();
                Books.Id = GId;
                Books.author = String.Join(", ", Books.authors);
                Books.createDate = DateTime.Now;
                _context.Books.Add(Books);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string BookID)
        {
            try
            {
                _context.Books.Remove(_context.Books.Where(x => x.Id == BookID).FirstOrDefault());
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public IList<BooksViewModel> GetAll()
        {
            return (from a in _context.Books
                    select a).ToList().Select(x=> new BooksViewModel()
                    {
                        Id = x.Id,
                        name = x.name,
                        dateOfPublication = x.dateOfPublication,
                        updateDate = x.updateDate,
                        createDate = x.createDate,
                        numberOfPages = x.numberOfPages,
                        authors =string.IsNullOrEmpty(x.author)?null: Regex.Split(x.author, ",")
                    }
            ).ToList();
        }
        
        public Book GetById(string BookId)
        {
            return _context.Books.Where(x => x.Id == BookId).FirstOrDefault();
        }

        public bool Update(Book Book)
        {
            try
            {
                Book.updateDate = DateTime.Now;
                if (Book.authors != null)
                    Book.author = String.Join(", ", Book.authors);
                _context.Books.Attach(Book);
                DbEntityEntry entry = _context.Entry(Book);
                foreach (var propertyName in entry.OriginalValues.PropertyNames)
                {
                    // Get the old field value from the database.
                    var original = entry.GetDatabaseValues().GetValue<object>(propertyName);
                    // Get the current value from posted edit page.
                    var current = entry.CurrentValues.GetValue<object>(propertyName);
                    if ((original != current) && (current != null))
                    {
                        entry.Property(propertyName).IsModified = true;
                    }
                }

                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

    }
}
