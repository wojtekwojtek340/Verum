using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.DataAccess.CQRS;
using Verum.DataAccess.CQRS.Commands.ReceivedLetters;
using Verum.DataAccess.CQRS.Queries.Customers;
using Verum.DataAccess.CQRS.Queries.Employees;
using Verum.DataAccess.Entities;
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;
using Verum.WPF.State.Validators.ReceivedLetters;

namespace Verum.WPF.ViewModel
{
    public class AddReceivedLetterViewModel : BaseViewModel
    {
        private readonly IRenavigator renavigator;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        protected AddReceivedLetterViewModelValidator Validator { get; set; }
        public ReceivedLetter ReceivedLetter { get; set; } = new ReceivedLetter();
        public ObservableCollection<Customer> CustomerList { get; set; } = new ObservableCollection<Customer>();

        public AddReceivedLetterViewModel(IPanelsVisibilityService panelsVisibilityService, IRenavigator renavigator, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            panelsVisibilityService.PanelsVisibility = false;
            this.renavigator = renavigator;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            Date = DateTime.Now;
            Employee = new Employee() {Name="aa", Login="aa", Password= "aa" , Surname= "aa"};
            Validator = new AddReceivedLetterViewModelValidator();
            GetData();
        }
        public override ValidationResult SelfValidate()
        {
            return Validator.Validate(this);
        }
        private async Task GetData()
        {
            CustomerList.Clear();
            var query = new GetAllCustomersQuery();
            var collection = await queryExecutor.Execute(query);
            collection.ForEach(CustomerList.Add);
        }

        public string Content
        {
            get
            {
                return ReceivedLetter.Content;
            }
            set
            {
                ReceivedLetter.Content = value;
                OnPropertyChanged(nameof(Content));

            }
        }

        public string Comment
        {
            get
            {
                return ReceivedLetter.Comment;
            }
            set
            {
                ReceivedLetter.Comment = value;
                OnPropertyChanged(nameof(Comment));

            }
        }

        public string Attachment
        {
            get
            {
                return ReceivedLetter.Attachment;
            }
            set
            {
                ReceivedLetter.Attachment = value;
                OnPropertyChanged(nameof(Attachment));

            }
        }

        public DateTime? Date
        {
            get
            {
                return ReceivedLetter.Date;
            }
            set
            {
                ReceivedLetter.Date = value;
                OnPropertyChanged(nameof(Date));

            }
        }

        public Customer Sender
        {
            get
            {
                return ReceivedLetter.Sender;
            }
            set
            {
                ReceivedLetter.Sender = value;
                OnPropertyChanged(nameof(Sender));

            }
        }

        public Customer Recipient
        {
            get
            {
                return ReceivedLetter.Recipient;
            }
            set
            {
                ReceivedLetter.Recipient = value;
                OnPropertyChanged(nameof(Recipient));

            }
        }

        public Employee Employee
        {
            get
            {
                return ReceivedLetter.Employee;
            }
            set
            {
                ReceivedLetter.Employee = value;
                OnPropertyChanged(nameof(Employee));

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
                        ReceivedLetter.Date = DateTime.Now;
                        ReceivedLetter.Employee = new Employee { Login = "test", Name = "test", Password = "test", Surname = "test" };
                        var command = new AddReceivedLetterCommand()
                        {
                            Parameter = ReceivedLetter
                        };
                        await commandExecutor.Execute(command);
                        renavigator.Renavigate(ViewType.Received);

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
                        renavigator.Renavigate(ViewType.Received);
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
