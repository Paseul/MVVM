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
        
        
        public MainViewModel()
        {
                
        }      

        
    }
}