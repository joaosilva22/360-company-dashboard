using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FirstREST.Models
{
    public class SpecialRegimes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public int SelfBillingIndicator
        {
            get;
            set;
        }

        public int CashVATSchemeIndicator
        {
            get;
            set;
        }

        public int ThirdPartiesBillingIndicator
        {
            get;
            set;
        }
    }
}
