using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Verum.WPF.Behaviors
{
    public class MovingWindowBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            Window window = this.AssociatedObject;
            if(window != null)
            {
                window.MouseDown += Window_MouseDown;
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window window = (Window)sender;
            window.DragMove();
        }
    }
}
