using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FirstREST.Models
{
    public class InvoiceLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public int LineNumber
        {
            get;
            set;
        }

        public string ProductCode
        {
            get;
            set;
        }

        public string ProductDescription
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public string UnitOfMeasure
        {
            get;
            set;
        }

        public float UnitPrice
        {
            get;
            set;
        } 

        public DateTime TaxPointDate 
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public float CreditAmount
        {
            get;
            set;
        }

        public Tax Tax
        {
            get;
            set;
        }

        public float SettlementAmount
        {
            get;
            set;
        }
    }
}
