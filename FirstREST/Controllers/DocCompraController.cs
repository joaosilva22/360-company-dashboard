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
       public IEnumerable<Lib_Primavera.Model.DocCompra> Get()
        {
                return Lib_Primavera.PriIntegration.List();
          
        }

       //get  api/DocCompra/Sociedade de Fornecimentos, Lda.
        public IEnumerable<Lib_Primavera.Model.DocCompra> Get(String nomeFornecedor)      
        {
            IEnumerable<Lib_Primavera.Model.DocCompra> docCompra =  Lib_Primavera.PriIntegration.ListTipoDoc(nomeFornecedor);
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
        
        //get  api/DocCompra/Sociedade de Fornecimentos, Lda./2015-03-12/2017-03-12
        public IEnumerable<Lib_Primavera.Model.DocCompra> Get(String nomeFornecedor, DateTime dataDe, DateTime dataAte)
        {
            Console.WriteLine(nomeFornecedor);
            IEnumerable<Lib_Primavera.Model.DocCompra> docCompra = Lib_Primavera.PriIntegration.ListTipoDocData(nomeFornecedor, dataDe, dataAte);
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
                string uri = Url.Link("DefaultApi", new { DocId = dc.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

    }
}
