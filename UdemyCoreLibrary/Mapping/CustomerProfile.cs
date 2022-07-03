using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;
using UdemyCoreLibrary.Models;

namespace FluentValidationApp.Web.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreditCard, CustomerDto>();
            CreateMap<Customer, CustomerDto>().IncludeMembers(x=>x.CreditCard);
            //CreateMap<Customer, CustomerDto>()
            //    .ForMember(dest => dest.Ad, opt => opt.MapFrom(x => x.Name))
            //    .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email));
        }
    }
}
 