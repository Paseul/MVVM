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
        }


        private void pa1_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pa1_btn.Content == FindResource("pa1_base"))
            {
                pa1_btn.Content = FindResource("pa1_normal");
            }
            else
            {
                pa1_btn.Content = FindResource("pa1_base");
            }
        }
    }
}
