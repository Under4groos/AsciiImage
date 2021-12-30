using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
 

namespace UcAutoClicker.Lib
{
    public static class WinApi
    {
        public struct pos
        {
            public int X;
            public int Y;
            public override string ToString()
            {
                return $"x:{X} / y:{Y}";
            }
        }
        #region kernel32
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);
        #endregion
        //========================================================
        #region user32
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, IntPtr callback, IntPtr hInstance, uint threadId);
        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy,int dwData, int dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out pos lpPoint);

        
        #endregion
        //========================================================
    }
}
