using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVM.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.ViewModel
{
    public class ControlViewModel : ViewModelBase
    {
        public RelayCommand OnClickCommand { get; set; }

        public Socket client = null;

        private static ManualResetEvent connectDone =
        new ManualResetEvent(false);

        public ControlViewModel()
        {
            serverConnect();

            OnClickCommand = new RelayCommand(OnClickCommandAction, null);
        }

        private void OnClickCommandAction()
        {

/*            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);*/

/*            EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 11200);
            socket.Connect(serverEP);

            byte[] byteSend = new byte[5];
            byteSend[0] = 0x41;
            byteSend[1] = 0x42;
            byteSend[2] = 0x43;
            byteSend[3] = 0x44;
            byteSend[4] = 0xf5;

            socket.Send(byteSend);*/
        }

        private void serverConnect()
        {
            Thread serverThread = new Thread(serverFunc);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void serverFunc(object obj)
        {
            /*            using (Socket srvSocket =
                        new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                        {
                            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 11200);
                            srvSocket.Bind(endPoint);

                            srvSocket.Listen(10);
                            Socket clntSocket = srvSocket.Accept();


                        }*/

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);

            client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            AsyncStateData data = new AsyncStateData();
            client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.  
            client.BeginConnect(remoteEP,
                new AsyncCallback(ConnectCallback), client);
            connectDone.WaitOne();

            data.Buffer = new byte[1024];
            data.Socket = client;
            client.BeginReceive(data.Buffer, 0, data.Buffer.Length,
            SocketFlags.None, new AsyncCallback(asyncReceiveCallback), data);
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void asyncReceiveCallback(IAsyncResult asyncResult)
        {
            AsyncStateData data = (AsyncStateData)asyncResult.AsyncState;
            Socket client = data.Socket;

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

            //Thread.Sleep(100);
            data.Buffer = new byte[1024];
            data.Socket = client;
            client.BeginReceive(data.Buffer, 0, data.Buffer.Length,
                    SocketFlags.None, new AsyncCallback(asyncReceiveCallback), data);
        }        
    }
}
