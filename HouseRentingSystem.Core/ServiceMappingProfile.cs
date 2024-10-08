using AutoMapper;
using HouseRentingSystem.Core.Models.Admin;
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

            CreateMap<Agent, UserViewModel>()
                .ForMember(a => a.FullName, cfg => cfg
                    .MapFrom(a => $"{a.User.FirstName} {a.User.LastName}"))
                .ForMember(a => a.Email, cfg => cfg
                    .MapFrom(a => a.User.Email))
                .ForMember(a => a.PhoneNumber, cfg => cfg
                    .MapFrom(a => a.PhoneNumber));

            CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(a => a.FullName, cfg => cfg
                    .MapFrom(a => $"{a.FirstName} {a.LastName}"))
                .ForMember(a => a.Email, cfg => cfg
                    .MapFrom(a => a.Email));

            CreateMap<House, RentedHouseViewModel>()
                .ForMember(h => h.AgentFullName, cfg => cfg
                    .MapFrom(h => $"{h.Agent.User.FirstName} {h.Agent.User.LastName}"))
                .ForMember(h => h.AgentEmail, cfg => cfg
                    .MapFrom(h => h.Agent.User.Email))
                .ForMember(h => h.RenterFullName, cfg => cfg
                    .MapFrom(h => $"{h.Renter!.FirstName} {h.Renter!.LastName}"))
                .ForMember(h => h.RenterEmail, cfg => cfg
                    .MapFrom(h => h.Renter!.Email));
        }
    }
}
