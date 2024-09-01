
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(HouseRentingDbContext _context)
        {
            context = _context;
        }

        private DbSet<T> DbSet<T>() where T : class
            => context.Set<T>();

        public IQueryable<T> All<T>() where T : class
            => DbSet<T>();

        public IQueryable<T> AllAsNoTracking<T>() where T : class
            => DbSet<T>().AsNoTracking();
    }
}
