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
using System.Reflection;
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
        public RelayCommand OnSeedCommand { get; set; }
        public RelayCommand OnPa1Command { get; set; }
        public RelayCommand OnPa2Command { get; set; }
        public RelayCommand OnPa3Command { get; set; }
        public RelayCommand OnPa4Command { get; set; }
        public RelayCommand OnPa4_1Command { get; set; }
        public RelayCommand OnPa4_2Command { get; set; }
        public RelayCommand OnPa4_3Command { get; set; }
        public RelayCommand OnPa4_4Command { get; set; }
        public RelayCommand OnPa4_5Command { get; set; }
        public RelayCommand OnPa4_6Command { get; set; }
        public RelayCommand OnPolCommand { get; set; }
        public RelayCommand OnSetCommand { get; set; }
        public string imgSourcePath { get; set; }

        private string _backgroundPath;
        public string BackgroundPath
        {
            get { return _backgroundPath; }
            set
            {
                _backgroundPath = value;
                NotifyPropertyChanged();
            }
        }
        private string _seedImgPath;
        public string SeedImgPath
        {
            get { return _seedImgPath; }
            set
            {
                _seedImgPath = value;
                NotifyPropertyChanged();
            }
        }
        private string _pa1ImgPath;
        public string Pa1ImgPath
        {
            get { return _pa1ImgPath; }
            set
            {
                _pa1ImgPath = value;
                NotifyPropertyChanged();
            }
        }
        private string _pa2ImgPath;
        public string Pa2ImgPath
        {
            get { return _pa2ImgPath; }
            set
            {
                _pa2ImgPath = value;
                NotifyPropertyChanged();
            }
        }
        private string _pa3ImgPath;
        public string Pa3ImgPath
        {
            get { return _pa3ImgPath; }
            set
            {
                _pa3ImgPath = value;
                NotifyPropertyChanged();
            }
        }
        private string _pa4ImgPath;
        public string Pa4ImgPath
        {
            get { return _pa4ImgPath; }
            set
            {
                _pa4ImgPath = value;
                NotifyPropertyChanged();
            }
        }
        private bool _seedBtnStatus;
        public bool SeedBtnStatus
        {
            get { return _seedBtnStatus; }
            set
            {
                _seedBtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa1BtnStatus;
        public bool Pa1BtnStatus
        {
            get { return _pa1BtnStatus; }
            set
            {
                _pa1BtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa2BtnStatus;
        public bool Pa2BtnStatus
        {
            get { return _pa2BtnStatus; }
            set
            {
                _pa2BtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa3BtnStatus;
        public bool Pa3BtnStatus
        {
            get { return _pa3BtnStatus; }
            set
            {
                _pa3BtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4BtnStatus;
        public bool Pa4BtnStatus
        {
            get { return _pa4BtnStatus; }
            set
            {
                _pa4BtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_1BtnStatus;
        public bool Pa4_1BtnStatus
        {
            get { return _pa4_1BtnStatus; }
            set
            {
                _pa4_1BtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_2BtnStatus;
        public bool Pa4_2BtnStatus
        {
            get { return _pa4_2BtnStatus; }
            set
            {
                _pa4_2BtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_3BtnStatus;
        public bool Pa4_3BtnStatus
        {
            get { return _pa4_3BtnStatus; }
            set
            {
                _pa4_3BtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_4BtnStatus;
        public bool Pa4_4BtnStatus
        {
            get { return _pa4_4BtnStatus; }
            set
            {
                _pa4_4BtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_5BtnStatus;
        public bool Pa4_5BtnStatus
        {
            get { return _pa4_5BtnStatus; }
            set
            {
                _pa4_5BtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_6BtnStatus;
        public bool Pa4_6BtnStatus
        {
            get { return _pa4_6BtnStatus; }
            set
            {
                _pa4_6BtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _polBtnStatus;
        public bool PolBtnStatus
        {
            get { return _polBtnStatus; }
            set
            {
                _polBtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _setBtnStatus;
        public bool SetBtnStatus
        {
            get { return _setBtnStatus; }
            set
            {
                _setBtnStatus = value;
                NotifyPropertyChanged();
            }
        }
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ControlViewModel()
        {
            OnSeedCommand = new RelayCommand(OnSeedCommandAction, null);
            OnPa1Command = new RelayCommand(OnPa1CommandAction, null);
            OnPa2Command = new RelayCommand(OnPa2CommandAction, null);
            OnPa3Command = new RelayCommand(OnPa3CommandAction, null);
            OnPa4Command = new RelayCommand(OnPa4CommandAction, null);
            OnPa4_1Command = new RelayCommand(OnPa4_1CommandAction, null);
            OnPa4_2Command = new RelayCommand(OnPa4_2CommandAction, null);
            OnPa4_3Command = new RelayCommand(OnPa4_3CommandAction, null);
            OnPa4_4Command = new RelayCommand(OnPa4_4CommandAction, null);
            OnPa4_5Command = new RelayCommand(OnPa4_5CommandAction, null);
            OnPa4_6Command = new RelayCommand(OnPa4_6CommandAction, null);
            OnPolCommand = new RelayCommand(OnPolCommandAction, null);
            OnSetCommand = new RelayCommand(OnSetCommandAction, null);

            Messenger.Default.Register<string>(this, MessageReceived);
            Messenger.Default.Register<monValue>(this, OnReceiveMessageAction);
            Messenger.Default.Register<readSetValue>(this, OnReceiveMessageAction);

            imgSourcePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            BackgroundPath = imgSourcePath + @"\images\Background.png";
            SeedImgPath = imgSourcePath + @"\images\SEED_base.png";
            Pa1ImgPath = imgSourcePath + @"\images\PA1_base.png";
            Pa2ImgPath = imgSourcePath + @"\images\PA2_base.png";
            Pa3ImgPath = imgSourcePath + @"\images\PA3_base.png";
            Pa4ImgPath = imgSourcePath + @"\images\PA4_base.png";
        }

        private void MessageReceived(string message)
        {
            if (message == "seedOn")
            {
                SeedImgPath = imgSourcePath + @"\images\SEED_normal.png";
            }
            else if (message == "seedOff")
            {
                SeedImgPath = imgSourcePath + @"\images\SEED_base.png";
            }
            else if (message == "amp1On")
            {
                Pa1ImgPath = imgSourcePath + @"\images\PA1_normal.png";
            }
            else if (message == "amp1Off")
            {
                Pa1ImgPath = imgSourcePath + @"\images\PA1_base.png";
            }
            else if (message == "amp2On")
            {
                Pa2ImgPath = imgSourcePath + @"\images\PA2_normal.png";
            }
            else if (message == "amp2Off")
            {
                Pa2ImgPath = imgSourcePath + @"\images\PA2_base.png";
            }
            else if (message == "amp3On")
            {
                Pa3ImgPath = imgSourcePath + @"\images\PA3_normal.png";
            }
            else if (message == "amp3Off")
            {
                Pa3ImgPath = imgSourcePath + @"\images\PA3_base.png";
            }
            else if (message == "amp4On")
            {
                Pa4ImgPath = imgSourcePath + @"\images\PA4_normal.png";
            }
            else if (message == "amp4Off")
            {
                Pa4ImgPath = imgSourcePath + @"\images\PA4_base.png";
            }
        }
        private void OnSeedCommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "seedOn",
            };
            Messenger.Default.Send(lcb002Cmd);
        }

        private void OnPa1CommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "amp1On",
            };
            Messenger.Default.Send(lcb002Cmd);
        }

        private void OnPa2CommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "amp2On",
            };
            Messenger.Default.Send(lcb002Cmd);
        }

        private void OnPa3CommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "amp3On",
            };
            Messenger.Default.Send(lcb002Cmd);
        }

        private void OnPa4CommandAction()
        {
            OnPa4_1CommandAction();
            OnPa4_2CommandAction();
            OnPa4_3CommandAction();
            OnPa4_4CommandAction();
            OnPa4_5CommandAction();
            OnPa4_6CommandAction();
        }

        private void OnPa4_1CommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "amp4_1On",
            };
            Messenger.Default.Send(lcb002Cmd);
        }

        private void OnPa4_2CommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "amp4_2On",
            };
            Messenger.Default.Send(lcb002Cmd);
        }

        private void OnPa4_3CommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "amp4_3On",
            };
            Messenger.Default.Send(lcb002Cmd);
        }

        private void OnPa4_4CommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "amp4_4On",
            };
            Messenger.Default.Send(lcb002Cmd);
        }

        private void OnPa4_5CommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "amp4_5On",
            };
            Messenger.Default.Send(lcb002Cmd);
        }

        private void OnPa4_6CommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "amp4_6On",
            };
            Messenger.Default.Send(lcb002Cmd);
        }
        private void OnPolCommandAction()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                cmd = "polOn",
            };
            Messenger.Default.Send(lcb002Cmd);
        }
        private void OnSetCommandAction()
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
                PolResponseSet = PolResponseRead
            };
            Messenger.Default.Send(lcb004writeSetCmd);
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
            PolResponseRead = obj.PolResponseRead;
        }
    }
}
