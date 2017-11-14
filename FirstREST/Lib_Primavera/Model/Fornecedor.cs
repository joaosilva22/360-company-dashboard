using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Fornecedor
    {

        public String NomeFornecedor
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
        public double TotalMerc
        {
            get;
            set;
        }
    }
}
