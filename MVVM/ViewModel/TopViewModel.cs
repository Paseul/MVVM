using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVM.Messages;
namespace MVVM.ViewModel
{
    public class TopViewModel : ViewModelBase
    {
        public RelayCommand OnResetCommand { get; set; }

        private float _pd7;
        public float Pd7
        {
            get { return _pd7; }
            set
            {
                _pd7 = value;
                NotifyPropertyChanged("Pd7");
            }
        }
        private float _paTemp13;
        public float PaTemp13
        {
            get { return _paTemp13; }
            set
            {
                _paTemp13 = value;
                NotifyPropertyChanged("PaTemp13");
            }
        }
        private float _seedHumid;
        public float SeedHumid
        {
            get { return _seedHumid; }
            set
            {
                _seedHumid = value;
                NotifyPropertyChanged("SeedHumid");
            }
        }
        private float _paHumid;
        public float PaHumid
        {
            get { return _paHumid; }
            set
            {
                _paHumid = value;
                NotifyPropertyChanged("PaHumid");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public TopViewModel()
        {
            Messenger.Default.Register<monValue>(this, OnReceiveMessageAction);
            OnResetCommand = new RelayCommand(OnResetCommandAction, null);
        }

        private void OnReceiveMessageAction(monValue obj)
        {
            Pd7 = obj.Pd7;
            PaTemp13 = obj.PaTemp13;
            PaHumid = obj.PaHumid;
        }

        private void OnResetCommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "resetOn",
            };
            Messenger.Default.Send(lcb002Cmd);
        }
    }
}
