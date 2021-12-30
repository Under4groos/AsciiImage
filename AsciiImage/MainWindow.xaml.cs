using AsciiImage.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UcAutoClicker.Lib;

namespace AsciiImage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            new WinResize(this).RightDown(border_resize);
            new WinDragMove(this)
            {
                TopDown = 35,
                LeftDown = 35 * 3,
            };
            new WBControl(this, minim, ACTIONS.SIZE_min);
            new WBControl(this, maxim, ACTIONS.SIZE_max);
            new WBControl(this, closeim, ACTIONS.CLOSE);
            name_program.Content = this.Title;
            

        }
        private void DisposeImage(BitmapImage img)
        {
            if (img != null)
            {
                try
                {
                    using (var ms = new MemoryStream(new byte[] { 0x0 }))
                    {
                        img = new BitmapImage();
                        img.StreamSource = ms;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("ImageDispose FAILED " + e.Message);
                }
            }
        }
        private void Grid_Drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
                return;
            string[] files = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
            string file_1 = files[0];
            FileInfo fi = new FileInfo(file_1);
            if(File.Exists(file_1))
            {
                 
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(file_1);
                bitmap.EndInit();
                
                image_a_.Source = bitmap;

                ImageProcessor imageProcessor = new ImageProcessor(file_1);
                file_1 = fi.Name + "_ip_" + fi.Extension;

                imageProcessor.DrawAsciiImage(file_1);


                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri( new FileInfo(file_1).FullName, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();


               
                image_d_.Source = bitmap;
                DisposeImage(bitmap);
               
            }
                
        }
    }
}
