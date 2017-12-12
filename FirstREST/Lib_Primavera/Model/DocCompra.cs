using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class DocCompra
    {

        public string id
        {
            get;
            set;
        }

        public String TipoDoc
        {
            get;
            set;
        }

        public DateTime DataDoc
        {
            get;
            set;
        }

        public double TotalLiquido
        {
            get;
            set;
        }

        public string NomeFornecedor
        {
            get;
            set;

        }

    }
}