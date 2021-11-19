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
    /// BitView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BitView : UserControl
    {
        public BitView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SeedStatus seedStatusWindow = new SeedStatus();
            seedStatusWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AmpCurrent ampCurrentWindow = new AmpCurrent();
            ampCurrentWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AmpVoltage ampVoltageWindow = new AmpVoltage();
            ampVoltageWindow.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AmpPD ampPDWindow = new AmpPD();
            ampPDWindow.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AmpTemp ampTempWindow = new AmpTemp();
            ampTempWindow.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            PowerBit powerBitWindow = new PowerBit();
            powerBitWindow.Show();
        }
    }
}
