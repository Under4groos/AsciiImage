using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UcAutoClicker.Lib
{
    public enum ACTIONS
    {
        CLOSE = 1,
        HIDE = 2,
        SIZE_min = 3,
        SIZE_max = 4,
    }
    public class WBControl
    {
        public WBControl(Window wind, UIElement uIElement, ACTIONS action)
        {

            switch (action)
            {
                case ACTIONS.CLOSE:
                    uIElement.PreviewMouseLeftButtonDown += (o, e) =>
                    {

                        wind.Close();
                    };
                    break;
                case ACTIONS.HIDE:
                    uIElement.PreviewMouseLeftButtonDown += (o, e) =>
                    {
                        wind.Hide();
                    };
                    break;
                case ACTIONS.SIZE_min:
                    uIElement.PreviewMouseLeftButtonDown += (o, e) =>
                    {
                        switch (wind.WindowState)
                        {
                            case WindowState.Normal:
                                wind.WindowState = WindowState.Minimized;
                                break;
                            case WindowState.Minimized:
                                break;
                            case WindowState.Maximized:
                                wind.WindowState = WindowState.Minimized;
                                break;
                            default:
                                break;
                        }
                    };
                    break;

                case ACTIONS.SIZE_max:
                    uIElement.PreviewMouseLeftButtonDown += (o, e) =>
                    {
                        switch (wind.WindowState)
                        {
                            case WindowState.Normal:
                                wind.WindowState = WindowState.Maximized;
                                break;
                            case WindowState.Minimized:
                                break;
                            case WindowState.Maximized:
                                wind.WindowState = WindowState.Normal;
                                break;
                            default:
                                break;
                        }
                    };
                    break;
                default:
                    break;
            }

        }
    }
}
