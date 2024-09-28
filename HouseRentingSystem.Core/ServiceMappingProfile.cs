using AutoMapper;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Core.Models.Houses;
using HouseRentingSystem.Infrastructure.Models;

namespace HouseRentingSystem.Core
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<House, HouseFormModel>();
            CreateMap<House, HouseDeleteViewModel>();
            CreateMap<House, IndexViewModel>();

            CreateMap<Category, HouseCategoryOptionModel>();

            CreateMap<House, HouseViewModel>()
                .ForMember(h => h.IsRented, cfg => cfg
                    .MapFrom(h => h.RenterId != null));

            CreateMap<House, HouseDetailsViewModel>()
                .ForMember(h => h.Category, cfg => cfg
                    .MapFrom(h => h.Category.Name))
                .ForMember(h => h.IsRented, cfg => cfg
                    .MapFrom(h => h.RenterId != null));

            CreateMap<Agent, HouseAgentInfoModel>()
                .ForMember(a => a.FullName, cfg => cfg
                    .MapFrom(a => $"{a.User.FirstName} {a.User.LastName}"))
                .ForMember(a => a.Email, cfg => cfg
                    .MapFrom(a => a.User.Email));
        }
    }
}
