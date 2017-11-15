using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstREST.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public string InvoiceNo
        {
            get;
            set;
        }

        public string ATCUD
        {
            get;
            set;
        }

        public DocumentStatus DocumentStatus
        {
            get;
            set;
        }

        public string Hash
        {
            get;
            set;
        }

        public int HashControl
        {
            get;
            set;
        }

        public string Period
        {
            get;
            set;
        }

        public DateTime InvoiceDate
        {
            get;
            set;
        }

        public string InvoiceType
        {
            get;
            set;
        }

        public SpecialRegimes SpecialRegimes
        {
            get;
            set;
        }

        public string SourceID
        {
            get;
            set;
        }

        public DateTime SystemEntryDate
        {
            get;
            set;
        }

        public string CustomerID
        {
            get;
            set;
        }

        public ShipTo ShipTo
        {
            get;
            set;
        }

        public ShipFrom ShipFrom
        {
            get;
            set;
        }

        public DateTime MovementStartTime
        {
            get;
            set;
        }

        public List<InvoiceLine> Lines
        {
            get;
            set;
        }

        public DocumentTotals DocumentTotals
        {
            get;
            set;
        }

        public WithholdingTax WithholdingTax
        {
            get;
            set;
        }
    }
}