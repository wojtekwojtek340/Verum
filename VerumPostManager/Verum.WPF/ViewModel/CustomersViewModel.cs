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
            CustomerList.Add(new Customer { Id = 1, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 2, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 3, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 4, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 5, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 6, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 7, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 8, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 9, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 10, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 11, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 12, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });
            CustomerList.Add(new Customer { Id = 13, Comments = "test", Country = "test", Name = "Wojek", PostCode = "test", Street = "tesd", Town = "tese" });         
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
