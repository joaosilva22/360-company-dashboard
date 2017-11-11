using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{

    public class LinhaDocCompra
    {
        //Artigo
        public string CodArtigo
        {
            get;
            set;
        }

        //Descricao
        public string DescArtigo
        {
            get;
            set;
        }

        //IdCabecCompras
        public string IdCabecDoc
        {
            get;
            set;
        }

        //NumLinha
        public int NumLinha
        {
            get;
            set;
        }

        //Quantidade 4
        public double Quantidade
        {
            get;
            set;
        }

        //Unidade
        public string Unidade
        {
            get;
            set;
        }

        //DescontoComercial 91
        public double Desconto
        {
            get;
            set;
        }

        //PrecUnit 455
        public double PrecoUnitario
        {
            get;
            set;
        }

        //TotalIliquido
        public double TotalILiquido
        {
            get;
            set;
        }

        //PrecoLiquido
        public double TotalLiquido
        {
            get;
            set;
        }

        //Armazem
        public string Armazem
        {
            get;
            set;
        }

        //Lote
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

        public string NomeFornecedor
        {
            get;
            set;

        }
        public String TipoDoc
        {
            get;
            set;
        }
    }
}