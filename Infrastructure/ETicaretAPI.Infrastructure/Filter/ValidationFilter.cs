using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Filter
{
    public class ValidationFilter : IAsyncActionFilter//actiona gelen isteklerde oluşacak filtre
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)//uygun olmayan işlemler varsa cliente uygun şekilde geri döndüreceğiz
            {
                var errors = context.ModelState
                    .Where(x=> x.Value.Errors.Any())
             .ToDictionary(e=>e.Key, e=>e.Value.Errors.Select(e=>e.ErrorMessage))//key propları getirecek error ise validation mesajlarını getirecek 
             .ToArray();
                context.Result = new BadRequestObjectResult(errors);
            }
            await next();
            
        }
    }
}
