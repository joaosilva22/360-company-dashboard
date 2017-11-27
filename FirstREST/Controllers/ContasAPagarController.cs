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
    public class ContasAPagarController : ApiController
    {
        //GET: api/ContasAPagar/2014-12-12/2017-12-12
        public IEnumerable<Lib_Primavera.Model.DocCompra> Get(DateTime arg1, DateTime arg2)
        {
            DateTime dataDe = arg1;
            DateTime dataAte = arg2;

            IEnumerable<Lib_Primavera.Model.DocCompra> contasAPagar = Lib_Primavera.PriIntegration.ListaContasAPagar(dataDe, dataAte);
            if (contasAPagar == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return contasAPagar;
            }
        }





    }
}

