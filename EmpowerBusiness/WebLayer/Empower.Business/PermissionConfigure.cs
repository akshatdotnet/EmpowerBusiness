using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business
{
    public static class PermissionConfigure
    {
        /// <summary>
        /// Define Admin System Module and Controller name
        /// </summary> 
        public static List<PermissionModule> GetSystemModules(bool isAdminUser)
        {
            List<PermissionModule> modules = new()
            {
                new PermissionModule(name : "Dashboard",controller : "Dashboard"),
            };
            if (isAdminUser)
            {
                //Only Allowed to Admin User
                modules.AddRange(new List<PermissionModule>()
                {
                    new PermissionModule(name : "Users",controller : "ManageUser"),
                    new PermissionModule(name : "Roles",controller : "ManageRole"),
                    new PermissionModule(name : "Access Permissions", controller : "ManageRolePermission")
                });
            }
            modules.AddRange(new List<PermissionModule>()
            {
                new PermissionModule(name : "Categories",controller : "Category"),
                new PermissionModule(name : "Sub Categories",controller : "SubCategory"),
                new PermissionModule(name : "Products",controller : "Product"),
                new PermissionModule(name : "Product Review",controller : "ProductReview"),
                new PermissionModule(name : "Product Variations",controller : "ProductVariationsMaster"),
                new PermissionModule(name : "Featured Product",controller : "FeaturedProduct"),
                new PermissionModule(name : "Customers", controller : "ManageCustomer"),
                new PermissionModule(name : "Orders", controller : "Order"),
                new PermissionModule(name : "Shipping", controller : "Shipping"),
                new PermissionModule(name : "Country", controller : "ManageCountryMaster"),
                new PermissionModule(name : "Currency", controller : "ManageCurrencyMaster"),
                new PermissionModule(name : "Measurement", controller : "ManageMeasurementMaster"),
                new PermissionModule(name : "VAT", controller : "ManageVatMaster"),
                new PermissionModule(name : "Content Management", controller : "CMS"),
                new PermissionModule(name : "Wallet", controller : "Wallet"),
                //new AdminPermissionModule(name : "Import Product Details", controller : "ImportProductDetails"),
            });
            return modules;
        }
        public sealed class PermissionModule
        {
            public PermissionModule(string name, string controller)
            {
                this.Name = name;
                this.Controller = controller;
            }
            public string Name { get; private set; }
            public string Controller { get; private set; }
        }
    }
}
