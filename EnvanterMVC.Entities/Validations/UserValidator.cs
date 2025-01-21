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
            RuleFor(x => x.TeslimEden).MaximumLength(70).WithMessage("'Teslim Eden' Alanı en fazla 70 karakter olabilir!");
            RuleFor(x => x.TeslimAlan).MaximumLength(70).WithMessage("'Teslim Alan' Alanı en fazla 70 karakter olabilir!");

        }
    }
}
