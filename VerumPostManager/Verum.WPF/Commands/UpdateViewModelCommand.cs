using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.WPF.State.Navigators;
using Verum.WPF.ViewModel;

namespace Verum.WPF.Commands
{
    public class UpdateViewModelCommand : ICommand
    {
        private readonly INavigator navigator;

        public UpdateViewModelCommand(INavigator navigator)
        {
            this.navigator = navigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
       {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                switch (viewType)
                {
                    case ViewType.Customers:
                        navigator.CurrentViewModel = new CustomersViewModel();
                        break;
                    case ViewType.Sent:
                        navigator.CurrentViewModel = new SentLettersViewModel();
                        break;
                    case ViewType.Received:
                        navigator.CurrentViewModel = new ReceivedLettersViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
