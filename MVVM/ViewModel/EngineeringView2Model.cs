using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVM.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class EngineeringView2Model : ViewModelBase
    {
        public RelayCommand OnLimitSetCommand { get; set; }
        public RelayCommand OnVerReqCommand { get; set; }

        private int _seedCurrLow;
        public int SeedCurrLow
        {
            get { return _seedCurrLow; }
            set
            {
                _seedCurrLow = value;
                RaisePropertyChanged("SeedCurrLow");
            }
        }
        private int _seedCurrHigh;
        public int SeedCurrHigh
        {
            get { return _seedCurrHigh; }
            set
            {
                _seedCurrHigh = value;
                RaisePropertyChanged("SeedCurrHigh");
            }
        }
        private int _seedTempLow;
        public int SeedTempLow
        {
            get { return _seedTempLow; }
            set
            {
                _seedTempLow = value;
                RaisePropertyChanged("SeedTempLow");
            }
        }
        private int _seedTempHigh;
        public int SeedTempHigh
        {
            get { return _seedTempHigh; }
            set
            {
                _seedTempHigh = value;
                RaisePropertyChanged("SeedTempHigh");
            }
        }
        private int _pa1CurrLow;
        public int Pa1CurrLow
        {
            get { return _pa1CurrLow; }
            set
            {
                _pa1CurrLow = value;
                RaisePropertyChanged("Pa1CurrLow");
            }
        }
        private int _pa1CurrHigh;
        public int Pa1CurrHigh
        {
            get { return _pa1CurrHigh; }
            set
            {
                _pa1CurrHigh = value;
                RaisePropertyChanged("Pa1CurrHigh");
            }
        }
        private int _pa1VoltLow;
        public int Pa1VoltLow
        {
            get { return _pa1VoltLow; }
            set
            {
                _pa1VoltLow = value;
                RaisePropertyChanged("Pa1VoltLow");
            }
        }
        private int _pa1VoltHigh;
        public int Pa1VoltHigh
        {
            get { return _pa1VoltHigh; }
            set
            {
                _pa1VoltHigh = value;
                RaisePropertyChanged("Pa1VoltHigh");
            }
        }
        private int _pa2CurrLow;
        public int Pa2CurrLow
        {
            get { return _pa2CurrLow; }
            set
            {
                _pa2CurrLow = value;
                RaisePropertyChanged("Pa2CurrLow");
            }
        }
        private int _pa2CurrHigh;
        public int Pa2CurrHigh
        {
            get { return _pa2CurrHigh; }
            set
            {
                _pa2CurrHigh = value;
                RaisePropertyChanged("Pa2CurrHigh");
            }
        }
        private int _pa2VoltLow;
        public int Pa2VoltLow
        {
            get { return _pa2VoltLow; }
            set
            {
                _pa2VoltLow = value;
                RaisePropertyChanged("Pa2VoltLow");
            }
        }
        private int _pa2VoltHigh;
        public int Pa2VoltHigh
        {
            get { return _pa2VoltHigh; }
            set
            {
                _pa2VoltHigh = value;
                RaisePropertyChanged("Pa2VoltHigh");
            }
        }
        private int _pa3CurrLow;
        public int Pa3CurrLow
        {
            get { return _pa3CurrLow; }
            set
            {
                _pa3CurrLow = value;
                RaisePropertyChanged("Pa3CurrLow");
            }
        }
        private int _pa3CurrHigh;
        public int Pa3CurrHigh
        {
            get { return _pa3CurrHigh; }
            set
            {
                _pa3CurrHigh = value;
                RaisePropertyChanged("Pa3CurrHigh");
            }
        }
        private int _pa3VoltLow;
        public int Pa3VoltLow
        {
            get { return _pa3VoltLow; }
            set
            {
                _pa3VoltLow = value;
                RaisePropertyChanged("Pa3VoltLow");
            }
        }
        private int _pa3VoltHigh;
        public int Pa3VoltHigh
        {
            get { return _pa3VoltHigh; }
            set
            {
                _pa3VoltHigh = value;
                RaisePropertyChanged("Pa3VoltHigh");
            }
        }
        private int _pa4_1CurrLow;
        public int Pa4_1CurrLow
        {
            get { return _pa4_1CurrLow; }
            set
            {
                _pa4_1CurrLow = value;
                RaisePropertyChanged("Pa4_1CurrLow");
            }
        }
        private int _pa4_1CurrHigh;
        public int Pa4_1CurrHigh
        {
            get { return _pa4_1CurrHigh; }
            set
            {
                _pa4_1CurrHigh = value;
                RaisePropertyChanged("Pa4_1CurrHigh");
            }
        }
        private int _pa4_1VoltLow;
        public int Pa4_1VoltLow
        {
            get { return _pa4_1VoltLow; }
            set
            {
                _pa4_1VoltLow = value;
                RaisePropertyChanged("Pa4_1VoltLow");
            }
        }
        private int _pa4_1VoltHigh;
        public int Pa4_1VoltHigh
        {
            get { return _pa4_1VoltHigh; }
            set
            {
                _pa4_1VoltHigh = value;
                RaisePropertyChanged("Pa4_1VoltHigh");
            }
        }
        private int _pa4_2CurrLow;
        public int Pa4_2CurrLow
        {
            get { return _pa4_2CurrLow; }
            set
            {
                _pa4_2CurrLow = value;
                RaisePropertyChanged("Pa4_2CurrLow");
            }
        }
        private int _pa4_2CurrHigh;
        public int Pa4_2CurrHigh
        {
            get { return _pa4_2CurrHigh; }
            set
            {
                _pa4_2CurrHigh = value;
                RaisePropertyChanged("Pa4_2CurrHigh");
            }
        }
        private int _pa4_2VoltLow;
        public int Pa4_2VoltLow
        {
            get { return _pa4_2VoltLow; }
            set
            {
                _pa4_2VoltLow = value;
                RaisePropertyChanged("Pa4_2VoltLow");
            }
        }
        private int _pa4_2VoltHigh;
        public int Pa4_2VoltHigh
        {
            get { return _pa4_2VoltHigh; }
            set
            {
                _pa4_2VoltHigh = value;
                RaisePropertyChanged("Pa4_2VoltHigh");
            }
        }
        private int _pa4_3CurrLow;
        public int Pa4_3CurrLow
        {
            get { return _pa4_3CurrLow; }
            set
            {
                _pa4_3CurrLow = value;
                RaisePropertyChanged("Pa4_3CurrLow");
            }
        }
        private int _pa4_3CurrHigh;
        public int Pa4_3CurrHigh
        {
            get { return _pa4_3CurrHigh; }
            set
            {
                _pa4_3CurrHigh = value;
                RaisePropertyChanged("Pa4_3CurrHigh");
            }
        }
        private int _pa4_3VoltLow;
        public int Pa4_3VoltLow
        {
            get { return _pa4_3VoltLow; }
            set
            {
                _pa4_3VoltLow = value;
                RaisePropertyChanged("Pa4_3VoltLow");
            }
        }
        private int _pa4_3VoltHigh;
        public int Pa4_3VoltHigh
        {
            get { return _pa4_3VoltHigh; }
            set
            {
                _pa4_3VoltHigh = value;
                RaisePropertyChanged("Pa4_3VoltHigh");
            }
        }
        private int _pa4_4CurrLow;
        public int Pa4_4CurrLow
        {
            get { return _pa4_4CurrLow; }
            set
            {
                _pa4_4CurrLow = value;
                RaisePropertyChanged("Pa4_4CurrLow");
            }
        }
        private int _pa4_4CurrHigh;
        public int Pa4_4CurrHigh
        {
            get { return _pa4_4CurrHigh; }
            set
            {
                _pa4_4CurrHigh = value;
                RaisePropertyChanged("Pa4_4CurrHigh");
            }
        }
        private int _pa4_4VoltLow;
        public int Pa4_4VoltLow
        {
            get { return _pa4_4VoltLow; }
            set
            {
                _pa4_4VoltLow = value;
                RaisePropertyChanged("Pa4_4VoltLow");
            }
        }
        private int _pa4_4VoltHigh;
        public int Pa4_4VoltHigh
        {
            get { return _pa4_4VoltHigh; }
            set
            {
                _pa4_4VoltHigh = value;
                RaisePropertyChanged("Pa4_4VoltHigh");
            }
        }
        private int _pa4_5CurrLow;
        public int Pa4_5CurrLow
        {
            get { return _pa4_5CurrLow; }
            set
            {
                _pa4_5CurrLow = value;
                RaisePropertyChanged("Pa4_5CurrLow");
            }
        }
        private int _pa4_5CurrHigh;
        public int Pa4_5CurrHigh
        {
            get { return _pa4_5CurrHigh; }
            set
            {
                _pa4_5CurrHigh = value;
                RaisePropertyChanged("Pa4_5CurrHigh");
            }
        }
        private int _pa4_5VoltLow;
        public int Pa4_5VoltLow
        {
            get { return _pa4_5VoltLow; }
            set
            {
                _pa4_5VoltLow = value;
                RaisePropertyChanged("Pa4_5VoltLow");
            }
        }
        private int _pa4_5VoltHigh;
        public int Pa4_5VoltHigh
        {
            get { return _pa4_5VoltHigh; }
            set
            {
                _pa4_5VoltHigh = value;
                RaisePropertyChanged("Pa4_5VoltHigh");
            }
        }
        private int _pa4_6CurrLow;
        public int Pa4_6CurrLow
        {
            get { return _pa4_6CurrLow; }
            set
            {
                _pa4_6CurrLow = value;
                RaisePropertyChanged("Pa4_6CurrLow");
            }
        }
        private int _pa4_6CurrHigh;
        public int Pa4_6CurrHigh
        {
            get { return _pa4_6CurrHigh; }
            set
            {
                _pa4_6CurrHigh = value;
                RaisePropertyChanged("Pa4_6CurrHigh");
            }
        }
        private int _pa4_6VoltLow;
        public int Pa4_6VoltLow
        {
            get { return _pa4_6VoltLow; }
            set
            {
                _pa4_6VoltLow = value;
                RaisePropertyChanged("Pa4_6VoltLow");
            }
        }
        private int _pa4_6VoltHigh;
        public int Pa4_6VoltHigh
        {
            get { return _pa4_6VoltHigh; }
            set
            {
                _pa4_6VoltHigh = value;
                RaisePropertyChanged("Pa4_6VoltHigh");
            }
        }
        private int _pd1Low;
        public int Pd1Low
        {
            get { return _pd1Low; }
            set
            {
                _pd1Low = value;
                RaisePropertyChanged("Pd1Low");
            }
        }
        private int _pd1High;
        public int Pd1High
        {
            get { return _pd1High; }
            set
            {
                _pd1High = value;
                RaisePropertyChanged("Pd1High");
            }
        }
        private int _pd2Low;
        public int Pd2Low
        {
            get { return _pd2Low; }
            set
            {
                _pd2Low = value;
                RaisePropertyChanged("Pd2Low");
            }
        }
        private int _pd2High;
        public int Pd2High
        {
            get { return _pd2High; }
            set
            {
                _pd2High = value;
                RaisePropertyChanged("Pd2High");
            }
        }
        private int _pd3Low;
        public int Pd3Low
        {
            get { return _pd3Low; }
            set
            {
                _pd3Low = value;
                RaisePropertyChanged("Pd3Low");
            }
        }
        private int _pd3High;
        public int Pd3High
        {
            get { return _pd3High; }
            set
            {
                _pd3High = value;
                RaisePropertyChanged("Pd3High");
            }
        }
        private int _pd4Low;
        public int Pd4Low
        {
            get { return _pd4Low; }
            set
            {
                _pd4Low = value;
                RaisePropertyChanged("Pd4Low");
            }
        }
        private int _pd4High;
        public int Pd4High
        {
            get { return _pd4High; }
            set
            {
                _pd4High = value;
                RaisePropertyChanged("Pd4High");
            }
        }
        private int _pd5Low;
        public int Pd5Low
        {
            get { return _pd5Low; }
            set
            {
                _pd5Low = value;
                RaisePropertyChanged("Pd5Low");
            }
        }
        private int _pd5High;
        public int Pd5High
        {
            get { return _pd5High; }
            set
            {
                _pd5High = value;
                RaisePropertyChanged("Pd5High");
            }
        }
        private int _pd6Low;
        public int Pd6Low
        {
            get { return _pd6Low; }
            set
            {
                _pd6Low = value;
                RaisePropertyChanged("Pd6Low");
            }
        }
        private int _pd6High;
        public int Pd6High
        {
            get { return _pd6High; }
            set
            {
                _pd6High = value;
                RaisePropertyChanged("Pd6High");
            }
        }
        private int _pd7Low;
        public int Pd7Low
        {
            get { return _pd7Low; }
            set
            {
                _pd7Low = value;
                RaisePropertyChanged("Pd7Low");
            }
        }
        private int _pd7High;
        public int Pd7High
        {
            get { return _pd7High; }
            set
            {
                _pd7High = value;
                RaisePropertyChanged("Pd7High");
            }
        }
        private int _seedTemp1Low;
        public int SeedTemp1Low
        {
            get { return _seedTemp1Low; }
            set
            {
                _seedTemp1Low = value;
                RaisePropertyChanged("SeedTemp1Low");
            }
        }
        private int _seedTemp1High;
        public int SeedTemp1High
        {
            get { return _seedTemp1High; }
            set
            {
                _seedTemp1High = value;
                RaisePropertyChanged("SeedTemp1High");
            }
        }
        private int _paTemp1Low;
        public int PaTemp1Low
        {
            get { return _paTemp1Low; }
            set
            {
                _paTemp1Low = value;
                RaisePropertyChanged("PaTemp1Low");
            }
        }
        private int _paTemp1High;
        public int PaTemp1High
        {
            get { return _paTemp1High; }
            set
            {
                _paTemp1High = value;
                RaisePropertyChanged("PaTemp1High");
            }
        }
        private int _paTemp2Low;
        public int PaTemp2Low
        {
            get { return _paTemp2Low; }
            set
            {
                _paTemp2Low = value;
                RaisePropertyChanged("PaTemp2Low");
            }
        }
        private int _paTemp2High;
        public int PaTemp2High
        {
            get { return _paTemp2High; }
            set
            {
                _paTemp2High = value;
                RaisePropertyChanged("PaTemp2High");
            }
        }
        private int _paTemp3Low;
        public int PaTemp3Low
        {
            get { return _paTemp3Low; }
            set
            {
                _paTemp3Low = value;
                RaisePropertyChanged("PaTemp3Low");
            }
        }
        private int _paTemp3High;
        public int PaTemp3High
        {
            get { return _paTemp3High; }
            set
            {
                _paTemp3High = value;
                RaisePropertyChanged("PaTemp3High");
            }
        }
        private int _paTemp4Low;
        public int PaTemp4Low
        {
            get { return _paTemp4Low; }
            set
            {
                _paTemp4Low = value;
                RaisePropertyChanged("PaTemp4Low");
            }
        }
        private int _paTemp4High;
        public int PaTemp4High
        {
            get { return _paTemp4High; }
            set
            {
                _paTemp4High = value;
                RaisePropertyChanged("PaTemp4High");
            }
        }
        private int _paTemp5Low;
        public int PaTemp5Low
        {
            get { return _paTemp5Low; }
            set
            {
                _paTemp5Low = value;
                RaisePropertyChanged("PaTemp5Low");
            }
        }
        private int _paTemp5High;
        public int PaTemp5High
        {
            get { return _paTemp5High; }
            set
            {
                _paTemp5High = value;
                RaisePropertyChanged("PaTemp5High");
            }
        }
        private int _paTemp6Low;
        public int PaTemp6Low
        {
            get { return _paTemp6Low; }
            set
            {
                _paTemp6Low = value;
                RaisePropertyChanged("PaTemp6Low");
            }
        }
        private int _paTemp6High;
        public int PaTemp6High
        {
            get { return _paTemp6High; }
            set
            {
                _paTemp6High = value;
                RaisePropertyChanged("PaTemp6High");
            }
        }
        private int _paTemp7Low;
        public int PaTemp7Low
        {
            get { return _paTemp7Low; }
            set
            {
                _paTemp7Low = value;
                RaisePropertyChanged("PaTemp7Low");
            }
        }
        private int _paTemp7High;
        public int PaTemp7High
        {
            get { return _paTemp7High; }
            set
            {
                _paTemp7High = value;
                RaisePropertyChanged("PaTemp7High");
            }
        }
        private int _paTemp8Low;
        public int PaTemp8Low
        {
            get { return _paTemp8Low; }
            set
            {
                _paTemp8Low = value;
                RaisePropertyChanged("PaTemp8Low");
            }
        }
        private int _paTemp8High;
        public int PaTemp8High
        {
            get { return _paTemp8High; }
            set
            {
                _paTemp8High = value;
                RaisePropertyChanged("PaTemp8High");
            }
        }
        private int _paTemp9Low;
        public int PaTemp9Low
        {
            get { return _paTemp9Low; }
            set
            {
                _paTemp9Low = value;
                RaisePropertyChanged("PaTemp9Low");
            }
        }
        private int _paTemp9High;
        public int PaTemp9High
        {
            get { return _paTemp9High; }
            set
            {
                _paTemp9High = value;
                RaisePropertyChanged("PaTemp9High");
            }
        }
        private int _paTemp10Low;
        public int PaTemp10Low
        {
            get { return _paTemp10Low; }
            set
            {
                _paTemp10Low = value;
                RaisePropertyChanged("PaTemp10Low");
            }
        }
        private int _paTemp10High;
        public int PaTemp10High
        {
            get { return _paTemp10High; }
            set
            {
                _paTemp10High = value;
                RaisePropertyChanged("PaTemp10High");
            }
        }
        private int _paTemp11Low;
        public int PaTemp11Low
        {
            get { return _paTemp11Low; }
            set
            {
                _paTemp11Low = value;
                RaisePropertyChanged("PaTemp11Low");
            }
        }
        private int _paTemp11High;
        public int PaTemp11High
        {
            get { return _paTemp11High; }
            set
            {
                _paTemp11High = value;
                RaisePropertyChanged("PaTemp11High");
            }
        }
        private int _paTemp12Low;
        public int PaTemp12Low
        {
            get { return _paTemp12Low; }
            set
            {
                _paTemp12Low = value;
                RaisePropertyChanged("PaTemp12Low");
            }
        }
        private int _paTemp12High;
        public int PaTemp12High
        {
            get { return _paTemp12High; }
            set
            {
                _paTemp12High = value;
                RaisePropertyChanged("PaTemp12High");
            }
        }
        private int _paTemp13Low;
        public int PaTemp13Low
        {
            get { return _paTemp13Low; }
            set
            {
                _paTemp13Low = value;
                RaisePropertyChanged("PaTemp13Low");
            }
        }
        private int _paTemp13High;
        public int PaTemp13High
        {
            get { return _paTemp13High; }
            set
            {
                _paTemp13High = value;
                RaisePropertyChanged("PaTemp13High");
            }
        }
        private int _paTemp14Low;
        public int PaTemp14Low
        {
            get { return _paTemp14Low; }
            set
            {
                _paTemp14Low = value;
                RaisePropertyChanged("PaTemp14Low");
            }
        }
        private int _paTemp14High;
        public int PaTemp14High
        {
            get { return _paTemp14High; }
            set
            {
                _paTemp14High = value;
                RaisePropertyChanged("PaTemp14High");
            }
        }
        private int _paTemp15Low;
        public int PaTemp15Low
        {
            get { return _paTemp15Low; }
            set
            {
                _paTemp15Low = value;
                RaisePropertyChanged("PaTemp15Low");
            }
        }
        private int _paTemp15High;
        public int PaTemp15High
        {
            get { return _paTemp15High; }
            set
            {
                _paTemp15High = value;
                RaisePropertyChanged("PaTemp15High");
            }
        }
        private int _paTemp16Low;
        public int PaTemp16Low
        {
            get { return _paTemp16Low; }
            set
            {
                _paTemp16Low = value;
                RaisePropertyChanged("PaTemp16Low");
            }
        }
        private int _paTemp16High;
        public int PaTemp16High
        {
            get { return _paTemp16High; }
            set
            {
                _paTemp16High = value;
                RaisePropertyChanged("PaTemp16High");
            }
        }
        private int _rfVmonLow;
        public int RfVmonLow
        {
            get { return _rfVmonLow; }
            set
            {
                _rfVmonLow = value;
                RaisePropertyChanged("RfVmonLow");
            }
        }
        private int _rfVmonHigh;
        public int RfVmonHigh
        {
            get { return _rfVmonHigh; }
            set
            {
                _rfVmonHigh = value;
                RaisePropertyChanged("RfVmonHigh");
            }
        }
        private int _seedHumidLow;
        public int SeedHumidLow
        {
            get { return _seedHumidLow; }
            set
            {
                _seedHumidLow = value;
                RaisePropertyChanged("SeedHumidLow");
            }
        }
        private int _seedHumidHigh;
        public int SeedHumidHigh
        {
            get { return _seedHumidHigh; }
            set
            {
                _seedHumidHigh = value;
                RaisePropertyChanged("SeedHumidHigh");
            }
        }
        private int _paHumidLow;
        public int PaHumidLow
        {
            get { return _paHumidLow; }
            set
            {
                _paHumidLow = value;
                RaisePropertyChanged("PaHumidLow");
            }
        }
        private int _paHumidHigh;
        public int PaHumidHigh
        {
            get { return _paHumidHigh; }
            set
            {
                _paHumidHigh = value;
                RaisePropertyChanged("PaHumidHigh");
            }
        }
        private int _swVer;
        public int SwVer
        {
            get { return _swVer; }
            set
            {
                _swVer = value;
                RaisePropertyChanged("SwVer");
            }
        }
        private int _hwVer;
        public int HwVer
        {
            get { return _hwVer; }
            set
            {
                _hwVer = value;
                RaisePropertyChanged("HwVer");
            }
        }
        private int _deviceId;
        public int DeviceId
        {
            get { return _deviceId; }
            set
            {
                _deviceId = value;
                RaisePropertyChanged("DeviceId");
            }
        }

        public EngineeringView2Model()
        {
            Messenger.Default.Register<versionResponse>(this, OnReceiveMessageAction);

            OnLimitSetCommand = new RelayCommand(OnLimitSetCommandAction, null);
            OnVerReqCommand = new RelayCommand(OnVerReqCommandAction, null);
        }

        private void OnLimitSetCommandAction()
        {
            var setHighLimit = new setHighLimit()
            {
                SeedCurrent = SeedCurrHigh,
                SeedTemp = SeedTempHigh,
                Pa1Current = Pa1CurrHigh,
                Pa2Current = Pa2CurrHigh,
                Pa3Current = Pa3CurrHigh,
                Pa4_1Current = Pa4_1CurrHigh,
                Pa4_2Current = Pa4_2CurrHigh,
                Pa4_3Current = Pa4_3CurrHigh,
                Pa4_4Current = Pa4_4CurrHigh,
                Pa4_5Current = Pa4_5CurrHigh,
                Pa4_6Current = Pa4_6CurrHigh,
                Pa1Voltage = Pa1VoltHigh,
                Pa2Voltage = Pa2VoltHigh,
                Pa3Voltage = Pa3VoltHigh,
                Pa4_1Voltage = Pa4_1VoltHigh,
                Pa4_2Voltage = Pa4_2VoltHigh,
                Pa4_3Voltage = Pa4_3VoltHigh,
                Pa4_4Voltage = Pa4_4VoltHigh,
                Pa4_5Voltage = Pa4_5VoltHigh,
                Pa4_6Voltage = Pa4_6VoltHigh,
                Pd1 = Pd1High,
                Pd2 = Pd2High,
                Pd3 = Pd3High,
                Pd4 = Pd4High,
                Pd5 = Pd5High,
                Pd6 = Pd6High,
                Pd7 = Pd7High,
                Pd8 = 0,
                SeedTemp1 = SeedTemp1High,
                SeedTemp2 = 0,
                SeedTemp3 = 0,
                PaTemp1 = PaTemp1High,
                PaTemp2 = PaTemp2High,
                PaTemp3 = PaTemp3High,
                PaTemp4 = PaTemp4High,
                PaTemp5 = PaTemp5High,
                PaTemp6 = PaTemp6High,
                PaTemp7 = PaTemp7High,
                PaTemp8 = PaTemp8High,
                PaTemp9 = PaTemp9High,
                PaTemp10 = PaTemp10High,
                PaTemp11 = PaTemp11High,
                PaTemp12 = PaTemp12High,
                PaTemp13 = PaTemp13High,
                PaTemp14 = PaTemp14High,
                PaTemp15 = PaTemp15High,
                PaTemp16 = PaTemp16High,
                RfVmon = RfVmonHigh,
                SeedHumid = SeedHumidHigh,
                PaHumid = PaHumidHigh
            };
            Messenger.Default.Send(setHighLimit);

            var setLowLimit = new setLowLimit()
            {
                SeedCurrent = SeedCurrLow,
                SeedTemp = SeedTempLow,
                Pa1Current = Pa1CurrLow,
                Pa2Current = Pa2CurrLow,
                Pa3Current = Pa3CurrLow,
                Pa4_1Current = Pa4_1CurrLow,
                Pa4_2Current = Pa4_2CurrLow,
                Pa4_3Current = Pa4_3CurrLow,
                Pa4_4Current = Pa4_4CurrLow,
                Pa4_5Current = Pa4_5CurrLow,
                Pa4_6Current = Pa4_6CurrLow,
                Pa1Voltage = Pa1VoltLow,
                Pa2Voltage = Pa2VoltLow,
                Pa3Voltage = Pa3VoltLow,
                Pa4_1Voltage = Pa4_1VoltLow,
                Pa4_2Voltage = Pa4_2VoltLow,
                Pa4_3Voltage = Pa4_3VoltLow,
                Pa4_4Voltage = Pa4_4VoltLow,
                Pa4_5Voltage = Pa4_5VoltLow,
                Pa4_6Voltage = Pa4_6VoltLow,
                Pd1 = Pd1Low,
                Pd2 = Pd2Low,
                Pd3 = Pd3Low,
                Pd4 = Pd4Low,
                Pd5 = Pd5Low,
                Pd6 = Pd6Low,
                Pd7 = Pd7Low,
                Pd8 = 0,
                SeedTemp1 = SeedTemp1Low,
                SeedTemp2 = 0,
                SeedTemp3 = 0,
                PaTemp1 = PaTemp1Low,
                PaTemp2 = PaTemp2Low,
                PaTemp3 = PaTemp3Low,
                PaTemp4 = PaTemp4Low,
                PaTemp5 = PaTemp5Low,
                PaTemp6 = PaTemp6Low,
                PaTemp7 = PaTemp7Low,
                PaTemp8 = PaTemp8Low,
                PaTemp9 = PaTemp9Low,
                PaTemp10 = PaTemp10Low,
                PaTemp11 = PaTemp11Low,
                PaTemp12 = PaTemp12Low,
                PaTemp13 = PaTemp13Low,
                PaTemp14 = PaTemp14Low,
                PaTemp15 = PaTemp15Low,
                PaTemp16 = PaTemp16Low,
                RfVmon = RfVmonLow,
                SeedHumid = SeedHumidLow,
                PaHumid = PaHumidLow
            };
            Messenger.Default.Send(setLowLimit);
        }

        private void OnVerReqCommandAction()
        {
            var lcb003Cmd = new lcb003Cmd()
            {
                cmd = "verReq",
            };
            Messenger.Default.Send(lcb003Cmd);
        }


        private void OnReceiveMessageAction(versionResponse obj)
        {
            SwVer = obj.SwVer;
            HwVer = obj.HwVer;
            DeviceId = obj.DeviceId;
        }
    }
}
