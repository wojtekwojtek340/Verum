using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.DataAccess.CQRS;
using Verum.DataAccess.CQRS.Commands.SentLetters;
using Verum.DataAccess.CQRS.Queries.SentLetters;
using Verum.DataAccess.Entities;
using Verum.WPF.State.LocalServices.CurrentViewModelService;
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;

namespace Verum.WPF.ViewModel
{
    public class SentLettersViewModel : BaseViewModel
    {
        private readonly IRenavigator renavigator;

        private readonly ILocalStorageService<SentLetter> localStorage;

        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public ObservableCollection<SentLetter> SentList { get; set; } = new ObservableCollection<SentLetter>();
        public SentLetter SelectedItem { get; set; }
        public SentLettersViewModel(IRenavigator renavigator, ILocalStorageService<SentLetter> localStorage, IPanelsVisibilityService panelsVisibilityService, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            panelsVisibilityService.PanelsVisibility = true;
            this.renavigator = renavigator;
            this.localStorage = localStorage;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
            GetData();
        }
        private async Task GetData()
        {
            SentList.Clear();
            var query = new GetAllSentLettersQuery();
            var collection = await queryExecutor.Execute(query);
            collection.ForEach(SentList.Add);
        }

        private ICommand deleteRowCommand;
        public ICommand DeleteRowCommand
        {
            get
            {
                deleteRowCommand = new RelayCommand(async
                    (object o) =>
                    {
                        var command = new DeleteSentLetterCommand()
                        {
                            Parameter = SelectedItem.Id
                        };
                        await commandExecutor.Execute(command);
                        GetData();
                    },
                    (object e) =>
                    {
                        return SelectedItem != null;
                    });

                return deleteRowCommand;
            }
        }

        private ICommand editRowCommand;
        public ICommand EditRowCommand
        {
            get
            {
                editRowCommand = new RelayCommand(
                    (object o) =>
                    {
                        localStorage.Data = SelectedItem;
                        renavigator.Renavigate(ViewType.EditSentLetter);
                    },
                    (object e) =>
                    {
                        return SelectedItem != null;
                    });

                return editRowCommand;
            }
        }

        private ICommand addRowCommand;

        public ICommand AddRowCommand
        {
            get
            {
                addRowCommand = new RelayCommand(
                    (object o) =>
                    {
                        renavigator.Renavigate(ViewType.AddSentLetter);
                    },
                    (object e) =>
                    {
                        return true;
                    });

                return addRowCommand;
            }
        }
    }
}
