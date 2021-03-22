﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.WPF.Models;

namespace Verum.WPF.ViewModel
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel;
    public class BaseViewModel : ObservableObject
    {

    }
}
