using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Verum.DataAccess.CQRS;
using Verum.DataAccess.Entities;
using Verum.WPF.State.Navigators;

namespace Verum.WPF.ViewModel
{
    public class CustomersViewModel : BaseViewModel
    {
        private readonly IRenavigator renavigator;

        public CustomersViewModel(IRenavigator renavigator)
        {
            this.renavigator = renavigator;
            CustomerList.Add(new Customer { Id = 1, Comments = "Customer", Country = "Customer", Name = "Customer", PostCode = "Customer", Street = "Customer", Town = "Customer" });
        }

        public ObservableCollection<Customer> CustomerList { get; set; } = new ObservableCollection<Customer>();
        public Customer SelectedItem { get; set; }


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

        private ICommand addRowCommand;        

        public ICommand AddRowCommand
        {
            get
            {
                addRowCommand = new RelayCommand(
                    (object o) =>
                    {
                        renavigator.Renavigate(ViewType.AddRow);
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
