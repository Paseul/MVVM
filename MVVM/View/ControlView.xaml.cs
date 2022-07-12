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

            pa4_1_combo.Items.Add("1");
            pa4_1_combo.Items.Add("2");
            pa4_1_combo.Items.Add("3");
            pa4_1_combo.SelectedIndex = 0;
            pa4_2_combo.Items.Add("1");
            pa4_2_combo.Items.Add("2");
            pa4_2_combo.Items.Add("3");
            pa4_2_combo.SelectedIndex = 0;
            pa4_3_combo.Items.Add("1");
            pa4_3_combo.Items.Add("2");
            pa4_3_combo.Items.Add("3");
            pa4_3_combo.SelectedIndex = 0;
            pa4_4_combo.Items.Add("1");
            pa4_4_combo.Items.Add("2");
            pa4_4_combo.Items.Add("3");
            pa4_4_combo.SelectedIndex = 0;
            pa4_5_combo.Items.Add("1");
            pa4_5_combo.Items.Add("2");
            pa4_5_combo.Items.Add("3");
            pa4_5_combo.SelectedIndex = 0;
            pa4_6_combo.Items.Add("1");
            pa4_6_combo.Items.Add("2");
            pa4_6_combo.Items.Add("3");
            pa4_6_combo.SelectedIndex = 0;
        }

        private void pa4_1_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pa4_1_combo.SelectedIndex == 0)
            {
                pa4_1_r1_a.IsEnabled = false;
                pa4_1_r1_a.Opacity = 0.5;
                pa4_1_r1_a.Text = "0";
                pa4_1_r2_a.IsEnabled = false;
                pa4_1_r2_a.Opacity = 0.5;
                pa4_1_r2_a.Text = "0";
                pa4_1_r1_t.IsEnabled = false;
                pa4_1_r1_t.Opacity = 0.5;
                pa4_1_r1_t.Text = "0";
                pa4_1_r2_t.IsEnabled = false;
                pa4_1_r2_t.Opacity = 0.5;
                pa4_1_r2_t.Text = "0";
            }
            else if(pa4_1_combo.SelectedIndex == 1)
            {
                pa4_1_r1_a.IsEnabled = false;
                pa4_1_r1_a.Opacity = 0.5;
                pa4_1_r1_a.Text = "0";
                pa4_1_r2_a.IsEnabled = true;
                pa4_1_r2_a.Opacity = 1;
                pa4_1_r1_t.IsEnabled = false;
                pa4_1_r1_t.Opacity = 0.5;
                pa4_1_r1_t.Text = "0";
                pa4_1_r2_t.IsEnabled = true;
                pa4_1_r2_t.Opacity = 1;
            }
            else if (pa4_1_combo.SelectedIndex == 2)
            {
                pa4_1_r1_a.IsEnabled = true;
                pa4_1_r1_a.Opacity = 1;
                pa4_1_r2_a.IsEnabled = true;
                pa4_1_r2_a.Opacity = 1;
                pa4_1_r1_t.IsEnabled = true;
                pa4_1_r1_t.Opacity = 1;
                pa4_1_r2_t.IsEnabled = true;
                pa4_1_r2_t.Opacity = 1;
            }
        }

        private void pa4_2_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pa4_2_combo.SelectedIndex == 0)
            {
                pa4_2_r1_a.IsEnabled = false;
                pa4_2_r1_a.Opacity = 0.5;
                pa4_2_r1_a.Text = "0";
                pa4_2_r2_a.IsEnabled = false;
                pa4_2_r2_a.Opacity = 0.5;
                pa4_2_r2_a.Text = "0";
                pa4_2_r1_t.IsEnabled = false;
                pa4_2_r1_t.Opacity = 0.5;
                pa4_2_r1_t.Text = "0";
                pa4_2_r2_t.IsEnabled = false;
                pa4_2_r2_t.Opacity = 0.5;
                pa4_2_r2_t.Text = "0";
            }
            else if (pa4_2_combo.SelectedIndex == 1)
            {
                pa4_2_r1_a.IsEnabled = false;
                pa4_2_r1_a.Opacity = 0.5;
                pa4_2_r1_a.Text = "0";
                pa4_2_r2_a.IsEnabled = true;
                pa4_2_r2_a.Opacity = 1;
                pa4_2_r1_t.IsEnabled = false;
                pa4_2_r1_t.Opacity = 0.5;
                pa4_2_r1_t.Text = "0";
                pa4_2_r2_t.IsEnabled = true;
                pa4_2_r2_t.Opacity = 1;
            }
            else if (pa4_2_combo.SelectedIndex == 2)
            {
                pa4_2_r1_a.IsEnabled = true;
                pa4_2_r1_a.Opacity = 1;
                pa4_2_r2_a.IsEnabled = true;
                pa4_2_r2_a.Opacity = 1;
                pa4_2_r1_t.IsEnabled = true;
                pa4_2_r1_t.Opacity = 1;
                pa4_2_r2_t.IsEnabled = true;
                pa4_2_r2_t.Opacity = 1;
            }        
        }

        private void pa4_3_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pa4_3_combo.SelectedIndex == 0)
            {
                pa4_3_r1_a.IsEnabled = false;
                pa4_3_r1_a.Opacity = 0.5;
                pa4_3_r1_a.Text = "0";
                pa4_3_r2_a.IsEnabled = false;
                pa4_3_r2_a.Opacity = 0.5;
                pa4_3_r2_a.Text = "0";
                pa4_3_r1_t.IsEnabled = false;
                pa4_3_r1_t.Opacity = 0.5;
                pa4_3_r1_t.Text = "0";
                pa4_3_r2_t.IsEnabled = false;
                pa4_3_r2_t.Opacity = 0.5;
                pa4_3_r2_t.Text = "0";
            }
            else if (pa4_3_combo.SelectedIndex == 1)
            {
                pa4_3_r1_a.IsEnabled = false;
                pa4_3_r1_a.Opacity = 0.5;
                pa4_3_r1_a.Text = "0";
                pa4_3_r2_a.IsEnabled = true;
                pa4_3_r2_a.Opacity = 1;
                pa4_3_r1_t.IsEnabled = false;
                pa4_3_r1_t.Opacity = 0.5;
                pa4_3_r1_t.Text = "0";
                pa4_3_r2_t.IsEnabled = true;
                pa4_3_r2_t.Opacity = 1;
            }
            else if (pa4_3_combo.SelectedIndex == 2)
            {
                pa4_3_r1_a.IsEnabled = true;
                pa4_3_r1_a.Opacity = 1;
                pa4_3_r2_a.IsEnabled = true;
                pa4_3_r2_a.Opacity = 1;
                pa4_3_r1_t.IsEnabled = true;
                pa4_3_r1_t.Opacity = 1;
                pa4_3_r2_t.IsEnabled = true;
                pa4_3_r2_t.Opacity = 1;
            }
        }

        private void pa4_4_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pa4_4_combo.SelectedIndex == 0)
            {
                pa4_4_r1_a.IsEnabled = false;
                pa4_4_r1_a.Opacity = 0.5;
                pa4_4_r1_a.Text = "0";
                pa4_4_r2_a.IsEnabled = false;
                pa4_4_r2_a.Opacity = 0.5;
                pa4_4_r2_a.Text = "0";
                pa4_4_r1_t.IsEnabled = false;
                pa4_4_r1_t.Opacity = 0.5;
                pa4_4_r1_t.Text = "0";
                pa4_4_r2_t.IsEnabled = false;
                pa4_4_r2_t.Opacity = 0.5;
                pa4_4_r2_t.Text = "0";
            }
            else if (pa4_4_combo.SelectedIndex == 1)
            {
                pa4_4_r1_a.IsEnabled = false;
                pa4_4_r1_a.Opacity = 0.5;
                pa4_4_r1_a.Text = "0";
                pa4_4_r2_a.IsEnabled = true;
                pa4_4_r2_a.Opacity = 1;
                pa4_4_r1_t.IsEnabled = false;
                pa4_4_r1_t.Opacity = 0.5;
                pa4_4_r1_t.Text = "0";
                pa4_4_r2_t.IsEnabled = true;
                pa4_4_r2_t.Opacity = 1;
            }
            else if (pa4_4_combo.SelectedIndex == 2)
            {
                pa4_4_r1_a.IsEnabled = true;
                pa4_4_r1_a.Opacity = 1;
                pa4_4_r2_a.IsEnabled = true;
                pa4_4_r2_a.Opacity = 1;
                pa4_4_r1_t.IsEnabled = true;
                pa4_4_r1_t.Opacity = 1;
                pa4_4_r2_t.IsEnabled = true;
                pa4_4_r2_t.Opacity = 1;
            }
        }

        private void pa4_5_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pa4_5_combo.SelectedIndex == 0)
            {
                pa4_5_r1_a.IsEnabled = false;
                pa4_5_r1_a.Opacity = 0.5;
                pa4_5_r1_a.Text = "0";
                pa4_5_r2_a.IsEnabled = false;
                pa4_5_r2_a.Opacity = 0.5;
                pa4_5_r2_a.Text = "0";
                pa4_5_r1_t.IsEnabled = false;
                pa4_5_r1_t.Opacity = 0.5;
                pa4_5_r1_t.Text = "0";
                pa4_5_r2_t.IsEnabled = false;
                pa4_5_r2_t.Opacity = 0.5;
                pa4_5_r2_t.Text = "0";
            }
            else if (pa4_5_combo.SelectedIndex == 1)
            {
                pa4_5_r1_a.IsEnabled = false;
                pa4_5_r1_a.Opacity = 0.5;
                pa4_5_r1_a.Text = "0";
                pa4_5_r2_a.IsEnabled = true;
                pa4_5_r2_a.Opacity = 1;
                pa4_5_r1_t.IsEnabled = false;
                pa4_5_r1_t.Opacity = 0.5;
                pa4_5_r1_t.Text = "0";
                pa4_5_r2_t.IsEnabled = true;
                pa4_5_r2_t.Opacity = 1;
            }
            else if (pa4_5_combo.SelectedIndex == 2)
            {
                pa4_5_r1_a.IsEnabled = true;
                pa4_5_r1_a.Opacity = 1;
                pa4_5_r2_a.IsEnabled = true;
                pa4_5_r2_a.Opacity = 1;
                pa4_5_r1_t.IsEnabled = true;
                pa4_5_r1_t.Opacity = 1;
                pa4_5_r2_t.IsEnabled = true;
                pa4_5_r2_t.Opacity = 1;
            }
        }

        private void pa4_6_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pa4_6_combo.SelectedIndex == 0)
            {
                pa4_6_r1_a.IsEnabled = false;
                pa4_6_r1_a.Opacity = 0.5;
                pa4_6_r1_a.Text = "0";
                pa4_6_r2_a.IsEnabled = false;
                pa4_6_r2_a.Opacity = 0.5;
                pa4_6_r2_a.Text = "0";
                pa4_6_r1_t.IsEnabled = false;
                pa4_6_r1_t.Opacity = 0.5;
                pa4_6_r1_t.Text = "0";
                pa4_6_r2_t.IsEnabled = false;
                pa4_6_r2_t.Opacity = 0.5;
                pa4_6_r2_t.Text = "0";
            }
            else if (pa4_6_combo.SelectedIndex == 1)
            {
                pa4_6_r1_a.IsEnabled = false;
                pa4_6_r1_a.Opacity = 0.5;
                pa4_6_r1_a.Text = "0";
                pa4_6_r2_a.IsEnabled = true;
                pa4_6_r2_a.Opacity = 1;
                pa4_6_r1_t.IsEnabled = false;
                pa4_6_r1_t.Opacity = 0.5;
                pa4_6_r1_t.Text = "0";
                pa4_6_r2_t.IsEnabled = true;
                pa4_6_r2_t.Opacity = 1;
            }
            else if (pa4_6_combo.SelectedIndex == 2)
            {
                pa4_6_r1_a.IsEnabled = true;
                pa4_6_r1_a.Opacity = 1;
                pa4_6_r2_a.IsEnabled = true;
                pa4_6_r2_a.Opacity = 1;
                pa4_6_r1_t.IsEnabled = true;
                pa4_6_r1_t.Opacity = 1;
                pa4_6_r2_t.IsEnabled = true;
                pa4_6_r2_t.Opacity = 1;
            }
        }
    }
}
