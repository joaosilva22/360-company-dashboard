using FirstREST.Context;
using FirstREST.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Xml.Linq;
using System.Linq;
using System.Data.Entity;
using System.Net.Http;
using System.Net;

namespace FirstREST.Controllers
{
    public class AuditFileController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Index()
        {
            using (var Context = new DatabaseContext())
            {
                XDocument Doc = XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/SAFT.xml"));
                XNamespace ns = Doc.Root.GetDefaultNamespace();

                AuditFile AuditFile = new AuditFile();

                #region Header

                XElement HeaderElement = Doc.Root.Element(ns + "Header");
                AuditFile.CompanyID = int.Parse(HeaderElement.Element(ns + "CompanyID").Value);
                AuditFile.FiscalYear = int.Parse(HeaderElement.Element(ns + "FiscalYear").Value);
                AuditFile.Header = new Header
                {
                    AuditFileVersion = HeaderElement.Element(ns + "AuditFileVersion").Value,
                    CompanyID = int.Parse(HeaderElement.Element(ns + "CompanyID").Value),
                    TaxRegistrationNumber = int.Parse(HeaderElement.Element(ns + "TaxRegistrationNumber").Value),
                    TaxAccountingBasis = HeaderElement.Element(ns + "TaxAccountingBasis").Value,
                    CompanyName = HeaderElement.Element(ns + "CompanyName").Value,
                    FiscalYear = int.Parse(HeaderElement.Element(ns + "FiscalYear").Value),
                    StartDate = DateTime.Parse(HeaderElement.Element(ns + "StartDate").Value),
                    EndDate = DateTime.Parse(HeaderElement.Element(ns + "EndDate").Value),
                    CurrencyCode = HeaderElement.Element(ns + "CurrencyCode").Value,
                    DateCreated = DateTime.Parse(HeaderElement.Element(ns + "DateCreated").Value),
                    TaxEntity = HeaderElement.Element(ns + "TaxEntity").Value,
                    ProductCompanyTaxID = int.Parse(HeaderElement.Element(ns + "ProductCompanyTaxID").Value),
                    SoftwareCertificateNumber = HeaderElement.Element(ns + "SoftwareCertificateNumber").Value,
                    ProductID = HeaderElement.Element(ns + "ProductID").Value,
                    ProductVersion = HeaderElement.Element(ns + "ProductVersion").Value,
                };

                XElement CompanyAddressElement = HeaderElement.Element(ns + "CompanyAddress");
                AuditFile.Header.CompanyAddress = new CompanyAddress
                {
                    StreetName = CompanyAddressElement.Element(ns + "StreetName").Value,
                    AddressDetail = CompanyAddressElement.Element(ns + "AddressDetail").Value,
                    City = CompanyAddressElement.Element(ns + "City").Value,
                    Country = CompanyAddressElement.Element(ns + "Country").Value,
                    PostalCode = CompanyAddressElement.Element(ns + "PostalCode").Value,
                    Region = CompanyAddressElement.Element(ns + "Region").Value,
                };

                if (Context.AuditFile.Any(e => e.Header.CompanyID == AuditFile.Header.CompanyID && e.Header.FiscalYear == AuditFile.Header.FiscalYear))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Audit file already exists.");
                }

                #endregion

                #region SourceDocuments

                XElement SourceDocumentsElement = Doc.Root.Element(ns + "SourceDocuments");
                AuditFile.SourceDocuments = new SourceDocuments 
                {
                    SalesInvoices = new SalesInvoices(),
                };              

                XElement SalesInvoicesElement = SourceDocumentsElement.Element(ns + "SalesInvoices");                               
                AuditFile.SourceDocuments.SalesInvoices = new SalesInvoices 
                {
                    NumberOfEntries = int.Parse(SalesInvoicesElement.Element(ns + "NumberOfEntries").Value),
                    TotalDebit = float.Parse(SalesInvoicesElement.Element(ns + "TotalDebit").Value),
                    TotalCredit = float.Parse(SalesInvoicesElement.Element(ns + "TotalCredit").Value),
                    Invoices = new List<Invoice>(),
                };               

                IEnumerable<XElement> InvoicesElements = SalesInvoicesElement.Elements(ns + "Invoice");
                foreach (var InvoiceElement in InvoicesElements)
                {
                    Invoice Invoice = new Invoice 
                    {
                        InvoiceNo = InvoiceElement.Element(ns + "InvoiceNo").Value,
                        ATCUD = InvoiceElement.Element(ns + "ATCUD").Value,
                        Hash = InvoiceElement.Element(ns + "Hash").Value,
                        HashControl = int.Parse(InvoiceElement.Element(ns + "HashControl").Value),
                        Period = InvoiceElement.Element(ns + "Period").Value,
                        InvoiceDate = DateTime.Parse(InvoiceElement.Element(ns + "InvoiceDate").Value),
                        InvoiceType = InvoiceElement.Element(ns + "InvoiceType").Value,
                        SourceID = InvoiceElement.Element(ns + "SourceID").Value,
                        SystemEntryDate = DateTime.Parse(InvoiceElement.Element(ns + "SystemEntryDate").Value),
                        CustomerID = InvoiceElement.Element(ns + "CustomerID").Value,
                        MovementStartTime = DateTime.Parse(InvoiceElement.Element(ns + "MovementStartTime").Value),
                        Lines = new List<InvoiceLine>(),
                    };

                    XElement DocumentStatusElement = InvoiceElement.Element(ns + "DocumentStatus");
                    Invoice.DocumentStatus = new DocumentStatus 
                    {
                        InvoiceStatus = DocumentStatusElement.Element(ns + "InvoiceStatus").Value,
                        InvoiceStatusDate = DateTime.Parse(DocumentStatusElement.Element(ns + "InvoiceStatusDate").Value),
                        SourceID = DocumentStatusElement.Element(ns + "SourceID").Value,
                        SourceBilling = DocumentStatusElement.Element(ns + "SourceBilling").Value,
                    };

                    XElement SpecialRegimesElement = InvoiceElement.Element(ns + "SpecialRegimes");
                    Invoice.SpecialRegimes = new SpecialRegimes
                    {
                        SelfBillingIndicator = int.Parse(SpecialRegimesElement.Element(ns + "SelfBillingIndicator").Value),
                        CashVATSchemeIndicator = int.Parse(SpecialRegimesElement.Element(ns + "CashVATSchemeIndicator").Value),
                        ThirdPartiesBillingIndicator = int.Parse(SpecialRegimesElement.Element(ns + "ThirdPartiesBillingIndicator").Value),
                    };

                    XElement ShipToElement = InvoiceElement.Element(ns + "ShipTo");
                    Invoice.ShipTo = new ShipTo
                    {
                        DeliveryDate = DateTime.Parse(ShipToElement.Element(ns + "DeliveryDate").Value),                        
                    };
                    XElement ShipToAddressElement = ShipToElement.Element(ns + "Address");
                    Invoice.ShipTo.Address = new Address
                    {
                        AddressDetail = ShipToAddressElement.Element(ns + "AddressDetail").Value,
                        City = ShipToAddressElement.Element(ns + "City").Value,
                        PostalCode = ShipToAddressElement.Element(ns + "PostalCode").Value,
                        Country = ShipToAddressElement.Element(ns + "Country").Value,
                    };

                    XElement ShipFromElement = InvoiceElement.Element(ns + "ShipFrom");
                    Invoice.ShipFrom = new ShipFrom
                    {
                        DeliveryDate = DateTime.Parse(ShipFromElement.Element(ns + "DeliveryDate").Value),
                    };
                    XElement ShipFromAddressElement = ShipFromElement.Element(ns + "Address");
                    Invoice.ShipFrom.Address = new Address
                    {
                        AddressDetail = ShipFromAddressElement.Element(ns + "AddressDetail").Value,
                        City = ShipFromAddressElement.Element(ns + "City").Value,
                        PostalCode = ShipFromAddressElement.Element(ns + "PostalCode").Value,
                        Country = ShipFromAddressElement.Element(ns + "Country").Value,
                    };

                    XElement DocumentTotalsElement = InvoiceElement.Element(ns + "DocumentTotals");
                    Invoice.DocumentTotals = new DocumentTotals
                    {
                        GrossTotal = float.Parse(DocumentTotalsElement.Element(ns + "GrossTotal").Value),
                        NetTotal = float.Parse(DocumentTotalsElement.Element(ns + "NetTotal").Value),
                        TaxPayable = float.Parse(DocumentTotalsElement.Element(ns + "TaxPayable").Value),
                    };

                    XElement WithholdingTaxElement = InvoiceElement.Element(ns + "WithholdingTax");
                    Invoice.WithholdingTax = new WithholdingTax
                    {
                        WithholdingTaxAmount = float.Parse(WithholdingTaxElement.Element(ns + "WithholdingTaxAmount").Value),
                    };

                    IEnumerable<XElement> LineElements = InvoiceElement.Elements(ns + "Line");
                    foreach (var LineElement in LineElements)
                    {
                        InvoiceLine Line = new InvoiceLine
                        {
                            LineNumber = int.Parse(LineElement.Element(ns + "LineNumber").Value),
                            ProductCode = LineElement.Element(ns + "ProductCode").Value,
                            ProductDescription = LineElement.Element(ns + "ProductDescription").Value,
                            Quantity = int.Parse(LineElement.Element(ns + "Quantity").Value),
                            UnitOfMeasure = LineElement.Element(ns + "UnitOfMeasure").Value,
                            UnitPrice = float.Parse(LineElement.Element(ns + "UnitPrice").Value),
                            TaxPointDate = DateTime.Parse(LineElement.Element(ns + "TaxPointDate").Value),
                            Description = LineElement.Element(ns + "Description").Value,
                            CreditAmount = float.Parse(LineElement.Element(ns + "CreditAmount").Value),
                            SettlementAmount = float.Parse(LineElement.Element(ns + "SettlementAmount").Value),
                        };

                        XElement TaxElement = LineElement.Element(ns + "Tax");
                        Line.Tax = new Tax
                        {
                            TaxCode = TaxElement.Element(ns + "TaxCode").Value,
                            TaxCountryRegion = TaxElement.Element(ns + "TaxCountryRegion").Value,
                            TaxPercentage = float.Parse(TaxElement.Element(ns + "TaxPercentage").Value),
                            TaxType = TaxElement.Element(ns + "TaxType").Value,
                        };

                        Invoice.Lines.Add(Line);
                    }

                    AuditFile.SourceDocuments.SalesInvoices.Invoices.Add(Invoice);
                }

                #endregion                

                Context.AuditFile.Add(AuditFile);           
                Context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, "Created audit file.");
            }
        }
    }
}
