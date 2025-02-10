using Empower.Data.Entities;
using Empower.Data.Repository;
using Empower.Models.Constants;
using Empower.Models.MyPreference;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.MyPreference
{
    public class MyPreferenceBL : IMyPreferenceBL
    {
        private readonly IRepository<UserPrefrence> _preference;
        private readonly IRepository<CountryMaster> _countryMaster;
        private readonly IRepository<CurrencyMaster> _currencyMaster;
        private readonly IRepository<MeasurementMaster> _measurementMaster;

        public MyPreferenceBL(
        IRepository<UserPrefrence> preference,
        IRepository<CountryMaster> countryMaster,
        IRepository<CurrencyMaster> currencyMaster,
        IRepository<MeasurementMaster> measurementMaster
        )
        {
            _preference = preference;
            _countryMaster = countryMaster;
            _currencyMaster = currencyMaster;
            _measurementMaster = measurementMaster;
        }

        public async Task<MyPreferenceDTO> GetDefaultPreference()
        {
            var defaultCurrency = await _currencyMaster.GetWhere(x => x.IsPrimary).FirstOrDefaultAsync();
            var defaultCountry = await _countryMaster.GetWhere(x => x.IsPrimary).FirstOrDefaultAsync();
            var defaultMeasurement = await _measurementMaster.GetWhere(x => x.IsPrimary).FirstOrDefaultAsync();
            return new MyPreferenceDTO()
            {
                CountryMasterId = defaultCountry != null ? defaultCountry.Id : 0,
                CurrencyMasterId = defaultCurrency != null ? defaultCurrency.Id : 0,
                MeasurementMasterId = defaultMeasurement != null ? defaultMeasurement.Id : 0,
                PreferredLanguage = GlobalConstants.DefaultLanguageCode,
                MeasurementName = defaultMeasurement != null ? defaultMeasurement.Name : ""
            };
        }

        public async Task<MyPreferenceDTO?> GetPreferenceByUserId(int userId)
        {
            var query = await _preference.GetWhere(x => x.UserId == userId && x.IsDeleted == false).FirstOrDefaultAsync();
            MyPreferenceDTO? MyPreferenceDTO = null;
            if (query != null)
            {
                MyPreferenceDTO = new MyPreferenceDTO()
                {
                    CountryMasterId = query.CountryMasterId ?? 0,
                    CurrencyMasterId = query.CurrencyMasterId ?? 0,
                    MeasurementMasterId = query.MeasurementMasterId ?? 0,
                    PreferredLanguage = query.PreferedLanguage ?? "",
                    MeasurementName = (await _measurementMaster.GetWhere(x => x.Id == (query.MeasurementMasterId ?? 0)).FirstOrDefaultAsync())?.Name ?? string.Empty
                };
            }
            return MyPreferenceDTO;
        }

        public async Task<MyPreferenceCountryDTO?> GetPreferredCountry(int id)
        {
            var defaultCountry = await _countryMaster.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
            if (defaultCountry != null)
            {
                return new MyPreferenceCountryDTO()
                {
                    CountryMasterId = defaultCountry.Id,
                    //Image = FileUploader.Get(defaultCountry.ImageName, Models.Enums.UploadedFileTypeEnum.CountryMaster),
                    Name = defaultCountry.Name,
                    ISOCode = defaultCountry.ISOCode
                };
            }
            return null;
        }

        public async Task<MyPreferenceInsertOutputDTO> InsertUpdatePreference(MyPreferenceInputDTO input)
        {

            var query = await _preference.GetWhere(x => x.UserId == input.UserId && x.IsDeleted == false).FirstOrDefaultAsync();
            if (query == null)
            {
                if (input.CurrencyMasterId == 0 && input.CountryMasterId == 0 && input.MeasurementMasterId == 0 && input.PreferredLanguage.IsNullOrEmpty())
                {
                    return new MyPreferenceInsertOutputDTO()
                    {
                        NoRecordToSave = true
                    };
                }
                await _preference.Add(new UserPrefrence()
                {

                    UserId = input.UserId ?? 0,
                    CountryMasterId = input.CountryMasterId,
                    CurrencyMasterId = input.CurrencyMasterId,
                    MeasurementMasterId = input.MeasurementMasterId,
                    PreferedLanguage = input.PreferredLanguage,
                    IsDeleted = false,
                    CreatedBy = input.UserId,
                    CreatedOn = DateTime.UtcNow,
                });
                return new MyPreferenceInsertOutputDTO()
                {
                    IsUserPreferenceInserted = true,
                    CurrencyMasterId = input.CurrencyMasterId,
                    MeasurementMasterId = input.MeasurementMasterId,
                    CountryMasterId = input.CountryMasterId,
                    PreferredLanguage = input.PreferredLanguage,
                    MeasurementMasterName = (await _measurementMaster.GetWhere(x => x.Id == input.MeasurementMasterId).FirstOrDefaultAsync())?.Name ?? string.Empty
                };
            }
            else
            {
                query.CurrencyMasterId = input.CurrencyMasterId;
                query.MeasurementMasterId = input.MeasurementMasterId;
                query.CountryMasterId = input.CountryMasterId;
                query.PreferedLanguage = input.PreferredLanguage;
                query.LastModifiedBy = input.UserId;
                query.LastModifiedOn = DateTime.UtcNow;
                await _preference.Update(query);
                return new MyPreferenceInsertOutputDTO()
                {
                    CurrencyMasterId = query.CurrencyMasterId ?? 0,
                    MeasurementMasterId = query.MeasurementMasterId ?? 0,
                    CountryMasterId = query.CountryMasterId ?? 0,
                    PreferredLanguage = query.PreferedLanguage,
                    IsUserPreferenceUpdated = true,
                    MeasurementMasterName = (await _measurementMaster.GetWhere(x => x.Id == input.MeasurementMasterId).FirstOrDefaultAsync())?.Name ?? string.Empty
                };
            }

        }

        public async Task<MyPreferenceInsertOutputDTO> InsertUpdatePreferredLanguage(int userId, string languageCode)
        {

            var query = await _preference.GetWhere(x => x.UserId == userId && x.IsDeleted == false).FirstOrDefaultAsync();
            if (query == null)
            {
                //It was updating into DB no need to update in DB
                //await _preference.Add(new UserPrefrence()
                //{

                //    UserId = userId,
                //    PreferedLanguage = languageCode,
                //    IsDeleted = false,
                //    CreatedBy = userId,
                //    CreatedOn = DateTime.UtcNow,
                //});
                return new MyPreferenceInsertOutputDTO()
                {
                    PreferredLanguage = languageCode,
                    IsUserPreferenceInserted = true
                };
            }
            else
            {

                query.PreferedLanguage = languageCode;
                query.LastModifiedBy = userId;
                query.LastModifiedOn = DateTime.UtcNow;
                //await _preference.Update(query);
                return new MyPreferenceInsertOutputDTO()
                {
                    CurrencyMasterId = query.CurrencyMasterId ?? 0,
                    MeasurementMasterId = query.MeasurementMasterId ?? 0,
                    CountryMasterId = query.CountryMasterId ?? 0,
                    PreferredLanguage = query.PreferedLanguage,
                    IsUserPreferenceUpdated = true
                };
            }

        }
    }
}
