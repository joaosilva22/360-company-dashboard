using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Artigo
    {
        public string CodArtigo
        {
            get;
            set;
        }

        public string DescArtigo
        {
            get;
            set;
        }

        public double STKActual
        {
            get;
            set;
        }

        public double PCMedio
        {
            get;
            set;
        }

        public String Iva
        {
            get;
            set;
        }

        public string UnidadeVenda
        {
            get;
            set;
        }

        public string UnidadeCompra
        {
            get;
            set;
        }

        public DateTime DataUltimaAtualizacao
        {
            get;
            set;
        }



        public Double QtReservadaGPR
        {
            get;
            set;
        }

        public Double Desconto
        {
            get;
            set;
        }
    }
}