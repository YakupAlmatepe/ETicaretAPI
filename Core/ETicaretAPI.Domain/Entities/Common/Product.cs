using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities.Common
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }//ilgili üründen fiyata kaç adet var gibi entity oluşturduk
        public ICollection<Order> Orders { get; set; }//bir order birden çok ürüne sahip olabilir çoka- çok ilişki
    }
}
