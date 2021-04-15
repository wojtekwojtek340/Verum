using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.WPF.Models;

namespace Verum.WPF.State.LocalServices.PanelsVisibilityService
{
    public class PanelsVisibilityService :ObservableObject, IPanelsVisibilityService
    {
        private bool panelsVisibility = true;

        public bool PanelsVisibility
        {
            get
            {
                return panelsVisibility;
            }
            set
            {
                panelsVisibility = value;
                OnPropertyChanged(nameof(PanelsVisibility));
            }
        }
    }
}
