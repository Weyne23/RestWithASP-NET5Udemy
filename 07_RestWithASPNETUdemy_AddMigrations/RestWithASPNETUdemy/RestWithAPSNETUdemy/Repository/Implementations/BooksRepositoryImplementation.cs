using RestWithAPSNETUdemy.Model;
using RestWithAPSNETUdemy.Model.Context;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAPSNETUdemy.Repository.Implementations
{
    public class BooksRepositoryImplementation : IBooksRepository
    {
        private readonly MySqlContext _context;

        public BooksRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        public List<Books> FindAll()
        {
            return _context.Books.ToList();
        }

        public Books FindById(long id)
        {
            return _context.Books.Find(id);
        }

        public Books Create(Books book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return book;
            }
            catch (System.Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public void Delete(long id)
        {
            var book = _context.Books.Find(id);

            if (book != null)
            {
                try
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    throw;
                }
            }

        }

        public Books Update(Books book)
        {
            if (!Exists(book.CD_book)) { return null; }

            var bookBd = _context.Books.Where(x => x.CD_book.Equals(book.CD_book)).FirstOrDefault();
            try
            {
                _context.Entry(bookBd).CurrentValues.SetValues(book);

                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }

            return book;
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(x => x.CD_book.Equals(id));
        }
    }
}
