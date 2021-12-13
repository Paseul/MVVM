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
    public class AmpVoltageModel : ViewModelBase, INotifyPropertyChanged
    {
        private bool _pa1VoltageHigh;
        public bool Pa1VoltageHigh
        {
            get { return _pa1VoltageHigh; }
            set
            {
                _pa1VoltageHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa1VoltageLow;
        public bool Pa1VoltageLow
        {
            get { return _pa1VoltageLow; }
            set
            {
                _pa1VoltageLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa2VoltageHigh;
        public bool Pa2VoltageHigh
        {
            get { return _pa2VoltageHigh; }
            set
            {
                _pa2VoltageHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa2VoltageLow;
        public bool Pa2VoltageLow
        {
            get { return _pa2VoltageLow; }
            set
            {
                _pa2VoltageLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa3VoltageHigh;
        public bool Pa3VoltageHigh
        {
            get { return _pa3VoltageHigh; }
            set
            {
                _pa3VoltageHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa3VoltageLow;
        public bool Pa3VoltageLow
        {
            get { return _pa3VoltageLow; }
            set
            {
                _pa3VoltageLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_1VoltageHigh;
        public bool Pa4_1VoltageHigh
        {
            get { return _pa4_1VoltageHigh; }
            set
            {
                _pa4_1VoltageHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_1VoltageLow;
        public bool Pa4_1VoltageLow
        {
            get { return _pa4_1VoltageLow; }
            set
            {
                _pa4_1VoltageLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_2VoltageHigh;
        public bool Pa4_2VoltageHigh
        {
            get { return _pa4_2VoltageHigh; }
            set
            {
                _pa4_2VoltageHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_2VoltageLow;
        public bool Pa4_2VoltageLow
        {
            get { return _pa4_2VoltageLow; }
            set
            {
                _pa4_2VoltageLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_3VoltageHigh;
        public bool Pa4_3VoltageHigh
        {
            get { return _pa4_3VoltageHigh; }
            set
            {
                _pa4_3VoltageHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_3VoltageLow;
        public bool Pa4_3VoltageLow
        {
            get { return _pa4_3VoltageLow; }
            set
            {
                _pa4_3VoltageLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_4VoltageHigh;
        public bool Pa4_4VoltageHigh
        {
            get { return _pa4_4VoltageHigh; }
            set
            {
                _pa4_4VoltageHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_4VoltageLow;
        public bool Pa4_4VoltageLow
        {
            get { return _pa4_4VoltageLow; }
            set
            {
                _pa4_4VoltageLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_5VoltageHigh;
        public bool Pa4_5VoltageHigh
        {
            get { return _pa4_5VoltageHigh; }
            set
            {
                _pa4_5VoltageHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_5VoltageLow;
        public bool Pa4_5VoltageLow
        {
            get { return _pa4_5VoltageLow; }
            set
            {
                _pa4_5VoltageLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_6VoltageHigh;
        public bool Pa4_6VoltageHigh
        {
            get { return _pa4_6VoltageHigh; }
            set
            {
                _pa4_6VoltageHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_6VoltageLow;
        public bool Pa4_6VoltageLow
        {
            get { return _pa4_6VoltageLow; }
            set
            {
                _pa4_6VoltageLow = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public AmpVoltageModel()
        {
            Messenger.Default.Register<errorMon>(this, OnReceiveMessageAction);
        }
        private void OnReceiveMessageAction(errorMon obj)
        {
            Pa1VoltageHigh = obj.Pa1VoltageHigh;
            Pa1VoltageLow = obj.Pa1VoltageLow;
            Pa2VoltageHigh = obj.Pa2VoltageHigh;
            Pa2VoltageLow = obj.Pa2VoltageLow;
            Pa3VoltageHigh = obj.Pa3VoltageHigh;
            Pa3VoltageLow = obj.Pa3VoltageLow;
            Pa4_1VoltageHigh = obj.Pa4_1VoltageHigh;
            Pa4_1VoltageLow = obj.Pa4_1VoltageLow;
            Pa4_2VoltageHigh = obj.Pa4_2VoltageHigh;
            Pa4_2VoltageLow = obj.Pa4_2VoltageLow;
            Pa4_3VoltageHigh = obj.Pa4_3VoltageHigh;
            Pa4_3VoltageLow = obj.Pa4_3VoltageLow;
            Pa4_4VoltageHigh = obj.Pa4_4VoltageHigh;
            Pa4_4VoltageLow = obj.Pa4_4VoltageLow;
            Pa4_5VoltageHigh = obj.Pa4_5VoltageHigh;
            Pa4_5VoltageLow = obj.Pa4_5VoltageLow;
            Pa4_6VoltageHigh = obj.Pa4_6VoltageHigh;
            Pa4_6VoltageLow = obj.Pa4_6VoltageLow;
        }
    }
}
