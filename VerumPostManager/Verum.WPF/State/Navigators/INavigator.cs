using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.WPF.ViewModel;

namespace Verum.WPF.State.Navigators
{
    public enum ViewType
    {
        Customers,
        SentLetters,
        ReceivedLetters        
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
