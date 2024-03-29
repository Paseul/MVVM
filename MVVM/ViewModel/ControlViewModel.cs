﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
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
using MVVM.Model;
using System.Collections.ObjectModel;

namespace MVVM.ViewModel
{
    public class ControlViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<DataRange> _dataRanges;

        public ObservableCollection<DataRange> DataRanges
        {
            get { return _dataRanges; }
            set { _dataRanges = value; }
        }

        private DataRange _selectdData;
        public DataRange SelectdData
        {
            get { return _selectdData; }
            set { _selectdData = value; }
        }

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
        public RelayCommand OnResetCommand { get; set; }
        public RelayCommand OnSetCommand { get; set; }
        public RelayCommand OnAutoCommand { get; set; }
        public RelayCommand OnOffCommand { get; set; }
        public RelayCommand OnPa4_1Selected { get; set; }
        public RelayCommand OnPa4_2Selected { get; set; }
        public RelayCommand OnPa4_3Selected { get; set; }
        public RelayCommand OnPa4_4Selected { get; set; }
        public RelayCommand OnPa4_5Selected { get; set; }
        public RelayCommand OnPa4_6Selected { get; set; }


        public string imgSourcePath;      
        private string _backgroundPath;

        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "SystemController";
        const string keyName = userRoot + "\\" + subkey;

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
        private bool _seedFlag;
        public bool SeedFlag
        {
            get { return _seedFlag; }
            set
            {
                _seedFlag = value;
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
        private bool _paFlag;
        public bool PaFlag
        {
            get { return _paFlag; }
            set
            {
                _paFlag = value;
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
        private bool _polFlag;
        public bool PolFlag
        {
            get { return _polFlag; }
            set
            {
                _polFlag = value;
                NotifyPropertyChanged();
            }
        }
        private bool _autoBtnStatus;
        public bool AutoBtnStatus
        {
            get { return _autoBtnStatus; }
            set
            {
                _autoBtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _offBtnStatus;
        public bool OffBtnStatus
        {
            get { return _offBtnStatus; }
            set
            {
                _offBtnStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _resetBtnStatus;
        public bool ResetBtnStatus
        {
            get { return _resetBtnStatus; }
            set
            {
                _resetBtnStatus = value;
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
        private int _delayTime1;
        public int DelayTime1
        {
            get { return _delayTime1; }
            set
            {
                _delayTime1 = value;
                NotifyPropertyChanged();
            }
        }
        private int _delayTime2;
        public int DelayTime2
        {
            get { return _delayTime2; }
            set
            {
                _delayTime2 = value;
                NotifyPropertyChanged();
            }
        }
        private int _delayTime3;
        public int DelayTime3
        {
            get { return _delayTime3; }
            set
            {
                _delayTime3 = value;
                NotifyPropertyChanged();
            }
        }
        private int _delayTime4;
        public int DelayTime4
        {
            get { return _delayTime4; }
            set
            {
                _delayTime4 = value;
                NotifyPropertyChanged();
            }
        }
        private string _polCmd;
        public string PolCmd
        {
            get { return _polCmd; }
            set
            {
                _polCmd = value;
                NotifyPropertyChanged();
            }
        }
        private int _polAvg;
        public int PolAvg
        {
            get { return _polAvg; }
            set
            {
                _polAvg = value;
                NotifyPropertyChanged();
            }
        }
        private int _polSts;
        public int PolSts
        {
            get { return _polSts; }
            set
            {
                _polSts = value;
                NotifyPropertyChanged();
            }
        }
        private int _polDly;
        public int PolDly
        {
            get { return _polDly; }
            set
            {
                _polDly = value;
                NotifyPropertyChanged();
            }
        }
        private int _polThh;
        public int PolThh
        {
            get { return _polThh; }
            set
            {
                _polThh = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1r1Opacity;
        public float Pa4_1r1Opacity
        {
            get { return _pa4_1r1Opacity; }
            set
            {
                _pa4_1r1Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_1r1Enable;
        public bool Pa4_1r1Enable
        {
            get { return _pa4_1r1Enable; }
            set
            {
                _pa4_1r1Enable = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_1r2Opacity;
        public float Pa4_1r2Opacity
        {
            get { return _pa4_1r2Opacity; }
            set
            {
                _pa4_1r2Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_1r2Enable;
        public bool Pa4_1r2Enable
        {
            get { return _pa4_1r2Enable; }
            set
            {
                _pa4_1r2Enable = value;
                NotifyPropertyChanged();
            }
        }

        private float _pa4_2r1Opacity;
        public float Pa4_2r1Opacity
        {
            get { return _pa4_2r1Opacity; }
            set
            {
                _pa4_2r1Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_2r1Enable;
        public bool Pa4_2r1Enable
        {
            get { return _pa4_2r1Enable; }
            set
            {
                _pa4_2r1Enable = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_2r2Opacity;
        public float Pa4_2r2Opacity
        {
            get { return _pa4_2r2Opacity; }
            set
            {
                _pa4_2r2Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_2r2Enable;
        public bool Pa4_2r2Enable
        {
            get { return _pa4_2r2Enable; }
            set
            {
                _pa4_2r2Enable = value;
                NotifyPropertyChanged();
            }
        }

        private float _pa4_3r1Opacity;
        public float Pa4_3r1Opacity
        {
            get { return _pa4_3r1Opacity; }
            set
            {
                _pa4_3r1Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_3r1Enable;
        public bool Pa4_3r1Enable
        {
            get { return _pa4_3r1Enable; }
            set
            {
                _pa4_3r1Enable = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_3r2Opacity;
        public float Pa4_3r2Opacity
        {
            get { return _pa4_3r2Opacity; }
            set
            {
                _pa4_3r2Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_3r2Enable;
        public bool Pa4_3r2Enable
        {
            get { return _pa4_3r2Enable; }
            set
            {
                _pa4_3r2Enable = value;
                NotifyPropertyChanged();
            }
        }

        private float _pa4_4r1Opacity;
        public float Pa4_4r1Opacity
        {
            get { return _pa4_4r1Opacity; }
            set
            {
                _pa4_4r1Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_4r1Enable;
        public bool Pa4_4r1Enable
        {
            get { return _pa4_4r1Enable; }
            set
            {
                _pa4_4r1Enable = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_4r2Opacity;
        public float Pa4_4r2Opacity
        {
            get { return _pa4_4r2Opacity; }
            set
            {
                _pa4_4r2Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_4r2Enable;
        public bool Pa4_4r2Enable
        {
            get { return _pa4_4r2Enable; }
            set
            {
                _pa4_4r2Enable = value;
                NotifyPropertyChanged();
            }
        }

        private float _pa4_5r1Opacity;
        public float Pa4_5r1Opacity
        {
            get { return _pa4_5r1Opacity; }
            set
            {
                _pa4_5r1Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_5r1Enable;
        public bool Pa4_5r1Enable
        {
            get { return _pa4_5r1Enable; }
            set
            {
                _pa4_5r1Enable = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_5r2Opacity;
        public float Pa4_5r2Opacity
        {
            get { return _pa4_5r2Opacity; }
            set
            {
                _pa4_5r2Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_5r2Enable;
        public bool Pa4_5r2Enable
        {
            get { return _pa4_5r2Enable; }
            set
            {
                _pa4_5r2Enable = value;
                NotifyPropertyChanged();
            }
        }

        private float _pa4_6r1Opacity;
        public float Pa4_6r1Opacity
        {
            get { return _pa4_6r1Opacity; }
            set
            {
                _pa4_6r1Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_6r1Enable;
        public bool Pa4_6r1Enable
        {
            get { return _pa4_6r1Enable; }
            set
            {
                _pa4_6r1Enable = value;
                NotifyPropertyChanged();
            }
        }
        private float _pa4_6r2Opacity;
        public float Pa4_6r2Opacity
        {
            get { return _pa4_6r2Opacity; }
            set
            {
                _pa4_6r2Opacity = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_6r2Enable;
        public bool Pa4_6r2Enable
        {
            get { return _pa4_6r2Enable; }
            set
            {
                _pa4_6r2Enable = value;
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
            OnResetCommand = new RelayCommand(OnResetCommandAction, null);
            OnSetCommand = new RelayCommand(OnSetCommandAction, null);
            OnAutoCommand = new RelayCommand(OnAutoCommandAction, null);
            OnOffCommand = new RelayCommand(OnOffCommandAction, null);
            OnPa4_1Selected = new RelayCommand(OnPa4_1SelectedAction, null);
            OnPa4_2Selected = new RelayCommand(OnPa4_2SelectedAction, null);
            OnPa4_3Selected = new RelayCommand(OnPa4_3SelectedAction, null);
            OnPa4_4Selected = new RelayCommand(OnPa4_4SelectedAction, null);
            OnPa4_5Selected = new RelayCommand(OnPa4_5SelectedAction, null);
            OnPa4_6Selected = new RelayCommand(OnPa4_6SelectedAction, null);

            Messenger.Default.Register<string>(this, MessageReceived);
            Messenger.Default.Register<monValue>(this, OnReceiveMessageAction);
            Messenger.Default.Register<readSetValue>(this, OnReceiveMessageAction);
            Messenger.Default.Register<polValue>(this, OnReceiveMessageAction);

            imgSourcePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            BackgroundPath = imgSourcePath + @"\images\Background.png";
            SeedImgPath = imgSourcePath + @"\images\SEED_base.png";
            Pa1ImgPath = imgSourcePath + @"\images\PA1_base.png";
            Pa2ImgPath = imgSourcePath + @"\images\PA2_base.png";
            Pa3ImgPath = imgSourcePath + @"\images\PA3_base.png";
            Pa4ImgPath = imgSourcePath + @"\images\PA4_base.png";

            Registry.SetValue(keyName, "", "0");

            DelayTime1 = int.Parse((string)Registry.GetValue(keyName, "DelayTime1", "150"));
            DelayTime2 = int.Parse((string)Registry.GetValue(keyName, "DelayTime2", "100"));
            DelayTime3 = int.Parse((string)Registry.GetValue(keyName, "DelayTime3", "150"));
            DelayTime4 = int.Parse((string)Registry.GetValue(keyName, "DelayTime4", "100"));

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

            PolCmd = "*MOD?       ";

            DataRanges = new ObservableCollection<DataRange>()
            {
                new DataRange(){Range = 1},
                new DataRange(){Range = 2},
                new DataRange(){Range = 3}
            };

            Pa4_1r1Opacity = 0.5f;
            Pa4_1r1Enable = false;
            Pa4_1r2Opacity = 0.5f;
            Pa4_1r2Enable = false;
            Pa4_2r1Opacity = 0.5f;
            Pa4_2r1Enable = false;
            Pa4_2r2Opacity = 0.5f;
            Pa4_2r2Enable = false;
            Pa4_3r1Opacity = 0.5f;
            Pa4_3r1Enable = false;
            Pa4_3r2Opacity = 0.5f;
            Pa4_3r2Enable = false;
            Pa4_4r1Opacity = 0.5f;
            Pa4_4r1Enable = false;
            Pa4_4r2Opacity = 0.5f;
            Pa4_4r2Enable = false;
            Pa4_5r1Opacity = 0.5f;
            Pa4_5r1Enable = false;
            Pa4_5r2Opacity = 0.5f;
            Pa4_5r2Enable = false;
            Pa4_6r1Opacity = 0.5f;
            Pa4_6r1Enable = false;
            Pa4_6r2Opacity = 0.5f;
            Pa4_6r2Enable = false;

            SeedFlag = true;
            lcb002CmdSend();
            SeedFlag = false;
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
            else if (message == "stop")
            {
                EStopAction();                
            }
            else if (message == "lcb002")
            {
                if (SeedBtnStatus == true)
                {
                    SeedFlag = true;
                    lcb002CmdSend();
                    SeedFlag = false;
                }
            }
        }
        private async void OnSeedCommandAction()
        {            
            if (SeedBtnStatus == false)
            {                
                SeedBtnStatus = true;                
            }
            else
            {
                Pa4BtnStatus = false;
                Pa4_1BtnStatus = false;
                Pa4_2BtnStatus = false;
                Pa4_3BtnStatus = false;
                Pa4_4BtnStatus = false;
                Pa4_5BtnStatus = false;
                Pa4_6BtnStatus = false;
                await Task.Delay(100);
                PaFlag = true;
                lcb002CmdSend();
                PaFlag = false;

                Pa3BtnStatus = false;
                await Task.Delay(100);
                PaFlag = true;
                lcb002CmdSend();
                PaFlag = false;

                Pa2BtnStatus = false;
                await Task.Delay(100);
                PaFlag = true;
                lcb002CmdSend();
                PaFlag = false;

                Pa1BtnStatus = false;
                await Task.Delay(100);
                PaFlag = true;
                lcb002CmdSend();
                PaFlag = false;

                SeedBtnStatus = false;
                await Task.Delay(100);
            }
            SeedFlag = true;
            lcb002CmdSend();
            SeedFlag = false;
        }

        private async void OnPa1CommandAction()
        {
            if (SeedBtnStatus)
            {
                if (Pa1BtnStatus == false)
                {
                    Pa1BtnStatus = true;
                    PaFlag = true;
                    lcb002CmdSend();
                    PaFlag = false;
                }
                else
                {                    
                    Pa4BtnStatus=false;
                    Pa4_1BtnStatus = false;
                    Pa4_2BtnStatus = false;
                    Pa4_3BtnStatus = false;
                    Pa4_4BtnStatus = false;
                    Pa4_5BtnStatus = false;
                    Pa4_6BtnStatus = false;
                    await Task.Delay(100);
                    PaFlag = true;
                    lcb002CmdSend();
                    PaFlag = false;
                    
                    Pa3BtnStatus = false;
                    await Task.Delay(100);
                    PaFlag = true;
                    lcb002CmdSend();
                    PaFlag = false;

                    Pa2BtnStatus = false;
                    await Task.Delay(100);
                    PaFlag = true;
                    lcb002CmdSend();
                    PaFlag = false;

                    Pa1BtnStatus = false;
                    
                    await Task.Delay(100);
                    PaFlag = true;
                    lcb002CmdSend();
                    PaFlag = false;
                }
            }
        }

        private async void OnPa2CommandAction()
        {
            if (SeedBtnStatus && Pa1BtnStatus)
            {
                if (Pa2BtnStatus == false)
                {
                    Pa2BtnStatus = true;
                }
                else
                {                    
                    Pa4BtnStatus = false;
                    Pa4_1BtnStatus = false;
                    Pa4_2BtnStatus = false;
                    Pa4_3BtnStatus = false;
                    Pa4_4BtnStatus = false;
                    Pa4_5BtnStatus = false;
                    Pa4_6BtnStatus = false;
                    await Task.Delay(100);
                    PaFlag = true;
                    lcb002CmdSend();
                    PaFlag = false;

                    Pa3BtnStatus = false;
                    await Task.Delay(100);
                    PaFlag = true;
                    lcb002CmdSend();
                    PaFlag = false;

                    Pa2BtnStatus = false;
                    await Task.Delay(100);
                }
                PaFlag = true;
                lcb002CmdSend();
                PaFlag = false;
            }
        }

        private async void OnPa3CommandAction()
        {
            if (SeedBtnStatus && Pa1BtnStatus && Pa2BtnStatus)
            {
                if (Pa3BtnStatus == false)
                {
                    Pa3BtnStatus = true;
                }
                else
                {
                    Pa4BtnStatus = false;
                    Pa4_1BtnStatus = false;
                    Pa4_2BtnStatus = false;
                    Pa4_3BtnStatus = false;
                    Pa4_4BtnStatus = false;
                    Pa4_5BtnStatus = false;
                    Pa4_6BtnStatus = false;
                    await Task.Delay(100);
                    PaFlag = true;
                    lcb002CmdSend();
                    PaFlag = false;

                    Pa3BtnStatus = false;
                    await Task.Delay(100);
                }
                PaFlag = true;
                lcb002CmdSend();
                PaFlag = false;
            }
        }

        private void OnPa4CommandAction()
        {            
            if (SeedBtnStatus && Pa1BtnStatus && Pa2BtnStatus && Pa3BtnStatus)
            {
                if (Pa4BtnStatus == false)
                {
                    Pa4BtnStatus = true;
                    Pa4_1BtnStatus = true;
                    Pa4_2BtnStatus = true;
                    Pa4_3BtnStatus = true;
                    Pa4_4BtnStatus = true;
                    Pa4_5BtnStatus = true;
                    Pa4_6BtnStatus = true;
                }
                else
                {
                    Pa4BtnStatus = false;
                    Pa4_1BtnStatus = false;
                    Pa4_2BtnStatus = false;
                    Pa4_3BtnStatus = false;
                    Pa4_4BtnStatus = false;
                    Pa4_5BtnStatus = false;
                    Pa4_6BtnStatus = false;
                }
                PaFlag = true;
                lcb002CmdSend();
                PaFlag = false;
            }            
        }

        private void OnPa4_1CommandAction()
        {
            if (Pa3BtnStatus == true && Pa4_1BtnStatus == false)
            {
                Pa4_1BtnStatus = true;
            }
            else
            {
                Pa4_1BtnStatus = false;
            }
            PaFlag = true;
            Pa4BtnStatusCheck();
            lcb002CmdSend();
            PaFlag = false;
        }

        private void OnPa4_2CommandAction()
        {
            if (Pa3BtnStatus == true && Pa4_2BtnStatus == false)
            {
                Pa4_2BtnStatus = true;
            }
            else
            {
                Pa4_2BtnStatus = false;
            }
            PaFlag = true;
            Pa4BtnStatusCheck();
            lcb002CmdSend();
            PaFlag = false;
        }

        private void OnPa4_3CommandAction()
        {
            if (Pa3BtnStatus == true && Pa4_3BtnStatus == false)
            {
                Pa4_3BtnStatus = true;
            }
            else
            {
                Pa4_3BtnStatus = false;
            }
            PaFlag = true;
            Pa4BtnStatusCheck();
            lcb002CmdSend();
            PaFlag = false;
        }

        private void OnPa4_4CommandAction()
        {
            if (Pa3BtnStatus == true && Pa4_4BtnStatus == false)
            {
                Pa4_4BtnStatus = true;
            }
            else
            {
                Pa4_4BtnStatus = false;
            }
            PaFlag = true;
            Pa4BtnStatusCheck();
            lcb002CmdSend();
            PaFlag = false;
        }

        private void OnPa4_5CommandAction()
        {
            if (Pa3BtnStatus == true && Pa4_5BtnStatus == false)
            {
                Pa4_5BtnStatus = true;
            }
            else
            {
                Pa4_5BtnStatus = false;
            }
            PaFlag = true;
            Pa4BtnStatusCheck();
            lcb002CmdSend();
            PaFlag = false;
        }

        private void OnPa4_6CommandAction()
        {
            if (Pa3BtnStatus == true && Pa4_6BtnStatus == false)
            {
                Pa4_6BtnStatus = true;
            }
            else
            {
                Pa4_6BtnStatus = false;
            }
            PaFlag = true;
            Pa4BtnStatusCheck();
            lcb002CmdSend();
            PaFlag = false;
        }

        private void Pa4BtnStatusCheck()
        {
            if (Pa4_1BtnStatus && Pa4_2BtnStatus && Pa4_3BtnStatus && Pa4_4BtnStatus && Pa4_5BtnStatus && Pa4_6BtnStatus)
                Pa4BtnStatus = true;
            else
                Pa4BtnStatus = false;
        }

        private async void EStopAction()
        {
            PolBtnStatus = false;

            Pa4BtnStatus = false;
            Pa4_1BtnStatus = false;
            Pa4_2BtnStatus = false;
            Pa4_3BtnStatus = false;
            Pa4_4BtnStatus = false;
            Pa4_5BtnStatus = false;
            Pa4_6BtnStatus = false;
            PaFlag = true;
            lcb002CmdSend();
            await Task.Delay(100);

            Pa3BtnStatus = false;
            lcb002CmdSend();
            await Task.Delay(100);

            Pa2BtnStatus = false;
            lcb002CmdSend();
            await Task.Delay(100);

            Pa1BtnStatus = false;
            lcb002CmdSend();
            await Task.Delay(100);

            PaFlag = false;
        }

        private async void OnPolCommandAction()
        {
            if (PolBtnStatus == false)
            {
                PolFlag = true;
                PolBtnStatus = true;
                PolCmd = "*VAR#        ";
                lcb002CmdSend();
                await Task.Delay(2500);

                PolCmd = "*AVG " + PolAvg.ToString() + "#       ";
                lcb002CmdSend();
                await Task.Delay(2500);

                PolCmd = "*STS " + PolSts.ToString() + "#        ";
                lcb002CmdSend();
                await Task.Delay(2500);

                PolCmd = "*DLY " + PolDly.ToString() + "#       ";
                lcb002CmdSend();
                await Task.Delay(2500);
                Console.WriteLine(PolCmd);

                PolCmd = "*THH " + PolThh.ToString() + "#       ";
                lcb002CmdSend();
                await Task.Delay(2500);

                PolCmd = "*ENA#       ";
                lcb002CmdSend();
                await Task.Delay(2500);

                PolCmd = "*MOD?      ";
                lcb002CmdSend();
                PolFlag = false;
            }
            else
            {
                PolFlag = true;
                PolCmd = "*DIS#      ";
                lcb002CmdSend();                
                await Task.Delay(2500);

                PolCmd = "*MOD?       ";
                lcb002CmdSend();
                PolBtnStatus = false;
                PolFlag = false;
            }
        }
        private async void OnResetCommandAction()
        {
            ResetBtnStatus = true;            
            lcb002CmdSend();
            ResetBtnStatus = false;
        }
        private void lcb002CmdSend()
        {
            var lcb002Cmd = new lcb002Cmd()
            {
                reset = Convert.ToInt32(ResetBtnStatus),
                seed = 30 + Convert.ToInt32(SeedBtnStatus) + 32,
                amp = Convert.ToInt32(Pa1BtnStatus) + (Convert.ToInt32(Pa2BtnStatus) << 1) + (Convert.ToInt32(Pa3BtnStatus) << 2) + (Convert.ToInt32(Pa4_1BtnStatus) << 3) + (Convert.ToInt32(Pa4_2BtnStatus) << 4)
                    + (Convert.ToInt32(Pa4_3BtnStatus) << 5) + (Convert.ToInt32(Pa4_4BtnStatus) << 6) + (Convert.ToInt32(Pa4_5BtnStatus) << 7) + (Convert.ToInt32(Pa4_6BtnStatus) << 8),
                cmd = Convert.ToInt32(ResetBtnStatus) + Convert.ToInt32(SeedFlag)*2 + Convert.ToInt32(PaFlag) *4 + Convert.ToInt32(PolFlag) *8,
                pol = PolCmd
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
            };
            Messenger.Default.Send(lcb004writeSetCmd);

            PaFlag = true;
            lcb002CmdSend();
            PaFlag = false;

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

        private async void OnAutoCommandAction()
        {
            Registry.SetValue(keyName, "DelayTime1", DelayTime1.ToString());
            Registry.SetValue(keyName, "DelayTime2", DelayTime2.ToString());
            Registry.SetValue(keyName, "DelayTime3", DelayTime3.ToString());
            Registry.SetValue(keyName, "DelayTime4", DelayTime4.ToString());

            AutoBtnStatus = true;
            Pa4BtnStatus = false;
            Pa4_1BtnStatus = false;
            Pa4_2BtnStatus = false;
            Pa4_3BtnStatus = false;
            Pa4_4BtnStatus = false;
            Pa4_5BtnStatus = false;
            Pa4_6BtnStatus = false;
            if (AutoBtnStatus == true && Pa1BtnStatus == false)
            {
                OnPa1CommandAction();
                await Task.Delay(DelayTime2);
            }
            if (AutoBtnStatus == true && Pa2BtnStatus == false)
            {
                OnPa2CommandAction();
                await Task.Delay(DelayTime3);
            }
            if (AutoBtnStatus == true && Pa3BtnStatus == false)
            {
                OnPa3CommandAction();
                await Task.Delay(DelayTime4);
            }
            if (AutoBtnStatus == true)
            {
                OnPa4CommandAction();
            }            
            AutoBtnStatus = false;
        }

        private async void OnOffCommandAction()
        {
            OffBtnStatus = true;
            PolBtnStatus = false;

            AutoBtnStatus = false;
            Pa4BtnStatus = false;
            Pa4_1BtnStatus = false;
            Pa4_2BtnStatus = false;
            Pa4_3BtnStatus = false;
            Pa4_4BtnStatus = false;
            Pa4_5BtnStatus = false;
            Pa4_6BtnStatus = false;
            PaFlag = true;
            lcb002CmdSend();
            await Task.Delay(100);

            Pa3BtnStatus = false;
            lcb002CmdSend();
            await Task.Delay(100);

            Pa2BtnStatus = false;
            lcb002CmdSend();
            await Task.Delay(100);

            Pa1BtnStatus = false;
            lcb002CmdSend();
            await Task.Delay(100);
            
            OffBtnStatus = false;
            PaFlag = false;
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
            PolResponseRead = obj.PolRead;
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

            PaFlag = true;
            lcb002CmdSend();
            PaFlag = false;
        }

        private void OnReceiveMessageAction(polValue obj)
        {
            PolAvg = obj.PolAvg;
            PolSts = obj.PolSts;
            PolDly = obj.PolDly;
            PolThh = obj.PolThh;
        }

        private void OnPa4_1SelectedAction()
        {
            if (SelectdData.Range == 1)
            {
                Pa4_1r1Opacity = 0.5f;
                Pa4_1r1Enable = false;
                Pa4_1r2Opacity = 0.5f;
                Pa4_1r2Enable = false;
                Pa4_1CurrentReadValueR1 = 0;
                Pa4_1TimeReadValueR1 = 0;
                Pa4_1CurrentReadValueR2 = 0;
                Pa4_1TimeReadValueR2 = 0;
            }
            else if (SelectdData.Range == 2)
            {
                Pa4_1r1Opacity = 0.5f;
                Pa4_1r1Enable = false;
                Pa4_1r2Opacity = 1f;
                Pa4_1r2Enable = true;
                Pa4_1CurrentReadValueR1 = 0;
                Pa4_1TimeReadValueR1 = 0;
            }
            else if (SelectdData.Range == 3)
            {
                Pa4_1r1Opacity = 1f;
                Pa4_1r1Enable = true;
                Pa4_1r2Opacity = 1f;
                Pa4_1r2Enable = true;
            }
        }

        private void OnPa4_2SelectedAction()
        {
            if (SelectdData.Range == 1)
            {
                Pa4_2r1Opacity = 0.5f;
                Pa4_2r1Enable = false;
                Pa4_2r2Opacity = 0.5f;
                Pa4_2r2Enable = false;
                Pa4_2CurrentReadValueR1 = 0;
                Pa4_2TimeReadValueR1 = 0;
                Pa4_2CurrentReadValueR2 = 0;
                Pa4_2TimeReadValueR2 = 0;
            }
            else if (SelectdData.Range == 2)
            {
                Pa4_2r1Opacity = 0.5f;
                Pa4_2r1Enable = false;
                Pa4_2r2Opacity = 1f;
                Pa4_2r2Enable = true;
                Pa4_2CurrentReadValueR1 = 0;
                Pa4_2TimeReadValueR1 = 0;
            }
            else if (SelectdData.Range == 3)
            {
                Pa4_2r1Opacity = 1f;
                Pa4_2r1Enable = true;
                Pa4_2r2Opacity = 1f;
                Pa4_2r2Enable = true;
            }
        }

        private void OnPa4_3SelectedAction()
        {
            if (SelectdData.Range == 1)
            {
                Pa4_3r1Opacity = 0.5f;
                Pa4_3r1Enable = false;
                Pa4_3r2Opacity = 0.5f;
                Pa4_3r2Enable = false;
                Pa4_3CurrentReadValueR1 = 0;
                Pa4_3TimeReadValueR1 = 0;
                Pa4_3CurrentReadValueR2 = 0;
                Pa4_3TimeReadValueR2 = 0;
            }
            else if (SelectdData.Range == 2)
            {
                Pa4_3r1Opacity = 0.5f;
                Pa4_3r1Enable = false;
                Pa4_3r2Opacity = 1f;
                Pa4_3r2Enable = true;
                Pa4_3CurrentReadValueR1 = 0;
                Pa4_3TimeReadValueR1 = 0;
            }
            else if (SelectdData.Range == 3)
            {
                Pa4_3r1Opacity = 1f;
                Pa4_3r1Enable = true;
                Pa4_3r2Opacity = 1f;
                Pa4_3r2Enable = true;
            }
        }

        private void OnPa4_4SelectedAction()
        {
            if (SelectdData.Range == 1)
            {
                Pa4_4r1Opacity = 0.5f;
                Pa4_4r1Enable = false;
                Pa4_4r2Opacity = 0.5f;
                Pa4_4r2Enable = false;
                Pa4_4CurrentReadValueR1 = 0;
                Pa4_4TimeReadValueR1 = 0;
                Pa4_4CurrentReadValueR2 = 0;
                Pa4_4TimeReadValueR2 = 0;
            }
            else if (SelectdData.Range == 2)
            {
                Pa4_4r1Opacity = 0.5f;
                Pa4_4r1Enable = false;
                Pa4_4r2Opacity = 1f;
                Pa4_4r2Enable = true;
                Pa4_4CurrentReadValueR1 = 0;
                Pa4_4TimeReadValueR1 = 0;
            }
            else if (SelectdData.Range == 3)
            {
                Pa4_4r1Opacity = 1f;
                Pa4_4r1Enable = true;
                Pa4_4r2Opacity = 1f;
                Pa4_4r2Enable = true;
            }
        }

        private void OnPa4_5SelectedAction()
        {
            if (SelectdData.Range == 1)
            {
                Pa4_5r1Opacity = 0.5f;
                Pa4_5r1Enable = false;
                Pa4_5r2Opacity = 0.5f;
                Pa4_5r2Enable = false;
                Pa4_5CurrentReadValueR1 = 0;
                Pa4_5TimeReadValueR1 = 0;
                Pa4_5CurrentReadValueR2 = 0;
                Pa4_5TimeReadValueR2 = 0;
            }
            else if (SelectdData.Range == 2)
            {
                Pa4_5r1Opacity = 0.5f;
                Pa4_5r1Enable = false;
                Pa4_5r2Opacity = 1f;
                Pa4_5r2Enable = true;
                Pa4_5CurrentReadValueR1 = 0;
                Pa4_5TimeReadValueR1 = 0;
            }
            else if (SelectdData.Range == 3)
            {
                Pa4_5r1Opacity = 1f;
                Pa4_5r1Enable = true;
                Pa4_5r2Opacity = 1f;
                Pa4_5r2Enable = true;
            }
        }

        private void OnPa4_6SelectedAction()
        {
            if (SelectdData.Range == 1)
            {
                Pa4_6r1Opacity = 0.5f;
                Pa4_6r1Enable = false;
                Pa4_6r2Opacity = 0.5f;
                Pa4_6r2Enable = false;
                Pa4_6CurrentReadValueR1 = 0;
                Pa4_6TimeReadValueR1 = 0;
                Pa4_6CurrentReadValueR2 = 0;
                Pa4_6TimeReadValueR2 = 0;
            }
            else if (SelectdData.Range == 2)
            {
                Pa4_6r1Opacity = 0.5f;
                Pa4_6r1Enable = false;
                Pa4_6r2Opacity = 1f;
                Pa4_6r2Enable = true;
                Pa4_6CurrentReadValueR1 = 0;
                Pa4_6TimeReadValueR1 = 0;
            }
            else if (SelectdData.Range == 3)
            {
                Pa4_6r1Opacity = 1f;
                Pa4_6r1Enable = true;
                Pa4_6r2Opacity = 1f;
                Pa4_6r2Enable = true;
            }
        }
    }
}
