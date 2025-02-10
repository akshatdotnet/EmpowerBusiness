using Empower.Business.CommonUtilities;
using Empower.Models.Account;
using Empower.Models.AppSettings;
using Empower.Models.Email;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Empower.Business.CommonUtilities.ConstantBL;

namespace Empower.Business.Email
{
    internal class EmailBL : IEmailBL
    {
        private readonly EmailSetting _emailSetting;
        private readonly IWebHostEnvironment _hostingEnvironment;
        string webRootPath;

        public EmailBL(IOptions<EmailSetting> emailSetting, IWebHostEnvironment hostingEnvironment)
        {
            _emailSetting = emailSetting.Value;
            _hostingEnvironment = hostingEnvironment;
            webRootPath = _hostingEnvironment.WebRootPath;
        }

        public async Task<MailRequestOutputDTO> SendCommonEmail(MailRequestInputDTO mailRequestInputDto)
        {
            try
            {
                if (!string.IsNullOrEmpty(mailRequestInputDto.EmailTemplatePath))
                {
                    string filePath = System.IO.Path.Combine(webRootPath, mailRequestInputDto.EmailTemplatePath ?? "");
                    string htmlContent = System.IO.File.ReadAllText(filePath);
                    if (mailRequestInputDto.MailType == EmailTypeConstants.SendOrderConfirmationWithInvoiceAttachment)
                    {
                        mailRequestInputDto.MailType = EmailTypeConstants.OrderConfirmation;
                        mailRequestInputDto.HtmlContent = htmlContent;
                        htmlContent = ReplaceHtmlTemplateContent(mailRequestInputDto);
                        string sendInvoiceTemp = System.IO.Path.Combine(webRootPath, ConstantBL.EmailTemplatePathConstants.SendInvoiceTemplatePath);
                        mailRequestInputDto.MailType = EmailTypeConstants.SendInvoice;
                        var sendInvoiceBody = System.IO.File.ReadAllText(sendInvoiceTemp);
                        mailRequestInputDto.HtmlContent = sendInvoiceBody;
                        sendInvoiceBody = ReplaceHtmlTemplateContent(mailRequestInputDto);
                        mailRequestInputDto.MailType = EmailTypeConstants.SendOrderConfirmationWithInvoiceAttachment;
                    }
                    else
                    {
                        mailRequestInputDto.HtmlContent = htmlContent;
                        htmlContent = ReplaceHtmlTemplateContent(mailRequestInputDto);
                    }
                    if (mailRequestInputDto.MailType == EmailTypeConstants.SendInvoice)
                    {
                        string sendInvoiceBody = System.IO.Path.Combine(webRootPath, ConstantBL.EmailTemplatePathConstants.SendInvoiceEmailBodyTemplate);
                        htmlContent = System.IO.File.ReadAllText(sendInvoiceBody);
                        htmlContent = htmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        htmlContent = htmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                    }
                    await SendEmail(new MailRequestInputDTO()
                    {
                        Subject = mailRequestInputDto.Subject,
                        ToEmail = mailRequestInputDto.ToEmail,
                        Body = htmlContent,
                        Attachments = mailRequestInputDto.Attachments
                    });
                    return new MailRequestOutputDTO() { IsError = false, ErrorMessage = string.Empty };
                }
                else
                {
                    return new MailRequestOutputDTO() { IsError = true, ErrorMessage = "Template path not found" };
                }
            }
            catch (Exception ex)
            {
                return new MailRequestOutputDTO() { IsError = true, ErrorMessage = ex.Message };
            }

        }

        private string ReplaceHtmlTemplateContent(MailRequestInputDTO mailRequestInputDto)
        {
            if (mailRequestInputDto != null)
            {
                switch (mailRequestInputDto.MailType)
                {
                    case EmailTypeConstants.CancelledOrder:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##Reason##", mailRequestInputDto.CancelReason);
                        break;

                    case EmailTypeConstants.CollectPayment:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##CollectPaymentLink##", mailRequestInputDto.CollectPaymentLink);
                        break;

                    case EmailTypeConstants.CompletedOrder:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##ProductReviewLink##", mailRequestInputDto.ProductReviewLink);
                        break;

                    case EmailTypeConstants.IncompleteOrder:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                        break;

                    case EmailTypeConstants.InTransitOrder:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##TrackingNumber##", mailRequestInputDto.TrackingNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                        break;

                    case EmailTypeConstants.OfflineOrder:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                        break;

                    case EmailTypeConstants.OrderPriceChange:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                        break;
                    case EmailTypeConstants.SendInvoice:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##FullName##", mailRequestInputDto.FullName);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##AddressLine1##", mailRequestInputDto.AddressLine1);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##AddressLine2##", mailRequestInputDto.AddressLine2);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##Region##", mailRequestInputDto.Region);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##City##", mailRequestInputDto.City);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##Country##", mailRequestInputDto.Country);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##ZipCode##", mailRequestInputDto.ZipCode);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##InvoiceDate##", mailRequestInputDto.InvoiceDate);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##TotalPayable##", mailRequestInputDto.OrderTotal);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderDate##", mailRequestInputDto.OrderDate);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##ShippingRate##", mailRequestInputDto.ShippingRate);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##VatPercentage##", mailRequestInputDto.VatPercentage);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##TotalVatAmount##", mailRequestInputDto.TotalVatAmount);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderSubTotal##", mailRequestInputDto.OrderSubTotal);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##BillingAddressFullName##", mailRequestInputDto.BillingAddress.AddressFullName);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##BillingAddressLine1##", mailRequestInputDto.BillingAddress.AddressLine1);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##BillingAddressLine2##", mailRequestInputDto.BillingAddress.AddressLine2);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##BillingRegion##", mailRequestInputDto.BillingAddress.Region);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##BillingCity##", mailRequestInputDto.BillingAddress.City);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##BillingCountry##", mailRequestInputDto.BillingAddress.Country);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##BillingZipCode##", mailRequestInputDto.BillingAddress.ZipCode);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##ShippingAddressFullName##", mailRequestInputDto.ShippingAddrss.AddressFullName);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##ShippingAddressLine1##", mailRequestInputDto.ShippingAddrss.AddressLine1);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##ShippingAddressLine2##", mailRequestInputDto.ShippingAddrss.AddressLine2);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##ShippingRegion##", mailRequestInputDto.ShippingAddrss.Region);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##ShippingCity##", mailRequestInputDto.ShippingAddrss.City);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##ShippingCountry##", mailRequestInputDto.ShippingAddrss.Country);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##ShippingZipCode##", mailRequestInputDto.ShippingAddrss.ZipCode);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##WalletAmount##", mailRequestInputDto.WalletDebitedAmount);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNo##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrederSubToal##", mailRequestInputDto.OrderSubTotal);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##VatPerCentage##", mailRequestInputDto.VatPercentage);

                        var purchasedItemsTR = string.Empty;
                        foreach (var item in mailRequestInputDto.PurchasedItem)
                        {
                            var purchssedItemTR = string.Format(@"<tr><td scope='row'>
                            {0}</td> <td>{1}</td> <td> {2} </td> <td> {3}</td>
                            <td> {4} </td><td> {5} </td></tr>", item.ProductName, item.Quantity, item.UnitPrice, item.VatRate, item.UnitVatAmount, item.SubTotal);
                            purchasedItemsTR += purchssedItemTR;
                        }
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderItemsTR##", purchasedItemsTR);

                        var file = ConstantBL.ConvertHtmlTextToPDF(mailRequestInputDto.HtmlContent);
                        var stream = new MemoryStream(file);
                        IFormFile formFile = new FormFile(stream, 0, file.Length, "name", $"Invoice-{DateTime.UtcNow.ToString("dd-MM-yyyy-h:mm-tt")}.pdf")
                        {
                            Headers = new HeaderDictionary(),
                            ContentType = "application/pdf",
                        };
                        mailRequestInputDto.Attachments = new List<IFormFile> { formFile };

                        break;
                    case EmailTypeConstants.SendVerificationCode:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##VerificationCode##", mailRequestInputDto.VerificationCode);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##VerificationReason##", mailRequestInputDto.VerificationReason);
                        break;
                    case EmailTypeConstants.SendWelcomeEmailToNewAddedAdminUser:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##Email##", mailRequestInputDto.Email);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##Password##", mailRequestInputDto.Password);
                        break;
                    case EmailTypeConstants.RefundToWallet:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##TansactionId##", mailRequestInputDto.TransactionId);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##RefundAmount##", mailRequestInputDto.RefundAmount);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##TransactionNote##", mailRequestInputDto.TransactionNote);
                        break;
                    case EmailTypeConstants.OrderConfirmation:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##TransactionId##", mailRequestInputDto.TransactionId);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##TrackingURL##", mailRequestInputDto.TrackingURL);
                        break;
                    case EmailTypeConstants.PaymentStatusFailed:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##TransactionId##", mailRequestInputDto.TransactionId);
                        break;
                    case EmailTypeConstants.WalletDebited:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderNumber##", mailRequestInputDto.OrderNumber);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DateTime##", DateTime.UtcNow.ToGlobalDateFormat());
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##TransactionId##", mailRequestInputDto.TransactionId);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##DebitAmount##", mailRequestInputDto.WalletDebitedAmount);
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##CurrencyCode##", mailRequestInputDto.CurrencyCode);
                        break;

                    case EmailTypeConstants.IncompleteOrderNotification:
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##UserName##", mailRequestInputDto.UserName);
                        var orderMessage = string.Empty;
                        foreach (var order in mailRequestInputDto.Orders)
                        {
                            var message = "Order Number :" + order.OrderNumber + "  Order Total : " + order.OrderTotal +
                                  "<br/>";
                            orderMessage += message;
                        }
                        mailRequestInputDto.HtmlContent = mailRequestInputDto.HtmlContent.Replace("##OrderDetail##", orderMessage);
                        break;

                    default:
                        break;
                }
            }
            return mailRequestInputDto?.HtmlContent ?? "";
        }

        /// <summary>
        /// Send user credential details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MailRequestOutputDTO> SendCustomerCredentialMail(SignUpInputDTO model)
        {
            try
            {
                string webRootPath = _hostingEnvironment.ContentRootPath;
                // Replace backslashes with forward slashes
                string normalizedPath = webRootPath.Replace("\\", "/");                
                string filePath = normalizedPath + "/HtmlTemplates/SendLoginCredentialTemplate.html";                
                string htmlContent = System.IO.File.ReadAllText(filePath);
                htmlContent = htmlContent.Replace("##Name##", $"{model.FirstName} {model.LastName}");
                htmlContent = htmlContent.Replace("##UserName##", model.EmailId);
                htmlContent = htmlContent.Replace("##Password##", model.Password);
                await SendEmail(new MailRequestInputDTO()
                {
                    Subject = "Login Credentials",
                    ToEmail = model.EmailId,
                    Body = htmlContent
                });
                return new MailRequestOutputDTO() { IsError = false, ErrorMessage = string.Empty };
            }
            catch (Exception exception)
            {

                return new MailRequestOutputDTO()
                {
                    IsError = true,
                    ErrorMessage = exception.Message
                };
            }
        }

        public async Task<SendOtpToEmailOutputDTO> SendEmailSignUpOtp(int otp, string email)
        {
            try
            {
                string subject = "Email Verification";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string filePath = System.IO.Path.Combine(webRootPath, "HtmlTemplates/SendEmailSignUpOtpTemplate.html");
                string htmlContent = System.IO.File.ReadAllText(filePath);
                htmlContent = htmlContent.Replace("##otp##", otp.ToString());
                await SendEmail(new MailRequestInputDTO()
                {
                    Subject = subject,
                    ToEmail = email,
                    Body = htmlContent
                });
                return new SendOtpToEmailOutputDTO() { IsOtpSent = true, ErrorMessage = string.Empty, };
            }
            catch (Exception exception)
            {

                return new SendOtpToEmailOutputDTO()
                {
                    IsOtpSent = false,
                    ErrorMessage = exception.Message
                };
            }
        }

        /// <summary>
        /// Send mail with token to reset password
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="callBackUrl"></param>
        /// <returns></returns>
        public async Task<MailRequestOutputDTO> SendUserResetPasswordEmail(string toEmail, string callBackUrl)
        {
            //var message = "To reset your password please" + $" <a href='{callBackUrl}'>click here.</a>";
            //Send Email
            string webRootPath = _hostingEnvironment.WebRootPath;
            string filePath = System.IO.Path.Combine(webRootPath, "HtmlTemplates/SendResetPasswordLinkTemplate.html");
            string htmlContent = System.IO.File.ReadAllText(filePath);
            htmlContent = htmlContent.Replace("##URL##", callBackUrl);
            try
            {
                await SendEmail(new MailRequestInputDTO()
                {
                    Subject = "Reset Password",
                    ToEmail = toEmail,
                    Body = htmlContent
                });
                return new MailRequestOutputDTO() { IsError = false, ErrorMessage = string.Empty };
            }
            catch (Exception ex)
            {
                return new MailRequestOutputDTO() { IsError = true, ErrorMessage = ex.Message };
            }

        }




        /// <summary>
        /// Send Email By MailKit SMTP
        /// </summary>
        /// <param name="mailRequest">Model</param>
        /// <returns></returns>
        private async Task<string> SendEmail(MailRequestInputDTO mailRequest)
        {
            var message = "";
            MimeMessage email = new()
            {
                Sender = MailboxAddress.Parse(_emailSetting.SenderEmailId)                
            };
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));            
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(_emailSetting.SmtpHost, _emailSetting.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailSetting.SenderEmailId, _emailSetting.SmtpPassword);                
                message = await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            return message;
        }


    }
}
