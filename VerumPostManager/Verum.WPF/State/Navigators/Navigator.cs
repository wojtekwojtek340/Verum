using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.WPF.Commands;
using Verum.WPF.Models;
using Verum.WPF.ViewModel;

namespace Verum.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {      
        private BaseViewModel currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return currentViewModel;
            }
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }        
        }

    }
}
