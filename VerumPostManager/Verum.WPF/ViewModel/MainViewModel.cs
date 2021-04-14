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
        public ICommand UpdateViewModelCommand { get; }
        public IRenavigator Renavigator { get; }

        public MainViewModel(IRenavigator renavigator, ICommand updateViewModelCommand)
        {
            Renavigator = renavigator;
            UpdateViewModelCommand = updateViewModelCommand;
            Renavigator.Renavigate(ViewType.Customers);
        }
    }
}
