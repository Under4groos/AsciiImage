using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UcAutoClicker.Lib
{
    public static class RGBColor
    {
        public static Color StringToColor(string colorStr)
        {
            TypeConverter cc = TypeDescriptor.GetConverter(typeof(Color));
            var result = (Color)cc.ConvertFromString(colorStr);
            return result;
        }
        public static Color StringToRGBColor(string colorStr)
        {
            Color color = new Color();
            string[] arr_ = colorStr.Split( new [] {';' , ','});
             
            switch (arr_.Length)
            {
                case 3:
                    color = Color.FromRgb(
                    (byte)int.Parse(arr_[0]),
                    (byte)int.Parse(arr_[1]),
                    (byte)int.Parse(arr_[2]));
                    break;
                case 4:
                    color = Color.FromArgb(
                    (byte)int.Parse(arr_[0]),   
                    (byte)int.Parse(arr_[1]),   
                    (byte)int.Parse(arr_[2]),   
                    (byte)int.Parse(arr_[3]));  
                    break;
                default:
                    color = Color.FromArgb(255, 255, 255, 255);
                    break;
            }

            
            return color;
        }
    }
}
