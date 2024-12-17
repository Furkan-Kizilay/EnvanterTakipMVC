using EnvanterMVC.Entities.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvanterMVC.Entities.Validations
{
    public class UrunBilgiValidation :AbstractValidator<UrunBilgi>
    {
        public UrunBilgiValidation()
        {
            RuleFor(x => x.Model).NotEmpty().WithMessage("Model giriniz..");
        }
    }
}
