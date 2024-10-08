using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Admin;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HouseRentingSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public UserService(
            IRepository _repository,
            IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var allUsers = new List<UserViewModel>();

            var agents = await repository
                .AllAsNoTracking<Agent>()
                .Include(a => a.User)
                .ProjectTo<UserViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();
            allUsers.AddRange(agents);

            var users = await repository
                .AllAsNoTracking<ApplicationUser>()
                .Where(au => repository
                    .AllAsNoTracking<Agent>()
                        .Any(a => a.UserId == au.Id) == false)
                .ProjectTo<UserViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();
            allUsers.AddRange(users);

            return allUsers;
        }
    }
}
