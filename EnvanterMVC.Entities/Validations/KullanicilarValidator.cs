using EnvanterMVC.Entities.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvanterMVC.Entities.Validations
{
    public class KullanicilarValidator: AbstractValidator<Kullanicilar>
    {
        public KullanicilarValidator()
        {
            RuleFor(x=> x.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez!");
            RuleFor(x=> x.KullaniciAdi).MaximumLength(30).WithMessage("Kullanıcı Adı En Fazla 30 Karakter Olabilir!");

            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Şifre Boş Geçilemez!");
            RuleFor(x => x.Sifre).MaximumLength(20).WithMessage("Şifre En Fazla 20 Karakter Olabilir!");
        }
    }
}
