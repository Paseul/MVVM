using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVM.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.ViewModel
{
    public class ControlViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public RelayCommand OnClickCommand { get; set; }


        private float _seedCurrent;

        public float SeedCurrent
        {
            get { return _seedCurrent; }
            set
            {
                _seedCurrent = value;
                NotifyPropertyChanged();
            }
        }
        private float _seedTemp;
        public float SeedTemp
        {
            get { return _seedTemp; }
            set
            {
                _seedTemp = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa1Current;
        public float Pa1Current
        {
            get { return _pa1Current; }
            set
            {
                _pa1Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa2Current;
        public float Pa2Current
        {
            get { return _pa2Current; }
            set
            {
                _pa2Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa3Current;
        public float Pa3Current
        {
            get { return _pa3Current; }
            set
            {
                _pa3Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1Current;
        public float Pa4_1Current
        {
            get { return _pa4_1Current; }
            set
            {
                _pa4_1Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2Current;
        public float Pa4_2Current
        {
            get { return _pa4_2Current; }
            set
            {
                _pa4_2Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3Current;
        public float Pa4_3Current
        {
            get { return _pa4_3Current; }
            set
            {
                _pa4_3Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4Current;
        public float Pa4_4Current
        {
            get { return _pa4_4Current; }
            set
            {
                _pa4_4Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5Current;
        public float Pa4_5Current
        {
            get { return _pa4_5Current; }
            set
            {
                _pa4_5Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6Current;
        public float Pa4_6Current
        {
            get { return _pa4_6Current; }
            set
            {
                _pa4_6Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa1Voltage;
        public float Pa1Voltage
        {
            get { return _pa1Voltage; }
            set
            {
                _pa1Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa2Voltage;
        public float Pa2Voltage
        {
            get { return _pa2Voltage; }
            set
            {
                _pa2Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa3Voltage;
        public float Pa3Voltage
        {
            get { return _pa3Voltage; }
            set
            {
                _pa3Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1Voltage;
        public float Pa4_1Voltage
        {
            get { return _pa4_1Voltage; }
            set
            {
                _pa4_1Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2Voltage;
        public float Pa4_2Voltage
        {
            get { return _pa4_2Voltage; }
            set
            {
                _pa4_2Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3Voltage;
        public float Pa4_3Voltage
        {
            get { return _pa4_3Voltage; }
            set
            {
                _pa4_3Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4Voltage;
        public float Pa4_4Voltage
        {
            get { return _pa4_4Voltage; }
            set
            {
                _pa4_4Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5Voltage;
        public float Pa4_5Voltage
        {
            get { return _pa4_5Voltage; }
            set
            {
                _pa4_5Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6Voltage;
        public float Pa4_6Voltage
        {
            get { return _pa4_6Voltage; }
            set
            {
                _pa4_6Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _pd1;
        public float Pd1
        {
            get { return _pd1; }
            set
            {
                _pd1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pd2;
        public float Pd2
        {
            get { return _pd2; }
            set
            {
                _pd2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pd3;
        public float Pd3
        {
            get { return _pd3; }
            set
            {
                _pd3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pd4;
        public float Pd4
        {
            get { return _pd4; }
            set
            {
                _pd4 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pd5;
        public float Pd5
        {
            get { return _pd5; }
            set
            {
                _pd5 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pd6;
        public float Pd6
        {
            get { return _pd6; }
            set
            {
                _pd6 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pd7;
        public float Pd7
        {
            get { return _pd7; }
            set
            {
                _pd7 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pd8;
        public float Pd8
        {
            get { return _pd8; }
            set
            {
                _pd8 = value;
                NotifyPropertyChanged();
            }
        }
        private float _seedTemp1;
        public float SeedTemp1
        {
            get { return _seedTemp1; }
            set
            {
                _seedTemp1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _seedTemp2;
        public float SeedTemp2
        {
            get { return _seedTemp2; }
            set
            {
                _seedTemp2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _seedTemp3;
        public float SeedTemp3
        {
            get { return _seedTemp3; }
            set
            {
                _seedTemp3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp1;
        public float PaTemp1
        {
            get { return _paTemp1; }
            set
            {
                _paTemp1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp2;
        public float PaTemp2
        {
            get { return _paTemp2; }
            set
            {
                _paTemp2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp3;
        public float PaTemp3
        {
            get { return _paTemp3; }
            set
            {
                _paTemp3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp4;
        public float PaTemp4
        {
            get { return _paTemp4; }
            set
            {
                _paTemp4 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp5;
        public float PaTemp5
        {
            get { return _paTemp5; }
            set
            {
                _paTemp5 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp6;
        public float PaTemp6
        {
            get { return _paTemp6; }
            set
            {
                _paTemp6 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp7;
        public float PaTemp7
        {
            get { return _paTemp7; }
            set
            {
                _paTemp7 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp8;
        public float PaTemp8
        {
            get { return _paTemp8; }
            set
            {
                _paTemp8 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp9;
        public float PaTemp9
        {
            get { return _paTemp9; }
            set
            {
                _paTemp9 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp10;
        public float PaTemp10
        {
            get { return _paTemp10; }
            set
            {
                _paTemp10 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp11;
        public float PaTemp11
        {
            get { return _paTemp11; }
            set
            {
                _paTemp11 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp12;
        public float PaTemp12
        {
            get { return _paTemp12; }
            set
            {
                _paTemp12 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp13;
        public float PaTemp13
        {
            get { return _paTemp13; }
            set
            {
                _paTemp13 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp14;
        public float PaTemp14
        {
            get { return _paTemp14; }
            set
            {
                _paTemp14 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp15;
        public float PaTemp15
        {
            get { return _paTemp15; }
            set
            {
                _paTemp15 = value;
                NotifyPropertyChanged();
            }
        }
        private float _paTemp16;
        public float PaTemp16
        {
            get { return _paTemp16; }
            set
            {
                _paTemp16 = value;
                NotifyPropertyChanged();
            }
        }
        private float _rfVolt;
        public float RfVolt
        {
            get { return _rfVolt; }
            set
            {
                _rfVolt = value;
                NotifyPropertyChanged();
            }
        }
        private float _seedHumid;
        public float SeedHumid
        {
            get { return _seedHumid; }
            set
            {
                _seedHumid = value;
                NotifyPropertyChanged();
            }
        }
        private float _paHumid;
        public float PaHumid
        {
            get { return _paHumid; }
            set
            {
                _paHumid = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ControlViewModel()
        {

            OnClickCommand = new RelayCommand(OnClickCommandAction, null);

            Messenger.Default.Register<string>(this, MessageReceived);
            Messenger.Default.Register<monValue>(this, OnReceiveMessageAction);
        }

        private void MessageReceived(string message)
        {
            if (message == "seedOn")
            {
                OnClickCommandAction();
            }
        }


        private void OnClickCommandAction()
        {
            SeedCurrent = 124;
        }
        private void OnReceiveMessageAction(monValue obj)
        {
            SeedCurrent = obj.SeedCurrent;
            SeedTemp = obj.SeedTemp;
            Pa1Current = obj.Pa1Current;
            Pa2Current = obj.Pa2Current;
            Pa3Current = obj.Pa3Current;
            Pa4_1Current = obj.Pa4_1Current;
            Pa4_2Current = obj.Pa4_2Current;
            Pa4_3Current = obj.Pa4_3Current;
            Pa4_4Current = obj.Pa4_4Current;
            Pa4_5Current = obj.Pa4_5Current;
            Pa4_6Current = obj.Pa4_6Current;
            Pa1Voltage = obj.Pa1Voltage;
            Pa2Voltage = obj.Pa2Voltage;
            Pa3Voltage = obj.Pa3Voltage;
            Pa4_1Voltage = obj.Pa4_1Voltage;
            Pa4_2Voltage = obj.Pa4_2Voltage;
            Pa4_3Voltage = obj.Pa4_3Voltage;
            Pa4_4Voltage = obj.Pa4_4Voltage;
            Pa4_5Voltage = obj.Pa4_5Voltage;
            Pa4_6Voltage = obj.Pa4_6Voltage;
            Pd1 = obj.Pd1;
            Pd2 = obj.Pd2;
            Pd3 = obj.Pd3;
            Pd4 = obj.Pd4;
            Pd5 = obj.Pd5;
            Pd6 = obj.Pd6;
            Pd7 = obj.Pd7;
            Pd8 = obj.Pd8;
            SeedTemp1 = obj.SeedTemp1;
            SeedTemp2 = obj.SeedTemp2;
            SeedTemp3 = obj.SeedTemp3;
            PaTemp1 = obj.PaTemp1;
            PaTemp2 = obj.PaTemp2;
            PaTemp3 = obj.PaTemp3;
            PaTemp4 = obj.PaTemp4;
            PaTemp5 = obj.PaTemp5;
            PaTemp6 = obj.PaTemp6;
            PaTemp7 = obj.PaTemp7;
            PaTemp8 = obj.PaTemp8;
            PaTemp9 = obj.PaTemp9;
            PaTemp10 = obj.PaTemp10;
            PaTemp11 = obj.PaTemp11;
            PaTemp12 = obj.PaTemp12;
            PaTemp13 = obj.PaTemp13;
            PaTemp14 = obj.PaTemp14;
            PaTemp15 = obj.PaTemp15;
            PaTemp16 = obj.PaTemp16;
            RfVolt = obj.RfVolt;
            SeedHumid = obj.SeedHumid;
            PaHumid = obj.PaHumid;
        }



    }
}
