using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETicaretAPI.API.Repositoies
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly EticaretAPIDbContext _context;

        public ReadRepository(EticaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();//burdaki table zerinden tüm işlemlerimizi gerçekleştirebiliriz

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();//tracking istenmezse asnotracking ile trackingi kestik
            if (!tracking)
                query =query.AsNoTracking();
            return query;
            
        }
 

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> methot, bool tracking = true)
        {
            var query = Table.Where(methot);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> methot, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(methot);
        }
        public async Task<T> GetByIdAsync(string id, bool tracking = true)//base entity yaptığımız Irepository de illaki bir id olacağı için direkt olarak baseentityden miras aldırdık id yi bulduk kod maliyeti minimum
        //=> await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));//id ye ulaşmak için firstordefaultasync den Marker interface yi uyguadık
        }
    }
}
