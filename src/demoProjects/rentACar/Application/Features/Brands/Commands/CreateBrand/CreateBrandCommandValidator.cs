using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        // FluentValidation ile Format Doğrulama işlemleri
        // Ekeleme işlemleri için ayrı güncelleme işlemleri vs. ler için ayrı doğrulama işlemleri olabileceği için "CreateBrandCommand" ile ekleme işlemleri için yapıldı
        public CreateBrandCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty(); // Boş geçilemez
            RuleFor(c => c.Name).MinimumLength(2); // En kısa uzunluk 2 karakter
        }
    }
}
