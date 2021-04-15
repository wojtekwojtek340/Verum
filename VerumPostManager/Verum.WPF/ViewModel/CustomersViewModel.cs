using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Verum.DataAccess.CQRS;
using Verum.DataAccess.CQRS.Queries.Customers;
using Verum.DataAccess.Entities;
using Verum.WPF.State.LocalServices.CurrentViewModelService;
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;


namespace Verum.WPF.ViewModel
{
    public class CustomersViewModel : BaseViewModel
    {
        private readonly IRenavigator renavigator;
        private readonly ILocalStorageService<Customer> localStorage;
        private readonly IQueryExecutor queryExecutor;

        public CustomersViewModel(IRenavigator renavigator, ILocalStorageService<Customer> localStorage, IPanelsVisibilityService panelsVisibilityService, IQueryExecutor queryExecutor)
        {
            panelsVisibilityService.PanelsVisibility = true;
            this.renavigator = renavigator;
            this.localStorage = localStorage;
            this.queryExecutor = queryExecutor;
            GetData();
        }

        public ObservableCollection<Customer> CustomerList { get; set; } = new ObservableCollection<Customer>();
        public Customer SelectedItem { get; set; }

        private async Task GetData()
        {
            var query = new GetAllCustomersQuery();
            var collection = await queryExecutor.Execute(query);
            collection.ForEach(CustomerList.Add);
        }

        private ICommand deleteRowCommand;
        public ICommand DeleteRowCommand
        {
            get
            {
                deleteRowCommand = new RelayCommand(
                    (object o) =>
                    {
                        CustomerList.Remove(SelectedItem);
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
                        renavigator.Renavigate(ViewType.EditCustomer);
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
                        renavigator.Renavigate(ViewType.AddCustomer);
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
