using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.WPF.ViewModel;

namespace Verum.WPF.State.Navigators
{
    public class ViewModelDelegateRenavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly INavigator navigator;
        private readonly CreateViewModel<TViewModel> createViewModel;

        public ViewModelDelegateRenavigator(INavigator navigator, CreateViewModel<TViewModel> createViewModel)
        {
            this.navigator = navigator;
            this.createViewModel = createViewModel;
        }

        public void Renavigate()
        {
            navigator.CurrentViewModel = createViewModel();
        }
    }
}
