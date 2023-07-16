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

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;


        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
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

            //await _productWriteRepository.AddAsync(new() { Name ="C Product", Price =1.500F, Stock =10, CreatedDate = DateTime.UtcNow });
            //await _productWriteRepository.SaveAsync();

            var customId = Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() { Id = customId, Name ="Yakup"});
            await _orderWriteRepository.AddAsync(new() { Description = "C blaaa", Adress = "bursa, Görükle" , CustomerId=customId});
            await _orderWriteRepository.AddAsync(new() { Description = "a blaaa", Adress = "bursa, Çekirge", CustomerId = customId });
            await _orderWriteRepository.AddAsync(new() { Description = "b blaaa", Adress = "Bursa, Fakülte", CustomerId = customId });
            await _orderWriteRepository.SaveAsync();

        }//
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product =  await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}
    }
}
