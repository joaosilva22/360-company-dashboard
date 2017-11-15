using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;

namespace FirstREST.Controllers
{
    public class DocCompraController : ApiController
    {

        //get  api/DocCompra
        public IEnumerable<Lib_Primavera.Model.DocCompra> Get()
        {
            IEnumerable<Lib_Primavera.Model.DocCompra> docCompra = Lib_Primavera.PriIntegration.ListDocCompra();
            if (docCompra == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return docCompra;
            }
        }

    
  
        //get  api/DocCompra/2015-03-12/2017-03-12
        /* public IEnumerable<Lib_Primavera.Model.DocCompra> Get(DateTime arg1, DateTime arg2)
       {
           DateTime dataDe = arg1;
           DateTime dataAte = arg2;

           IEnumerable<Lib_Primavera.Model.DocCompra> docCompra = Lib_Primavera.PriIntegration.ListDocCompraData( dataDe, dataAte);
           if (docCompra == null)
           {
               throw new HttpResponseException(
                       Request.CreateResponse(HttpStatusCode.NotFound));

           }
           else
           {
               return docCompra;
           }
       }

      
       public HttpResponseMessage Post(Lib_Primavera.Model.DocCompra dc)
       {
           Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();
           erro = Lib_Primavera.PriIntegration.VGR_New(dc);

           if (erro.Erro == 0)
           {
               var response = Request.CreateResponse(
                  HttpStatusCode.Created, dc.id);
               string uri = Url.Link("DefaultApi");
               response.Headers.Location = new Uri(uri);
               return response;
           }

           else
           {
               return Request.CreateResponse(HttpStatusCode.BadReque);
           }

       }*/

    }
}
