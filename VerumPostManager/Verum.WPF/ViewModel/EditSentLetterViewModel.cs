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
using Verum.WPF.State.LocalServices.CurrentViewModelService;
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;

namespace Verum.WPF.ViewModel
{
    public class EditSentLetterViewModel : BaseViewModel 
    {
        private readonly IRenavigator renavigator;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        public ObservableCollection<Customer> CustomerList { get; set; } = new ObservableCollection<Customer>();
        public SentLetter SentLetter { get; set; }
        public EditSentLetterViewModel(IPanelsVisibilityService panelsVisibilityService, ILocalStorageService<SentLetter> localStorage, IRenavigator renavigator, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            panelsVisibilityService.PanelsVisibility = false;
            SentLetter = localStorage.Data;
            this.renavigator = renavigator;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            GetData();
        }
        private async Task GetData()
        {
            CustomerList.Clear();
            var query = new GetAllCustomersQuery();
            var collection = await queryExecutor.Execute(query);
            collection.ForEach(CustomerList.Add);
        }

        private ICommand editRow;
        public ICommand EditRow
        {
            get
            {
                editRow = new RelayCommand(async
                    (object o) =>
                    {
                        var command = new UpdateSentLetterCommand()
                        {
                            Parameter = SentLetter
                        };
                        await commandExecutor.Execute(command);
                        renavigator.Renavigate(ViewType.Sent);
                    },
                    (object e) =>
                    {
                        return true;
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
