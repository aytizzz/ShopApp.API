using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.API.DTOS.BrandDtos
{
    public class BrandEditDto
    {
        //[Required]
        //[MaxLength(35)]
        public string Name { get; set; }

        public class BrandEditDtoValidator : AbstractValidator<BrandEditDto>
        {
            public BrandEditDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(35);
            }
        }
    }
}
