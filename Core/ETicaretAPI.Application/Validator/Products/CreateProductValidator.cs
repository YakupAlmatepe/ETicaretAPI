using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ETicaretAPI.Application.Validator.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull().WithMessage("Lütfen Ürün Adını Boş Geçmeyiniz")
            .MaximumLength(150)
            .MinimumLength(2)
            .WithMessage("Lütfen ürün Adını 2 ila 150 karakter arsında giriniz");

            RuleFor(p => p.Stok)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stok bilgisini boş geçmeyiniz")
                 .Must(s => s >= 0)
                    .WithMessage("Stok bilgisi negatif olamaz");


            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Fiyat bilgisini boş geçmeyiniz")
                 .Must(s => s >= 0)
                    .WithMessage("Fiyat bilgisi negatif olamaz");


        }
    }
}
