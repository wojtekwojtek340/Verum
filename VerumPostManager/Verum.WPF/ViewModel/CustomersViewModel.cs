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
            Customer customer = new Customer { Id = 1, Comments = "test", Country = "test", Name = "test", PostCode = "test", Street = "tesd", Town = "tese" };
            CustomerList.Add(customer);
            CustomerList.Add(customer);
            CustomerList.Add(customer);
            CustomerList.Add(customer);
            CustomerList.Add(customer);
            CustomerList.Add(customer);
            CustomerList.Add(customer);
            CustomerList.Add(customer);
            CustomerList.Add(customer);
            CustomerList.Add(customer);
            CustomerList.Add(customer);
            CustomerList.Add(customer);
            CustomerList.Add(customer);         
        }

        public ObservableCollection<Customer> CustomerList { get; set; } = new ObservableCollection<Customer>();

        

    }
}
