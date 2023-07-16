using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T: BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true); //ıqueryable, veritabanında sorgu üzerine çalışmalarda kullanılır

        IQueryable<T> GetWhere(Expression<Func<T, bool>> methot, bool tracking = true);// where şarta uygun olan özel tanımlı fonksiyon
       Task<T> GetSingleAsync(Expression<Func<T, bool>> methot, bool tracking = true    );
        Task<T> GetByIdAsync(string id, bool tracking = true);//idye uygun olanı çağıracak
    }
}
