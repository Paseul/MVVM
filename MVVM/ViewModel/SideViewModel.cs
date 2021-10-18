using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class SideViewModel : ViewModelBase
    {
        public RelayCommand OnClickCommand { get; set; }

        public Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 11200);

        public bool first = true;
        public int count = 0;
        int d1 = 31;
        int d2 = 32;
        int d3 = 33;
        int d4 = 34;

        public SideViewModel()
        {
            OnClickCommand = new RelayCommand(OnClickCommandAction, null);
        }

        private void OnClickCommandAction()
        {
            if (first == true)
            {
                socket.Connect(serverEP);
                first = false;
            }

            byte[] byteSend = new byte[5];

            d1 = d1 + count;
            d2 = d2 + count;
            d3 = d3 + count;
            d4 = d4 + count;

            byteSend[0] = Convert.ToByte(d1);
            byteSend[1] = Convert.ToByte(d2);
            byteSend[2] = Convert.ToByte(d3);
            byteSend[3] = Convert.ToByte(d4);
            byteSend[4] = 0xf5;

            count += 1;            

            socket.Send(byteSend);
        }
    }
}
