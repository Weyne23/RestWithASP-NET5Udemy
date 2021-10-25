using RestWithAPSNETUdemy.Data.VO;
using RestWithAPSNETUdemy.Model;
using RestWithAPSNETUdemy.Data.Converter.Contract;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAPSNETUdemy.Data.Converter.Implementatios
{
    public class BooksConverter : IParser<BooksVO, Books>, IParser<Books, BooksVO>
    {
        public Books Parse(BooksVO origin)
        {
            return new Books
            {
                CD_book = origin.CD_book,
                CH_author = origin.CH_author,
                CH_title = origin.CH_title,  
                DT_launch_date = origin.DT_launch_date,
                VR_price = origin.VR_price,
                DT_Criacao = origin.DT_Criacao,
                DT_Edicao = origin.DT_Edicao,
            };
        }

        public BooksVO Parse(Books origin)
        {
            return new BooksVO
            {
                CD_book = origin.CD_book,
                CH_author = origin.CH_author,
                CH_title = origin.CH_title,
                DT_launch_date = origin.DT_launch_date,
                VR_price = origin.VR_price,
                DT_Criacao = origin.DT_Criacao,
                DT_Edicao = origin.DT_Edicao,
            };
        }

        public List<Books> Parse(List<BooksVO> origin)
        {
            if (origin == null) return null;
                return origin.Select(item => Parse(item)).ToList();
        }

        public List<BooksVO> Parse(List<Books> origin)
        {
            if (origin == null) return null;
                return origin.Select(item => Parse(item)).ToList();
        }
    }
}
