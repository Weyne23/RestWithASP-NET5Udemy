using RestWithAPSNETUdemy.Model;
using RestWithAPSNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithAPSNETUdemy.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private readonly IBooksRepository _repository;

        public BooksBusinessImplementation(IBooksRepository repository)
        {
            _repository = repository;
        }

        public Books Create(Books book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Books> FindAll()
        {
            return _repository.FindAll();
        }

        public Books FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Books Update(Books person)
        {
            return _repository.Update(person);
        }
    }
}
