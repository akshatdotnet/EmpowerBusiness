using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models.Email
{
    public class MailRequestInputDTO
    {
        public string? ToEmail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? CallBackUrl { get; set; }
        public string? MailType { get; set; }
        public string HtmlContent { get; set; } = string.Empty;
        public string? OrderNumber { get; set; }
        public string? EmailTemplatePath { get; set; }
        public string? TrackingNumber { get; set; }
        public string? CollectPaymentLink { get; set; }
        public string? FullName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? OrderDate { get; set; }
        public string InvoiceDate { get; set; } = string.Empty;
        public string VerificationCode { get; set; } = string.Empty;
        public string? VerificationReason { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? TransactionId { get; set; }
        public string? TransactionNote { get; set; }
        public string? TrackingURL { get; set; }
        public string? RefundAmount { get; set; }
        public string? ProductReviewLink { get; set; }
        public string? WalletDebitedAmount { get; set; }
        public string? CurrencyCode { get; set; }
        public string OrderTotal { get; set; } = string.Empty;
        public string ShippingRate { get; set; } = string.Empty;
        public string VatPercentage { get; set; } = string.Empty;
        public string OrderSubTotal { get; set; } = string.Empty;
        public string TotalVatAmount { get; set; } = string.Empty;
        public AddressInputDTO BillingAddress { get; set; } = new();
        public AddressInputDTO ShippingAddrss { get; set; } = new();

        public List<OrdersInputDto> Orders { get; set; } = new();
        public string UserName { get; set; } = string.Empty;
        public string CancelReason { get; set; } = string.Empty;

        public List<PurchasedItemInputDTO> PurchasedItem { get; set; } = new();
        public List<IFormFile>? Attachments
        {
            get; set;
        }
    }

    public class PurchasedItemInputDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public string UnitVatAmount { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty;
        public string UnitPrice { get; set; } = string.Empty;
        public string VatRate { get; set; } = string.Empty;
        public string SubTotal { get; set; } = string.Empty;

    }
    public class AddressInputDTO
    {
        public string AddressFullName { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }

    public class OrdersInputDto
    {
        public string OrderNumber { get; set; } = string.Empty;
        public string OrderTotal { get; set; } = string.Empty;
    }
}
