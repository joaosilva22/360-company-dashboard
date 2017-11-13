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



        //get  api/Fornecedores/VFA
        public IEnumerable<Lib_Primavera.Model.Fornecedor> Get(String tipoDoc)
        {
            IEnumerable<Lib_Primavera.Model.Fornecedor> fornecedores = Lib_Primavera.PriIntegration.ListForecedorTipoDoc(tipoDoc);
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


        //get  api/DocCompra?tipoDoc=VFA%dateDe=2015-03-12&dateAte=2017-03-12
        public IEnumerable<Lib_Primavera.Model.Fornecedor> Get(String tipoDoc, DateTime dataDe, DateTime dataAte)
        {
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
