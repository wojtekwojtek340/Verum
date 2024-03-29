﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.DataAccess.CQRS;
using Verum.DataAccess.CQRS.Commands.ReceivedLetters;
using Verum.DataAccess.CQRS.Queries.ReceivedLetters;
using Verum.DataAccess.Entities;
using Verum.WPF.State.LocalServices.CurrentViewModelService;
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;

namespace Verum.WPF.ViewModel
{
    public class ReceivedLettersViewModel : BaseViewModel
    {
        private readonly IRenavigator renavigator;

        private readonly ILocalStorageService<ReceivedLetter> localStorage;

        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public ObservableCollection<ReceivedLetter> ReceivedList { get; set; } = new ObservableCollection<ReceivedLetter>();
        public ReceivedLetter SelectedItem { get; set; }

        public ReceivedLettersViewModel(IRenavigator renavigator, ILocalStorageService<ReceivedLetter> localStorage, IPanelsVisibilityService panelsVisibilityService, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
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
            ReceivedList.Clear();
            var query = new GetAllReceivedLettersQuery();
            var collection = await queryExecutor.Execute(query);
            collection.ForEach(ReceivedList.Add);
        }

        private ICommand deleteRowCommand;
        public ICommand DeleteRowCommand
        {
            get
            {
                deleteRowCommand = new RelayCommand(async
                    (object o) =>
                    {
                        var command = new DeleteReceivedLetterCommand()
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
                        renavigator.Renavigate(ViewType.EditReceivedLetter);
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
                        renavigator.Renavigate(ViewType.AddReceivedLetter);
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
