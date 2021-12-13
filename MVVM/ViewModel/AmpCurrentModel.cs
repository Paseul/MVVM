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
    public class AmpCurrentModel : ViewModelBase, INotifyPropertyChanged
    {
        private bool _pa1CurrentHigh;
        public bool Pa1CurrentHigh
        {
            get { return _pa1CurrentHigh; }
            set
            {
                _pa1CurrentHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa1CurrentLow;
        public bool Pa1CurrentLow
        {
            get { return _pa1CurrentLow; }
            set
            {
                _pa1CurrentLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa2CurrentHigh;
        public bool Pa2CurrentHigh
        {
            get { return _pa2CurrentHigh; }
            set
            {
                _pa2CurrentHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa2CurrentLow;
        public bool Pa2CurrentLow
        {
            get { return _pa2CurrentLow; }
            set
            {
                _pa2CurrentLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa3CurrentHigh;
        public bool Pa3CurrentHigh
        {
            get { return _pa3CurrentHigh; }
            set
            {
                _pa3CurrentHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa3CurrentLow;
        public bool Pa3CurrentLow
        {
            get { return _pa3CurrentLow; }
            set
            {
                _pa3CurrentLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_1CurrentHigh;
        public bool Pa4_1CurrentHigh
        {
            get { return _pa4_1CurrentHigh; }
            set
            {
                _pa4_1CurrentHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_1CurrentLow;
        public bool Pa4_1CurrentLow
        {
            get { return _pa4_1CurrentLow; }
            set
            {
                _pa4_1CurrentLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_2CurrentHigh;
        public bool Pa4_2CurrentHigh
        {
            get { return _pa4_2CurrentHigh; }
            set
            {
                _pa4_2CurrentHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_2CurrentLow;
        public bool Pa4_2CurrentLow
        {
            get { return _pa4_2CurrentLow; }
            set
            {
                _pa4_2CurrentLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_3CurrentHigh;
        public bool Pa4_3CurrentHigh
        {
            get { return _pa4_3CurrentHigh; }
            set
            {
                _pa4_3CurrentHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_3CurrentLow;
        public bool Pa4_3CurrentLow
        {
            get { return _pa4_3CurrentLow; }
            set
            {
                _pa4_3CurrentLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_4CurrentHigh;
        public bool Pa4_4CurrentHigh
        {
            get { return _pa4_4CurrentHigh; }
            set
            {
                _pa4_4CurrentHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_4CurrentLow;
        public bool Pa4_4CurrentLow
        {
            get { return _pa4_4CurrentLow; }
            set
            {
                _pa4_4CurrentLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_5CurrentHigh;
        public bool Pa4_5CurrentHigh
        {
            get { return _pa4_5CurrentHigh; }
            set
            {
                _pa4_5CurrentHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_5CurrentLow;
        public bool Pa4_5CurrentLow
        {
            get { return _pa4_5CurrentLow; }
            set
            {
                _pa4_5CurrentLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_6CurrentHigh;
        public bool Pa4_6CurrentHigh
        {
            get { return _pa4_6CurrentHigh; }
            set
            {
                _pa4_6CurrentHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_6CurrentLow;
        public bool Pa4_6CurrentLow
        {
            get { return _pa4_6CurrentLow; }
            set
            {
                _pa4_6CurrentLow = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public AmpCurrentModel()
        {
            Messenger.Default.Register<errorMon>(this, OnReceiveMessageAction);
        }

        private void OnReceiveMessageAction(errorMon obj)
        {
            Pa1CurrentHigh = obj.Pa1CurrentHigh;
            Pa1CurrentLow = obj.Pa1CurrentLow;
            Pa2CurrentHigh = obj.Pa2CurrentHigh;
            Pa2CurrentLow = obj.Pa2CurrentLow;
            Pa3CurrentHigh = obj.Pa3CurrentHigh;
            Pa3CurrentLow = obj.Pa3CurrentLow;
            Pa4_1CurrentHigh = obj.Pa4_1CurrentHigh;
            Pa4_1CurrentLow = obj.Pa4_1CurrentLow;
            Pa4_2CurrentHigh = obj.Pa4_2CurrentHigh;
            Pa4_2CurrentLow = obj.Pa4_2CurrentLow;
            Pa4_3CurrentHigh = obj.Pa4_3CurrentHigh;
            Pa4_3CurrentLow = obj.Pa4_3CurrentLow;
            Pa4_4CurrentHigh = obj.Pa4_4CurrentHigh;
            Pa4_4CurrentLow = obj.Pa4_4CurrentLow;
            Pa4_5CurrentHigh = obj.Pa4_5CurrentHigh;
            Pa4_5CurrentLow = obj.Pa4_5CurrentLow;
            Pa4_6CurrentHigh = obj.Pa4_6CurrentHigh;
            Pa4_6CurrentLow = obj.Pa4_6CurrentLow;
        }
    }
}
