using AutoMapper;
using HouseRentingSystem.Core.Models.Admin;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Core.Models.Houses;
using HouseRentingSystem.Infrastructure.Models;
using Moq;

namespace HouseRentingSystem.Tests.Mocks
{
    public static class IMapperMock
    {
        public static IMapper Instance
        {
            get
            {
                var mockedMapper = new Mock<IMapper>();

                mockedMapper
                    .Setup(m => m.ConfigurationProvider)
                    .Returns(new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Agent, UserViewModel>()
                            .ForMember(a => a.FullName, cfg => cfg
                                .MapFrom(a => $"{a.User.FirstName} {a.User.LastName}"))
                            .ForMember(a => a.Email, cfg => cfg
                                .MapFrom(a => a.User.Email))
                            .ForMember(a => a.PhoneNumber, cfg => cfg
                                .MapFrom(a => a.PhoneNumber));

                        cfg.CreateMap<ApplicationUser, UserViewModel>()
                            .ForMember(a => a.FullName, cfg => cfg
                                .MapFrom(a => $"{a.FirstName} {a.LastName}"))
                            .ForMember(a => a.Email, cfg => cfg
                                .MapFrom(a => a.Email));

                        cfg.CreateMap<Category, HouseCategoryOptionModel>();

                        cfg.CreateMap<House, IndexViewModel>();

                        cfg.CreateMap<House, HouseViewModel>()
                            .ForMember(h => h.IsRented, cfg => cfg
                                .MapFrom(h => h.RenterId != null));

                        cfg.CreateMap<House, RentedHouseViewModel>()
                            .ForMember(h => h.AgentFullName, cfg => cfg
                                .MapFrom(h => $"{h.Agent.User.FirstName} {h.Agent.User.LastName}"))
                            .ForMember(h => h.AgentEmail, cfg => cfg
                                .MapFrom(h => h.Agent.User.Email))
                            .ForMember(h => h.RenterFullName, cfg => cfg
                                .MapFrom(h => $"{h.Renter!.FirstName} {h.Renter!.LastName}"))
                            .ForMember(h => h.RenterEmail, cfg => cfg
                                .MapFrom(h => h.Renter!.Email));
                                }));

                return mockedMapper.Object;
            }
        }
    }
}
