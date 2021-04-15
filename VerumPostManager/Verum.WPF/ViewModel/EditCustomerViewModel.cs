using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.DataAccess.Entities;
using Verum.WPF.State.LocalServices.CurrentViewModelService;
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;

namespace Verum.WPF.ViewModel
{
    public class EditCustomerViewModel : BaseViewModel
    {
        private readonly IRenavigator renavigator;
        public Customer Customer { get; set; }
        public EditCustomerViewModel(IPanelsVisibilityService panelsVisibility, ILocalStorageService<Customer> localStorage, IRenavigator renavigator)
        {
            panelsVisibility.PanelsVisibility = false;
            Customer = localStorage.Data;
            this.renavigator = renavigator;
        }

        private ICommand editRow;
        public ICommand EditRow
        {
            get
            {
                editRow = new RelayCommand(
                    (object o) =>
                    {

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
                        renavigator.Renavigate(ViewType.Customers);
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
