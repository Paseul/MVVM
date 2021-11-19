using GalaSoft.MvvmLight.Messaging;
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
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM.View
{
    /// <summary>
    /// ControlView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ControlView : UserControl
    {
        public ControlView()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, MessageReceived);
        }

        private void MessageReceived(string message)
        {
            if (message == "seedOn")
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { seed_btn.Content = FindResource("seed_normal"); }));                
            }
            else if (message == "seedOff")
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { seed_btn.Content = FindResource("seed_base"); }));
            }
            else if (message == "amp1On")
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa1_btn.Content = FindResource("pa1_normal"); }));
            }
            else if (message == "amp1Off")
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa1_btn.Content = FindResource("pa1_base"); }));
            }
            else if (message == "amp2On")
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa2_btn.Content = FindResource("pa2_normal"); }));
            }
            else if (message == "amp2Off")
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa2_btn.Content = FindResource("pa2_base"); }));
            }
            else if (message == "amp3On")
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa3_btn.Content = FindResource("pa3_normal"); }));
            }
            else if (message == "amp3Off")
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa3_btn.Content = FindResource("pa3_base"); }));
            }
            else if (message == "amp4On")
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4_btn.Content = FindResource("pa4_normal"); }));
            }
            else if (message == "amp4Off")
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4_btn.Content = FindResource("pa4_base"); }));
            }
        }

        private void seed_on_btn_Click(object sender, RoutedEventArgs e)
        {            

            if (seed_on_btn.Background == Brushes.LightGray)
            {
                seed_on_btn.Background = Brushes.Lime;
                seed_btn.Content = FindResource("seed_normal");
            }
            else
            {
                seed_on_btn.Background = Brushes.LightGray;
                seed_btn.Content = FindResource("seed_base");
            }            
        }

        private void pa1_on_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pa1_on_btn.Background == Brushes.LightGray)
            {
                pa1_on_btn.Background = Brushes.Lime;
                pa1_btn.Content = FindResource("pa1_normal");
            }
            else
            {
                pa1_on_btn.Background = Brushes.LightGray;
                pa1_btn.Content = FindResource("pa1_base");
            }
        }

        private void pa2_on_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pa2_on_btn.Background == Brushes.LightGray)
            {
                pa2_on_btn.Background = Brushes.Lime;
                pa2_btn.Content = FindResource("pa2_normal");
            }
            else
            {
                pa2_on_btn.Background = Brushes.LightGray;
                pa2_btn.Content = FindResource("pa2_base");
            }
        }

        private void pa3_on_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pa3_on_btn.Background == Brushes.LightGray)
            {
                pa3_on_btn.Background = Brushes.Lime;
                pa3_btn.Content = FindResource("pa3_normal");
            }
            else
            {
                pa3_on_btn.Background = Brushes.LightGray;
                pa3_btn.Content = FindResource("pa3_base");
            }
        }

        private void pa4_on_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pa4_on_btn.Background == Brushes.LightGray)
            {
                pa4_on_btn.Background = Brushes.Lime;
                pa4_btn.Content = FindResource("pa4_normal");
            }
            else
            {
                pa4_on_btn.Background = Brushes.LightGray;
                pa4_btn.Content = FindResource("pa4_base");
            }
        }

        private void pa4_1_on_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pa4_1_on_btn.Background == Brushes.LightGray)
            {
                pa4_1_on_btn.Background = Brushes.Lime;
            }
            else
            {
                pa4_1_on_btn.Background = Brushes.LightGray;
            }
        }

        private void pa4_2_on_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pa4_2_on_btn.Background == Brushes.LightGray)
            {
                pa4_2_on_btn.Background = Brushes.Lime;
            }
            else
            {
                pa4_2_on_btn.Background = Brushes.LightGray;
            }
        }

        private void pa4_3_on_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pa4_3_on_btn.Background == Brushes.LightGray)
            {
                pa4_3_on_btn.Background = Brushes.Lime;
            }
            else
            {
                pa4_3_on_btn.Background = Brushes.LightGray;
            }
        }

        private void pa4_4_on_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pa4_4_on_btn.Background == Brushes.LightGray)
            {
                pa4_4_on_btn.Background = Brushes.Lime;
            }
            else
            {
                pa4_4_on_btn.Background = Brushes.LightGray;
            }
        }

        private void pa4_5_on_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pa4_5_on_btn.Background == Brushes.LightGray)
            {
                pa4_5_on_btn.Background = Brushes.Lime;
            }
            else
            {
                pa4_5_on_btn.Background = Brushes.LightGray;
            }
        }

        private void pa4_6_on_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pa4_6_on_btn.Background == Brushes.LightGray)
            {
                pa4_6_on_btn.Background = Brushes.Lime;
            }
            else
            {
                pa4_6_on_btn.Background = Brushes.LightGray;
            }
        }

        private void polcont_btn_Click(object sender, RoutedEventArgs e)
        {
            if (polcont_btn.Background == Brushes.LightGray)
            {
                polcont_btn.Background = Brushes.Lime;
            }
            else
            {
                polcont_btn.Background = Brushes.LightGray;
            }
        }
    }
}
