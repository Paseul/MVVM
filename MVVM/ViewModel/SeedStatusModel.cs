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
    public class SeedStatusModel : ViewModelBase, INotifyPropertyChanged
    {
        private int _seedTempHigh;
        public int SeedTempHigh
        {
            get { return _seedTempHigh; }
            set
            {
                _seedTempHigh = value;
                NotifyPropertyChanged();
            }
        }
        private int _seedTempLow;
        public int SeedTempLow
        {
            get { return _seedTempLow; }
            set
            {
                _seedTempLow = value;
                NotifyPropertyChanged();
            }
        }
        private int _seedTemp1High;
        public int SeedTemp1High
        {
            get { return _seedTemp1High; }
            set
            {
                _seedTemp1High = value;
                NotifyPropertyChanged();
            }
        }
        private int _seedTemp1Low;
        public int SeedTemp1Low
        {
            get { return _seedTemp1Low; }
            set
            {
                _seedTemp1Low = value;
                NotifyPropertyChanged();
            }
        }
        private int _seedTemp2High;
        public int SeedTemp2High
        {
            get { return _seedTemp2High; }
            set
            {
                _seedTemp2High = value;
                NotifyPropertyChanged();
            }
        }
        private int _seedTemp2Low;
        public int SeedTemp2Low
        {
            get { return _seedTemp2Low; }
            set
            {
                _seedTemp2Low = value;
                NotifyPropertyChanged();
            }
        }
        private int _seedTemp3High;
        public int SeedTemp3High
        {
            get { return _seedTemp3High; }
            set
            {
                _seedTemp3High = value;
                NotifyPropertyChanged();
            }
        }
        private int _seedTemp3Low;
        public int SeedTemp3Low
        {
            get { return _seedTemp3Low; }
            set
            {
                _seedTemp3Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _seedCurrentHigh;
        public bool SeedCurrentHigh
        {
            get { return _seedCurrentHigh; }
            set
            {
                _seedCurrentHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _seedCurrentLow;
        public bool SeedCurrentLow
        {
            get { return _seedCurrentLow; }
            set
            {
                _seedCurrentLow = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public SeedStatusModel()
        {
            Messenger.Default.Register<warnMon>(this, OnReceiveMessageAction);
            Messenger.Default.Register<errorMon>(this, OnReceiveMessageAction);
        }

        private void OnReceiveMessageAction(warnMon obj)
        {
            SeedTempHigh = obj.SeedTempHigh ? 1 : 2;
            SeedTempLow = obj.SeedTempLow ? 1 : 2;
            SeedTemp1High = obj.SeedTemp1High ? 1 : 2;
            SeedTemp1Low = obj.SeedTemp1Low ? 1 : 2;
            SeedTemp2High = obj.SeedTemp2High ? 1 : 2;
            SeedTemp2Low = obj.SeedTemp2Low ? 1 : 2;
            SeedTemp3High = obj.SeedTemp3High ? 1 : 2;
            SeedTemp3Low = obj.SeedTemp3Low ? 1 : 2;
        }

        private void OnReceiveMessageAction(errorMon obj)
        {
            SeedCurrentHigh = obj.SeedLdCurrentHigh;
            SeedCurrentLow = obj.SeedLdCurrentLow;
        }
    }
}
