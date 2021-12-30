using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiImage.Lib
{
    public class BrDrawSetting
    {
        List<string> list = new List<string>();
        public string file_
        {
            get; set;
        } = "AsciiSetting.txt";
        public int count
        {
            get
            {
               return list.Count;
            }
        }
        public bool is_valid()
        {
            return File.Exists(file_);
        }
        public void add( string Ascii , int cc_i )
        {
            list.Add( $"{Ascii}:{cc_i}" );
        }
        public void save( string str = null )
        {
            File.WriteAllText(file_, str == null ? string.Join("\n", list) : str);

        }
        public void clear() => list.Clear();
        public (string,int) GetId( int id)
        {
            if(list.Count > 0 && list.Count > id)
            {
                string[] st_ = list[id].Split('`');
                int icn_color = 0;
                if(int.TryParse(st_[1], out icn_color))
                {
                    
                    return (st_[0], icn_color);

                }

                return ("-", 0);

            }
            return ("-", 0);
        }
        public override string ToString()
        {
            return string.Join("\n" , list);
        }
        public void open()
        {
            clear();
            string[] lines = File.ReadAllLines(file_);
            list.AddRange(lines);
        }
    }
}
