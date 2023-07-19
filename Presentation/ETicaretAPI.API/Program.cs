using ETicaretAPI.Application.Validator.Products;
using ETicaretAPI.Infrastructure.Filter;
using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();//Service regestration i�lemi i�in �a�IRDIK
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost4200").AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddControllers(opt=>opt.Filters.Add<ValidationFilter>()).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())//fluent validationslar� uygulamas�n� belirttik
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true) ;//core da gelen defoult fluentleri kendi fluentlerimize �zelle�tirdik(controllera sormadan cliente d�nd�rmesin, controllerdaki fluentlere sorsun ona g�re cliente d�nd�rs�n)
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
