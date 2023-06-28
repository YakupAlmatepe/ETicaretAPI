using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }//bir müşterinin sabit adresi olmadığını düşünerek
        public ICollection<Product> Products { get; set; }//bir order 1den fazla product var (çoka çok ilişki için)
        public Customer Customer { get; set; }//1 e çok ilişki için (1 order 1tane müşterisi olur)
    }
}
