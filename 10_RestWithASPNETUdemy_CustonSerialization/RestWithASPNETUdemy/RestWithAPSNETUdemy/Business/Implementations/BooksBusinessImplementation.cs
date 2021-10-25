using RestWithAPSNETUdemy.Data.Converter.Implementatios;
using RestWithAPSNETUdemy.Data.VO;
using RestWithAPSNETUdemy.Model;
using RestWithAPSNETUdemy.Repository;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithAPSNETUdemy.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private readonly IRepository<Books> _repository;
        private readonly BooksConverter _converter;

        public BooksBusinessImplementation(IRepository<Books> repository)
        {
            _repository = repository;
            _converter = new BooksConverter();
        }

        public BooksVO Create(BooksVO book)
        {
            var BooksVOConv = _converter.Parse(book);
            _repository.Create(BooksVOConv);
            return _converter.Parse(BooksVOConv);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BooksVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BooksVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BooksVO Update(BooksVO books)
        {
            var booksVOConverter = _converter.Parse(books);
            _repository.Update(booksVOConverter);
            return _converter.Parse(booksVOConverter);
        }
    }
}
