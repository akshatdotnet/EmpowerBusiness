using Empower.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Data.EntityFrameworkCore
{
    public class EPowerDbContext : DbContext
    {
        public EPowerDbContext(DbContextOptions<EPowerDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<CountryMaster> CountryMasters { get; set; }
        public DbSet<CurrencyMaster> CurrencyMasters { get; set; }
        public DbSet<MeasurementMaster> MeasurementMasters { get; set; }
        public DbSet<UserPrefrence> UserPrefrences { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserRolePermission> UserRolePermissions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<OtpManager> OtpManagers { get; set; }



    }
}
