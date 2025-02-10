using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.CommonUtilities
{
    public class EnumBL
    {
        public enum DefaultVriations
        {
            Shape = 1,
            Orientation = 2,
            Size = 3
        }
        public enum DefaultAttribute
        {
            [Description("Rectaangular")]
            Rectangular = 1,
            [Description("Circular")]
            Circular = 2,
            [Description("600mm Dia")]
            Dia = 3
        }


        public enum ProductFormField
        {
            [Description("Id(*)")]
            Id = 1,
            [Description("Product Name(*)")]
            ProductName = 2,
            [Description("Sku Id(*)")]
            SkuId = 3,
            [Description("Product Category(*)")]
            ProductCategory = 4,
            [Description("Product Sub Category(*)")]
            ProductSubCategory = 5,
            [Description("Short Description(*)")]
            ShortDescription = 6,
            FullDescription = 7,
            ShowOnHomepage = 8,
            AllowCustomerReviews = 9,
            [Description("Price(*)")]
            Price = 10,
            ProductSearchTag = 11,
            [Description("Country(*)")]
            Country = 12,
            SimilarProduct = 13,
            FeaturedProduct = 14,
            Published = 15,
            [Description("Image Path(*)")]
            ImagePath = 16,
            [Description("Weight(*)")]
            Weight = 17,
            [Description("ar_Product Name(*)")]
            ar_ProductName = 18,
            [Description("ar_Short Description(*)")]
            ar_ShortDescription = 19,
            [Description("de_Product Name(*)")]
            de_ProductName = 20,
            [Description("de_Short Description(*)")]
            de_ShortDescription = 21,
            [Description("es_Product Name(*)")]
            es_ProductName = 22,
            [Description("es_Short Description(*)")]
            es_ShortDescription = 23,
            [Description("fr_Product Name(*)")]
            fr_ProductName = 24,
            [Description("fr_Short Description(*)")]
            fr_ShortDescription = 25,
            [Description("in_Product Name(*)")]
            in_ProductName = 26,
            [Description("in_Short Description(*)")]
            in_ShortDescription = 27,
            [Description("ur_Product Name(*)")]
            ur_ProductName = 28,
            [Description("ur_Short Description(*)")]
            ur_ShortDescription = 29,
            [Description("zh_Product Name(*)")]
            zh_ProductName = 30,
            [Description("zh_Short Description(*)")]
            zh_ShortDescription = 31,
            [Description("ar_Full Description(*)")]
            ar_FullDescription = 32,
            [Description("de_Full Description(*)")]
            de_FullDescription = 33,
            [Description("es_Full Description(*)")]
            es_FullDescription = 34,
            [Description("fr_Full Description(*)")]
            fr_FullDescription = 35,
            [Description("in_Full Description(*)")]
            in_FullDescription = 36,
            [Description("ur_Full Description(*)")]
            ur_FullDescription = 37,
            [Description("zh_Full Description(*)")]
            zh_FullDescription = 38,
            [Description("Unique Variant Id(*)")]
            UniqueVariantId = 39,
        }

        public enum FileExtensionType
        {
            [Description(".xls")]
            Xls = 1,
            [Description(".xlsx")]
            Xlsx = 2,
            [Description(".csv")]
            Csv = 3
        }
        public enum RecordAddedSorceType
        {
            [Description("Form")]
            Form = 1,
            [Description("Excel")]
            Excel = 2,
            [Description("Csv")]
            Csv = 3,
            [Description("Median Db")]
            MedianDb = 4

        }
        public enum OrderType
        {
            [Description("Online")]
            Online = 1,
            [Description("Offline")]
            Offline = 2

        }
        public enum RequestType
        {
            [Description("Save")]
            Save = 1,
            [Description("Edit")]
            Edit = 2,
            [Description("Update")]
            Update = 3,
            [Description("Delete")]
            Delete = 4,
            [Description("List")]
            List = 5


        }
        public enum PaymentStatus
        {
            [Description("Pending")]
            Pending = 1,
            [Description("Paid")]
            Paid = 2,
            [Description("Refunded")]
            Refunded = 3,
            [Description("Fail")]
            Fail = 4,
        }
        public enum OrderStatus
        {
            [Description("Pending")]
            Pending = 1,
            [Description("Placed")]
            Placed = 2,
            [Description("Processing")]
            Processing = 3,
            [Description("In Transit")]
            InTransit = 4,
            [Description("Completed")]
            Completed = 5,
            [Description("Cancelled")]
            Cancelled = 6,
            [Description("Refunded")]
            Refunded = 7
        }
        public enum RoleType
        {
            [Description("Admin")]
            Admin = 1,

        }

        public enum TransactionType
        {
            Credit = 1,
            Debit = 2
        }

        public enum UserInputType
        {
            Mobile = 1,
            Email = 2,
        }
        public enum CollectPaymentOrderType
        {
            [Description("New Order")]
            NewOrder = 1,
            [Description("Edit Order")]
            EditOrder = 2

        }

        public enum PaymentMethod
        {
            [Description("None")]
            None = 0,
            [Description("Card")]
            Card = 1,
            [Description("Wallet")]
            Wallet = 2,
            [Description("Wallet/Card")]
            WalletAndCard = 3,
            [Description("Wallet/Payment Link Sent")]
            WalletAndPaymentLink = 4
        }
    }
}
