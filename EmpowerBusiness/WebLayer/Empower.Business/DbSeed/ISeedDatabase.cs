using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.DbSeed
{
    public interface ISeedDatabase
    {
        Task SeedMasterData();
    }
}
