using RestWithAPSNETUdemy.Data.Converter.Contract;
using RestWithAPSNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAPSNETUdemy.Data.Converter.Implementatios
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public RestWithASPNETUdemy.Model.Person Parse(VO.PersonVO origin)
        {
            if (origin == null) return null;
            return new RestWithASPNETUdemy.Model.Person
            {
                CD_pessoa = origin.CD_pessoa,
                CH_address = origin.CH_address,
                CH_firstName = origin.CH_firstName,
                CH_gender = origin.CH_gender,
                CH_lastName = origin.CH_lastName,
                DT_Criacao = origin.DT_Criacao,
                DT_Edicao = origin.DT_Edicao
            };
        }

        public VO.PersonVO Parse(RestWithASPNETUdemy.Model.Person origin)
        {
            if (origin == null) return null;
            return new VO.PersonVO
            {
                CD_pessoa = origin.CD_pessoa,
                CH_address = origin.CH_address,
                CH_firstName = origin.CH_firstName,
                CH_gender = origin.CH_gender,
                CH_lastName = origin.CH_lastName,
                DT_Criacao = origin.DT_Criacao,
                DT_Edicao = origin.DT_Edicao
            };
        }

        public List<RestWithASPNETUdemy.Model.Person> Parse(List<VO.PersonVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<VO.PersonVO> Parse(List<RestWithASPNETUdemy.Model.Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
