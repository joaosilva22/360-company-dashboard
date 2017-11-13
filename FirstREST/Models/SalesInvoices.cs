using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstREST.Models
{
    public class SalesInvoices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public int NumberOfEntries
        {
            get;
            set;
        }

        public float TotalDebit
        {
            get;
            set;
        }

        public float TotalCredit
        {
            get;
            set;
        }

        public List<Invoice> Invoices
        {
            get;
            set;
        }
    }
}