using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.WPF.Models;
using Verum.WPF.ViewModel;

namespace Verum.WPF.State.LocalServices.CurrentViewModelService
{
    public class LocalStorageService<T> : ILocalStorageService<T> where T : class
    {
        public T Data { get; set; }
    }
}
