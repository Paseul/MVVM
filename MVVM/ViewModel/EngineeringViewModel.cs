using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
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
    public class EngineeringViewModel : ViewModelBase, INotifyPropertyChanged
    {
        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "SystemController";
        const string keyName = userRoot + "\\" + subkey;

        public RelayCommand OnSetSetCommand { get; set; }
        public RelayCommand OnSetLoadCommand { get; set; }
        public RelayCommand OnCalSetCommand { get; set; }


        private float _seedCurrentReadValue;
        public float SeedCurrentReadValue
        {
            get { return _seedCurrentReadValue; }
            set
            {
                _seedCurrentReadValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _seedTempReadValue;
        public float SeedTempReadValue
        {
            get { return _seedTempReadValue; }
            set
            {
                _seedTempReadValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _hsTempReadValue;
        public float HsTempReadValue
        {
            get { return _hsTempReadValue; }
            set
            {
                _hsTempReadValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa1CurrentReadValue;
        public float Pa1CurrentReadValue
        {
            get { return _pa1CurrentReadValue; }
            set
            {
                _pa1CurrentReadValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa2CurrentReadValue;
        public float Pa2CurrentReadValue
        {
            get { return _pa2CurrentReadValue; }
            set
            {
                _pa2CurrentReadValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa3CurrentReadValue;
        public float Pa3CurrentReadValue
        {
            get { return _pa3CurrentReadValue; }
            set
            {
                _pa3CurrentReadValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1CurrentReadValueR1;
        public float Pa4_1CurrentReadValueR1
        {
            get { return _pa4_1CurrentReadValueR1; }
            set
            {
                _pa4_1CurrentReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1TimeReadValueR1;
        public float Pa4_1TimeReadValueR1
        {
            get { return _pa4_1TimeReadValueR1; }
            set
            {
                _pa4_1TimeReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1CurrentReadValueR2;
        public float Pa4_1CurrentReadValueR2
        {
            get { return _pa4_1CurrentReadValueR2; }
            set
            {
                _pa4_1CurrentReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1TimeReadValueR2;
        public float Pa4_1TimeReadValueR2
        {
            get { return _pa4_1TimeReadValueR2; }
            set
            {
                _pa4_1TimeReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1CurrentReadValueR3;
        public float Pa4_1CurrentReadValueR3
        {
            get { return _pa4_1CurrentReadValueR3; }
            set
            {
                _pa4_1CurrentReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1TimeReadValueR3;
        public float Pa4_1TimeReadValueR3
        {
            get { return _pa4_1TimeReadValueR3; }
            set
            {
                _pa4_1TimeReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2CurrentReadValueR1;
        public float Pa4_2CurrentReadValueR1
        {
            get { return _pa4_2CurrentReadValueR1; }
            set
            {
                _pa4_2CurrentReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2TimeReadValueR1;
        public float Pa4_2TimeReadValueR1
        {
            get { return _pa4_2TimeReadValueR1; }
            set
            {
                _pa4_2TimeReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2CurrentReadValueR2;
        public float Pa4_2CurrentReadValueR2
        {
            get { return _pa4_2CurrentReadValueR2; }
            set
            {
                _pa4_2CurrentReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2TimeReadValueR2;
        public float Pa4_2TimeReadValueR2
        {
            get { return _pa4_2TimeReadValueR2; }
            set
            {
                _pa4_2TimeReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2CurrentReadValueR3;
        public float Pa4_2CurrentReadValueR3
        {
            get { return _pa4_2CurrentReadValueR3; }
            set
            {
                _pa4_2CurrentReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2TimeReadValueR3;
        public float Pa4_2TimeReadValueR3
        {
            get { return _pa4_2TimeReadValueR3; }
            set
            {
                _pa4_2TimeReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3CurrentReadValueR1;
        public float Pa4_3CurrentReadValueR1
        {
            get { return _pa4_3CurrentReadValueR1; }
            set
            {
                _pa4_3CurrentReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3TimeReadValueR1;
        public float Pa4_3TimeReadValueR1
        {
            get { return _pa4_3TimeReadValueR1; }
            set
            {
                _pa4_3TimeReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3CurrentReadValueR2;
        public float Pa4_3CurrentReadValueR2
        {
            get { return _pa4_3CurrentReadValueR2; }
            set
            {
                _pa4_3CurrentReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3TimeReadValueR2;
        public float Pa4_3TimeReadValueR2
        {
            get { return _pa4_3TimeReadValueR2; }
            set
            {
                _pa4_3TimeReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3CurrentReadValueR3;
        public float Pa4_3CurrentReadValueR3
        {
            get { return _pa4_3CurrentReadValueR3; }
            set
            {
                _pa4_3CurrentReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3TimeReadValueR3;
        public float Pa4_3TimeReadValueR3
        {
            get { return _pa4_3TimeReadValueR3; }
            set
            {
                _pa4_3TimeReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4CurrentReadValueR1;
        public float Pa4_4CurrentReadValueR1
        {
            get { return _pa4_4CurrentReadValueR1; }
            set
            {
                _pa4_4CurrentReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4TimeReadValueR1;
        public float Pa4_4TimeReadValueR1
        {
            get { return _pa4_4TimeReadValueR1; }
            set
            {
                _pa4_4TimeReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4CurrentReadValueR2;
        public float Pa4_4CurrentReadValueR2
        {
            get { return _pa4_4CurrentReadValueR2; }
            set
            {
                _pa4_4CurrentReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4TimeReadValueR2;
        public float Pa4_4TimeReadValueR2
        {
            get { return _pa4_4TimeReadValueR2; }
            set
            {
                _pa4_4TimeReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4CurrentReadValueR3;
        public float Pa4_4CurrentReadValueR3
        {
            get { return _pa4_4CurrentReadValueR3; }
            set
            {
                _pa4_4CurrentReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4TimeReadValueR3;
        public float Pa4_4TimeReadValueR3
        {
            get { return _pa4_4TimeReadValueR3; }
            set
            {
                _pa4_4TimeReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5CurrentReadValueR1;
        public float Pa4_5CurrentReadValueR1
        {
            get { return _pa4_5CurrentReadValueR1; }
            set
            {
                _pa4_5CurrentReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5TimeReadValueR1;
        public float Pa4_5TimeReadValueR1
        {
            get { return _pa4_5TimeReadValueR1; }
            set
            {
                _pa4_5TimeReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5CurrentReadValueR2;
        public float Pa4_5CurrentReadValueR2
        {
            get { return _pa4_5CurrentReadValueR2; }
            set
            {
                _pa4_5CurrentReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5TimeReadValueR2;
        public float Pa4_5TimeReadValueR2
        {
            get { return _pa4_5TimeReadValueR2; }
            set
            {
                _pa4_5TimeReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5CurrentReadValueR3;
        public float Pa4_5CurrentReadValueR3
        {
            get { return _pa4_5CurrentReadValueR3; }
            set
            {
                _pa4_5CurrentReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5TimeReadValueR3;
        public float Pa4_5TimeReadValueR3
        {
            get { return _pa4_5TimeReadValueR3; }
            set
            {
                _pa4_5TimeReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6CurrentReadValueR1;
        public float Pa4_6CurrentReadValueR1
        {
            get { return _pa4_6CurrentReadValueR1; }
            set
            {
                _pa4_6CurrentReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6TimeReadValueR1;
        public float Pa4_6TimeReadValueR1
        {
            get { return _pa4_6TimeReadValueR1; }
            set
            {
                _pa4_6TimeReadValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6CurrentReadValueR2;
        public float Pa4_6CurrentReadValueR2
        {
            get { return _pa4_6CurrentReadValueR2; }
            set
            {
                _pa4_6CurrentReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6TimeReadValueR2;
        public float Pa4_6TimeReadValueR2
        {
            get { return _pa4_6TimeReadValueR2; }
            set
            {
                _pa4_6TimeReadValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6CurrentReadValueR3;
        public float Pa4_6CurrentReadValueR3
        {
            get { return _pa4_6CurrentReadValueR3; }
            set
            {
                _pa4_6CurrentReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6TimeReadValueR3;
        public float Pa4_6TimeReadValueR3
        {
            get { return _pa4_6TimeReadValueR3; }
            set
            {
                _pa4_6TimeReadValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _rfVxpVoltReadValue;
        public float RfVxpVoltReadValue
        {
            get { return _rfVxpVoltReadValue; }
            set
            {
                _rfVxpVoltReadValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _rfVampVoltReadValue;
        public float RfVampVoltReadValue
        {
            get { return _rfVampVoltReadValue; }
            set
            {
                _rfVampVoltReadValue = value;
                NotifyPropertyChanged();
            }
        }
        private string _polResponseRead;
        public string PolResponseRead
        {
            get { return _polResponseRead; }
            set
            {
                _polResponseRead = value;
                NotifyPropertyChanged();
            }
        }
        private float _seedCurrentSetValue;
        public float SeedCurrentSetValue
        {
            get { return _seedCurrentSetValue; }
            set
            {
                _seedCurrentSetValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _seedTempSetValue;
        public float SeedTempSetValue
        {
            get { return _seedTempSetValue; }
            set
            {
                _seedTempSetValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _hsTempSetValue;
        public float HsTempSetValue
        {
            get { return _hsTempSetValue; }
            set
            {
                _hsTempSetValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa1CurrentSetValue;
        public float Pa1CurrentSetValue
        {
            get { return _pa1CurrentSetValue; }
            set
            {
                _pa1CurrentSetValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa2CurrentSetValue;
        public float Pa2CurrentSetValue
        {
            get { return _pa2CurrentSetValue; }
            set
            {
                _pa2CurrentSetValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa3CurrentSetValue;
        public float Pa3CurrentSetValue
        {
            get { return _pa3CurrentSetValue; }
            set
            {
                _pa3CurrentSetValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1CurrentSetValueR1;
        public float Pa4_1CurrentSetValueR1
        {
            get { return _pa4_1CurrentSetValueR1; }
            set
            {
                _pa4_1CurrentSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1TimeSetValueR1;
        public float Pa4_1TimeSetValueR1
        {
            get { return _pa4_1TimeSetValueR1; }
            set
            {
                _pa4_1TimeSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1CurrentSetValueR2;
        public float Pa4_1CurrentSetValueR2
        {
            get { return _pa4_1CurrentSetValueR2; }
            set
            {
                _pa4_1CurrentSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1TimeSetValueR2;
        public float Pa4_1TimeSetValueR2
        {
            get { return _pa4_1TimeSetValueR2; }
            set
            {
                _pa4_1TimeSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1CurrentSetValueR3;
        public float Pa4_1CurrentSetValueR3
        {
            get { return _pa4_1CurrentSetValueR3; }
            set
            {
                _pa4_1CurrentSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1TimeSetValueR3;
        public float Pa4_1TimeSetValueR3
        {
            get { return _pa4_1TimeSetValueR3; }
            set
            {
                _pa4_1TimeSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2CurrentSetValueR1;
        public float Pa4_2CurrentSetValueR1
        {
            get { return _pa4_2CurrentSetValueR1; }
            set
            {
                _pa4_2CurrentSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2TimeSetValueR1;
        public float Pa4_2TimeSetValueR1
        {
            get { return _pa4_2TimeSetValueR1; }
            set
            {
                _pa4_2TimeSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2CurrentSetValueR2;
        public float Pa4_2CurrentSetValueR2
        {
            get { return _pa4_2CurrentSetValueR2; }
            set
            {
                _pa4_2CurrentSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2TimeSetValueR2;
        public float Pa4_2TimeSetValueR2
        {
            get { return _pa4_2TimeSetValueR2; }
            set
            {
                _pa4_2TimeSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2CurrentSetValueR3;
        public float Pa4_2CurrentSetValueR3
        {
            get { return _pa4_2CurrentSetValueR3; }
            set
            {
                _pa4_2CurrentSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2TimeSetValueR3;
        public float Pa4_2TimeSetValueR3
        {
            get { return _pa4_2TimeSetValueR3; }
            set
            {
                _pa4_2TimeSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3CurrentSetValueR1;
        public float Pa4_3CurrentSetValueR1
        {
            get { return _pa4_3CurrentSetValueR1; }
            set
            {
                _pa4_3CurrentSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3TimeSetValueR1;
        public float Pa4_3TimeSetValueR1
        {
            get { return _pa4_3TimeSetValueR1; }
            set
            {
                _pa4_3TimeSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3CurrentSetValueR2;
        public float Pa4_3CurrentSetValueR2
        {
            get { return _pa4_3CurrentSetValueR2; }
            set
            {
                _pa4_3CurrentSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3TimeSetValueR2;
        public float Pa4_3TimeSetValueR2
        {
            get { return _pa4_3TimeSetValueR2; }
            set
            {
                _pa4_3TimeSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3CurrentSetValueR3;
        public float Pa4_3CurrentSetValueR3
        {
            get { return _pa4_3CurrentSetValueR3; }
            set
            {
                _pa4_3CurrentSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3TimeSetValueR3;
        public float Pa4_3TimeSetValueR3
        {
            get { return _pa4_3TimeSetValueR3; }
            set
            {
                _pa4_3TimeSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4CurrentSetValueR1;
        public float Pa4_4CurrentSetValueR1
        {
            get { return _pa4_4CurrentSetValueR1; }
            set
            {
                _pa4_4CurrentSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4TimeSetValueR1;
        public float Pa4_4TimeSetValueR1
        {
            get { return _pa4_4TimeSetValueR1; }
            set
            {
                _pa4_4TimeSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4CurrentSetValueR2;
        public float Pa4_4CurrentSetValueR2
        {
            get { return _pa4_4CurrentSetValueR2; }
            set
            {
                _pa4_4CurrentSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4TimeSetValueR2;
        public float Pa4_4TimeSetValueR2
        {
            get { return _pa4_4TimeSetValueR2; }
            set
            {
                _pa4_4TimeSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4CurrentSetValueR3;
        public float Pa4_4CurrentSetValueR3
        {
            get { return _pa4_4CurrentSetValueR3; }
            set
            {
                _pa4_4CurrentSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4TimeSetValueR3;
        public float Pa4_4TimeSetValueR3
        {
            get { return _pa4_4TimeSetValueR3; }
            set
            {
                _pa4_4TimeSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5CurrentSetValueR1;
        public float Pa4_5CurrentSetValueR1
        {
            get { return _pa4_5CurrentSetValueR1; }
            set
            {
                _pa4_5CurrentSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5TimeSetValueR1;
        public float Pa4_5TimeSetValueR1
        {
            get { return _pa4_5TimeSetValueR1; }
            set
            {
                _pa4_5TimeSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5CurrentSetValueR2;
        public float Pa4_5CurrentSetValueR2
        {
            get { return _pa4_5CurrentSetValueR2; }
            set
            {
                _pa4_5CurrentSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5TimeSetValueR2;
        public float Pa4_5TimeSetValueR2
        {
            get { return _pa4_5TimeSetValueR2; }
            set
            {
                _pa4_5TimeSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5CurrentSetValueR3;
        public float Pa4_5CurrentSetValueR3
        {
            get { return _pa4_5CurrentSetValueR3; }
            set
            {
                _pa4_5CurrentSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5TimeSetValueR3;
        public float Pa4_5TimeSetValueR3
        {
            get { return _pa4_5TimeSetValueR3; }
            set
            {
                _pa4_5TimeSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6CurrentSetValueR1;
        public float Pa4_6CurrentSetValueR1
        {
            get { return _pa4_6CurrentSetValueR1; }
            set
            {
                _pa4_6CurrentSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6TimeSetValueR1;
        public float Pa4_6TimeSetValueR1
        {
            get { return _pa4_6TimeSetValueR1; }
            set
            {
                _pa4_6TimeSetValueR1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6CurrentSetValueR2;
        public float Pa4_6CurrentSetValueR2
        {
            get { return _pa4_6CurrentSetValueR2; }
            set
            {
                _pa4_6CurrentSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6TimeSetValueR2;
        public float Pa4_6TimeSetValueR2
        {
            get { return _pa4_6TimeSetValueR2; }
            set
            {
                _pa4_6TimeSetValueR2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6CurrentSetValueR3;
        public float Pa4_6CurrentSetValueR3
        {
            get { return _pa4_6CurrentSetValueR3; }
            set
            {
                _pa4_6CurrentSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6TimeSetValueR3;
        public float Pa4_6TimeSetValueR3
        {
            get { return _pa4_6TimeSetValueR3; }
            set
            {
                _pa4_6TimeSetValueR3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _rfVxpVoltSetValue;
        public float RfVxpVoltSetValue
        {
            get { return _rfVxpVoltSetValue; }
            set
            {
                _rfVxpVoltSetValue = value;
                NotifyPropertyChanged();
            }
        }
        private float _rfVampVoltSetValue;
        public float RfVampVoltSetValue
        {
            get { return _rfVampVoltSetValue; }
            set
            {
                _rfVampVoltSetValue = value;
                NotifyPropertyChanged();
            }
        }        
        private float _pdChannel;
        public float PdChannel
        {
            get { return _pdChannel; }
            set
            {
                _pdChannel = value;
                NotifyPropertyChanged();
            }
        }
        private float _tableLength;
        public float TableLength
        {
            get { return _tableLength; }
            set
            {
                _tableLength = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdAdc1;
        public float PdAdc1
        {
            get { return _pdAdc1; }
            set
            {
                _pdAdc1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdAdc2;
        public float PdAdc2
        {
            get { return _pdAdc2; }
            set
            {
                _pdAdc2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdAdc3;
        public float PdAdc3
        {
            get { return _pdAdc3; }
            set
            {
                _pdAdc3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdAdc4;
        public float PdAdc4
        {
            get { return _pdAdc4; }
            set
            {
                _pdAdc4 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdAdc5;
        public float PdAdc5
        {
            get { return _pdAdc5; }
            set
            {
                _pdAdc5 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdAdc6;
        public float PdAdc6
        {
            get { return _pdAdc6; }
            set
            {
                _pdAdc6 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdAdc7;
        public float PdAdc7
        {
            get { return _pdAdc7; }
            set
            {
                _pdAdc7 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdAdc8;
        public float PdAdc8
        {
            get { return _pdAdc8; }
            set
            {
                _pdAdc8 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdAdc9;
        public float PdAdc9
        {
            get { return _pdAdc9; }
            set
            {
                _pdAdc9 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdAdc10;
        public float PdAdc10
        {
            get { return _pdAdc10; }
            set
            {
                _pdAdc10 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdPower1;
        public float PdPower1
        {
            get { return _pdPower1; }
            set
            {
                _pdPower1 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdPower2;
        public float PdPower2
        {
            get { return _pdPower2; }
            set
            {
                _pdPower2 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdPower3;
        public float PdPower3
        {
            get { return _pdPower3; }
            set
            {
                _pdPower3 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdPower4;
        public float PdPower4
        {
            get { return _pdPower4; }
            set
            {
                _pdPower4 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdPower5;
        public float PdPower5
        {
            get { return _pdPower5; }
            set
            {
                _pdPower5 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdPower6;
        public float PdPower6
        {
            get { return _pdPower6; }
            set
            {
                _pdPower6 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdPower7;
        public float PdPower7
        {
            get { return _pdPower7; }
            set
            {
                _pdPower7 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdPower8;
        public float PdPower8
        {
            get { return _pdPower8; }
            set
            {
                _pdPower8 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdPower9;
        public float PdPower9
        {
            get { return _pdPower9; }
            set
            {
                _pdPower9 = value;
                NotifyPropertyChanged();
            }
        }
        private float _pdPower10;
        public float PdPower10
        {
            get { return _pdPower10; }
            set
            {
                _pdPower10 = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public EngineeringViewModel()
        {
            Messenger.Default.Register<writeSetValue>(this, OnReceiveMessageAction);
            Messenger.Default.Register<writeCalValue>(this, OnReceiveMessageAction);
            Messenger.Default.Register<readCalValue>(this, OnReceiveMessageAction);
            Messenger.Default.Register<setHighLimit>(this, OnReceiveMessageAction);
            Messenger.Default.Register<setLowLimit>(this, OnReceiveMessageAction);
            Messenger.Default.Register<pdCalibration>(this, OnReceiveMessageAction);
            Messenger.Default.Register<readSetValue>(this, OnReceiveMessageAction);

            OnSetSetCommand = new RelayCommand(OnSetSetCommandAction, null);
            OnSetLoadCommand = new RelayCommand(OnSetLoadCommandAction, null);
            OnCalSetCommand = new RelayCommand(OnCalSetCommandAction, null);

            SeedCurrentReadValue = float.Parse((string)Registry.GetValue(keyName, "SeedCurrentReadValue", "150"));
            SeedTempReadValue = float.Parse((string)Registry.GetValue(keyName, "SeedTempReadValue", "25"));
            HsTempReadValue = float.Parse((string)Registry.GetValue(keyName, "HsTempReadValue", "0"));
            Pa1CurrentReadValue = float.Parse((string)Registry.GetValue(keyName, "Pa1CurrentReadValue", "4"));
            Pa2CurrentReadValue = float.Parse((string)Registry.GetValue(keyName, "Pa2CurrentReadValue", "4"));
            Pa3CurrentReadValue = float.Parse((string)Registry.GetValue(keyName, "Pa3CurrentReadValue", "4"));
            Pa4_1CurrentReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_1CurrentReadValueR1", "0"));
            Pa4_1TimeReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_1TimeReadValueR1", "0"));
            Pa4_1CurrentReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_1CurrentReadValueR2", "0"));
            Pa4_1TimeReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_1TimeReadValueR2", "0"));
            Pa4_1CurrentReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_1CurrentReadValueR3", "4"));
            Pa4_1TimeReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_1TimeReadValueR3", "0"));
            Pa4_2CurrentReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_2CurrentReadValueR1", "0"));
            Pa4_2TimeReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_2TimeReadValueR1", "0"));
            Pa4_2CurrentReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_2CurrentReadValueR2", "0"));
            Pa4_2TimeReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_2TimeReadValueR2", "0"));
            Pa4_2CurrentReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_2CurrentReadValueR3", "4"));
            Pa4_2TimeReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_2TimeReadValueR3", "0"));
            Pa4_3CurrentReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_3CurrentReadValueR1", "0"));
            Pa4_3TimeReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_3TimeReadValueR1", "0"));
            Pa4_3CurrentReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_3CurrentReadValueR2", "0"));
            Pa4_3TimeReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_3TimeReadValueR2", "0"));
            Pa4_3CurrentReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_3CurrentReadValueR3", "4"));
            Pa4_3TimeReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_3TimeReadValueR3", "0"));
            Pa4_4CurrentReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_4CurrentReadValueR1", "0"));
            Pa4_4TimeReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_4TimeReadValueR1", "0"));
            Pa4_4CurrentReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_4CurrentReadValueR2", "0"));
            Pa4_4TimeReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_4TimeReadValueR2", "0"));
            Pa4_4CurrentReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_4CurrentReadValueR3", "4"));
            Pa4_4TimeReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_4TimeReadValueR3", "0"));
            Pa4_5CurrentReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_5CurrentReadValueR1", "0"));
            Pa4_5TimeReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_5TimeReadValueR1", "0"));
            Pa4_5CurrentReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_5CurrentReadValueR2", "0"));
            Pa4_5TimeReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_5TimeReadValueR2", "0"));
            Pa4_5CurrentReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_5CurrentReadValueR3", "4"));
            Pa4_5TimeReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_5TimeReadValueR3", "0"));
            Pa4_6CurrentReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_6CurrentReadValueR1", "0"));
            Pa4_6TimeReadValueR1 = float.Parse((string)Registry.GetValue(keyName, "Pa4_6TimeReadValueR1", "0"));
            Pa4_6CurrentReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_6CurrentReadValueR2", "0"));
            Pa4_6TimeReadValueR2 = float.Parse((string)Registry.GetValue(keyName, "Pa4_6TimeReadValueR2", "0"));
            Pa4_6CurrentReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_6CurrentReadValueR3", "4"));
            Pa4_6TimeReadValueR3 = float.Parse((string)Registry.GetValue(keyName, "Pa4_6TimeReadValueR3", "0"));
            RfVxpVoltReadValue = float.Parse((string)Registry.GetValue(keyName, "RfVxpVoltReadValue", "0"));
            RfVampVoltReadValue = float.Parse((string)Registry.GetValue(keyName, "RfVampVoltReadValue", "0"));

            PdChannel = float.Parse((string)Registry.GetValue(keyName, "PdChannel", "2"));
            TableLength = float.Parse((string)Registry.GetValue(keyName, "TableLength", "10"));
            PdAdc1 = float.Parse((string)Registry.GetValue(keyName, "PdAdc1", "1000"));
            PdAdc2 = float.Parse((string)Registry.GetValue(keyName, "PdAdc2", "2000"));
            PdAdc3 = float.Parse((string)Registry.GetValue(keyName, "PdAdc3", "3000"));
            PdAdc4 = float.Parse((string)Registry.GetValue(keyName, "PdAdc4", "4000"));
            PdAdc5 = float.Parse((string)Registry.GetValue(keyName, "PdAdc5", "5000"));
            PdAdc6 = float.Parse((string)Registry.GetValue(keyName, "PdAdc6", "6000"));
            PdAdc7 = float.Parse((string)Registry.GetValue(keyName, "PdAdc7", "7000"));
            PdAdc8 = float.Parse((string)Registry.GetValue(keyName, "PdAdc8", "8000"));
            PdAdc9 = float.Parse((string)Registry.GetValue(keyName, "PdAdc9", "9000"));
            PdAdc10 = float.Parse((string)Registry.GetValue(keyName, "PdAdc10", "10000"));
            PdPower1 = float.Parse((string)Registry.GetValue(keyName, "PdPower1", "100"));
            PdPower2 = float.Parse((string)Registry.GetValue(keyName, "PdPower2", "200"));
            PdPower3 = float.Parse((string)Registry.GetValue(keyName, "PdPower3", "300"));
            PdPower4 = float.Parse((string)Registry.GetValue(keyName, "PdPower4", "400"));
            PdPower5 = float.Parse((string)Registry.GetValue(keyName, "PdPower5", "500"));
            PdPower6 = float.Parse((string)Registry.GetValue(keyName, "PdPower6", "600"));
            PdPower7 = float.Parse((string)Registry.GetValue(keyName, "PdPower7", "700"));
            PdPower8 = float.Parse((string)Registry.GetValue(keyName, "PdPower8", "800"));
            PdPower9 = float.Parse((string)Registry.GetValue(keyName, "PdPower9", "900"));
            PdPower10 = float.Parse((string)Registry.GetValue(keyName, "PdPower10", "1000"));
        }

        private void OnSetSetCommandAction()
        {
            var lcb004writeSetCmd = new lcb004writeSetCmd()
            {
                SeedCurrentSetValue = SeedCurrentReadValue,
                SeedTempSetValue = SeedTempReadValue,
                HsTempSetValue = HsTempReadValue,
                Pa1CurrentSetValue = Pa1CurrentReadValue,
                Pa2CurrentSetValue = Pa2CurrentReadValue,
                Pa3CurrentSetValue = Pa3CurrentReadValue,
                Pa4_1CurrentSetValueR1 = Pa4_1CurrentReadValueR1,
                Pa4_1TimeSetValueR1 = Pa4_1TimeReadValueR1,
                Pa4_1CurrentSetValueR2 = Pa4_1CurrentReadValueR2,
                Pa4_1TimeSetValueR2 = Pa4_1TimeReadValueR2,
                Pa4_1CurrentSetValueR3 = Pa4_1CurrentReadValueR3,
                Pa4_1TimeSetValueR3 = Pa4_1TimeReadValueR3,
                Pa4_2CurrentSetValueR1 = Pa4_2CurrentReadValueR1,
                Pa4_2TimeSetValueR1 = Pa4_2TimeReadValueR1,
                Pa4_2CurrentSetValueR2 = Pa4_2CurrentReadValueR2,
                Pa4_2TimeSetValueR2 = Pa4_2TimeReadValueR2,
                Pa4_2CurrentSetValueR3 = Pa4_2CurrentReadValueR3,
                Pa4_2TimeSetValueR3 = Pa4_2TimeReadValueR3,
                Pa4_3CurrentSetValueR1 = Pa4_3CurrentReadValueR1,
                Pa4_3TimeSetValueR1 = Pa4_3TimeReadValueR1,
                Pa4_3CurrentSetValueR2 = Pa4_3CurrentReadValueR2,
                Pa4_3TimeSetValueR2 = Pa4_3TimeReadValueR2,
                Pa4_3CurrentSetValueR3 = Pa4_3CurrentReadValueR3,
                Pa4_3TimeSetValueR3 = Pa4_3TimeReadValueR3,
                Pa4_4CurrentSetValueR1 = Pa4_4CurrentReadValueR1,
                Pa4_4TimeSetValueR1 = Pa4_4TimeReadValueR1,
                Pa4_4CurrentSetValueR2 = Pa4_4CurrentReadValueR2,
                Pa4_4TimeSetValueR2 = Pa4_4TimeReadValueR2,
                Pa4_4CurrentSetValueR3 = Pa4_4CurrentReadValueR3,
                Pa4_4TimeSetValueR3 = Pa4_4TimeReadValueR3,
                Pa4_5CurrentSetValueR1 = Pa4_5CurrentReadValueR1,
                Pa4_5TimeSetValueR1 = Pa4_5TimeReadValueR1,
                Pa4_5CurrentSetValueR2 = Pa4_5CurrentReadValueR2,
                Pa4_5TimeSetValueR2 = Pa4_5TimeReadValueR2,
                Pa4_5CurrentSetValueR3 = Pa4_5CurrentReadValueR3,
                Pa4_5TimeSetValueR3 = Pa4_5TimeReadValueR3,
                Pa4_6CurrentSetValueR1 = Pa4_6CurrentReadValueR1,
                Pa4_6TimeSetValueR1 = Pa4_6TimeReadValueR1,
                Pa4_6CurrentSetValueR2 = Pa4_6CurrentReadValueR2,
                Pa4_6TimeSetValueR2 = Pa4_6TimeReadValueR2,
                Pa4_6CurrentSetValueR3 = Pa4_6CurrentReadValueR3,
                Pa4_6TimeSetValueR3 = Pa4_6TimeReadValueR3,
                RfVxpVoltSetValue = RfVxpVoltReadValue,
                RfVampVoltSetValue = RfVampVoltReadValue,
            };
            Messenger.Default.Send(lcb004writeSetCmd);
            
            lcb002CmdSend();

            Registry.SetValue(keyName, "SeedCurrentReadValue", SeedCurrentReadValue);
            Registry.SetValue(keyName, "SeedTempReadValue", SeedTempReadValue);
            Registry.SetValue(keyName, "HsTempReadValue", HsTempReadValue);
            Registry.SetValue(keyName, "Pa1CurrentReadValue", Pa1CurrentReadValue);
            Registry.SetValue(keyName, "Pa2CurrentReadValue", Pa2CurrentReadValue);
            Registry.SetValue(keyName, "Pa3CurrentReadValue", Pa3CurrentReadValue);
            Registry.SetValue(keyName, "Pa4_1CurrentReadValueR1", Pa4_1CurrentReadValueR1);
            Registry.SetValue(keyName, "Pa4_1TimeReadValueR1", Pa4_1TimeReadValueR1);
            Registry.SetValue(keyName, "Pa4_1CurrentReadValueR2", Pa4_1CurrentReadValueR2);
            Registry.SetValue(keyName, "Pa4_1TimeReadValueR2", Pa4_1TimeReadValueR2);
            Registry.SetValue(keyName, "Pa4_1CurrentReadValueR3", Pa4_1CurrentReadValueR3);
            Registry.SetValue(keyName, "Pa4_1TimeReadValueR3", Pa4_1TimeReadValueR3);
            Registry.SetValue(keyName, "Pa4_2CurrentReadValueR1", Pa4_2CurrentReadValueR1);
            Registry.SetValue(keyName, "Pa4_2TimeReadValueR1", Pa4_2TimeReadValueR1);
            Registry.SetValue(keyName, "Pa4_2CurrentReadValueR2", Pa4_2CurrentReadValueR2);
            Registry.SetValue(keyName, "Pa4_2TimeReadValueR2", Pa4_2TimeReadValueR2);
            Registry.SetValue(keyName, "Pa4_2CurrentReadValueR3", Pa4_2CurrentReadValueR3);
            Registry.SetValue(keyName, "Pa4_2TimeReadValueR3", Pa4_2TimeReadValueR3);
            Registry.SetValue(keyName, "Pa4_3CurrentReadValueR1", Pa4_3CurrentReadValueR1);
            Registry.SetValue(keyName, "Pa4_3TimeReadValueR1", Pa4_3TimeReadValueR1);
            Registry.SetValue(keyName, "Pa4_3CurrentReadValueR2", Pa4_3CurrentReadValueR2);
            Registry.SetValue(keyName, "Pa4_3TimeReadValueR2", Pa4_3TimeReadValueR2);
            Registry.SetValue(keyName, "Pa4_3CurrentReadValueR3", Pa4_3CurrentReadValueR3);
            Registry.SetValue(keyName, "Pa4_3TimeReadValueR3", Pa4_3TimeReadValueR3);
            Registry.SetValue(keyName, "Pa4_4CurrentReadValueR1", Pa4_4CurrentReadValueR1);
            Registry.SetValue(keyName, "Pa4_4TimeReadValueR1", Pa4_4TimeReadValueR1);
            Registry.SetValue(keyName, "Pa4_4CurrentReadValueR2", Pa4_4CurrentReadValueR2);
            Registry.SetValue(keyName, "Pa4_4TimeReadValueR2", Pa4_4TimeReadValueR2);
            Registry.SetValue(keyName, "Pa4_4CurrentReadValueR3", Pa4_4CurrentReadValueR3);
            Registry.SetValue(keyName, "Pa4_4TimeReadValueR3", Pa4_4TimeReadValueR3);
            Registry.SetValue(keyName, "Pa4_5CurrentReadValueR1", Pa4_5CurrentReadValueR1);
            Registry.SetValue(keyName, "Pa4_5TimeReadValueR1", Pa4_5TimeReadValueR1);
            Registry.SetValue(keyName, "Pa4_5CurrentReadValueR2", Pa4_5CurrentReadValueR2);
            Registry.SetValue(keyName, "Pa4_5TimeReadValueR2", Pa4_5TimeReadValueR2);
            Registry.SetValue(keyName, "Pa4_5CurrentReadValueR3", Pa4_5CurrentReadValueR3);
            Registry.SetValue(keyName, "Pa4_5TimeReadValueR3", Pa4_5TimeReadValueR3);
            Registry.SetValue(keyName, "Pa4_6CurrentReadValueR1", Pa4_6CurrentReadValueR1);
            Registry.SetValue(keyName, "Pa4_6TimeReadValueR1", Pa4_6TimeReadValueR1);
            Registry.SetValue(keyName, "Pa4_6CurrentReadValueR2", Pa4_6CurrentReadValueR2);
            Registry.SetValue(keyName, "Pa4_6TimeReadValueR2", Pa4_6TimeReadValueR2);
            Registry.SetValue(keyName, "Pa4_6CurrentReadValueR3", Pa4_6CurrentReadValueR3);
            Registry.SetValue(keyName, "Pa4_6TimeReadValueR3", Pa4_6TimeReadValueR3);
            Registry.SetValue(keyName, "RfVxpVoltReadValue", RfVxpVoltReadValue);
            Registry.SetValue(keyName, "RfVampVoltReadValue", RfVampVoltReadValue);
        }        

        private void OnSetLoadCommandAction()
        {
            var lcb004ReadSetCmd = new lcb004ReadSetCmd()
            {
                cmd = "readSet",
            };
            Messenger.Default.Send(lcb004ReadSetCmd);
        }
        private void OnCalSetCommandAction()
        {
            var lcb004PdCalCmd = new lcb004PdCalCmd()
            {
                PdChannel = PdChannel,
                TableLength = TableLength,
                PdAdc1 = PdAdc1,
                PdAdc2 = PdAdc2,
                PdAdc3 = PdAdc3,
                PdAdc4 = PdAdc4,
                PdAdc5 = PdAdc5,
                PdAdc6 = PdAdc6,
                PdAdc7 = PdAdc7,
                PdAdc8 = PdAdc8,
                PdAdc9 = PdAdc9,
                PdAdc10 = PdAdc10,
                PdPower1 = PdPower1,
                PdPower2 = PdPower2,
                PdPower3 = PdPower3,
                PdPower4 = PdPower4,
                PdPower5 = PdPower5,
                PdPower6 = PdPower6,
                PdPower7 = PdPower7,
                PdPower8 = PdPower8,
                PdPower9 = PdPower9,
                PdPower10 = PdPower10
            };
            Messenger.Default.Send(lcb004PdCalCmd);

            Registry.SetValue(keyName, "PdChannel", PdChannel);
            Registry.SetValue(keyName, "TableLength", TableLength);
            Registry.SetValue(keyName, "PdAdc1", PdAdc1);
            Registry.SetValue(keyName, "PdAdc2", PdAdc2);
            Registry.SetValue(keyName, "PdAdc3", PdAdc3);
            Registry.SetValue(keyName, "PdAdc4", PdAdc4);
            Registry.SetValue(keyName, "PdAdc5", PdAdc5);
            Registry.SetValue(keyName, "PdAdc6", PdAdc6);
            Registry.SetValue(keyName, "PdAdc7", PdAdc7);
            Registry.SetValue(keyName, "PdAdc8", PdAdc8);
            Registry.SetValue(keyName, "PdAdc9", PdAdc9);
            Registry.SetValue(keyName, "PdAdc10", PdAdc10);
            Registry.SetValue(keyName, "PdPower1", PdPower1);
            Registry.SetValue(keyName, "PdPower2", PdPower2);
            Registry.SetValue(keyName, "PdPower3", PdPower3);
            Registry.SetValue(keyName, "PdPower4", PdPower4);
            Registry.SetValue(keyName, "PdPower5", PdPower5);
            Registry.SetValue(keyName, "PdPower6", PdPower6);
            Registry.SetValue(keyName, "PdPower7", PdPower7);
            Registry.SetValue(keyName, "PdPower8", PdPower8);
            Registry.SetValue(keyName, "PdPower9", PdPower9);
            Registry.SetValue(keyName, "PdPower10", PdPower10);
        }

        private void OnReceiveMessageAction(writeSetValue obj)
        {
            SeedCurrentSetValue = obj.SeedCurrentSetValue;
            SeedTempSetValue = obj.SeedTempSetValue;
            HsTempSetValue = obj.HsTempSetValue;
            Pa1CurrentSetValue = obj.Pa1CurrentSetValue;
            Pa2CurrentSetValue = obj.Pa2CurrentSetValue;
            Pa3CurrentSetValue = obj.Pa3CurrentSetValue;
            Pa4_1CurrentSetValueR1 = obj.Pa4_1CurrentSetValueR1;
            Pa4_1TimeSetValueR1 = obj.Pa4_1TimeSetValueR1;
            Pa4_1CurrentSetValueR2 = obj.Pa4_1CurrentSetValueR2;
            Pa4_1TimeSetValueR2 = obj.Pa4_1TimeSetValueR2;
            Pa4_1CurrentSetValueR3 = obj.Pa4_1CurrentSetValueR3;
            Pa4_1TimeSetValueR3 = obj.Pa4_1TimeSetValueR3;
            Pa4_2CurrentSetValueR1 = obj.Pa4_2CurrentSetValueR1;
            Pa4_2TimeSetValueR1 = obj.Pa4_2TimeSetValueR1;
            Pa4_2CurrentSetValueR2 = obj.Pa4_2CurrentSetValueR2;
            Pa4_2TimeSetValueR2 = obj.Pa4_2TimeSetValueR2;
            Pa4_2CurrentSetValueR3 = obj.Pa4_2CurrentSetValueR3;
            Pa4_2TimeSetValueR3 = obj.Pa4_2TimeSetValueR3;
            Pa4_3CurrentSetValueR1 = obj.Pa4_3CurrentSetValueR1;
            Pa4_3TimeSetValueR1 = obj.Pa4_3TimeSetValueR1;
            Pa4_3CurrentSetValueR2 = obj.Pa4_3CurrentSetValueR2;
            Pa4_3TimeSetValueR2 = obj.Pa4_3TimeSetValueR2;
            Pa4_3CurrentSetValueR3 = obj.Pa4_3CurrentSetValueR3;
            Pa4_3TimeSetValueR3 = obj.Pa4_3TimeSetValueR3;
            Pa4_4CurrentSetValueR1 = obj.Pa4_4CurrentSetValueR1;
            Pa4_4TimeSetValueR1 = obj.Pa4_4TimeSetValueR1;
            Pa4_4CurrentSetValueR2 = obj.Pa4_4CurrentSetValueR2;
            Pa4_4TimeSetValueR2 = obj.Pa4_4TimeSetValueR2;
            Pa4_4CurrentSetValueR3 = obj.Pa4_4CurrentSetValueR3;
            Pa4_4TimeSetValueR3 = obj.Pa4_4TimeSetValueR3;
            Pa4_5CurrentSetValueR1 = obj.Pa4_5CurrentSetValueR1;
            Pa4_5TimeSetValueR1 = obj.Pa4_5TimeSetValueR1;
            Pa4_5CurrentSetValueR2 = obj.Pa4_5CurrentSetValueR2;
            Pa4_5TimeSetValueR2 = obj.Pa4_5TimeSetValueR2;
            Pa4_5CurrentSetValueR3 = obj.Pa4_5CurrentSetValueR3;
            Pa4_5TimeSetValueR3 = obj.Pa4_5TimeSetValueR3;
            Pa4_6CurrentSetValueR1 = obj.Pa4_6CurrentSetValueR1;
            Pa4_6TimeSetValueR1 = obj.Pa4_6TimeSetValueR1;
            Pa4_6CurrentSetValueR2 = obj.Pa4_6CurrentSetValueR2;
            Pa4_6TimeSetValueR2 = obj.Pa4_6TimeSetValueR2;
            Pa4_6CurrentSetValueR3 = obj.Pa4_6CurrentSetValueR3;
            Pa4_6TimeSetValueR3 = obj.Pa4_6TimeSetValueR3;
            RfVxpVoltSetValue = obj.RfVxpVoltSetValue;
            RfVampVoltSetValue = obj.RfVampVoltSetValue;
        }
        private void OnReceiveMessageAction(writeCalValue obj)
        {
            Console.WriteLine(obj.SeedCurrentCal);
            Console.WriteLine(obj.SeedTempCal);
            Console.WriteLine(obj.HsTempCal);
            Console.WriteLine(obj.Pa1CurrentCal);
            Console.WriteLine(obj.Pa2CurrentCal);
            Console.WriteLine(obj.Pa3CurrentCal);
            Console.WriteLine(obj.Pa4_1CurrentCal);
            Console.WriteLine(obj.Pa4_2CurrentCal);
            Console.WriteLine(obj.Pa4_3CurrentCal);
            Console.WriteLine(obj.Pa4_4CurrentCal);
            Console.WriteLine(obj.Pa4_5CurrentCal);
            Console.WriteLine(obj.Pa4_6CurrentCal);
            Console.WriteLine(obj.RfVxpCal);
            Console.WriteLine(obj.RfVampCal);
        }
        private void OnReceiveMessageAction(readCalValue obj)
        {
            Console.WriteLine(obj.SeedCurrentCal);
            Console.WriteLine(obj.SeedTempCal);
            Console.WriteLine(obj.Pa1CurrentCal);
            Console.WriteLine(obj.Pa2CurrentCal);
            Console.WriteLine(obj.Pa3CurrentCal);
            Console.WriteLine(obj.Pa4_1CurrentCal);
            Console.WriteLine(obj.Pa4_2CurrentCal);
            Console.WriteLine(obj.Pa4_3CurrentCal);
            Console.WriteLine(obj.Pa4_4CurrentCal);
            Console.WriteLine(obj.Pa4_5CurrentCal);
            Console.WriteLine(obj.Pa4_6CurrentCal);
            Console.WriteLine(obj.Pa1VoltageCal);
            Console.WriteLine(obj.Pa2VoltageCal);
            Console.WriteLine(obj.Pa3VoltageCal);
            Console.WriteLine(obj.Pa4_1VoltageCal);
            Console.WriteLine(obj.Pa4_2VoltageCal);
            Console.WriteLine(obj.Pa4_3VoltageCal);
            Console.WriteLine(obj.Pa4_4VoltageCal);
            Console.WriteLine(obj.Pa4_5VoltageCal);
            Console.WriteLine(obj.Pa4_6VoltageCal);
            Console.WriteLine(obj.SeedTemp1Cal);
            Console.WriteLine(obj.SeedTemp2Cal);
            Console.WriteLine(obj.SeedTemp3Cal);
            Console.WriteLine(obj.PaTemp1Cal);
            Console.WriteLine(obj.PaTemp2Cal);
            Console.WriteLine(obj.PaTemp3Cal);
            Console.WriteLine(obj.PaTemp4Cal);
            Console.WriteLine(obj.PaTemp5Cal);
            Console.WriteLine(obj.PaTemp6Cal);
            Console.WriteLine(obj.PaTemp7Cal);
            Console.WriteLine(obj.PaTemp8Cal);
            Console.WriteLine(obj.PaTemp9Cal);
            Console.WriteLine(obj.PaTemp10Cal);
            Console.WriteLine(obj.PaTemp11Cal);
            Console.WriteLine(obj.PaTemp12Cal);
            Console.WriteLine(obj.PaTemp13Cal);
            Console.WriteLine(obj.PaTemp14Cal);
            Console.WriteLine(obj.PaTemp15Cal);
            Console.WriteLine(obj.PaTemp16Cal);
            Console.WriteLine(obj.RfVmonCal);
        }
        private void OnReceiveMessageAction(setHighLimit obj)
        {
            Console.WriteLine(obj.SeedCurrent);
            Console.WriteLine(obj.SeedTemp);
            Console.WriteLine(obj.Pa1Current);
            Console.WriteLine(obj.Pa2Current);
            Console.WriteLine(obj.Pa3Current);
            Console.WriteLine(obj.Pa4_1Current);
            Console.WriteLine(obj.Pa4_2Current);
            Console.WriteLine(obj.Pa4_3Current);
            Console.WriteLine(obj.Pa4_4Current);
            Console.WriteLine(obj.Pa4_5Current);
            Console.WriteLine(obj.Pa4_6Current);
            Console.WriteLine(obj.Pa1Voltage);
            Console.WriteLine(obj.Pa2Voltage);
            Console.WriteLine(obj.Pa3Voltage);
            Console.WriteLine(obj.Pa4_1Voltage);
            Console.WriteLine(obj.Pa4_2Voltage);
            Console.WriteLine(obj.Pa4_3Voltage);
            Console.WriteLine(obj.Pa4_4Voltage);
            Console.WriteLine(obj.Pa4_5Voltage);
            Console.WriteLine(obj.Pa4_6Voltage);
            Console.WriteLine(obj.Pd1);
            Console.WriteLine(obj.Pd2);
            Console.WriteLine(obj.Pd3);
            Console.WriteLine(obj.Pd4);
            Console.WriteLine(obj.Pd5);
            Console.WriteLine(obj.Pd6);
            Console.WriteLine(obj.Pd7);
            Console.WriteLine(obj.Pd8);
            Console.WriteLine(obj.SeedTemp1);
            Console.WriteLine(obj.SeedTemp2);
            Console.WriteLine(obj.SeedTemp3);
            Console.WriteLine(obj.PaTemp1);
            Console.WriteLine(obj.PaTemp2);
            Console.WriteLine(obj.PaTemp3);
            Console.WriteLine(obj.PaTemp4);
            Console.WriteLine(obj.PaTemp5);
            Console.WriteLine(obj.PaTemp6);
            Console.WriteLine(obj.PaTemp7);
            Console.WriteLine(obj.PaTemp8);
            Console.WriteLine(obj.PaTemp9);
            Console.WriteLine(obj.PaTemp10);
            Console.WriteLine(obj.PaTemp11);
            Console.WriteLine(obj.PaTemp12);
            Console.WriteLine(obj.PaTemp13);
            Console.WriteLine(obj.PaTemp14);
            Console.WriteLine(obj.PaTemp15);
            Console.WriteLine(obj.PaTemp16);
            Console.WriteLine(obj.RfVmon);
            Console.WriteLine(obj.SeedHumid);
            Console.WriteLine(obj.PaHumid);
        }

        private void OnReceiveMessageAction(setLowLimit obj)
        {
            Console.WriteLine(obj.SeedCurrent);
            Console.WriteLine(obj.SeedTemp);
            Console.WriteLine(obj.Pa1Current);
            Console.WriteLine(obj.Pa2Current);
            Console.WriteLine(obj.Pa3Current);
            Console.WriteLine(obj.Pa4_1Current);
            Console.WriteLine(obj.Pa4_2Current);
            Console.WriteLine(obj.Pa4_3Current);
            Console.WriteLine(obj.Pa4_4Current);
            Console.WriteLine(obj.Pa4_5Current);
            Console.WriteLine(obj.Pa4_6Current);
            Console.WriteLine(obj.Pa1Voltage);
            Console.WriteLine(obj.Pa2Voltage);
            Console.WriteLine(obj.Pa3Voltage);
            Console.WriteLine(obj.Pa4_1Voltage);
            Console.WriteLine(obj.Pa4_2Voltage);
            Console.WriteLine(obj.Pa4_3Voltage);
            Console.WriteLine(obj.Pa4_4Voltage);
            Console.WriteLine(obj.Pa4_5Voltage);
            Console.WriteLine(obj.Pa4_6Voltage);
            Console.WriteLine(obj.Pd1);
            Console.WriteLine(obj.Pd2);
            Console.WriteLine(obj.Pd3);
            Console.WriteLine(obj.Pd4);
            Console.WriteLine(obj.Pd5);
            Console.WriteLine(obj.Pd6);
            Console.WriteLine(obj.Pd7);
            Console.WriteLine(obj.Pd8);
            Console.WriteLine(obj.SeedTemp1);
            Console.WriteLine(obj.SeedTemp2);
            Console.WriteLine(obj.SeedTemp3);
            Console.WriteLine(obj.PaTemp1);
            Console.WriteLine(obj.PaTemp2);
            Console.WriteLine(obj.PaTemp3);
            Console.WriteLine(obj.PaTemp4);
            Console.WriteLine(obj.PaTemp5);
            Console.WriteLine(obj.PaTemp6);
            Console.WriteLine(obj.PaTemp7);
            Console.WriteLine(obj.PaTemp8);
            Console.WriteLine(obj.PaTemp9);
            Console.WriteLine(obj.PaTemp10);
            Console.WriteLine(obj.PaTemp11);
            Console.WriteLine(obj.PaTemp12);
            Console.WriteLine(obj.PaTemp13);
            Console.WriteLine(obj.PaTemp14);
            Console.WriteLine(obj.PaTemp15);
            Console.WriteLine(obj.PaTemp16);
            Console.WriteLine(obj.RfVmon);
            Console.WriteLine(obj.SeedHumid);
            Console.WriteLine(obj.PaHumid);
        }
        private void OnReceiveMessageAction(pdCalibration obj)
        {
            Console.WriteLine(obj.PdChennel);
            Console.WriteLine(obj.TableLength);
            Console.WriteLine(obj.Pd1Selection);
            Console.WriteLine(obj.Pd2Selection);
            Console.WriteLine(obj.Pd3Selection);
            Console.WriteLine(obj.Pd4Selection);
            Console.WriteLine(obj.Pd5Selection);
            Console.WriteLine(obj.Pd6Selection);
            Console.WriteLine(obj.Pd7Selection);
            Console.WriteLine(obj.PdAdc1);
            Console.WriteLine(obj.PdAdc2);
            Console.WriteLine(obj.PdAdc3);
            Console.WriteLine(obj.PdAdc4);
            Console.WriteLine(obj.PdAdc5);
            Console.WriteLine(obj.PdAdc6);
            Console.WriteLine(obj.PdAdc7);
            Console.WriteLine(obj.PdAdc8);
            Console.WriteLine(obj.PdAdc9);
            Console.WriteLine(obj.PdAdc10);
            Console.WriteLine(obj.PdLaserPower1);
            Console.WriteLine(obj.PdLaserPower2);
            Console.WriteLine(obj.PdLaserPower3);
            Console.WriteLine(obj.PdLaserPower4);
            Console.WriteLine(obj.PdLaserPower5);
            Console.WriteLine(obj.PdLaserPower6);
            Console.WriteLine(obj.PdLaserPower7);
            Console.WriteLine(obj.PdLaserPower8);
            Console.WriteLine(obj.PdLaserPower9);
            Console.WriteLine(obj.PdLaserPower10);
        }

        private async void lcb002CmdSend()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                seed = 62,
                reset = 0,
                amp = 0,
                pol = "              ",
                cmd = 2,
            };
            await Task.Delay(2000);
            Messenger.Default.Send(lcb002Cmd);
        }

        private void OnReceiveMessageAction(readSetValue obj)
        {
            SeedCurrentReadValue = obj.SeedCurrentReadValue;
            SeedTempReadValue = obj.SeedTempReadValue;
            HsTempReadValue = obj.HsTempReadValue;
            Pa1CurrentReadValue = obj.Pa1CurrentReadValue;
            Pa2CurrentReadValue = obj.Pa2CurrentReadValue;
            Pa3CurrentReadValue = obj.Pa3CurrentReadValue;
            Pa4_1CurrentReadValueR1 = obj.Pa4_1CurrentReadValueR1;
            Pa4_1TimeReadValueR1 = obj.Pa4_1TimeReadValueR1;
            Pa4_1CurrentReadValueR2 = obj.Pa4_1CurrentReadValueR2;
            Pa4_1TimeReadValueR2 = obj.Pa4_1TimeReadValueR2;
            Pa4_1CurrentReadValueR3 = obj.Pa4_1CurrentReadValueR3;
            Pa4_1TimeReadValueR3 = obj.Pa4_1TimeReadValueR3;
            Pa4_2CurrentReadValueR1 = obj.Pa4_2CurrentReadValueR1;
            Pa4_2TimeReadValueR1 = obj.Pa4_2TimeReadValueR1;
            Pa4_2CurrentReadValueR2 = obj.Pa4_2CurrentReadValueR2;
            Pa4_2TimeReadValueR2 = obj.Pa4_2TimeReadValueR2;
            Pa4_2CurrentReadValueR3 = obj.Pa4_2CurrentReadValueR3;
            Pa4_2TimeReadValueR3 = obj.Pa4_2TimeReadValueR3;
            Pa4_3CurrentReadValueR1 = obj.Pa4_3CurrentReadValueR1;
            Pa4_3TimeReadValueR1 = obj.Pa4_3TimeReadValueR1;
            Pa4_3CurrentReadValueR2 = obj.Pa4_3CurrentReadValueR2;
            Pa4_3TimeReadValueR2 = obj.Pa4_3TimeReadValueR2;
            Pa4_3CurrentReadValueR3 = obj.Pa4_3CurrentReadValueR3;
            Pa4_3TimeReadValueR3 = obj.Pa4_3TimeReadValueR3;
            Pa4_4CurrentReadValueR1 = obj.Pa4_4CurrentReadValueR1;
            Pa4_4TimeReadValueR1 = obj.Pa4_4TimeReadValueR1;
            Pa4_4CurrentReadValueR2 = obj.Pa4_4CurrentReadValueR2;
            Pa4_4TimeReadValueR2 = obj.Pa4_4TimeReadValueR2;
            Pa4_4CurrentReadValueR3 = obj.Pa4_4CurrentReadValueR3;
            Pa4_4TimeReadValueR3 = obj.Pa4_4TimeReadValueR3;
            Pa4_5CurrentReadValueR1 = obj.Pa4_5CurrentReadValueR1;
            Pa4_5TimeReadValueR1 = obj.Pa4_5TimeReadValueR1;
            Pa4_5CurrentReadValueR2 = obj.Pa4_5CurrentReadValueR2;
            Pa4_5TimeReadValueR2 = obj.Pa4_5TimeReadValueR2;
            Pa4_5CurrentReadValueR3 = obj.Pa4_5CurrentReadValueR3;
            Pa4_5TimeReadValueR3 = obj.Pa4_5TimeReadValueR3;
            Pa4_6CurrentReadValueR1 = obj.Pa4_6CurrentReadValueR1;
            Pa4_6TimeReadValueR1 = obj.Pa4_6TimeReadValueR1;
            Pa4_6CurrentReadValueR2 = obj.Pa4_6CurrentReadValueR2;
            Pa4_6TimeReadValueR2 = obj.Pa4_6TimeReadValueR2;
            Pa4_6CurrentReadValueR3 = obj.Pa4_6CurrentReadValueR3;
            Pa4_6TimeReadValueR3 = obj.Pa4_6TimeReadValueR3;
            RfVxpVoltReadValue = obj.RfVxpVoltReadValue;
            RfVampVoltReadValue = obj.RfVampVoltReadValue;
        }
    }
}
