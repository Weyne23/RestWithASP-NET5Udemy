using RestWithAPSNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithAPSNETUdemy.Repository
{
    public interface IBooksRepository
    {
        Books Create(Books person);

        Books FindById(long id);

        List<Books> FindAll();

        Books Update(Books person);

        void Delete(long id);

        bool Exists(long id);
    }
}
