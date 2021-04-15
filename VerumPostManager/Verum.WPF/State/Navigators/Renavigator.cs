using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.WPF.ViewModel.Factories;

namespace Verum.WPF.State.Navigators
{
    public class Renavigator : IRenavigator    {
        public IVerumViewModelFactory VerumViewModelFactory { get; }
        public INavigator Navigator { get; }

        public Renavigator(IVerumViewModelFactory verumViewModelFactory, INavigator navigator)
        {
            this.VerumViewModelFactory = verumViewModelFactory;
            this.Navigator = navigator;
        }

        public void Renavigate(ViewType viewType)
        {
            Navigator.CurrentViewModel = VerumViewModelFactory.CreateViewModel(viewType);
        }
    }
}
