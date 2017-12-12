using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstREST.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public long AccountID
        {
            get;
            set;
        }

        public string AccountDescription
        {
            get;
            set;
        }

        public float OpeningDebitBalance
        {
            get;
            set;
        }

        public float OpeningCreditBalance
        {
            get;
            set;
        }

        public float ClosingDebitBalance
        {
            get;
            set;
        }

        public float ClosingCreditBalance
        {
            get;
            set;
        }

        public string GroupingCategory
        {
            get;
            set;
        }
    }
}
