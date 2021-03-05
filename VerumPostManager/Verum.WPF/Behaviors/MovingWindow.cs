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
    public class MovingWindow : Behavior<Window>
    {
        protected override void OnAttached()
        {
            Window window = this.AssociatedObject;
            if(window != null)
            {
                window.MouseDown += Window_MouseDown;
                window.MouseMove += Window_MouseMove;
                window.MouseUp += Window_MouseUp;
            }
        }

        private bool isMoveing = false;
        Point cursorPossition;
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window window = (Window)sender;

            if(isMoveing && e.LeftButton == MouseButtonState.Pressed)
            {
                isMoveing = true;
                cursorPossition = e.GetPosition(window);
            }
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Window window = (Window)sender;

            if (isMoveing)
            {
                Point nowCursorPossition = e.GetPosition(window);
                Vector displacement = nowCursorPossition - cursorPossition;
                window.Left += displacement.X;
                window.Top += displacement.Y;
            }
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window window = (Window)sender;

            if (isMoveing && e.LeftButton == MouseButtonState.Released)
            {
                isMoveing = false;
            }
        }
    }
}
