using Microsoft.AspNetCore.Mvc;
using RestWithAPSNETUdemy.Data.VO;
using RestWithAPSNETUdemy.Hypermedia.Constants;
using System.Text;
using System.Threading.Tasks;

namespace RestWithAPSNETUdemy.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {
        private readonly object _locker = new object();
        protected override Task EnrichModel(PersonVO context, IUrlHelper urlHelper)
        {
            var path = "api/person";

            string link = GetLink(context.CD_pessoa, urlHelper, path);

            context.Links.Add(new HyperMediaLink()
            { 
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            context.Links.Add(new HyperMediaLink()
            { 
                Action = HttpActionVerb.POST,
                Href = link.Replace($"/{context.CD_pessoa}", ""),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            context.Links.Add(new HyperMediaLink()
            { 
                Action = HttpActionVerb.PATCH,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPatch
            });

            context.Links.Add(new HyperMediaLink()
            { 
                Action = HttpActionVerb.PUT,
                Href = link.Replace($"/{context.CD_pessoa}", ""),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut
            });

            context.Links.Add(new HyperMediaLink()
            { 
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"
            });

            return Task.CompletedTask;
        }

        private string GetLink(long cD_pessoa, IUrlHelper urlHelper, string path)
        {
            lock (_locker)
            {
                var url = new { controller = path, id = cD_pessoa };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }
    }
}
