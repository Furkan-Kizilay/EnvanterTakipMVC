using EnvanterMVC.Entities.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvanterMVC.Entities.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x=>  x.Username).NotEmpty();
            RuleFor(x=>  x.Password).NotEmpty();
            RuleFor(x => x.Username).MaximumLength(30).WithMessage("'Username' Alanı en fazla 30 karakter olabilir!");
            RuleFor(x => x.Password).MaximumLength(30).WithMessage("'Password' Alanı en fazla 30 karakter olabilir!");
            RuleFor(x => x.Tur).NotEmpty().WithMessage("'Tür' Alanı Boş Geçilemez!");
            RuleFor(x => x.TeslimEden).NotEmpty().WithMessage("'Teslim Eden ' Alanı Boş Geçilemez!");
            RuleFor(x => x.TeslimEden).MaximumLength(70).WithMessage("'Teslim Eden' Alanı en fazla 70 karakter olabilir!");
            RuleFor(x => x.TeslimAlan).MaximumLength(70).WithMessage("'Teslim Alan' Alanı en fazla 70 karakter olabilir!");

        }
    }
}
