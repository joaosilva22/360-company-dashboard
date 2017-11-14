using FirstREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstREST.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {
            Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());        
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<AuditFile> AuditFile { get; set; }
        public DbSet<DocumentStatus> DocumentStatus { get; set; }
        public DbSet<DocumentTotals> DocumentTotals { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceLine> InvoiceLine { get; set; }
        public DbSet<SalesInvoices> SalesInvoices { get; set; }
        public DbSet<ShipFrom> ShipFrom { get; set; }
        public DbSet<ShipTo> ShipTo { get; set; }
        public DbSet<SourceDocuments> SourceDocuments { get; set; }
        public DbSet<SpecialRegimes> SpecialRegimes { get; set; }
        public DbSet<Tax> Tax { get; set; }
        public DbSet<WithholdingTax> WithholdingTax { get; set; }
    }
}