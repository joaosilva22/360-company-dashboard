using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstREST.Models
{
    public class Header
    {
        public string AuditFileVersion
        {
            get;
            set;
        }

        [Key, Column(Order=0)]
        public int CompanyID
        {
            get;
            set;
        }

        public int TaxRegistrationNumber
        {
            get;
            set;
        }

        public string TaxAccountingBasis
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }

        public CompanyAddress CompanyAddress
        {
            get;
            set;
        }

        [Key, Column(Order = 1)]
        public int FiscalYear
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }

        public string CurrencyCode
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }

        public string TaxEntity
        {
            get;
            set;
        }

        public int ProductCompanyTaxID
        {
            get;
            set;
        }

        public string SoftwareCertificateNumber
        {
            get;
            set;
        }

        public string ProductID
        {
            get;
            set;
        }

        public string ProductVersion
        {
            get;
            set;
        }
    }
}