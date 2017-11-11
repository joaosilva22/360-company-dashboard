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

        public double STKAtual
        {
            get;
            set;
        }

        public double PCMedio
        {
            get;
            set;
        }

        public double Iva
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

        public Double Desconto
        {
            get;
            set;
        }

        public Double QtdReservadaGPR
        {
            get;
            set;
        }
    }
}