using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using RealTimeGraphX;
using RealTimeGraphX.DataPoints;
using RealTimeGraphX.Renderers;
using RealTimeGraphX.WPF;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows;

public class AsyncStateData
{
    public byte[] Buffer;
    public Socket Socket;
}

namespace MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _data1;
        private string _data2;
        private string _data3;
        private string _data4;

        public string data1
        {
            get { return _data1; }
            set
            {
                _data1 = value;
                RaisePropertyChanged("data1");
            }
        }

        public string data2
        {
            get { return _data2; }
            set
            {
                _data2 = value;
                RaisePropertyChanged("data2");
            }
        }

        public string data3
        {
            get { return _data3; }
            set
            {
                _data3 = value;
                RaisePropertyChanged("data3");
            }
        }

        public string data4
        {
            get { return _data4; }
            set
            {
                _data4 = value;
                RaisePropertyChanged("data4");
            }
        }

        public RelayCommand OnClickCommand { get; set; }
        public WpfGraphController<TimeSpanDataPoint, DoubleDataPoint> MultiController { get; set; }
        public MainViewModel()
        {
            serverConnect();

            OnClickCommand = new RelayCommand(OnClickCommandAction, null);

            MultiController = new WpfGraphController<TimeSpanDataPoint, DoubleDataPoint>();
            MultiController.Range.MinimumY = 0;
            MultiController.Range.MaximumY = 1080;
            MultiController.Range.MaximumX = TimeSpan.FromSeconds(10);
            MultiController.Range.AutoY = true;

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 1",
                Stroke = Colors.Red,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 2",
                Stroke = Colors.Green,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 3",
                Stroke = Colors.Blue,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 4",
                Stroke = Colors.Yellow,
            });

            Stopwatch watch = new Stopwatch();
            watch.Start();

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var d1 = Convert.ToInt32(data1);
                    var d2 = Convert.ToInt32(data2);
                    var d3 = Convert.ToInt32(data3);
                    var d4 = Convert.ToInt32(data4);

                    List<DoubleDataPoint> yy = new List<DoubleDataPoint>()
                    {
                        d1,
                        d2,
                        d3,
                        d4
                    };

                    var x = watch.Elapsed;

                    List<TimeSpanDataPoint> xx = new List<TimeSpanDataPoint>()
                    {
                        x,
                        x,
                        x,
                        x
                    };

                    MultiController.PushData(xx, yy);

                    Thread.Sleep(30);
                }
            });
        }

        private void OnClickCommandAction()
        {
            /*var viewModelMessage = new ViewModelMessage()
            {
                Text = TextBoxText
            };

            Messenger.Default.Send(viewModelMessage);*/

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 11200);
            socket.Connect(serverEP);

            //int num = Convert.ToInt32(TextBoxText);

            byte[] byteSend = new byte[4];
            byteSend[0] = 0x41;
            byteSend[1] = 0x42;
            byteSend[2] = 0x43;
            byteSend[3] = 0x44;//Convert.ToByte(num);

            socket.Send(byteSend);
        }

        private void serverConnect()
        {
            Thread serverThread = new Thread(serverFunc);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void serverFunc(object obj)
        {
            using (Socket srvSocket =
            new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 11200);
                srvSocket.Bind(endPoint);

                srvSocket.Listen(10);
                while (true)
                {
                    Socket clntSocket = srvSocket.Accept();
                    AsyncStateData data = new AsyncStateData();
                    data.Buffer = new byte[1024];
                    data.Socket = clntSocket;
                    clntSocket.BeginReceive(data.Buffer, 0, data.Buffer.Length,
                    SocketFlags.None, new AsyncCallback(asyncReceiveCallback), data);
                }
            }
        }

        private void asyncReceiveCallback(IAsyncResult asyncResult)
        {
            AsyncStateData rcvData = asyncResult.AsyncState as AsyncStateData;
            float ByteToFloat = BitConverter.ToUInt16(rcvData.Buffer, 2);

            string string1 = string.Format("{0:x2}", rcvData.Buffer[0]);
            string string2 = string.Format("{0:x2}", rcvData.Buffer[1]);
            string string3 = string.Format("{0:x2}", rcvData.Buffer[2]);
            string string4 = string.Format("{0:x2}", rcvData.Buffer[3]);
            data1 = string1;
            data2 = string2;
            data3 = string3;
            data4 = string4;
        }
    }
}