using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.WPF.Commands;
using Verum.WPF.State.Navigators;
using Verum.WPF.ViewModel.Factories;

namespace Verum.WPF.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; }
        public ICommand UpdateViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IVerumViewModelFactory verumViewModelFactory)
        {
            Navigator = navigator;
            UpdateViewModelCommand = new UpdateViewModelCommand(navigator, verumViewModelFactory);
            UpdateViewModelCommand.Execute(ViewType.Customers);
        }
    }
}
