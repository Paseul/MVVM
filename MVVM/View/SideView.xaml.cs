using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO.Ports;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using GalaSoft.MvvmLight.Messaging;

namespace MVVM.View
{
    /// <summary>
    /// SideView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SideView : UserControl
    {
        SerialPort serial = new SerialPort();
        public SideView()
        {
            InitializeComponent();
        }
    }
}
