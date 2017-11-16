using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class DocCompra
    {


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

        public double TotalIva
        {
            get;
            set;
        }

        public double TotalDesc
        {
            get;
            set;
        }

        public double TotalOutros
        {
            get;
            set;
        }


        public string Entidade
        {
            get;
            set;

        }

    }
}