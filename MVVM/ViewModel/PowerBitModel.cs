using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MVVM.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class PowerBitModel : ViewModelBase, INotifyPropertyChanged
    {
        private bool _vacVoltHigh;
        public bool VacVoltHigh
        {
            get { return _vacVoltHigh; }
            set
            {
                _vacVoltHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _vacVoltLow;
        public bool VacVoltLow
        {
            get { return _vacVoltLow; }
            set
            {
                _vacVoltLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _vacCurrHigh;
        public bool VacCurrHigh
        {
            get { return _vacCurrHigh; }
            set
            {
                _vacCurrHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _vacCurrLow;
        public bool VacCurrLow
        {
            get { return _vacCurrLow; }
            set
            {
                _vacCurrLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pbVoltHigh;
        public bool PbVoltHigh
        {
            get { return _pbVoltHigh; }
            set
            {
                _pbVoltHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pbVoltLow;
        public bool PbVoltLow
        {
            get { return _pbVoltLow; }
            set
            {
                _pbVoltLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pbCurrHigh;
        public bool PbCurrHigh
        {
            get { return _pbCurrHigh; }
            set
            {
                _pbCurrHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pbCurrLow;
        public bool PbCurrLow
        {
            get { return _pbCurrLow; }
            set
            {
                _pbCurrLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp1_2VoltHigh;
        public bool Amp1_2VoltHigh
        {
            get { return _amp1_2VoltHigh; }
            set
            {
                _amp1_2VoltHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp1_2VoltLow;
        public bool Amp1_2VoltLow
        {
            get { return _amp1_2VoltLow; }
            set
            {
                _amp1_2VoltLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp1_2CurrHigh;
        public bool Amp1_2CurrHigh
        {
            get { return _amp1_2CurrHigh; }
            set
            {
                _amp1_2CurrHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp1_2CurrLow;
        public bool Amp1_2CurrLow
        {
            get { return _amp1_2CurrLow; }
            set
            {
                _amp1_2CurrLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp3VoltHigh;
        public bool Amp3VoltHigh
        {
            get { return _amp3VoltHigh; }
            set
            {
                _amp3VoltHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp3VoltLow;
        public bool Amp3VoltLow
        {
            get { return _amp3VoltLow; }
            set
            {
                _amp3VoltLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp3CurrHigh;
        public bool Amp3CurrHigh
        {
            get { return _amp3CurrHigh; }
            set
            {
                _amp3CurrHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp3CurrLow;
        public bool Amp3CurrLow
        {
            get { return _amp3CurrLow; }
            set
            {
                _amp3CurrLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_1VoltHigh;
        public bool Amp4_1VoltHigh
        {
            get { return _amp4_1VoltHigh; }
            set
            {
                _amp4_1VoltHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_1VoltLow;
        public bool Amp4_1VoltLow
        {
            get { return _amp4_1VoltLow; }
            set
            {
                _amp4_1VoltLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_1CurrHigh;
        public bool Amp4_1CurrHigh
        {
            get { return _amp4_1CurrHigh; }
            set
            {
                _amp4_1CurrHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_1CurrLow;
        public bool Amp4_1CurrLow
        {
            get { return _amp4_1CurrLow; }
            set
            {
                _amp4_1CurrLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_2VoltHigh;
        public bool Amp4_2VoltHigh
        {
            get { return _amp4_2VoltHigh; }
            set
            {
                _amp4_2VoltHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_2VoltLow;
        public bool Amp4_2VoltLow
        {
            get { return _amp4_2VoltLow; }
            set
            {
                _amp4_2VoltLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_2CurrHigh;
        public bool Amp4_2CurrHigh
        {
            get { return _amp4_2CurrHigh; }
            set
            {
                _amp4_2CurrHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_2CurrLow;
        public bool Amp4_2CurrLow
        {
            get { return _amp4_2CurrLow; }
            set
            {
                _amp4_2CurrLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_3VoltHigh;
        public bool Amp4_3VoltHigh
        {
            get { return _amp4_3VoltHigh; }
            set
            {
                _amp4_3VoltHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_3VoltLow;
        public bool Amp4_3VoltLow
        {
            get { return _amp4_3VoltLow; }
            set
            {
                _amp4_3VoltLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_3CurrHigh;
        public bool Amp4_3CurrHigh
        {
            get { return _amp4_3CurrHigh; }
            set
            {
                _amp4_3CurrHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_3CurrLow;
        public bool Amp4_3CurrLow
        {
            get { return _amp4_3CurrLow; }
            set
            {
                _amp4_3CurrLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_4VoltHigh;
        public bool Amp4_4VoltHigh
        {
            get { return _amp4_4VoltHigh; }
            set
            {
                _amp4_4VoltHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_4VoltLow;
        public bool Amp4_4VoltLow
        {
            get { return _amp4_4VoltLow; }
            set
            {
                _amp4_4VoltLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_4CurrHigh;
        public bool Amp4_4CurrHigh
        {
            get { return _amp4_4CurrHigh; }
            set
            {
                _amp4_4CurrHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_4CurrLow;
        public bool Amp4_4CurrLow
        {
            get { return _amp4_4CurrLow; }
            set
            {
                _amp4_4CurrLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_5VoltHigh;
        public bool Amp4_5VoltHigh
        {
            get { return _amp4_5VoltHigh; }
            set
            {
                _amp4_5VoltHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_5VoltLow;
        public bool Amp4_5VoltLow
        {
            get { return _amp4_5VoltLow; }
            set
            {
                _amp4_5VoltLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_5CurrHigh;
        public bool Amp4_5CurrHigh
        {
            get { return _amp4_5CurrHigh; }
            set
            {
                _amp4_5CurrHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_5CurrLow;
        public bool Amp4_5CurrLow
        {
            get { return _amp4_5CurrLow; }
            set
            {
                _amp4_5CurrLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_6VoltHigh;
        public bool Amp4_6VoltHigh
        {
            get { return _amp4_6VoltHigh; }
            set
            {
                _amp4_6VoltHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_6VoltLow;
        public bool Amp4_6VoltLow
        {
            get { return _amp4_6VoltLow; }
            set
            {
                _amp4_6VoltLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_6CurrHigh;
        public bool Amp4_6CurrHigh
        {
            get { return _amp4_6CurrHigh; }
            set
            {
                _amp4_6CurrHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4_6CurrLow;
        public bool Amp4_6CurrLow
        {
            get { return _amp4_6CurrLow; }
            set
            {
                _amp4_6CurrLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _tempHigh;
        public bool TempHigh
        {
            get { return _tempHigh; }
            set
            {
                _tempHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _tempLow;
        public bool TempLow
        {
            get { return _tempLow; }
            set
            {
                _tempLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _humidityHigh;
        public bool HumidityHigh
        {
            get { return _humidityHigh; }
            set
            {
                _humidityHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _humidityLow;
        public bool HumidityLow
        {
            get { return _humidityLow; }
            set
            {
                _humidityLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _e_stop;
        public bool E_stop
        {
            get { return _e_stop; }
            set
            {
                _e_stop = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public PowerBitModel()
        {
            Messenger.Default.Register<dcpBit>(this, OnReceiveMessageAction);
        }

        private void OnReceiveMessageAction(dcpBit obj)
        {
            VacVoltHigh = obj.vacVoltHigh;
            VacVoltLow = obj.vacVoltLow;
            VacCurrHigh = obj.vacCurrHigh;
            VacCurrLow = obj.vacCurrLow;
            PbVoltHigh = obj.pbVoltHigh;
            PbVoltLow = obj.pbVoltLow;
            PbCurrHigh = obj.pbCurrHigh;
            PbCurrLow = obj.pbCurrLow;
            Amp1_2VoltHigh = obj.amp1_2VoltHigh;
            Amp1_2VoltLow = obj.amp1_2VoltLow;
            Amp1_2CurrHigh = obj.amp1_2CurrHigh;
            Amp1_2CurrLow = obj.amp1_2CurrLow;
            Amp3VoltHigh = obj.amp3VoltHigh;
            Amp3VoltLow = obj.amp3VoltLow;
            Amp3CurrHigh = obj.amp3CurrHigh;
            Amp3CurrLow = obj.amp3CurrLow;
            Amp4_1VoltHigh = obj.amp4_1VoltHigh;
            Amp4_1VoltLow = obj.amp4_1VoltLow;
            Amp4_1CurrHigh = obj.amp4_1CurrHigh;
            Amp4_1CurrLow = obj.amp4_1CurrLow;
            Amp4_2VoltHigh = obj.amp4_2VoltHigh;
            Amp4_2VoltLow = obj.amp4_2VoltLow;
            Amp4_2CurrHigh = obj.amp4_2CurrHigh;
            Amp4_2CurrLow = obj.amp4_2CurrLow;
            Amp4_3VoltHigh = obj.amp4_3VoltHigh;
            Amp4_3VoltLow = obj.amp4_3VoltLow;
            Amp4_3CurrHigh = obj.amp4_3CurrHigh;
            Amp4_3CurrLow = obj.amp4_3CurrLow;
            Amp4_4VoltHigh = obj.amp4_4VoltHigh;
            Amp4_4VoltLow = obj.amp4_4VoltLow;
            Amp4_4CurrHigh = obj.amp4_4CurrHigh;
            Amp4_4CurrLow = obj.amp4_4CurrLow;
            Amp4_5VoltHigh = obj.amp4_5VoltHigh;
            Amp4_5VoltLow = obj.amp4_5VoltLow;
            Amp4_5CurrHigh = obj.amp4_5CurrHigh;
            Amp4_5CurrLow = obj.amp4_5CurrLow;
            Amp4_6VoltHigh = obj.amp4_6VoltHigh;
            Amp4_6VoltLow = obj.amp4_6VoltLow;
            Amp4_6CurrHigh = obj.amp4_6CurrHigh;
            Amp4_6CurrLow = obj.amp4_6CurrLow;
            TempHigh = obj.tempHigh;
            TempLow = obj.tempLow;
            HumidityHigh = obj.humidityHigh;
            HumidityLow = obj.humidityLow;
            E_stop = obj.e_stop;
        }
    }
}
