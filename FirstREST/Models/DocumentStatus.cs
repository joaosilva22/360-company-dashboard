using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FirstREST.Models
{
    public class DocumentStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public string InvoiceStatus
        {
            get;
            set;
        }

        public DateTime InvoiceStatusDate
        {
            get;
            set;
        }

        public string SourceID
        {
            get;
            set;
        }

        public string SourceBilling
        {
            get;
            set;
        }   
    }
}
