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
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;
using Verum.WPF.State.Validators.Customers;


namespace Verum.WPF.ViewModel
{
    public class AddCustomerViewModel: BaseViewModel
    {

        private readonly IRenavigator renavigator;

        private readonly ICommandExecutor commandExecutor;

        protected AddCustomerViewModelValidator Validator { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public AddCustomerViewModel(IPanelsVisibilityService panelsVisibilityService, IRenavigator renavigator, ICommandExecutor commandExecutor)
        {
            panelsVisibilityService.PanelsVisibility = false;
            this.renavigator = renavigator;
            this.commandExecutor = commandExecutor;
            Validator = new AddCustomerViewModelValidator();
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

        private ICommand addRow;
        public ICommand AddRow
        {
            get
            {
                addRow = new RelayCommand(async
                    (object o) =>
                    {
                        var command = new AddCustomerCommand()
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

                return addRow;
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
