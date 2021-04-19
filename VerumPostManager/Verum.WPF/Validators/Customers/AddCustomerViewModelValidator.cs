using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.WPF.ViewModel;

namespace Verum.WPF.Validators.Customers
{
    public class AddCustomerViewModelValidator : AbstractValidator<AddCustomerViewModel>
    {
        public AddCustomerViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Street)
                .NotEmpty()
                .NotNull();
        }
    }
}
