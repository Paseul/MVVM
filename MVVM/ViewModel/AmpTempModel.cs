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
    public class AmpTempModel : ViewModelBase, INotifyPropertyChanged
    {
        private bool _paTemp1High;
        public bool PaTemp1High
        {
            get { return _paTemp1High; }
            set
            {
                _paTemp1High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp1Low;
        public bool PaTemp1Low
        {
            get { return _paTemp1Low; }
            set
            {
                _paTemp1Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp2High;
        public bool PaTemp2High
        {
            get { return _paTemp2High; }
            set
            {
                _paTemp2High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp2Low;
        public bool PaTemp2Low
        {
            get { return _paTemp2Low; }
            set
            {
                _paTemp2Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp3High;
        public bool PaTemp3High
        {
            get { return _paTemp3High; }
            set
            {
                _paTemp3High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp3Low;
        public bool PaTemp3Low
        {
            get { return _paTemp3Low; }
            set
            {
                _paTemp3Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp4High;
        public bool PaTemp4High
        {
            get { return _paTemp4High; }
            set
            {
                _paTemp4High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp4Low;
        public bool PaTemp4Low
        {
            get { return _paTemp4Low; }
            set
            {
                _paTemp4Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp5High;
        public bool PaTemp5High
        {
            get { return _paTemp5High; }
            set
            {
                _paTemp5High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp5Low;
        public bool PaTemp5Low
        {
            get { return _paTemp5Low; }
            set
            {
                _paTemp5Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp6High;
        public bool PaTemp6High
        {
            get { return _paTemp6High; }
            set
            {
                _paTemp6High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp6Low;
        public bool PaTemp6Low
        {
            get { return _paTemp6Low; }
            set
            {
                _paTemp6Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp7High;
        public bool PaTemp7High
        {
            get { return _paTemp7High; }
            set
            {
                _paTemp7High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp7Low;
        public bool PaTemp7Low
        {
            get { return _paTemp7Low; }
            set
            {
                _paTemp7Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp8High;
        public bool PaTemp8High
        {
            get { return _paTemp8High; }
            set
            {
                _paTemp8High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp8Low;
        public bool PaTemp8Low
        {
            get { return _paTemp8Low; }
            set
            {
                _paTemp8Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp9High;
        public bool PaTemp9High
        {
            get { return _paTemp9High; }
            set
            {
                _paTemp9High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp9Low;
        public bool PaTemp9Low
        {
            get { return _paTemp9Low; }
            set
            {
                _paTemp9Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp10High;
        public bool PaTemp10High
        {
            get { return _paTemp10High; }
            set
            {
                _paTemp10High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp10Low;
        public bool PaTemp10Low
        {
            get { return _paTemp10Low; }
            set
            {
                _paTemp10Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp11High;
        public bool PaTemp11High
        {
            get { return _paTemp11High; }
            set
            {
                _paTemp11High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp11Low;
        public bool PaTemp11Low
        {
            get { return _paTemp11Low; }
            set
            {
                _paTemp11Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp12High;
        public bool PaTemp12High
        {
            get { return _paTemp12High; }
            set
            {
                _paTemp12High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp12Low;
        public bool PaTemp12Low
        {
            get { return _paTemp12Low; }
            set
            {
                _paTemp12Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp13High;
        public bool PaTemp13High
        {
            get { return _paTemp13High; }
            set
            {
                _paTemp13High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp13Low;
        public bool PaTemp13Low
        {
            get { return _paTemp13Low; }
            set
            {
                _paTemp13Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp14High;
        public bool PaTemp14High
        {
            get { return _paTemp14High; }
            set
            {
                _paTemp14High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp14Low;
        public bool PaTemp14Low
        {
            get { return _paTemp14Low; }
            set
            {
                _paTemp14Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp15High;
        public bool PaTemp15High
        {
            get { return _paTemp15High; }
            set
            {
                _paTemp15High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp15Low;
        public bool PaTemp15Low
        {
            get { return _paTemp15Low; }
            set
            {
                _paTemp15Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp16High;
        public bool PaTemp16High
        {
            get { return _paTemp16High; }
            set
            {
                _paTemp16High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp16Low;
        public bool PaTemp16Low
        {
            get { return _paTemp16Low; }
            set
            {
                _paTemp16Low = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public AmpTempModel()
        {
            Messenger.Default.Register<warnMon>(this, OnReceiveMessageAction);
        }

        private void OnReceiveMessageAction(warnMon obj)
        {
            PaTemp1High = obj.PaTemp1High;
            PaTemp1Low = obj.PaTemp1Low;
            PaTemp2High = obj.PaTemp2High;
            PaTemp2Low = obj.PaTemp2Low;
            PaTemp3High = obj.PaTemp3High;
            PaTemp3Low = obj.PaTemp3Low;
            PaTemp4High = obj.PaTemp4High;
            PaTemp4Low = obj.PaTemp4Low;
            PaTemp5High = obj.PaTemp5High;
            PaTemp5Low = obj.PaTemp5Low;
            PaTemp6High = obj.PaTemp6High;
            PaTemp6Low = obj.PaTemp6Low;
            PaTemp7High = obj.PaTemp7High;
            PaTemp7Low = obj.PaTemp7Low;
            PaTemp8High = obj.PaTemp8High;
            PaTemp8Low = obj.PaTemp8Low;
            PaTemp9High = obj.PaTemp9High;
            PaTemp9Low = obj.PaTemp9Low;
            PaTemp10High = obj.PaTemp10High;
            PaTemp10Low = obj.PaTemp10Low;
            PaTemp11High = obj.PaTemp11High;
            PaTemp11Low = obj.PaTemp11Low;
            PaTemp12High = obj.PaTemp12High;
            PaTemp12Low = obj.PaTemp12Low;
            PaTemp13High = obj.PaTemp13High;
            PaTemp13Low = obj.PaTemp13Low;
            PaTemp14High = obj.PaTemp14High;
            PaTemp14Low = obj.PaTemp14Low;
            PaTemp15High = obj.PaTemp15High;
            PaTemp15Low = obj.PaTemp15Low;
            PaTemp16High = obj.PaTemp16High;
            PaTemp16Low = obj.PaTemp16Low;
        }
    }
}
