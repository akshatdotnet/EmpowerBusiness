using AutoMapper;
using Empower.Models.Account;
using Empower.Models.API;
using Empower.Models.ManageOtp;

namespace Empower.API.Config
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<RegisterRequestDTO, SignUpInputDTO>().ReverseMap();
            CreateMap<RegisterResponseDTO, SignUpOutputDTO>().ReverseMap();

            CreateMap<LoginRequestDTO, LoginInputDTO>()
                .ForMember(dest => dest.EmailMobile, opt => opt.MapFrom(src => src.Email)).ReverseMap();
            CreateMap<LoginResponseDTO, LoginOutputDTO>().ReverseMap();

            CreateMap<ManageOtpRequestDTO, ManageOtpInputDTO>().ReverseMap();
            CreateMap<ManageOtpResponseDTO, ManageOtpOutputDTO>().ReverseMap();
        }
    }
}
