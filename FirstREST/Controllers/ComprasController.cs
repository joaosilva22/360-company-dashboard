using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;

namespace FirstREST.Controllers
{
    public class ComprasController : ApiController
    {
      
        //
        // GET: /Compras/

        public Compras Get()
        {
            return Lib_Primavera.PriIntegration.TotalCompras();

        }

        public Compras Get(DateTime arg1, DateTime arg2)
        {
            DateTime dataDe = arg1;
            DateTime dataAte = arg2;

            return Lib_Primavera.PriIntegration.TotalComprasData(dataDe, dataAte);

        }
         

    }
}

