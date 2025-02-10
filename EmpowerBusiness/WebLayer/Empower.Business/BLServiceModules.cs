using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Empower.Business.Account;
using Empower.Business.Email;
using Empower.Business.ManageOtp;
using Empower.Business.MyPreference;
using Empower.Business.Wallet;
using Empower.Data.Entities;
using Empower.Data.Repository;

namespace Empower.Business
{
    public class BLServiceModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            //business layers            
            builder.RegisterType<AccountBL>().As<IAccountBL>();
            builder.RegisterType<MyPreferenceBL>().As<IMyPreferenceBL>();
            builder.RegisterType<WalletBL>().As<IWalletBL>();            
            builder.RegisterType<EmailBL>().As<IEmailBL>();
            builder.RegisterType<OtpManagerBL>().As<IOtpManagerBL>();
            builder.RegisterType<UserRoleBL>().As<IUserRoleBL>();
            

            //entities
            builder.RegisterType<Repository<User>>().As<IRepository<User>>();            
            builder.RegisterType<Repository<UserDetail>>().As<IRepository<UserDetail>>();
            builder.RegisterType<Repository<CountryMaster>>().As<IRepository<CountryMaster>>();
            builder.RegisterType<Repository<CurrencyMaster>>().As<IRepository<CurrencyMaster>>();
            builder.RegisterType<Repository<MeasurementMaster>>().As<IRepository<MeasurementMaster>>();
            builder.RegisterType<Repository<UserPrefrence>>().As<IRepository<UserPrefrence>>();
            builder.RegisterType<Repository<UserRole>>().As<IRepository<UserRole>>();
            builder.RegisterType<Repository<UserRolePermission>>().As<IRepository<UserRolePermission>>();
            builder.RegisterType<Repository<Empower.Data.Entities.Wallet>>().As<IRepository<Empower.Data.Entities.Wallet>>();
            builder.RegisterType<Repository<OtpManager>>().As<IRepository<OtpManager>>();



        }
    }
}
