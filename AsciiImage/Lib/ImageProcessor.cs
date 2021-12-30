using AsciiImage.Lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

class ImageProcessor
{
    private string path;
    BrDrawSetting brDrawSetting = new BrDrawSetting();
    public ImageProcessor(string filepath)
    {
        path = filepath;

        if (!brDrawSetting.is_valid())
            brDrawSetting.save(AsciiImage.Properties.Resources.Ascii_2);

        brDrawSetting.open();

        
    }

    public string fpath { get { return path; } set { path = value; } }

    int AverageRgb(int x, int y, Bitmap image)
    {
        // 0 - 255
        var col = image.GetPixel(x, y);
        int average = (col.R + col.G + col.B) / 3;
        return average;
    }

    public void DrawAsciiImage(string ResultFileFullPath)
    {
        int spacing = 3;
        Bitmap image = new Bitmap(this.fpath);
        Bitmap AsciiImage = new Bitmap(image.Width, image.Height);
        Font drawFont = new Font("Arial", spacing-1);
        SolidBrush drawBrush = new SolidBrush(Color.Black);




        //Console.WriteLine(brDrawSetting);
        List<string> lines = new List<string>();
        for (int y = 0; y < image.Height; y += spacing)
        {
            string line_ = "";
            for (int x = 0; x < image.Width; x += spacing)
            {
                using (Graphics g = Graphics.FromImage(AsciiImage))
                {
                    for (int i = 0; i < brDrawSetting.count; i++)
                    {
                        (string, int) d = brDrawSetting.GetId(i);
                        if (AverageRgb(x, y, image) > d.Item2)
                        {
                            g.DrawString(d.Item1, drawFont, drawBrush, new PointF((float)x, (float)y));
                            line_ += d.Item1;
                            break;
                        }
                    }
                    #region MyRegion
                    //if (AverageRgb(x, y, image) > brDrawSetting.GetId(0).Item2)
                    //{
                    //    g.DrawString(brDrawSetting.GetId(0).Item1, drawFont, drawBrush, new PointF((float)x, (float)y));
                    //}
                    //else if (AverageRgb(x, y, image) > brDrawSetting.GetId(1).Item2)
                    //{
                    //    g.DrawString(brDrawSetting.GetId(1).Item1, drawFont, drawBrush, new PointF((float)x, (float)y));
                    //}
                    //else if (AverageRgb(x, y, image) > brDrawSetting.GetId(2).Item2)
                    //{
                    //    g.DrawString(brDrawSetting.GetId(2).Item1, drawFont, drawBrush, new PointF((float)x, (float)y));
                    //}
                    //else if (AverageRgb(x, y, image) > brDrawSetting.GetId(3).Item2)
                    //{
                    //    g.DrawString(brDrawSetting.GetId(3).Item1, drawFont, drawBrush, new PointF((float)x, (float)y));
                    //}
                    //else if (AverageRgb(x, y, image) > brDrawSetting.GetId(4).Item2)
                    //{
                    //    g.DrawString(brDrawSetting.GetId(4).Item1, drawFont, drawBrush, new PointF((float)x, (float)y));
                    //}
                    //else if (AverageRgb(x, y, image) > brDrawSetting.GetId(5).Item2)
                    //{
                    //    g.DrawString(brDrawSetting.GetId(5).Item1, drawFont, drawBrush, new PointF((float)x, (float)y));
                    //}
                    //else if (AverageRgb(x, y, image) > brDrawSetting.GetId(6).Item2)
                    //{
                    //    g.DrawString(brDrawSetting.GetId(6).Item1, drawFont, drawBrush, new PointF((float)x, (float)y));
                    //}
                    //else
                    //{
                    //    g.DrawString(brDrawSetting.GetId(7).Item1, drawFont, drawBrush, new PointF((float)x, (float)y));
                    //}
                    #endregion
                }
                line_ += "  ";
            }
            lines.Add(line_);
            
        }
        File.WriteAllLines("ret.txt", lines);
        void save( int ic = 0)
        {
            string ex =  new FileInfo(ResultFileFullPath).Extension;
            try
            {
                ResultFileFullPath = ResultFileFullPath.Replace(ex, ic + ex);
                if (File.Exists(ResultFileFullPath))
                    File.Delete(ResultFileFullPath);
                AsciiImage.Save(ResultFileFullPath);
            }
            catch (Exception)
            {

                save(ic++);
            }
        }
        if (File.Exists(ResultFileFullPath))
            File.Delete(ResultFileFullPath);
        AsciiImage.Save(ResultFileFullPath);


    }
}