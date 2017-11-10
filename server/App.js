const fs = require('fs');
const xml2js = require('xml2js');

const express = require('express');
const cors = require('cors');

const app = express();
app.use(cors());

const readAuditFile = (filepath) => {
  const content = fs.readFileSync(filepath).toString();
  const parser = new xml2js.Parser();
  
  let auditFile;
  const doc = parser.parseString(content, (err, data) => {
    if (err) throw err;
    auditFile = data.AuditFile;
  });
  return auditFile;
}

const auditFile = readAuditFile('../SAFT-T.xml');

app.get('/api/start-date', (req, res) => {
  res.json(getStartDate(auditFile));
});

app.get('/api/end-date', (req, res) => {
  res.json(getEndDate(auditFile));
});

app.get('/api/total-sales', (req, res) => {
  res.json(getTotalSales(auditFile));
});

app.get('/api/sales-invoices', (req, res) => {
  res.json(getSalesInvoices(auditFile));
});

app.get('/api/average-sale-value', (req, res) => {
  res.json(getAverageSaleValue(auditFile));
});

app.listen(3000, () => console.log('Server listening on port 3000...'));

const getStartDate = (auditFile) => {
  const header = auditFile.Header[0];
  const startDate = header.StartDate[0];
  return {
    startDate,
  };
}

const getEndDate = (auditFile) => {
  const header = auditFile.Header[0];
  const endDate = header.EndDate[0];
  return {
    endDate,
  };
}

const getTotalSales = (auditFile) => {
  const sourceDocuments = auditFile.SourceDocuments[0];
  const salesInvoices = sourceDocuments.SalesInvoices[0];
  
  const totalNumber = salesInvoices.NumberOfEntries[0];
  const totalValue = salesInvoices.TotalCredit[0];
    
  return {
    totalNumber,
    totalValue,
  }
}

const getSalesInvoices = (auditFile) => {
  const sourceDocuments = auditFile.SourceDocuments[0];
  const salesInvoices = sourceDocuments.SalesInvoices[0];
  return salesInvoices.Invoice;
}

const getAverageSaleValue = (auditFile) => {
  const sourceDocuments = auditFile.SourceDocuments[0];
  const salesInvoices = sourceDocuments.SalesInvoices[0];
  
  const totalNumber = salesInvoices.NumberOfEntries[0];
  const totalValue = salesInvoices.TotalCredit[0];
  const average = totalValue / totalNumber;
  return {
    average,
  };
}
