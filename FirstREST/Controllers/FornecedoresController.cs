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

        //get  api/Fornecedores/nomeFornecedor
        public IEnumerable<Lib_Primavera.Model.DocCompra> Get(String arg1)
        {
            String nomeFornecedor = arg1;

            IEnumerable<Lib_Primavera.Model.DocCompra> fornecedores = Lib_Primavera.PriIntegration.ListFornecedor(nomeFornecedor);
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

        //get  api/Fornecedores/VFA/2015-03-12/2017-03-12
        public IEnumerable<Lib_Primavera.Model.Fornecedor> Get(String arg1, DateTime arg2, DateTime arg3)
        {
            String tipoDoc = arg1;
            DateTime dataDe = arg2;
            DateTime dataAte = arg3;

            IEnumerable<Lib_Primavera.Model.Fornecedor> fornecedores = Lib_Primavera.PriIntegration.ListFornecedoresTipoDocData(tipoDoc, dataDe, dataAte);
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
