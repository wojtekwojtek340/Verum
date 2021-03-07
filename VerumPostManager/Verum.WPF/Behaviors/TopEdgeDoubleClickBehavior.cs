using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Verum.WPF.Behaviors
{
    public class TopEdgeDoubleClickBehavior : Behavior<UserControl>
    {
        protected override void OnAttached()
        {
            UserControl topPanel = this.AssociatedObject;
            if (topPanel != null)
            {
                topPanel.MouseDoubleClick += TopPanel_MouseDoubleClick;
            }
        }

        private void TopPanel_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UserControl topPanel = (UserControl)sender;
            Window window = Window.GetWindow(topPanel);

            if (!MaxWindowBehavior.isMaximalized)
            {
                MaxWindowBehavior.isMaximalized = true;
                window.WindowState = WindowState.Maximized;
            }
            else
            {
                MaxWindowBehavior.isMaximalized = false;
                window.WindowState = WindowState.Normal;
            }
        }
    }
}
