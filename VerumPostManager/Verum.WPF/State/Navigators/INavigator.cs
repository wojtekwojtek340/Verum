﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.WPF.ViewModel;

namespace Verum.WPF.State.Navigators
{
    public enum ViewType
    {
        Customers,
        Sent,
        Received,
        Login,
        AddCustomer,
        AddSentLetter,
        AddReceivedLetter,
        EditCustomer,
        EditSentLetter,
        EditReceivedLetter

    }
    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
    }
}
