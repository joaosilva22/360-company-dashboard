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
        // GET /api/Financas?action=[acao]&initialDate=[date]&finalDate=[date]
        public IEnumerable<Lib_Primavera.Model.Pagamento> Get(string action, DateTime initialDate, DateTime finalDate)
        {
            if(action.Equals("payments"))
                return Lib_Primavera.PriIntegration.getPagamentos(initialDate, finalDate);

            else throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    }
}
