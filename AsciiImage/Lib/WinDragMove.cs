using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UcAutoClicker.Lib
{
    public class WinDragMove
    {


        public double? TopDown
        {
            get; set;
        } = 35;
        public double? LeftDown
        {
            get; set;
        } = 35;

        public WinDragMove(Window win_  )
        {
            win_.MouseLeftButtonDown += (sender, e) =>
            {
                 
                if (e.GetPosition(win_).Y < TopDown && e.LeftButton == System.Windows.Input.MouseButtonState.Pressed && (win_.Width -  e.GetPosition(win_).X) > LeftDown)
                    win_.DragMove();

             
            };
        }
    }
}
