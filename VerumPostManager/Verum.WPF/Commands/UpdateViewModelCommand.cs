using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.WPF.State.Navigators;
using Verum.WPF.ViewModel;
using Verum.WPF.ViewModel.Factories;

namespace Verum.WPF.Commands
{
    public class UpdateViewModelCommand : ICommand
    {
        private readonly INavigator navigator;
        private readonly IVerumViewModelFactory verumViewModelFactory;

        public UpdateViewModelCommand(INavigator navigator, IVerumViewModelFactory verumViewModelFactory)
        {
            this.navigator = navigator;
            this.verumViewModelFactory = verumViewModelFactory;
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
                navigator.CurrentViewModel = verumViewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
