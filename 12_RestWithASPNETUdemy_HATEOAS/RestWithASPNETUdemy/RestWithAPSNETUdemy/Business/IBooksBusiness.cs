using RestWithAPSNETUdemy.Data.VO;
using RestWithAPSNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithAPSNETUdemy.Business
{
    public interface IBooksBusiness
    {
        BooksVO Create(BooksVO book);

        BooksVO FindById(long id);

        List<BooksVO> FindAll();

        BooksVO Update(BooksVO book);

        void Delete(long id);
    }
}
