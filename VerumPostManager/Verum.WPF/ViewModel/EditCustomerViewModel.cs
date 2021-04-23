using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.DataAccess.CQRS;
using Verum.DataAccess.CQRS.Commands.Customers;
using Verum.DataAccess.Entities;
using Verum.WPF.State.LocalServices.CurrentViewModelService;
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;
using Verum.WPF.State.Validators.Customers;

namespace Verum.WPF.ViewModel
{
    public class EditCustomerViewModel : BaseViewModel
    {
        private readonly IRenavigator renavigator;
        private readonly ICommandExecutor commandExecutor;
        protected EditCustomerViewModelValidator Validator { get; set; }
        public Customer Customer { get; set; }
        public EditCustomerViewModel(IPanelsVisibilityService panelsVisibility, ILocalStorageService<Customer> localStorage, IRenavigator renavigator, ICommandExecutor commandExecutor)
        {
            panelsVisibility.PanelsVisibility = false;
            Customer = localStorage.Data;
            this.renavigator = renavigator;
            this.commandExecutor = commandExecutor;
            Validator = new EditCustomerViewModelValidator();
        }

        public override ValidationResult SelfValidate()
        {
            return Validator.Validate(this);
        }
        public string Name
        {
            get
            {
                return Customer.Name;
            }
            set
            {
                Customer.Name = value;
                OnPropertyChanged(nameof(Name));

            }
        }

        public string Street
        {
            get
            {
                return Customer.Street;
            }
            set
            {
                Customer.Street = value;
                OnPropertyChanged(nameof(Street));

            }
        }

        public string Town
        {
            get
            {
                return Customer.Town;
            }
            set
            {
                Customer.Town = value;
                OnPropertyChanged(nameof(Town));

            }
        }

        public string Country
        {
            get
            {
                return Customer.Country;
            }
            set
            {
                Customer.Country = value;
                OnPropertyChanged(nameof(Country));

            }
        }

        public string PostCode
        {
            get
            {
                return Customer.PostCode;
            }
            set
            {
                Customer.PostCode = value;
                OnPropertyChanged(nameof(PostCode));

            }
        }

        public string Comments
        {
            get
            {
                return Customer.Comments;
            }
            set
            {
                Customer.Comments = value;
                OnPropertyChanged(nameof(Comments));

            }
        }

        private ICommand editRow;
        public ICommand EditRow
        {
            get
            {
                editRow = new RelayCommand(async
                    (object o) =>
                    {
                        var command = new UpdateCustomerCommand()
                        {
                            Parameter = Customer
                        };
                        await commandExecutor.Execute(command);
                        renavigator.Renavigate(ViewType.Customers);
                    },
                    (object e) =>
                    {
                        return SelfValidate().IsValid;
                    });

                return editRow;
            }
        }

        private ICommand cancel;      
        public ICommand Cancel
        {
            get
            {
                cancel = new RelayCommand(
                    (object o) =>
                    {
                        renavigator.Renavigate(ViewType.Customers);
                    },
                    (object e) =>
                    {
                        return true;
                    });

                return cancel;
            }
        }
    }
}
