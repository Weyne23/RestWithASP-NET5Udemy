using Microsoft.AspNetCore.Mvc;
using RestWithAPSNETUdemy.Data.VO;
using RestWithAPSNETUdemy.Hypermedia.Constants;
using System.Text;
using System.Threading.Tasks;

namespace RestWithAPSNETUdemy.Hypermedia.Enricher
{
    public class BooksEnricher : ContentResponseEnricher<BooksVO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(BooksVO context, IUrlHelper urlHelper)
        {
            var path = "api/books";

            string link = GetLink(context.CD_book, urlHelper, path);

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
                Href = link.Replace($"/{context.CD_book}", ""),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            context.Links.Add(new HyperMediaLink() 
            { 
                Action = HttpActionVerb.PUT,
                Href = link.Replace($"/{context.CD_book}", ""),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut
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
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"
            });

            return Task.CompletedTask;
        }

        private string GetLink(long cD_book, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = cD_book };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }
    }
}
