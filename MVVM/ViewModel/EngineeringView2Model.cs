using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
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
        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "SystemController";
        const string keyName = userRoot + "\\" + subkey;

        public RelayCommand OnLimitSetCommand { get; set; }
        public RelayCommand OnVerReqCommand { get; set; }

        private float _seedCurrLow;
        public float SeedCurrLow
        {
            get { return _seedCurrLow; }
            set
            {
                _seedCurrLow = value;
                RaisePropertyChanged("SeedCurrLow");
            }
        }
        private float _seedCurrHigh;
        public float SeedCurrHigh
        {
            get { return _seedCurrHigh; }
            set
            {
                _seedCurrHigh = value;
                RaisePropertyChanged("SeedCurrHigh");
            }
        }
        private float _seedTempLow;
        public float SeedTempLow
        {
            get { return _seedTempLow; }
            set
            {
                _seedTempLow = value;
                RaisePropertyChanged("SeedTempLow");
            }
        }
        private float _seedTempHigh;
        public float SeedTempHigh
        {
            get { return _seedTempHigh; }
            set
            {
                _seedTempHigh = value;
                RaisePropertyChanged("SeedTempHigh");
            }
        }
        private float _pa1CurrLow;
        public float Pa1CurrLow
        {
            get { return _pa1CurrLow; }
            set
            {
                _pa1CurrLow = value;
                RaisePropertyChanged("Pa1CurrLow");
            }
        }
        private float _pa1CurrHigh;
        public float Pa1CurrHigh
        {
            get { return _pa1CurrHigh; }
            set
            {
                _pa1CurrHigh = value;
                RaisePropertyChanged("Pa1CurrHigh");
            }
        }
        private float _pa1VoltLow;
        public float Pa1VoltLow
        {
            get { return _pa1VoltLow; }
            set
            {
                _pa1VoltLow = value;
                RaisePropertyChanged("Pa1VoltLow");
            }
        }
        private float _pa1VoltHigh;
        public float Pa1VoltHigh
        {
            get { return _pa1VoltHigh; }
            set
            {
                _pa1VoltHigh = value;
                RaisePropertyChanged("Pa1VoltHigh");
            }
        }
        private float _pa2CurrLow;
        public float Pa2CurrLow
        {
            get { return _pa2CurrLow; }
            set
            {
                _pa2CurrLow = value;
                RaisePropertyChanged("Pa2CurrLow");
            }
        }
        private float _pa2CurrHigh;
        public float Pa2CurrHigh
        {
            get { return _pa2CurrHigh; }
            set
            {
                _pa2CurrHigh = value;
                RaisePropertyChanged("Pa2CurrHigh");
            }
        }
        private float _pa2VoltLow;
        public float Pa2VoltLow
        {
            get { return _pa2VoltLow; }
            set
            {
                _pa2VoltLow = value;
                RaisePropertyChanged("Pa2VoltLow");
            }
        }
        private float _pa2VoltHigh;
        public float Pa2VoltHigh
        {
            get { return _pa2VoltHigh; }
            set
            {
                _pa2VoltHigh = value;
                RaisePropertyChanged("Pa2VoltHigh");
            }
        }
        private float _pa3CurrLow;
        public float Pa3CurrLow
        {
            get { return _pa3CurrLow; }
            set
            {
                _pa3CurrLow = value;
                RaisePropertyChanged("Pa3CurrLow");
            }
        }
        private float _pa3CurrHigh;
        public float Pa3CurrHigh
        {
            get { return _pa3CurrHigh; }
            set
            {
                _pa3CurrHigh = value;
                RaisePropertyChanged("Pa3CurrHigh");
            }
        }
        private float _pa3VoltLow;
        public float Pa3VoltLow
        {
            get { return _pa3VoltLow; }
            set
            {
                _pa3VoltLow = value;
                RaisePropertyChanged("Pa3VoltLow");
            }
        }
        private float _pa3VoltHigh;
        public float Pa3VoltHigh
        {
            get { return _pa3VoltHigh; }
            set
            {
                _pa3VoltHigh = value;
                RaisePropertyChanged("Pa3VoltHigh");
            }
        }
        private float _pa4_1CurrLow;
        public float Pa4_1CurrLow
        {
            get { return _pa4_1CurrLow; }
            set
            {
                _pa4_1CurrLow = value;
                RaisePropertyChanged("Pa4_1CurrLow");
            }
        }
        private float _pa4_1CurrHigh;
        public float Pa4_1CurrHigh
        {
            get { return _pa4_1CurrHigh; }
            set
            {
                _pa4_1CurrHigh = value;
                RaisePropertyChanged("Pa4_1CurrHigh");
            }
        }
        private float _pa4_1VoltLow;
        public float Pa4_1VoltLow
        {
            get { return _pa4_1VoltLow; }
            set
            {
                _pa4_1VoltLow = value;
                RaisePropertyChanged("Pa4_1VoltLow");
            }
        }
        private float _pa4_1VoltHigh;
        public float Pa4_1VoltHigh
        {
            get { return _pa4_1VoltHigh; }
            set
            {
                _pa4_1VoltHigh = value;
                RaisePropertyChanged("Pa4_1VoltHigh");
            }
        }
        private float _pa4_2CurrLow;
        public float Pa4_2CurrLow
        {
            get { return _pa4_2CurrLow; }
            set
            {
                _pa4_2CurrLow = value;
                RaisePropertyChanged("Pa4_2CurrLow");
            }
        }
        private float _pa4_2CurrHigh;
        public float Pa4_2CurrHigh
        {
            get { return _pa4_2CurrHigh; }
            set
            {
                _pa4_2CurrHigh = value;
                RaisePropertyChanged("Pa4_2CurrHigh");
            }
        }
        private float _pa4_2VoltLow;
        public float Pa4_2VoltLow
        {
            get { return _pa4_2VoltLow; }
            set
            {
                _pa4_2VoltLow = value;
                RaisePropertyChanged("Pa4_2VoltLow");
            }
        }
        private float _pa4_2VoltHigh;
        public float Pa4_2VoltHigh
        {
            get { return _pa4_2VoltHigh; }
            set
            {
                _pa4_2VoltHigh = value;
                RaisePropertyChanged("Pa4_2VoltHigh");
            }
        }
        private float _pa4_3CurrLow;
        public float Pa4_3CurrLow
        {
            get { return _pa4_3CurrLow; }
            set
            {
                _pa4_3CurrLow = value;
                RaisePropertyChanged("Pa4_3CurrLow");
            }
        }
        private float _pa4_3CurrHigh;
        public float Pa4_3CurrHigh
        {
            get { return _pa4_3CurrHigh; }
            set
            {
                _pa4_3CurrHigh = value;
                RaisePropertyChanged("Pa4_3CurrHigh");
            }
        }
        private float _pa4_3VoltLow;
        public float Pa4_3VoltLow
        {
            get { return _pa4_3VoltLow; }
            set
            {
                _pa4_3VoltLow = value;
                RaisePropertyChanged("Pa4_3VoltLow");
            }
        }
        private float _pa4_3VoltHigh;
        public float Pa4_3VoltHigh
        {
            get { return _pa4_3VoltHigh; }
            set
            {
                _pa4_3VoltHigh = value;
                RaisePropertyChanged("Pa4_3VoltHigh");
            }
        }
        private float _pa4_4CurrLow;
        public float Pa4_4CurrLow
        {
            get { return _pa4_4CurrLow; }
            set
            {
                _pa4_4CurrLow = value;
                RaisePropertyChanged("Pa4_4CurrLow");
            }
        }
        private float _pa4_4CurrHigh;
        public float Pa4_4CurrHigh
        {
            get { return _pa4_4CurrHigh; }
            set
            {
                _pa4_4CurrHigh = value;
                RaisePropertyChanged("Pa4_4CurrHigh");
            }
        }
        private float _pa4_4VoltLow;
        public float Pa4_4VoltLow
        {
            get { return _pa4_4VoltLow; }
            set
            {
                _pa4_4VoltLow = value;
                RaisePropertyChanged("Pa4_4VoltLow");
            }
        }
        private float _pa4_4VoltHigh;
        public float Pa4_4VoltHigh
        {
            get { return _pa4_4VoltHigh; }
            set
            {
                _pa4_4VoltHigh = value;
                RaisePropertyChanged("Pa4_4VoltHigh");
            }
        }
        private float _pa4_5CurrLow;
        public float Pa4_5CurrLow
        {
            get { return _pa4_5CurrLow; }
            set
            {
                _pa4_5CurrLow = value;
                RaisePropertyChanged("Pa4_5CurrLow");
            }
        }
        private float _pa4_5CurrHigh;
        public float Pa4_5CurrHigh
        {
            get { return _pa4_5CurrHigh; }
            set
            {
                _pa4_5CurrHigh = value;
                RaisePropertyChanged("Pa4_5CurrHigh");
            }
        }
        private float _pa4_5VoltLow;
        public float Pa4_5VoltLow
        {
            get { return _pa4_5VoltLow; }
            set
            {
                _pa4_5VoltLow = value;
                RaisePropertyChanged("Pa4_5VoltLow");
            }
        }
        private float _pa4_5VoltHigh;
        public float Pa4_5VoltHigh
        {
            get { return _pa4_5VoltHigh; }
            set
            {
                _pa4_5VoltHigh = value;
                RaisePropertyChanged("Pa4_5VoltHigh");
            }
        }
        private float _pa4_6CurrLow;
        public float Pa4_6CurrLow
        {
            get { return _pa4_6CurrLow; }
            set
            {
                _pa4_6CurrLow = value;
                RaisePropertyChanged("Pa4_6CurrLow");
            }
        }
        private float _pa4_6CurrHigh;
        public float Pa4_6CurrHigh
        {
            get { return _pa4_6CurrHigh; }
            set
            {
                _pa4_6CurrHigh = value;
                RaisePropertyChanged("Pa4_6CurrHigh");
            }
        }
        private float _pa4_6VoltLow;
        public float Pa4_6VoltLow
        {
            get { return _pa4_6VoltLow; }
            set
            {
                _pa4_6VoltLow = value;
                RaisePropertyChanged("Pa4_6VoltLow");
            }
        }
        private float _pa4_6VoltHigh;
        public float Pa4_6VoltHigh
        {
            get { return _pa4_6VoltHigh; }
            set
            {
                _pa4_6VoltHigh = value;
                RaisePropertyChanged("Pa4_6VoltHigh");
            }
        }
        private float _pd1Low;
        public float Pd1Low
        {
            get { return _pd1Low; }
            set
            {
                _pd1Low = value;
                RaisePropertyChanged("Pd1Low");
            }
        }
        private float _pd1High;
        public float Pd1High
        {
            get { return _pd1High; }
            set
            {
                _pd1High = value;
                RaisePropertyChanged("Pd1High");
            }
        }
        private float _pd2Low;
        public float Pd2Low
        {
            get { return _pd2Low; }
            set
            {
                _pd2Low = value;
                RaisePropertyChanged("Pd2Low");
            }
        }
        private float _pd2High;
        public float Pd2High
        {
            get { return _pd2High; }
            set
            {
                _pd2High = value;
                RaisePropertyChanged("Pd2High");
            }
        }
        private float _pd3Low;
        public float Pd3Low
        {
            get { return _pd3Low; }
            set
            {
                _pd3Low = value;
                RaisePropertyChanged("Pd3Low");
            }
        }
        private float _pd3High;
        public float Pd3High
        {
            get { return _pd3High; }
            set
            {
                _pd3High = value;
                RaisePropertyChanged("Pd3High");
            }
        }
        private float _pd4Low;
        public float Pd4Low
        {
            get { return _pd4Low; }
            set
            {
                _pd4Low = value;
                RaisePropertyChanged("Pd4Low");
            }
        }
        private float _pd4High;
        public float Pd4High
        {
            get { return _pd4High; }
            set
            {
                _pd4High = value;
                RaisePropertyChanged("Pd4High");
            }
        }
        private float _pd5Low;
        public float Pd5Low
        {
            get { return _pd5Low; }
            set
            {
                _pd5Low = value;
                RaisePropertyChanged("Pd5Low");
            }
        }
        private float _pd5High;
        public float Pd5High
        {
            get { return _pd5High; }
            set
            {
                _pd5High = value;
                RaisePropertyChanged("Pd5High");
            }
        }
        private float _pd6Low;
        public float Pd6Low
        {
            get { return _pd6Low; }
            set
            {
                _pd6Low = value;
                RaisePropertyChanged("Pd6Low");
            }
        }
        private float _pd6High;
        public float Pd6High
        {
            get { return _pd6High; }
            set
            {
                _pd6High = value;
                RaisePropertyChanged("Pd6High");
            }
        }
        private float _pd7Low;
        public float Pd7Low
        {
            get { return _pd7Low; }
            set
            {
                _pd7Low = value;
                RaisePropertyChanged("Pd7Low");
            }
        }
        private float _pd7High;
        public float Pd7High
        {
            get { return _pd7High; }
            set
            {
                _pd7High = value;
                RaisePropertyChanged("Pd7High");
            }
        }
        private float _seedTemp1Low;
        public float SeedTemp1Low
        {
            get { return _seedTemp1Low; }
            set
            {
                _seedTemp1Low = value;
                RaisePropertyChanged("SeedTemp1Low");
            }
        }
        private float _seedTemp1High;
        public float SeedTemp1High
        {
            get { return _seedTemp1High; }
            set
            {
                _seedTemp1High = value;
                RaisePropertyChanged("SeedTemp1High");
            }
        }
        private float _paTemp1Low;
        public float PaTemp1Low
        {
            get { return _paTemp1Low; }
            set
            {
                _paTemp1Low = value;
                RaisePropertyChanged("PaTemp1Low");
            }
        }
        private float _paTemp1High;
        public float PaTemp1High
        {
            get { return _paTemp1High; }
            set
            {
                _paTemp1High = value;
                RaisePropertyChanged("PaTemp1High");
            }
        }
        private float _paTemp2Low;
        public float PaTemp2Low
        {
            get { return _paTemp2Low; }
            set
            {
                _paTemp2Low = value;
                RaisePropertyChanged("PaTemp2Low");
            }
        }
        private float _paTemp2High;
        public float PaTemp2High
        {
            get { return _paTemp2High; }
            set
            {
                _paTemp2High = value;
                RaisePropertyChanged("PaTemp2High");
            }
        }
        private float _paTemp3Low;
        public float PaTemp3Low
        {
            get { return _paTemp3Low; }
            set
            {
                _paTemp3Low = value;
                RaisePropertyChanged("PaTemp3Low");
            }
        }
        private float _paTemp3High;
        public float PaTemp3High
        {
            get { return _paTemp3High; }
            set
            {
                _paTemp3High = value;
                RaisePropertyChanged("PaTemp3High");
            }
        }
        private float _paTemp4Low;
        public float PaTemp4Low
        {
            get { return _paTemp4Low; }
            set
            {
                _paTemp4Low = value;
                RaisePropertyChanged("PaTemp4Low");
            }
        }
        private float _paTemp4High;
        public float PaTemp4High
        {
            get { return _paTemp4High; }
            set
            {
                _paTemp4High = value;
                RaisePropertyChanged("PaTemp4High");
            }
        }
        private float _paTemp5Low;
        public float PaTemp5Low
        {
            get { return _paTemp5Low; }
            set
            {
                _paTemp5Low = value;
                RaisePropertyChanged("PaTemp5Low");
            }
        }
        private float _paTemp5High;
        public float PaTemp5High
        {
            get { return _paTemp5High; }
            set
            {
                _paTemp5High = value;
                RaisePropertyChanged("PaTemp5High");
            }
        }
        private float _paTemp6Low;
        public float PaTemp6Low
        {
            get { return _paTemp6Low; }
            set
            {
                _paTemp6Low = value;
                RaisePropertyChanged("PaTemp6Low");
            }
        }
        private float _paTemp6High;
        public float PaTemp6High
        {
            get { return _paTemp6High; }
            set
            {
                _paTemp6High = value;
                RaisePropertyChanged("PaTemp6High");
            }
        }
        private float _paTemp7Low;
        public float PaTemp7Low
        {
            get { return _paTemp7Low; }
            set
            {
                _paTemp7Low = value;
                RaisePropertyChanged("PaTemp7Low");
            }
        }
        private float _paTemp7High;
        public float PaTemp7High
        {
            get { return _paTemp7High; }
            set
            {
                _paTemp7High = value;
                RaisePropertyChanged("PaTemp7High");
            }
        }
        private float _paTemp8Low;
        public float PaTemp8Low
        {
            get { return _paTemp8Low; }
            set
            {
                _paTemp8Low = value;
                RaisePropertyChanged("PaTemp8Low");
            }
        }
        private float _paTemp8High;
        public float PaTemp8High
        {
            get { return _paTemp8High; }
            set
            {
                _paTemp8High = value;
                RaisePropertyChanged("PaTemp8High");
            }
        }
        private float _paTemp9Low;
        public float PaTemp9Low
        {
            get { return _paTemp9Low; }
            set
            {
                _paTemp9Low = value;
                RaisePropertyChanged("PaTemp9Low");
            }
        }
        private float _paTemp9High;
        public float PaTemp9High
        {
            get { return _paTemp9High; }
            set
            {
                _paTemp9High = value;
                RaisePropertyChanged("PaTemp9High");
            }
        }
        private float _paTemp10Low;
        public float PaTemp10Low
        {
            get { return _paTemp10Low; }
            set
            {
                _paTemp10Low = value;
                RaisePropertyChanged("PaTemp10Low");
            }
        }
        private float _paTemp10High;
        public float PaTemp10High
        {
            get { return _paTemp10High; }
            set
            {
                _paTemp10High = value;
                RaisePropertyChanged("PaTemp10High");
            }
        }
        private float _paTemp11Low;
        public float PaTemp11Low
        {
            get { return _paTemp11Low; }
            set
            {
                _paTemp11Low = value;
                RaisePropertyChanged("PaTemp11Low");
            }
        }
        private float _paTemp11High;
        public float PaTemp11High
        {
            get { return _paTemp11High; }
            set
            {
                _paTemp11High = value;
                RaisePropertyChanged("PaTemp11High");
            }
        }
        private float _paTemp12Low;
        public float PaTemp12Low
        {
            get { return _paTemp12Low; }
            set
            {
                _paTemp12Low = value;
                RaisePropertyChanged("PaTemp12Low");
            }
        }
        private float _paTemp12High;
        public float PaTemp12High
        {
            get { return _paTemp12High; }
            set
            {
                _paTemp12High = value;
                RaisePropertyChanged("PaTemp12High");
            }
        }
        private float _paTemp13Low;
        public float PaTemp13Low
        {
            get { return _paTemp13Low; }
            set
            {
                _paTemp13Low = value;
                RaisePropertyChanged("PaTemp13Low");
            }
        }
        private float _paTemp13High;
        public float PaTemp13High
        {
            get { return _paTemp13High; }
            set
            {
                _paTemp13High = value;
                RaisePropertyChanged("PaTemp13High");
            }
        }
        private float _paTemp14Low;
        public float PaTemp14Low
        {
            get { return _paTemp14Low; }
            set
            {
                _paTemp14Low = value;
                RaisePropertyChanged("PaTemp14Low");
            }
        }
        private float _paTemp14High;
        public float PaTemp14High
        {
            get { return _paTemp14High; }
            set
            {
                _paTemp14High = value;
                RaisePropertyChanged("PaTemp14High");
            }
        }
        private float _paTemp15Low;
        public float PaTemp15Low
        {
            get { return _paTemp15Low; }
            set
            {
                _paTemp15Low = value;
                RaisePropertyChanged("PaTemp15Low");
            }
        }
        private float _paTemp15High;
        public float PaTemp15High
        {
            get { return _paTemp15High; }
            set
            {
                _paTemp15High = value;
                RaisePropertyChanged("PaTemp15High");
            }
        }
        private float _paTemp16Low;
        public float PaTemp16Low
        {
            get { return _paTemp16Low; }
            set
            {
                _paTemp16Low = value;
                RaisePropertyChanged("PaTemp16Low");
            }
        }
        private float _paTemp16High;
        public float PaTemp16High
        {
            get { return _paTemp16High; }
            set
            {
                _paTemp16High = value;
                RaisePropertyChanged("PaTemp16High");
            }
        }
        private float _rfVmonLow;
        public float RfVmonLow
        {
            get { return _rfVmonLow; }
            set
            {
                _rfVmonLow = value;
                RaisePropertyChanged("RfVmonLow");
            }
        }
        private float _rfVmonHigh;
        public float RfVmonHigh
        {
            get { return _rfVmonHigh; }
            set
            {
                _rfVmonHigh = value;
                RaisePropertyChanged("RfVmonHigh");
            }
        }
        private float _seedHumidLow;
        public float SeedHumidLow
        {
            get { return _seedHumidLow; }
            set
            {
                _seedHumidLow = value;
                RaisePropertyChanged("SeedHumidLow");
            }
        }
        private float _seedHumidHigh;
        public float SeedHumidHigh
        {
            get { return _seedHumidHigh; }
            set
            {
                _seedHumidHigh = value;
                RaisePropertyChanged("SeedHumidHigh");
            }
        }
        private float _paHumidLow;
        public float PaHumidLow
        {
            get { return _paHumidLow; }
            set
            {
                _paHumidLow = value;
                RaisePropertyChanged("PaHumidLow");
            }
        }
        private float _paHumidHigh;
        public float PaHumidHigh
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

            SeedCurrHigh = float.Parse((string)Registry.GetValue(keyName, "SeedCurrHigh", "150"));
            SeedTempHigh = float.Parse((string)Registry.GetValue(keyName, "SeedTempHigh", "35"));
            Pa1CurrHigh = float.Parse((string)Registry.GetValue(keyName, "Pa1CurrHigh", "6"));
            Pa2CurrHigh = float.Parse((string)Registry.GetValue(keyName, "Pa2CurrHigh", "8"));
            Pa3CurrHigh = float.Parse((string)Registry.GetValue(keyName, "Pa3CurrHigh", "12"));
            Pa4_1CurrHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_1CurrHigh", "24"));
            Pa4_2CurrHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_2CurrHigh", "24"));
            Pa4_3CurrHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_3CurrHigh", "24"));
            Pa4_4CurrHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_4CurrHigh", "24"));
            Pa4_5CurrHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_5CurrHigh", "24"));
            Pa4_6CurrHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_6CurrHigh", "24"));
            Pa1VoltHigh = float.Parse((string)Registry.GetValue(keyName, "Pa1VoltHigh", "6"));
            Pa2VoltHigh = float.Parse((string)Registry.GetValue(keyName, "Pa2VoltHigh", "6"));
            Pa3VoltHigh = float.Parse((string)Registry.GetValue(keyName, "Pa3VoltHigh", "13"));
            Pa4_1VoltHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_1VoltHigh", "52"));
            Pa4_2VoltHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_2VoltHigh", "52"));
            Pa4_3VoltHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_3VoltHigh", "52"));
            Pa4_4VoltHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_4VoltHigh", "52"));
            Pa4_5VoltHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_5VoltHigh", "52"));
            Pa4_6VoltHigh = float.Parse((string)Registry.GetValue(keyName, "Pa4_6VoltHigh", "52"));
            Pd1High = float.Parse((string)Registry.GetValue(keyName, "Pd1High", "25"));
            Pd2High = float.Parse((string)Registry.GetValue(keyName, "Pd2High", "150"));
            Pd3High = float.Parse((string)Registry.GetValue(keyName, "Pd3High", "3.5"));
            Pd4High = float.Parse((string)Registry.GetValue(keyName, "Pd4High", "3.5"));
            Pd5High = float.Parse((string)Registry.GetValue(keyName, "Pd5High", "40"));
            Pd6High = float.Parse((string)Registry.GetValue(keyName, "Pd6High", "40"));
            Pd7High = float.Parse((string)Registry.GetValue(keyName, "Pd7High", "2700"));
            SeedTemp1High = float.Parse((string)Registry.GetValue(keyName, "SeedTemp1High", "80"));
            PaTemp1High = float.Parse((string)Registry.GetValue(keyName, "PaTemp1High", "55"));
            PaTemp2High = float.Parse((string)Registry.GetValue(keyName, "PaTemp2High", "55"));
            PaTemp3High = float.Parse((string)Registry.GetValue(keyName, "PaTemp3High", "55"));
            PaTemp4High = float.Parse((string)Registry.GetValue(keyName, "PaTemp4High", "55"));
            PaTemp5High = float.Parse((string)Registry.GetValue(keyName, "PaTemp5High", "55"));
            PaTemp6High = float.Parse((string)Registry.GetValue(keyName, "PaTemp6High", "55"));
            PaTemp7High = float.Parse((string)Registry.GetValue(keyName, "PaTemp7High", "50"));
            PaTemp8High = float.Parse((string)Registry.GetValue(keyName, "PaTemp8High", "50"));
            PaTemp9High = float.Parse((string)Registry.GetValue(keyName, "PaTemp9High", "50"));
            PaTemp10High = float.Parse((string)Registry.GetValue(keyName, "PaTemp10High", "50"));
            PaTemp11High = float.Parse((string)Registry.GetValue(keyName, "PaTemp11High", "50"));
            PaTemp12High = float.Parse((string)Registry.GetValue(keyName, "PaTemp12High", "50"));
            PaTemp13High = float.Parse((string)Registry.GetValue(keyName, "PaTemp13High", "30"));
            PaTemp14High = float.Parse((string)Registry.GetValue(keyName, "PaTemp14High", "40"));
            PaTemp15High = float.Parse((string)Registry.GetValue(keyName, "PaTemp15High", "45"));
            PaTemp16High = float.Parse((string)Registry.GetValue(keyName, "PaTemp16High", "50"));
            RfVmonHigh = float.Parse((string)Registry.GetValue(keyName, "RfVmonHigh", "65535"));
            SeedHumidHigh = float.Parse((string)Registry.GetValue(keyName, "SeedHumidHigh", "70"));
            PaHumidHigh = float.Parse((string)Registry.GetValue(keyName, "PaHumidHigh", "70"));
            SeedCurrLow = float.Parse((string)Registry.GetValue(keyName, "SeedCurrLow", "3"));
            SeedTempLow = float.Parse((string)Registry.GetValue(keyName, "SeedTempLow", "15"));
            Pa1CurrLow = float.Parse((string)Registry.GetValue(keyName, "Pa1CurrLow", "0.3"));
            Pa2CurrLow = float.Parse((string)Registry.GetValue(keyName, "Pa2CurrLow", "0.3"));
            Pa3CurrLow = float.Parse((string)Registry.GetValue(keyName, "Pa3CurrLow", "0.3"));
            Pa4_1CurrLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_1CurrLow", "1"));
            Pa4_2CurrLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_2CurrLow", "1"));
            Pa4_3CurrLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_3CurrLow", "1"));
            Pa4_4CurrLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_4CurrLow", "1"));
            Pa4_5CurrLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_5CurrLow", "1"));
            Pa4_6CurrLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_6CurrLow", "1"));
            Pa1VoltLow = float.Parse((string)Registry.GetValue(keyName, "Pa1VoltLow", "1"));
            Pa2VoltLow = float.Parse((string)Registry.GetValue(keyName, "Pa2VoltLow", "1"));
            Pa3VoltLow = float.Parse((string)Registry.GetValue(keyName, "Pa3VoltLow", "1"));
            Pa4_1VoltLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_1VoltLow", "1"));
            Pa4_2VoltLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_2VoltLow", "1"));
            Pa4_3VoltLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_3VoltLow", "1"));
            Pa4_4VoltLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_4VoltLow", "1"));
            Pa4_5VoltLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_5VoltLow", "1"));
            Pa4_6VoltLow = float.Parse((string)Registry.GetValue(keyName, "Pa4_6VoltLow", "1"));
            Pd1Low = float.Parse((string)Registry.GetValue(keyName, "Pd1Low", "150"));
            Pd2Low = float.Parse((string)Registry.GetValue(keyName, "Pd2Low", "150"));
            Pd3Low = float.Parse((string)Registry.GetValue(keyName, "Pd3Low", "150"));
            Pd4Low = float.Parse((string)Registry.GetValue(keyName, "Pd4Low", "150"));
            Pd5Low = float.Parse((string)Registry.GetValue(keyName, "Pd5Low", "150"));
            Pd6Low = float.Parse((string)Registry.GetValue(keyName, "Pd6Low", "150"));
            Pd7Low = float.Parse((string)Registry.GetValue(keyName, "Pd7Low", "150"));
            SeedTemp1Low = float.Parse((string)Registry.GetValue(keyName, "SeedTemp1Low", "5"));
            PaTemp1Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp1Low", "5"));
            PaTemp2Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp2Low", "5"));
            PaTemp3Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp3Low", "5"));
            PaTemp4Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp4Low", "5"));
            PaTemp5Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp5Low", "5"));
            PaTemp6Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp6Low", "5"));
            PaTemp7Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp7Low", "5"));
            PaTemp8Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp8Low", "5"));
            PaTemp9Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp9Low", "5"));
            PaTemp10Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp10Low", "5"));
            PaTemp11Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp11Low", "5"));
            PaTemp12Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp12Low", "5"));
            PaTemp13Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp13Low", "5"));
            PaTemp14Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp14Low", "5"));
            PaTemp15Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp15Low", "5"));
            PaTemp16Low = float.Parse((string)Registry.GetValue(keyName, "PaTemp16Low", "5"));
            RfVmonLow = float.Parse((string)Registry.GetValue(keyName, "RfVmonLow", "0"));
            SeedHumidLow = float.Parse((string)Registry.GetValue(keyName, "SeedHumidLow", "1"));
            PaHumidLow = float.Parse((string)Registry.GetValue(keyName, "PaHumidLow", "1"));
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
                SeedTemp2 = 40,
                SeedTemp3 = 40,
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

            Registry.SetValue(keyName, "SeedCurrHigh", SeedCurrHigh);
            Registry.SetValue(keyName, "SeedTempHigh", SeedTempHigh);
            Registry.SetValue(keyName, "Pa1CurrHigh", Pa1CurrHigh);
            Registry.SetValue(keyName, "Pa2CurrHigh", Pa2CurrHigh);
            Registry.SetValue(keyName, "Pa3CurrHigh", Pa3CurrHigh);
            Registry.SetValue(keyName, "Pa4_1CurrHigh", Pa4_1CurrHigh);
            Registry.SetValue(keyName, "Pa4_2CurrHigh", Pa4_2CurrHigh);
            Registry.SetValue(keyName, "Pa4_3CurrHigh", Pa4_3CurrHigh);
            Registry.SetValue(keyName, "Pa4_4CurrHigh", Pa4_4CurrHigh);
            Registry.SetValue(keyName, "Pa4_5CurrHigh", Pa4_5CurrHigh);
            Registry.SetValue(keyName, "Pa4_6CurrHigh", Pa4_6CurrHigh);
            Registry.SetValue(keyName, "Pa1VoltHigh", Pa1VoltHigh);
            Registry.SetValue(keyName, "Pa2VoltHigh", Pa2VoltHigh);
            Registry.SetValue(keyName, "Pa3VoltHigh", Pa3VoltHigh);
            Registry.SetValue(keyName, "Pa4_1VoltHigh", Pa4_1VoltHigh);
            Registry.SetValue(keyName, "Pa4_2VoltHigh", Pa4_2VoltHigh);
            Registry.SetValue(keyName, "Pa4_3VoltHigh", Pa4_3VoltHigh);
            Registry.SetValue(keyName, "Pa4_4VoltHigh", Pa4_4VoltHigh);
            Registry.SetValue(keyName, "Pa4_5VoltHigh", Pa4_5VoltHigh);
            Registry.SetValue(keyName, "Pa4_6VoltHigh", Pa4_6VoltHigh);
            Registry.SetValue(keyName, "Pd1High", Pd1High);
            Registry.SetValue(keyName, "Pd2High", Pd2High);
            Registry.SetValue(keyName, "Pd3High", Pd3High);
            Registry.SetValue(keyName, "Pd4High", Pd4High);
            Registry.SetValue(keyName, "Pd5High", Pd5High);
            Registry.SetValue(keyName, "Pd6High", Pd6High);
            Registry.SetValue(keyName, "Pd7High", Pd7High);
            Registry.SetValue(keyName, "SeedTemp1High", SeedTemp1High);
            Registry.SetValue(keyName, "PaTemp1High", PaTemp1High);
            Registry.SetValue(keyName, "PaTemp2High", PaTemp2High);
            Registry.SetValue(keyName, "PaTemp3High", PaTemp3High);
            Registry.SetValue(keyName, "PaTemp4High", PaTemp4High);
            Registry.SetValue(keyName, "PaTemp5High", PaTemp5High);
            Registry.SetValue(keyName, "PaTemp6High", PaTemp6High);
            Registry.SetValue(keyName, "PaTemp7High", PaTemp7High);
            Registry.SetValue(keyName, "PaTemp8High", PaTemp8High);
            Registry.SetValue(keyName, "PaTemp9High", PaTemp9High);
            Registry.SetValue(keyName, "PaTemp10High", PaTemp10High);
            Registry.SetValue(keyName, "PaTemp11High", PaTemp11High);
            Registry.SetValue(keyName, "PaTemp12High", PaTemp12High);
            Registry.SetValue(keyName, "PaTemp13High", PaTemp13High);
            Registry.SetValue(keyName, "PaTemp14High", PaTemp14High);
            Registry.SetValue(keyName, "PaTemp15High", PaTemp15High);
            Registry.SetValue(keyName, "PaTemp16High", PaTemp16High);
            Registry.SetValue(keyName, "RfVmonHigh", RfVmonHigh);
            Registry.SetValue(keyName, "SeedHumidHigh", SeedHumidHigh);
            Registry.SetValue(keyName, "PaHumidHigh", PaHumidHigh);
            Registry.SetValue(keyName, "SeedCurrLow", SeedCurrLow);
            Registry.SetValue(keyName, "SeedTempLow", SeedTempLow);
            Registry.SetValue(keyName, "Pa1CurrLow", Pa1CurrLow);
            Registry.SetValue(keyName, "Pa2CurrLow", Pa2CurrLow);
            Registry.SetValue(keyName, "Pa3CurrLow", Pa3CurrLow);
            Registry.SetValue(keyName, "Pa4_1CurrLow", Pa4_1CurrLow);
            Registry.SetValue(keyName, "Pa4_2CurrLow", Pa4_2CurrLow);
            Registry.SetValue(keyName, "Pa4_3CurrLow", Pa4_3CurrLow);
            Registry.SetValue(keyName, "Pa4_4CurrLow", Pa4_4CurrLow);
            Registry.SetValue(keyName, "Pa4_5CurrLow", Pa4_5CurrLow);
            Registry.SetValue(keyName, "Pa4_6CurrLow", Pa4_6CurrLow);
            Registry.SetValue(keyName, "Pa1VoltLow", Pa1VoltLow);
            Registry.SetValue(keyName, "Pa2VoltLow", Pa2VoltLow);
            Registry.SetValue(keyName, "Pa3VoltLow", Pa3VoltLow);
            Registry.SetValue(keyName, "Pa4_1VoltLow", Pa4_1VoltLow);
            Registry.SetValue(keyName, "Pa4_2VoltLow", Pa4_2VoltLow);
            Registry.SetValue(keyName, "Pa4_3VoltLow", Pa4_3VoltLow);
            Registry.SetValue(keyName, "Pa4_4VoltLow", Pa4_4VoltLow);
            Registry.SetValue(keyName, "Pa4_5VoltLow", Pa4_5VoltLow);
            Registry.SetValue(keyName, "Pa4_6VoltLow", Pa4_6VoltLow);
            Registry.SetValue(keyName, "Pd1Low", Pd1Low);
            Registry.SetValue(keyName, "Pd2Low", Pd2Low);
            Registry.SetValue(keyName, "Pd3Low", Pd3Low);
            Registry.SetValue(keyName, "Pd4Low", Pd4Low);
            Registry.SetValue(keyName, "Pd5Low", Pd5Low);
            Registry.SetValue(keyName, "Pd6Low", Pd6Low);
            Registry.SetValue(keyName, "Pd7Low", Pd7Low);
            Registry.SetValue(keyName, "SeedTemp1Low", SeedTemp1Low);
            Registry.SetValue(keyName, "PaTemp1Low", PaTemp1Low);
            Registry.SetValue(keyName, "PaTemp2Low", PaTemp2Low);
            Registry.SetValue(keyName, "PaTemp3Low", PaTemp3Low);
            Registry.SetValue(keyName, "PaTemp4Low", PaTemp4Low);
            Registry.SetValue(keyName, "PaTemp5Low", PaTemp5Low);
            Registry.SetValue(keyName, "PaTemp6Low", PaTemp6Low);
            Registry.SetValue(keyName, "PaTemp7Low", PaTemp7Low);
            Registry.SetValue(keyName, "PaTemp8Low", PaTemp8Low);
            Registry.SetValue(keyName, "PaTemp9Low", PaTemp9Low);
            Registry.SetValue(keyName, "PaTemp10Low", PaTemp10Low);
            Registry.SetValue(keyName, "PaTemp11Low", PaTemp11Low);
            Registry.SetValue(keyName, "PaTemp12Low", PaTemp12Low);
            Registry.SetValue(keyName, "PaTemp13Low", PaTemp13Low);
            Registry.SetValue(keyName, "PaTemp14Low", PaTemp14Low);
            Registry.SetValue(keyName, "PaTemp15Low", PaTemp15Low);
            Registry.SetValue(keyName, "PaTemp16Low", PaTemp16Low);
            Registry.SetValue(keyName, "RfVmonLow", RfVmonLow);
            Registry.SetValue(keyName, "SeedHumidLow", SeedHumidLow);
            Registry.SetValue(keyName, "PaHumidLow", PaHumidLow);
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
