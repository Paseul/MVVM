using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
using MVVM.Messages;
using System.Collections;

public class AsyncStateData
{
    public byte[] Buffer;
    public Socket Socket;
}

namespace MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        

        private BitArray _barray;
        public BitArray barray
        {
            get { return _barray; }
            set
            {
                _barray = value;
                RaisePropertyChanged("count");
            }
        }

        

        #region Fields
        /*private IDataService dataservice = new DataService();*/
        private SolidColorBrush colorBrush;
        #endregion

        #region Properties
        public SolidColorBrush ColorBrush
        {
            get { return colorBrush; }
            set
            {
                colorBrush = value;
                RaisePropertyChanged("ColorBrush");
            }

        }
        #endregion

        public RelayCommand OnClickCommand { get; set; }
        
        public MainViewModel()
        {
            serverConnect();

            OnClickCommand = new RelayCommand(OnClickCommandAction, null);

            
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

            byte[] byteSend = new byte[5];
            byteSend[0] = 0x41;
            byteSend[1] = 0x42;
            byteSend[2] = 0x43;
            byteSend[3] = 0x44;//Convert.ToByte(num);
            byteSend[4] = 0xf5;

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

            var viewModelMessage = new ViewModelMessage()
            {
                d1 = string.Format("{0:x2}", rcvData.Buffer[0]),
                d2 = string.Format("{0:x2}", rcvData.Buffer[1]),
                d3 = string.Format("{0:x2}", rcvData.Buffer[2]),
                d4 = string.Format("{0:x2}", rcvData.Buffer[3]),
                ba = rcvData.Buffer[4]
            };

            Messenger.Default.Send(viewModelMessage);
        }
    }
}