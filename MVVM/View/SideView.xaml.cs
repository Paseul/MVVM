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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] bytesToSend = new byte[13] { 0x02, 0x31, 0x35, 0x30, 0x31, 0x30, 0x35, 0x2B, 0x32, 0x30, 0x2E, 0x31, 0x03 };
            serial.Write(bytesToSend, 0, bytesToSend.Length);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Sets up serial port
            serial.PortName = "COM3";
            serial.BaudRate = 19200;
            serial.Handshake = System.IO.Ports.Handshake.None;
            serial.Parity = Parity.None;
            serial.DataBits = 8;
            serial.StopBits = StopBits.Two;
            serial.ReadTimeout = 200;
            serial.WriteTimeout = 50;
            serial.Open();

            serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Recieve);
        }

        private delegate void UpdateUiTextDelegate(string text);
        private void Recieve(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort port = (SerialPort)sender;

            int bytes = port.BytesToRead;
            byte[] buffer = new byte[bytes];

            if (port.BytesToRead > 1)
            {
                port.Read(buffer, 0, bytes);
            }

            ASCIIEncoding ascii = new ASCIIEncoding();

            byte[] smallPortion = buffer.Skip(1).Take(3).ToArray();
            byte[] largeBytes = buffer.Skip(7).Take(5).ToArray();

            String decoded2 = ascii.GetString(smallPortion);
            String decoded3 = ascii.GetString(largeBytes);
            if(decoded2 == "150" && buffer.Length == 13)
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { chiller_ch1_temp_rcv.Text = decoded3; }));
            }            
        }
    }
}
