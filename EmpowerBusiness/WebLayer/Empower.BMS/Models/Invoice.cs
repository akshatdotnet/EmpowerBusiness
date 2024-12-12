namespace Empower.Web.Models
{
    public class Invoice
    {
        public string OrderNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string AmountInWords { get; set; }
    }
}
