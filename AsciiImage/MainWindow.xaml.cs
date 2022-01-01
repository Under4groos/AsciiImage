using System;
using System.IO;
using System.Windows;
 
using System.Windows.Media.Imaging;
using UcAutoClicker.Lib;

namespace AsciiImage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageProcessor imageProcessor;
        public MainWindow()
        {
            InitializeComponent();

            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * 0.7;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height * 0.7;

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


            

            save_to_txt.PreviewMouseLeftButtonDown += (o, e) =>
            {
                if(imageProcessor != null)
                    imageProcessor.DrawAsciiImage(imageProcessor.new_path , ImageProcessorType.Type.txt);
            };
        }
        private void Grid_Drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
                return;
            string[] files = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
            string file_1 = files[0];
            FileInfo fi = new FileInfo(file_1);
            if (File.Exists(file_1))
            {

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(file_1);
                bitmap.EndInit();

                image_a_.Source = bitmap;

                imageProcessor = new ImageProcessor(file_1);
                imageProcessor.new_path = fi.Name + "_ip_" + fi.Extension;

                imageProcessor.DrawAsciiImage(imageProcessor.new_path);


                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(new FileInfo(imageProcessor.new_path).FullName, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();



                image_d_.Source = bitmap;


            }

        }
    }
}
