using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.WPF.Models;

namespace Verum.WPF.State.Windows
{
    class WindowsService : ObservableObject, IWindowsService
    {
        private bool isAddingNow = false;
        public bool IsAddingNow
        {
            get
            {
                return isAddingNow;
            }
            set
            {
                isAddingNow = value;
                OnPropertyChanged(nameof(IsAddingNow));
            }
        }
    }
}
