using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{

    public class LinhaDocCompra
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


        public int NumLinha
        {
            get;
            set;
        }

        public double Quantidade
        {
            get;
            set;
        }

        public string Unidade
        {
            get;
            set;
        }

        public double TDescontoComercial
        {
            get;
            set;
        }

        public double TDescontoArtigo
        {
            get;
            set;
        }

        public double PrecoUnitario
        {
            get;
            set;
        }

        public double TotalILiquido
        {
            get;
            set;
        }

        public double TotalLiquido
        {
            get;
            set;
        }

        public string Armazem
        {
            get;
            set;
        }

        public string Lote
        {
            get;
            set;
        }

        public double Iva
        {
            get;
            set;
        }

        public double TotalIva
        {
            get;
            set;
        }

        public double PercIncidenciaIva
        {
            get;
            set;
        }


    }
}