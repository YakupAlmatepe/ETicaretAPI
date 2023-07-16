using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            // {
            //     new(){Id =Guid.NewGuid(), Name = "Product 1" , Price =100, CreateData = DateTime.UtcNow,Stock =10},
            //     new(){Id =Guid.NewGuid(), Name = "Product 2" , Price =200, CreateData = DateTime.UtcNow,Stock =20},
            //     new(){Id =Guid.NewGuid(), Name = "Product 3" ,Price =300, CreateData = DateTime.UtcNow,Stock =130},

            // });
            //var count = await _productWriteRepository.SaveAsync();

            //Product p = await _productReadRepository.GetByIdAsync("426d464f-1bff-49bb-b852-7f1299532aef", false);//tracking takibi durdurduk artık database etkilenmyecek sadece bu sorgu için:)
            //p.Name = "Ahmet";
            //await _productWriteRepository.SaveAsync();

            await _productWriteRepository.AddAsync(new() { Name ="C Product", Price =1.500F, Stock =10, CreatedDate = DateTime.UtcNow });
            await _productWriteRepository.SaveAsync();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product =  await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
