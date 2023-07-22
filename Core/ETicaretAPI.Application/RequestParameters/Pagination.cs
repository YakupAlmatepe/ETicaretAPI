using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.RequestParameters
{
    public record Pagination
    {
        public int Page { get; set; } = 0;//o koyarak default olarak sıfır dedik
        public int Size { get; set; } = 5;//5 koyarak default olarak 5 dedik
    }
}
