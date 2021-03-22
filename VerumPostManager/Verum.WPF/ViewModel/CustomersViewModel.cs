using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.DataAccess.CQRS;
using Verum.DataAccess.Entities;
using Verum.WPF.ViewModel;

namespace Verum.WPF.ViewModel
{
    public class CustomersViewModel : BaseViewModel
    {
        public CustomersViewModel()
        {
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


    }
}
