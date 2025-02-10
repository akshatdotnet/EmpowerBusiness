using iText.Html2pdf;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.CommonUtilities
{
    public class ConstantBL
    {
        public class EntityConstants
        {
            public const string AdminProducts = "AdminProducts";
            public const string Categories = "Categories";
            public const string SubCategoriesLanguageMapping = "SubCategoriesLanguageMapping";
            public const string CountryMasters = "CountryMasters";
            public const string ProductVariations = "ProductVariations";
            public const string ProductVariationsAttribute = "ProductVariationsAttribute";
            public const string MeasurementMasters = "MeasurementMasters";
            public const string SubCategories = "SubCategories";

        }
        public class ImportFileConstants
        {
            public const int FileHeaderPosition = 1;

        }
        public class CommonConstants
        {
            public const string RequiredField = "{0} field is required.";
            public const string MinCharLength = "The {0} must be at least of {1} characters long.";
            public const string MaxCharLength = "The {0} cannot exceed {1} characters.";
            public const string AlreadyExist = "{0} is already in use.";
            public const string NumericOnly = "{0} field must be numeric.";
            public const string AlphabatesOnly = "{0} field must be alphabate.";
            public const string AtleastOneFieldOnly = "Atleast one {0} is required.";
            public const string CombinationRequired = "{0} combination required.";
            public const string AddedSuccessFully = "{0} added successfully.";
            public const string UpdatedSuccessFully = "{0} updated successfully.";
            public const string DeletedSuccessfully = "{0} deleted successfully.";
            public const string ImportedSuccessFully = "{0} imported successfully.";
            public const string NotDeleteAssoiciatedRecord = "{0} is associated with {1}, Cannot delete a {2} which is associated with {3}";
            public const string ErrorOccured = "Error occured while {0}.";
            public const string FileUploadedSuccessFully = "{0} uploaded successfully.";
            public const string InvalidDecimal = "{0} field is invalid.";
            public const string AllowedImagextension = ".png, .svg, .jpg, .ico, .jpeg";
            public const string NotMapped = "{0} not mapped to {1}";
            public const int MaxProductImageCount = 8;
            public const string MaxCount = "Only {0} {1} are allowed";
            public const string AllowedRatingReviewMedia = ".png, .svg, .jpg, .ico, .jpeg, .mp4, .mov, .mkv";
            public const int ProductReviewTitleMaxLength = 150;
            public const int ProductReviewMaxLength = 4000;
            public const int ProductReviewCommentMaxLength = 128;
            public const int ProductReviewCommentMinLength = 2;
            public const int ProductReviewMaxFileLimit = 6;
            public const int ProductReviewMaxImageFileLimit = 4;
            public const int ProductReviewMaxVideoFileLimit = 2;
            public const string OfflineOrderSuccessMessage = "Thank you for your purchase, Customer Care will contact you for Delivery details.";
            public const int TransactionalNoteMaxLength = 256;
            public const int TransactionalNoteMinLength = 2;
            public const string VerifyOtpMessage = "Please enter {0} as a OTP to proceed {1}.";
            public const string CreateOrderVerifyOtpEmailSubject = "Create Order | Verification";
            public const string NotRegisteredUser = "{0} is not registered with us";
            public const string SmsSendtoUserAccount = "Enter {0} we just sent to {1}";
        }
        public class DefaultConstants
        {
            public const string DefaultImageName = "default.png";
            public const string DefaultLanguageCode = "en";
            public const string DefaultLanguageName = "English";
            public const string DefaultProductName = "191 OLD MILL ROAD";
            public const string DefaultProductShortDescription = "These signs are used to indicate the name of a particular street";
            public const string DefaultProdctFullDescription = "These signs are used to indicate the name of a particular street";
            public const decimal DefaultProductPrice = 134;
            public const string DefaultProductSearchTags = "Weather, chemical and abrasive resistant";
            public const decimal DefaultProductWeight = 2450;
            public const string DefaultProductSkuId = "G00020";
            public const int DefaultPageSize = 5;
            public const int IncompleteOrderDaysFlag = -5;
            public const string DefaultCountryCode = "UAE";
            public const string DefaultCountryName = "United Arab Emirates";
            public const string DefaultUniqueVariantId = "1001";

        }
        public class MedianDbConfigurationConstants
        {
            public const string ConnectionString = "Data source=localhost; initial catalog=gsignageECommerceQA; TrustServerCertificate=true; Trusted_Connection=True;";
            public const string GetMedianDbQuery = "Select * from MedianDb where IsActive=1";
            public const string UpdateMedianDbQuery = "Update MedianDb set IsActive=0 where IsActive=1";

        }
        public class ImportConstants
        {
            public const string ProductFileName = "ProductsSample.xlsx";
            public const string ProductDirectoryName = "ProductImportFiles";

        }
        public class EmailConstant
        {
            public const string PendingOrderSubject = "Order";
            public const string PendingOrderMessage = "Order Number is : {0} and order status is :{1}";
            public const string IncompleteOrderSubjectForAdmin = "Incomplete Order";
            public const string IncompleteOrderSubjectForCustomer = "Incomplete Order";
            public const string InTransitOrderMessage = "The following order {0} is in transit";
        }

        public class AdminConstant
        {
            public const string AdminIdBehalfOfCustomer = "AdminIdBehalfOfCustomer";
            public const string AdminUserUniqueId = "AdminUserUniqueId";

        }
        public class PaymentConstant
        {
            public const string Channel = "Web";
            public const string OrderName = "GSignagePayment";
            public const string ReturnPath = "https://{0}/Payment/PaymentAuthorization/{1}";
            public const string TransactionHint = "CPT:Y;VCC:N;";
            public const string CollectGSignagePaymentUrl = "https://{0}/Collect/Index/{1}";
            public const string CustomerPortalUrl = "{0}/Collect/Index/{1}";
            public const string TrackOrderURL = "https://{0}/TrackOrders/TrackOrdersidList";
            public const string TrackOrderURLGuestUser = "https://{0}/TrackOrders/OrderStatus";
            public const string AdminTrackOrderURL = "{0}/TrackOrders/TrackOrdersidList";
            public const string ProductReviewURL = "{0}/MyOrders/Index";

        }
        public class EmailTypeConstants
        {
            public const string CancelledOrder = "CancelledOrder";
            public const string CollectPayment = "CollectPayment";
            public const string CompletedOrder = "CompletedOrder";
            public const string IncompleteOrder = "IncompletedOrder";
            public const string InTransitOrder = "InTransitOrder";
            public const string OfflineOrder = "OfflineOrder";
            public const string OrderPriceChange = "OrderPriceChange";
            public const string SendInvoice = "SendInvoice";
            public const string SendVerificationCode = "SendVerificationCode";
            public const string SendWelcomeEmailToNewAddedAdminUser = "SendWelcomeEmailToNewAddedAdminUser";
            public const string RefundToWallet = "RefundToWallet";
            public const string OrderConfirmation = "OrderConfirmation";
            public const string PaymentStatusFailed = "PaymentStatusFailed";
            public const string WalletDebited = "WalletDebited";
            public const string IncompleteOrderNotification = "IncompleteOrderNotification";
            public const string SendOrderConfirmationWithInvoiceAttachment = "SendOrderConfirmationWithInvoiceAttachment";
        }

        public class WalletConstants
        {
            public const string WalletUsageNote = "Debited for Order Number {0}";

        }
        public class EmailSubjectConstants
        {
            public const string CancelledOrderSubject = "Order Cancelled";
            public const string CollectPaymentSubject = "Create Order";
            public const string CompletedOrderSubject = "Order Delivered";
            public const string IncompleteOrderSubject = "Incomplete Orders";
            public const string InTransitOrderSubject = "Order in transit";
            public const string OfflineOrderSubject = "Large Order";
            public const string OrderPriceChangeSubject = "Order Status change";
            public const string SendInvoiceSubject = "Invoice For Order {0}";
            public const string SendWelcomeEmailToNewAddedAdminUser = "Your Login Detail";
            public const string RefundToWalletSubject = "The amount (funds) have been credited to your wallet.";
            public const string OrderConfirmationSubject = "Payment Success!";
            public const string PaymentStatusFailedSubject = "Payment failed!";
            public const string WalletDebitedSubject = "Please be advised that the following amount (funds) have been debited from your wallet.";
            public const string IncompleteOrderNotificationSubject = "Incomplete Orders";

        }
        public class EmailTemplatePathConstants
        {
            public const string CancelledOrderTemplatePath = "HtmlTemplates/CancelledOrderTemplate.html";
            public const string CollectPaymentTemplatePath = "HtmlTemplates/CollectPaymentTemplate.html";
            public const string CompletedOrderTemplatePath = "HtmlTemplates/CompletedOrderTemplate.html";
            public const string IncompleteOrderTemplatePath = "HtmlTemplates/IncompleteOrderTemplateForCustomer.html";
            public const string InTransitOrderTemplatePath = "HtmlTemplates/InTransitOrderTemplate.html";
            public const string OfflineOrderTemplatePath = "HtmlTemplates/OfflineOrderTemplate.html";
            public const string OrderPriceChangeTemplatePath = "HtmlTemplates/OrderPriceChangeTemplate.html";
            public const string SendInvoiceTemplatePath = "HtmlTemplates/InvoiceTemplate.html";
            public const string SendCreateOrderVerificationCodePath = "HtmlTemplates/CreateOrderVerificationCodes.html";
            public const string SendWelcomeEmailToNewAddedAdminUser = "HtmlTemplates/SendWelcomeEmailToNewAddedAdminUser.html";
            public const string SendOTPTemplate = "HtmlTemplates/SendOTPTemplate.html";
            public const string RefundToWalletTemplate = "HtmlTemplates/RefundToWalletTemplate.html";
            public const string OrderConfirmationTemplate = "HtmlTemplates/OrderConfirmationTemplate.html";
            public const string PaymentStatusFailedTemplate = "HtmlTemplates/PaymentFailedTemplate.html";
            public const string WalletDebitedTemplate = "HtmlTemplates/WalletDebitTemplate.html";
            public const string IncompleteOrderNotificationTemplate = "HtmlTemplates/IncompleteOrderNotificationTemplate.html";
            public const string SendInvoiceEmailBodyTemplate = "HtmlTemplates/SendInvoiceTemplate.html";

        }
        public class SmsTypeConstants
        {
            public const string CancelledOrder = "CancelledOrder";
            public const string CollectPayment = "CollectPayment";
            public const string CompletedOrder = "CompletedOrder";
            public const string IncompleteOrder = "IncompletedOrder";
            public const string InTransitOrder = "InTransitOrder";
            public const string OfflineOrder = "OfflineOrder";
            public const string OrderPriceChange = "OrderPriceChange";
            public const string OrderConfirmation = "OrderConfirmation";
        }
        public class SmsTemplatePathConstants
        {
            public const string CancelledOrderTemplatePath = "HtmlTemplates/CancelledOrderTemplate.txt";
            public const string CollectPaymentTemplatePath = "HtmlTemplates/CollectPaymentTemplate.txt";
            public const string CompletedOrderTemplatePath = "HtmlTemplates/CompletedOrderTemplate.txt";
            public const string IncompleteOrderTemplatePath = "HtmlTemplates/IncompleteOrderTemplateForCustomer.txt";
            public const string InTransitOrderTemplatePath = "HtmlTemplates/InTransitOrderTemplate.txt";
            public const string OfflineOrderTemplatePath = "HtmlTemplates/OfflineOrderTemplate.txt";
            public const string OrderPriceChangeTemplatePath = "HtmlTemplates/OrderPriceChangeTemplate.txt";
            public const string OrderConfirmationTemplatePath = "HtmlTemplates/OrderConfirmationTemplate.txt";

        }

        public static byte[] ConvertHtmlTextToPDF(string htmlContent)
        {
            var workStream = new MemoryStream();
            ConverterProperties properties = new ConverterProperties();

            using (var pdfWriter = new PdfWriter(workStream))
            {
                pdfWriter.SetCloseStream(false);
                HtmlConverter.ConvertToPdf(htmlContent, pdfWriter, properties);
            }

            workStream.Position = 0;
            return workStream.ToArray();
        }
    }
}
