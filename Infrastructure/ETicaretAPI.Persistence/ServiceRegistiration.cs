

using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public  static class ServiceRegistiration //extencion fonksiyon tanımlayacağımız için static yaptık
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<EticaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
        }
    }
}
