using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.WPF.State.Navigators;

namespace Verum.WPF.ViewModel.Factories
{
    public interface IVerumViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
