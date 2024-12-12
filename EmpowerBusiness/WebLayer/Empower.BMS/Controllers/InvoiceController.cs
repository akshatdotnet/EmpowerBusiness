using Empower.Web.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Empower.Web.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            // Sample invoice data
            var invoice = new Invoice
            {
                OrderNumber = "402-4087091-9229903",
                InvoiceNumber = "DEX8-11303",
                OrderDate = DateTime.Parse("2024-07-12"),
                InvoiceDate = DateTime.Parse("2024-07-12"),
                Description = "Realme 12 Pro 5G (8GB RAM, 256GB Storage)",
                UnitPrice = 21185.59M,
                Quantity = 1,
                TaxRate = 18M,
                TaxAmount = 3813.41M,
                TotalAmount = 24999.00M,
                BillingAddress = "VAISHNAV ENGINEERING, SURYA NAGAR, Mumbai, MH, 400083",
                ShippingAddress = "Block 146, 1st Floor, SurajTeahouse, MUMBAI, MAHARASHTRA, 400083",
                AmountInWords = "Twenty-four Thousand Nine Hundred Ninety-nine only"
            };

            return View(invoice);
        }

        public IActionResult GeneratePdf()
        {
            //var pdfPath = "wwwroot/invoice.pdf";
            //using (var writer = new PdfWriter(pdfPath))
            //{
            //    var pdf = new PdfDocument(writer);
            //    var document = new Document(pdf);

            //    // Add content to PDF
            //    document.Add(new Paragraph("Tax Invoice")
            //        .SetTextAlignment(TextAlignment.CENTER)
            //        .SetBold()
            //        .SetFontSize(20));

            //    document.Add(new Paragraph("Order Number: 402-4087091-9229903"));
            //    document.Add(new Paragraph("Invoice Number: DEX8-11303"));
            //    document.Add(new Paragraph("Order Date: 12-07-2024"));
            //    document.Add(new Paragraph("Invoice Date: 12-07-2024"));
            //    document.Add(new Paragraph("Description: Realme 12 Pro 5G (8GB RAM, 256GB Storage)"));
            //    document.Add(new Paragraph("Unit Price: ₹21,185.59"));
            //    document.Add(new Paragraph("Tax Rate: 18%"));
            //    document.Add(new Paragraph("Tax Amount: ₹3,813.41"));
            //    document.Add(new Paragraph("Total Amount: ₹24,999.00"));
            //    document.Add(new Paragraph("Amount in Words: Twenty-four Thousand Nine Hundred Ninety-nine only"));

            //    document.Close();
            //}

            return File("wwwroot/invoice.pdf", "application/pdf", "invoice.pdf");
        }

    }
}
