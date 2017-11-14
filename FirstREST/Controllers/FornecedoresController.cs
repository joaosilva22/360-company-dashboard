﻿using System;
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

        //get  api/DocCompra/VFA/2015-03-12/017-03-12
        public IEnumerable<Lib_Primavera.Model.Fornecedor> Get(String arg1, DateTime arg2, DateTime arg3)
        {
            String tipoDoc = arg1;
            DateTime dateDe = arg2;
            DateTime dateAte = arg3;

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