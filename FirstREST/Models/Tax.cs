using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FirstREST.Models
{
    public class Tax
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public string TaxType
        {
            get;
            set;
        }

        public string TaxCountryRegion
        {
            get;
            set;
        }

        public string TaxCode
        {
            get;
            set;
        }

        public float TaxPercentage
        {
            get;
            set;
        }
    }
}
