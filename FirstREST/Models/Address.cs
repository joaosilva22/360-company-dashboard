using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FirstREST.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public string AddressDetail
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string PostalCode
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }
    }
}
