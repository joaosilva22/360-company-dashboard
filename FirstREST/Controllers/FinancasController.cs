using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class FinancasController : ApiController
    {
        // GET /api/Financas/[acao]/[date]/[date]
        public IEnumerable<Lib_Primavera.Model.Pagamento> Get(string arg1, DateTime arg2, DateTime arg3)
        {
            string action = arg1;
            DateTime initialDate = arg2;
            DateTime finalDate = arg3;


            if(action.Equals("payments"))
                return Lib_Primavera.PriIntegration.getPagamentos(initialDate, finalDate);

            else throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    }
}
