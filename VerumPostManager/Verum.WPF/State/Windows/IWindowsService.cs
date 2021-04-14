using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verum.WPF.State.Windows
{
    public interface IWindowsService
    {
        public bool IsAddingNow { get; set; }
    }
}
