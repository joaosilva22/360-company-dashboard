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
    public class FornecedoresController : ApiController
    {
        //get  api/Fornecedores
        public IEnumerable<Lib_Primavera.Model.Fornecedor> Get()
        {
            return Lib_Primavera.PriIntegration.ListFornecedores();

        }

        //get  api/Fornecedores/F0001
        public Fornecedor Get(String arg1)
        {
            String nomeFornecedor = arg1;

           Fornecedor fornecedore = Lib_Primavera.PriIntegration.ListFornecedor(nomeFornecedor);
            if (fornecedore == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return fornecedore;
            }
        }

        //get  api/Fornecedores/2015-03-12/2017-03-12
        public IEnumerable<Lib_Primavera.Model.Fornecedor> Get( DateTime arg1, DateTime arg2)
        {
            DateTime dataDe = arg1;
            DateTime dataAte = arg2;

            IEnumerable<Lib_Primavera.Model.Fornecedor> fornecedores = Lib_Primavera.PriIntegration.ListFornecedoresData( dataDe, dataAte);
            if (fornecedores == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return fornecedores;
            }
        }

    }
}
