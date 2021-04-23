using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.DataAccess.CQRS;
using Verum.DataAccess.CQRS.Commands.SentLetters;
using Verum.DataAccess.CQRS.Queries.Customers;
using Verum.DataAccess.Entities;
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;
using Verum.WPF.State.Validators.SentLetters;

namespace Verum.WPF.ViewModel
{
    public class AddSentLetterViewModel : BaseViewModel
    {
        private readonly IRenavigator renavigator;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        protected AddSentLetterViewModelValidator Validator { get; set; }
        public SentLetter SentLetter { get; set; } = new SentLetter();
        public ObservableCollection<Customer> CustomerList { get; set; } = new ObservableCollection<Customer>();
        public AddSentLetterViewModel(IPanelsVisibilityService panelsVisibilityService, IRenavigator renavigator, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            panelsVisibilityService.PanelsVisibility = false;
            this.renavigator = renavigator;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            Date = DateTime.Now;
            Validator = new AddSentLetterViewModelValidator();
            Employee = new Employee() { Name = "aa", Login = "aa", Password = "aa", Surname = "aa" };
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
                return SentLetter.Content;
            }
            set
            {
                SentLetter.Content = value;
                OnPropertyChanged(nameof(Content));

            }
        }

        public string Comment
        {
            get
            {
                return SentLetter.Comment;
            }
            set
            {
                SentLetter.Comment = value;
                OnPropertyChanged(nameof(Comment));

            }
        }

        public string Attachment
        {
            get
            {
                return SentLetter.Attachment;
            }
            set
            {
                SentLetter.Attachment = value;
                OnPropertyChanged(nameof(Attachment));

            }
        }
        public bool ConfirmationOfSending
        {
            get
            {
                return SentLetter.ConfirmationOfSending;
            }
            set
            {
                SentLetter.ConfirmationOfSending = value;
                OnPropertyChanged(nameof(ConfirmationOfSending));

            }
        }

        public DateTime? Date
        {
            get
            {
                return SentLetter.Date;
            }
            set
            {
                SentLetter.Date = value;
                OnPropertyChanged(nameof(Date));

            }
        }

        public Customer Sender
        {
            get
            {
                return SentLetter.Sender;
            }
            set
            {
                SentLetter.Sender = value;
                OnPropertyChanged(nameof(Sender));

            }
        }

        public Customer Recipient
        {
            get
            {
                return SentLetter.Recipient;
            }
            set
            {
                SentLetter.Recipient = value;
                OnPropertyChanged(nameof(Recipient));

            }
        }

        public Employee Employee
        {
            get
            {
                return SentLetter.Employee;
            }
            set
            {
                SentLetter.Employee = value;
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
                        SentLetter.Date = DateTime.Now;
                        SentLetter.Employee = new Employee { Login = "test", Name = "test", Password = "test", Surname = "test" };
                        var command = new AddSentLetterCommand()
                        {
                            Parameter = SentLetter
                        };
                        await commandExecutor.Execute(command);
                        renavigator.Renavigate(ViewType.Sent);
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
                        renavigator.Renavigate(ViewType.Sent);
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
