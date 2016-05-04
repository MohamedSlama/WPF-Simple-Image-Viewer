using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Win32;
using System.Windows.Media.Animation;


namespace image_veiwer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        double scaleX = 1.0;
        double scaleY = 1.0;
        int d;
        ScaleTransform scale;
        RotateTransform rot;
        bool full = true;
        //
        //
        //
        System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        string st;
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();

        }
        int count = 0;
        List<BitmapImage> list = new List<BitmapImage>();
        void folder()
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = fbd.ShowDialog();
            string[] files = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories);
            gr.Items.Clear();
            list.Clear();
            for (int i = 0; i < files.Length; i++)
            {
                Image im = new Image();
                gr.Items.Add(im);
                im.Width = 50;
                im.Height = 50;
                im.Stretch = Stretch.Fill;
                BitmapImage bit = new BitmapImage(new Uri(files[i]));
                im.Source = bit;
                list.Add(bit);
                im.MouseDown += im_MouseDown;
            }

        }
        void im_MouseDown(object sender, MouseButtonEventArgs e)
        {


        }

        private void gri_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void gri_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void can_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        void max()
        {
            actH = (int)newctrl.ActualWidth / 2;
            actW = (int)newctrl.ActualHeight / 2;
            scaleX += 0.1;
            scaleY += 0.1;
            scale = new ScaleTransform(scaleX, scaleY, newctrl.ActualWidth / 2, newctrl.ActualHeight / 2);
            newctrl.RenderTransform = scale;
        }
        int actW = 0;
        int actH = 0;
        void min()
        {
            if (scaleX <= .1 || scaleY <= .1)
            {

            }
            else
            {
                scaleX -= 0.1;
                scaleY -= 0.1;
                scale = new ScaleTransform(scaleX, scaleY, newctrl.ActualWidth / 2, newctrl.ActualHeight / 2);
                newctrl.RenderTransform = scale;
            }

        }
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                folder();
                newctrl.Source = list[0];
            }
            catch
            {
                //MessageBox.Show("Invalid Selection");
            }
        }

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            rec.Fill = new SolidColorBrush(Colors.Aqua);
        }

        private void rec_MouseLeave(object sender, MouseEventArgs e)
        {

            rec.Fill = new SolidColorBrush(Colors.Transparent);
        }

        private void rec1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            scaleX = 1.0;
            scaleY = 1.0;
            d = 0;
            scale = new ScaleTransform(scaleX, scaleY, vi.ActualWidth / 2, vi.ActualHeight / 2);
            newctrl.RenderTransform = scale;
            if (count <= 0)
                return;
            try
            {
                newctrl.Source = list[count--];
            }
            catch { }
        }

        private void rec1_MouseEnter(object sender, MouseEventArgs e)
        {
            rec1.Fill = new SolidColorBrush(Colors.Aqua);
        }

        private void rec1_MouseLeave(object sender, MouseEventArgs e)
        {
            rec1.Fill = new SolidColorBrush(Colors.Transparent);
        }

        private void Rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            scaleX = 1.0;
            scaleY = 1.0;
            d = 0;
            scale = new ScaleTransform(scaleX, scaleY, vi.ActualWidth / 2, vi.ActualHeight / 2);
            newctrl.RenderTransform = scale;
            if (count >= list.Count)
                return;
            try
            {
                newctrl.Source = list[count++];
            }
            catch { }
        }

        private void rec2_MouseEnter(object sender, MouseEventArgs e)
        {
            rec2.Fill = new SolidColorBrush(Colors.Aqua);
        }

        private void rec2_MouseLeave(object sender, MouseEventArgs e)
        {
            rec2.Fill = new SolidColorBrush(Colors.Transparent);
        }

        private void Rectangle_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            d += 90;
            RotateTransform rote = new RotateTransform(d, newctrl.ActualWidth / 2, newctrl.ActualHeight / 2);
            newctrl.RenderTransform = rote;
        }

        private void Rectangle_MouseEnter_1(object sender, MouseEventArgs e)
        {
            rec3.Fill = new SolidColorBrush(Colors.Aqua);
        }

        private void rec3_MouseLeave(object sender, MouseEventArgs e)
        {
            rec3.Fill = new SolidColorBrush(Colors.Transparent);
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void rr_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vi.Stretch = Stretch.Fill;
            gr.Visibility = Visibility.Hidden;
            rec.Visibility = System.Windows.Visibility.Hidden;
            rec1.Visibility = System.Windows.Visibility.Hidden;
            rec2.Visibility = System.Windows.Visibility.Hidden;
            rec3.Visibility = System.Windows.Visibility.Hidden;
            rr.Visibility = System.Windows.Visibility.Hidden;
            tx1.Visibility = System.Windows.Visibility.Hidden;
            tx2.Visibility = System.Windows.Visibility.Hidden;
            tx3.Visibility = System.Windows.Visibility.Hidden;
            tx4.Visibility = System.Windows.Visibility.Hidden;
            tx5.Visibility = System.Windows.Visibility.Hidden;
            bor.Visibility = Visibility.Hidden;
            full = false;
            scaleX = 1.0;
            scaleY = 1.0;
            d = 0;
            scale = new ScaleTransform(scaleX, scaleY, vi.ActualWidth / 2, vi.ActualHeight / 2);
            newctrl.RenderTransform = scale;
            ///////////////////////////////////////////////////
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 4, 0);
            myDispatcherTimer.Tick += myDispatcherTimer_Tick;
            myDispatcherTimer.Start();
        }

        byte red = 0;
        byte green = 0;
        byte blue = 0;
        SolidColorBrush MainBrush = new SolidColorBrush(Colors.Black);
        void dd()
        {

            /////////////////
            red += 10;
            green += 10;
            blue += 10;
            MainBrush.Color = Color.FromRgb(red, green, blue);
            gri.Background = MainBrush;
            ////////
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation(20, 1000, new Duration(new TimeSpan(0, 0, 3)));
            Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.Width)"));
            sb.Children.Add(da);
            newctrl.BeginStoryboard(sb);
            
        }

        int i = 0;
        void myDispatcherTimer_Tick(object sender, EventArgs e)
        {
            newctrl.Source = list[i];
            dd();
            i += 1;
            if (i == gr.Items.Count-1)
            {
                i = 0;
            }
        }
        private void rr_MouseEnter(object sender, MouseEventArgs e)
        {

            rr.Fill = new SolidColorBrush(Colors.Aqua);
        }

        private void rr_MouseLeave(object sender, MouseEventArgs e)
        {
            rr.Fill = new SolidColorBrush(Colors.Transparent);
        }



        private void op_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void can_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            newctrl.Height = (int)gri.ActualHeight;
            newctrl.Width = (int)gri.ActualWidth;
        }

        private void win_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (full)
            {
                if (e.Delta < 0)
                {
                   
                    min();
                }
                else if (e.Delta > 0)
                {
                    max();
                }
            }

        }

        private void newctrl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void newctrl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void win_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                vi.Stretch = Stretch.Uniform;
                gri.Background = new SolidColorBrush(Colors.Transparent);
                gr.Visibility = Visibility.Visible;
                rec.Visibility = System.Windows.Visibility.Visible;
                rec1.Visibility = System.Windows.Visibility.Visible;
                rec2.Visibility = System.Windows.Visibility.Visible;
                rec3.Visibility = System.Windows.Visibility.Visible;
                rr.Visibility = System.Windows.Visibility.Visible;
                tx1.Visibility = System.Windows.Visibility.Visible;
                tx2.Visibility = System.Windows.Visibility.Visible;
                tx3.Visibility = System.Windows.Visibility.Visible;
                tx4.Visibility = System.Windows.Visibility.Visible;
                tx5.Visibility = System.Windows.Visibility.Visible;
                bor.Visibility = Visibility.Visible;
                full = true;
                rot = new RotateTransform(d, newctrl.ActualWidth / 2, newctrl.ActualHeight / 2);
                newctrl.RenderTransform = rot;
                myDispatcherTimer.Stop();
            }
            else if (e.Key == Key.Down)
            {
                min();
            }
            else if (e.Key == Key.Up)
            {
                max();
            }
        }
        bool con;
        private void newctrl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            con = true;
            //gr.Visibility = Visibility.Visible;
            //vi.Stretch = Stretch.Uniform;
            //gri.Background = new SolidColorBrush(Colors.Transparent);
            //rec.Visibility = System.Windows.Visibility.Visible;
            //rec1.Visibility = System.Windows.Visibility.Visible;
            //rec2.Visibility = System.Windows.Visibility.Visible;
            //rec3.Visibility = System.Windows.Visibility.Visible;
            //rr.Visibility = System.Windows.Visibility.Visible;
            //tx1.Visibility = System.Windows.Visibility.Visible;
            //tx2.Visibility = System.Windows.Visibility.Visible;
            //tx3.Visibility = System.Windows.Visibility.Visible;
            //tx4.Visibility = System.Windows.Visibility.Visible;
            //tx5.Visibility = System.Windows.Visibility.Visible;
            //bor.Visibility = Visibility.Visible;
            //full = true;
            //rot = new RotateTransform(d, newctrl.ActualWidth / 2, newctrl.ActualHeight / 2);
            //newctrl.RenderTransform = rot;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            win.Close();
        }

        private void newctrl_MouseLeave(object sender, MouseEventArgs e)
        {
        }

        private void vi_MouseLeave(object sender, MouseEventArgs e)
        {
        }

        private void gr_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation x = new DoubleAnimation(1, TimeSpan.FromSeconds(1));
            gr.BeginAnimation(Image.OpacityProperty, x);
        }

        private void gr_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation x = new DoubleAnimation(0, TimeSpan.FromSeconds(2));
            gr.BeginAnimation(Image.OpacityProperty, x);
        }

        private void gr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation(0, 400, new Duration(new TimeSpan(0, 0, 1)));
            Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.Height)"));
            sb.Children.Add(da);
            newctrl.BeginStoryboard(sb);
            try
            {
                newctrl.Source = list[gr.SelectedIndex];
                //Uri u = new Uri(list[gr.SelectedIndex].ToString());
                //ImageBrush b = new ImageBrush();
                //b.ImageSource = new BitmapImage(u);
                //moha.Background = b;
                scaleX = 1.0;
                scaleY = 1.0;
                d = 0;
                scale = new ScaleTransform(scaleX, scaleY, vi.ActualWidth / 2, vi.ActualHeight / 2);
                newctrl.RenderTransform = scale;
            }
            catch { }

        }

        private void vi_MouseMove(object sender, MouseEventArgs e)
        {
            //    if (con == true)
            //    {
            //vi.SetValue(Canvas.TopProperty, e.GetPosition(cnv).Y - vi.ActualHeight / 2);
            //vi.SetValue(Canvas.LeftProperty, e.GetPosition(cnv).X - vi.ActualWidth / 2);
            //}
        }

        private void vi_MouseUp(object sender, MouseButtonEventArgs e)
        {
            con = false;
        }

        private void win_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

    }
}
