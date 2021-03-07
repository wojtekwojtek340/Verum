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
    public class MaxWindowBehavior : Behavior<Button>
    {
        public static bool isMaximalized = false;
        protected override void OnAttached()
        {
            Button button = this.AssociatedObject;
            if (button != null)
            {
                button.Click += Button_Click;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Window window = Window.GetWindow(button);

            if (!isMaximalized)
            {
                isMaximalized = true;
                window.WindowState = WindowState.Maximized;
            }
            else
            {
                isMaximalized = false;
                window.WindowState = WindowState.Normal;
            }
        }
    }
}
