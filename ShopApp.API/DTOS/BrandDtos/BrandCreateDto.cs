using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.API.DTOS.BrandDtos
{
    public class BrandCreateDto
    {
        //[Required]
        //[MaxLength(35)]
        public string Name { get; set; }
    }


    public class BrandCreateDtoValidator : AbstractValidator<BrandCreateDto>
    {
        public BrandCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bos ola bilmez").
                MaximumLength(35).WithMessage("35-den uzun ola bilmez");
            //notempty-ne null ne de empty ola biler
        }
    }
}
