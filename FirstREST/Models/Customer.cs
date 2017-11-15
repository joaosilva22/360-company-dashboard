using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FirstREST.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public string CustomerID
        {
            get;
            set;
        }

        public string AccountID
        {
            get;
            set;
        }
        
        public string CustomerTaxID
        {
            get;
            set;
        }
		
        public string CompanyName
        {
            get;
            set;
        }

        public Address BillingAddress
        {
            get;
            set;
        }

        public Address ShipToAddress
        {
            get;
            set;
        }

        public String SelfBillingIndicator
        {
            get;
            set;
        }
    }
}
