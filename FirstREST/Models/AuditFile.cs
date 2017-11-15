using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FirstREST.Models
{
    public class AuditFile
    {
        [Key, ForeignKey("Header"), Column(Order=0)]
        public int CompanyID
        {
            get;
            set;
        }

        [Key, ForeignKey("Header"), Column(Order = 1)]
        public int FiscalYear
        {
            get;
            set;
        }

        public Header Header
        {
            get;
            set;
        }

        public MasterFiles MasterFiles
        {
            get;
            set;
        }

        public SourceDocuments SourceDocuments
        {
            get;
            set;
        }
    }
}
