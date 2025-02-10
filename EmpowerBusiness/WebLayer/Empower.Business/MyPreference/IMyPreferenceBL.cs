using Empower.Models.MyPreference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.MyPreference
{
    public interface IMyPreferenceBL
    {
        Task<MyPreferenceInsertOutputDTO> InsertUpdatePreference(MyPreferenceInputDTO input);
        Task<MyPreferenceDTO?> GetPreferenceByUserId(int userId);
        Task<MyPreferenceInsertOutputDTO> InsertUpdatePreferredLanguage(int userId, string languageCode);
        Task<MyPreferenceDTO> GetDefaultPreference();
        Task<MyPreferenceCountryDTO?> GetPreferredCountry(int id);

    }
}
