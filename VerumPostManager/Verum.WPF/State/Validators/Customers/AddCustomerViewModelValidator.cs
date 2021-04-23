using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.WPF.ViewModel;

namespace Verum.WPF.State.Validators.Customers
{
    public class AddCustomerViewModelValidator : AbstractValidator<AddCustomerViewModel>
    {
        public AddCustomerViewModelValidator()
        {
            RuleFor(x => x.Name)                
                .NotEmpty()
                .WithMessage("Pole 'Nazwa' nie może być puste!")
                .Must(x => x?.Length <= 100)
                .WithMessage("Maksymalna liczba znaków: 100");


            RuleFor(x => x.Street)
                .NotEmpty()
                .WithMessage("Pole 'Ulica' nie może być puste!")
                .Must(x => x?.Length <= 50)
                .WithMessage("Maksymalna liczba znaków: 50");

            RuleFor(x => x.Town)
               .NotEmpty()
               .WithMessage("Pole 'Miasto' nie może być puste!")
               .Must(x => x?.Length <= 50)
                .WithMessage("Maksymalna liczba znaków: 50");

            RuleFor(x => x.PostCode)
                .NotEmpty()
                .WithMessage("Pole 'Kod Pocztowy' nie może być puste!")
                .Must(x => x?.Length <= 10)
                .WithMessage("Maksymalna liczba znaków: 10");

            RuleFor(x => x.Country)
               .NotEmpty()
               .WithMessage("Pole 'Kraj' nie może być puste!")
               .Must(x => x?.Length <= 50)
               .WithMessage("Maksymalna liczba znaków: 50");

            RuleFor(x => x.Comments)
                .NotEmpty()
                .WithMessage("Pole 'Komentarz' nie może być puste!")
                .Must(x => x?.Length <= 150)
                .WithMessage("Maksymalna liczba znaków: 150");

        }
    }
}
