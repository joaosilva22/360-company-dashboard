using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FirstREST.Models
{
    public class DocumentTotals
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public float TaxPayable
        {
            get;
            set;
        }

        public float NetTotal
        {
            get;
            set;
        }

        public float GrossTotal
        {
            get;
            set;
        }
    }
}
