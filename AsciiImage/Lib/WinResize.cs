using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static UcAutoClicker.Lib.WinApi;

namespace UcAutoClicker.Lib
{
    public class WinResize
    {
        Window Wind;
        UIElement Element;
        TimerTick timerTick = new TimerTick();
        pos poscur;
        pos last_poscur;

        double Width = 0;
        double Height = 0;
        Size resizeSize;
        bool isMouseDoun = false;
        bool isMouseMoove = false;
        public WinResize() { }
        public WinResize(Window w)
        {
            Wind = w;
            Width = Wind.Width;
            Height = Wind.Height;
            timerTick.Tick += (sender, e) =>
            {
                if (Mouse.LeftButton == MouseButtonState.Released)
                    isMouseDoun = false;

                Update();
                Wind.Width = Width < Wind.MinWidth ? Wind.MinWidth + 15 : Width;
                Wind.Height = Height < Wind.MinHeight ? Wind.MinHeight + 15 : Height;
            };

            Wind.MouseEnter += (sender, e) => isMouseMoove = true;
            Wind.MouseLeave += (sender, e) => isMouseMoove = false;
            timerTick.Start();
        }

        public WinResize(bool isMouseMoove)
        {
            this.isMouseMoove = isMouseMoove;
        }

        public void RightDown(UIElement element)
        {
            Element = element;
            MouseHandlers(Element);
        }

        private void MouseHandlers(UIElement element)
        {
            element.MouseLeftButtonDown += new MouseButtonEventHandler(element_MouseLeftButtonDown);
            element.MouseLeftButtonUp += new MouseButtonEventHandler(element_MouseLeftButtonUp);
            element.MouseEnter += (sender, e) =>
            {
                Wind.Cursor = Cursors.SizeNWSE;
                isMouseMoove = false;
            };
            element.MouseLeave += (sender, e) =>
            {
                Wind.Cursor = Cursors.Arrow;
                isMouseMoove = true;
            };
        }

        private void element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDoun = false;
        }

        private void element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WinApi.GetCursorPos(out last_poscur);
            resizeSize = new Size(Wind.Width, Wind.Height);
           
            isMouseDoun = true;
                
        }

        public void Update()
        {
            if (Mouse.LeftButton == MouseButtonState.Released)
                isMouseDoun = false;
            if (isMouseDoun)
            {
                WinApi.GetCursorPos(out poscur);
                Width = resizeSize.Width - (last_poscur.X - poscur.X);
                Height = resizeSize.Height - (last_poscur.Y - poscur.Y);

                
            }
        }
    }
}
