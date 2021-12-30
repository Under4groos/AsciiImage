using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AsciiImage.Controls
{
    public class DGrid : Grid
    {
        public double Alpha
        {
            get
            {
                return this.Opacity;
            }
            set
            {
                this.Opacity = value;
            }
        }
    }
}
