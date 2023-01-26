using ECommerceAPI.Application.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ECommerceAPI.Application.Validators.Products;

public class CreateProductValidator:AbstractValidator<CreateProductVM>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
                .WithMessage("Lütfen ürün adını boş geçmeyiniz!")
            .MaximumLength(150)
            .MinimumLength(2)
                .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz!");

        RuleFor(p => p.Stock)
            .NotEmpty()
            .NotNull()
                .WithMessage("Lütfen stok bilgisini boş geçmeyiniz!")
            .Must(s => s >= 0)
                .WithMessage("Stok bilgisi negatif olamaz!");

        RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull()
                .WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz!")
            .Must(s => s >= 0)
                .WithMessage("Fiyat bilgisi negatif olamaz!");

    }
}