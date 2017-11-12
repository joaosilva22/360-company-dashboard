using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Pagamento
    {
        public string Nome
        {
            get;
            set;
        }

        public double valor
        {
            get;
            set;
        }

        public DateTime Data
        {
            get;
            set;
        }

        public string Moeda
        {
            get;
            set;
        }

    }
}