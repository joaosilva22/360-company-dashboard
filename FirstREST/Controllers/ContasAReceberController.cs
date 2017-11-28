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
    public class ContasAReceberController : ApiController
    {
        //GET: api/ContasAReceber
        public IEnumerable<Lib_Primavera.Model.DocVenda> Get()
        {

            IEnumerable<Lib_Primavera.Model.DocVenda> contasAReceber = Lib_Primavera.PriIntegration.ListaContasAReceber();
            if (contasAReceber == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return contasAReceber;
            }
        }





    }
}

