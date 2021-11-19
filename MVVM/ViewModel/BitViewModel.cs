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
    public class BitViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private bool _seedStatus;
        public bool SeedStatus
        {
            get { return _seedStatus; }
            set
            {
                _seedStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _ampCurrent;
        public bool AmpCurrent
        {
            get { return _ampCurrent; }
            set
            {
                _ampCurrent = value;
                NotifyPropertyChanged();
            }
        }
        private bool _ampVoltage;
        public bool AmpVoltage
        {
            get { return _ampVoltage; }
            set
            {
                _ampVoltage = value;
                NotifyPropertyChanged();
            }
        }
        private bool _ampTemp;
        public bool AmpTemp
        {
            get { return _ampTemp; }
            set
            {
                _ampTemp = value;
                NotifyPropertyChanged();
            }
        }
        private bool _ampPd;
        public bool AmpPd
        {
            get { return _ampPd; }
            set
            {
                _ampPd = value;
                NotifyPropertyChanged();
            }
        }
        private bool _vacInput;
        public bool VacInput
        {
            get { return _vacInput; }
            set
            {
                _vacInput = value;
                NotifyPropertyChanged();
            }
        }
        private bool _powerBoard;
        public bool PowerBoard
        {
            get { return _powerBoard; }
            set
            {
                _powerBoard = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp1_2;
        public bool Amp1_2
        {
            get { return _amp1_2; }
            set
            {
                _amp1_2 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp3;
        public bool Amp3
        {
            get { return _amp3; }
            set
            {
                _amp3 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _amp4;
        public bool Amp4
        {
            get { return _amp4; }
            set
            {
                _amp4 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _etc;
        public bool Etc
        {
            get { return _etc; }
            set
            {
                _etc = value;
                NotifyPropertyChanged();
            }
        }
        private bool _compOverHeat;
        public bool CompOverHeat
        {
            get { return _compOverHeat; }
            set
            {
                _compOverHeat = value;
                NotifyPropertyChanged();
            }
        }
        private bool _overCurrent;
        public bool OverCurrent
        {
            get { return _overCurrent; }
            set
            {
                _overCurrent = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pressure;
        public bool Pressure
        {
            get { return _pressure; }
            set
            {
                _pressure = value;
                NotifyPropertyChanged();
            }
        }
        private bool _flowMeter;
        public bool FlowMeter
        {
            get { return _flowMeter; }
            set
            {
                _flowMeter = value;
                NotifyPropertyChanged();
            }
        }
        private bool _level;
        public bool Level
        {
            get { return _level; }
            set
            {
                _level = value;
                NotifyPropertyChanged();
            }
        }
        private bool _temp;
        public bool Temp
        {
            get { return _temp; }
            set
            {
                _temp = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pressureHigh;
        public bool PressureHigh
        {
            get { return _pressureHigh; }
            set
            {
                _pressureHigh = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pressureLow;
        public bool PressureLow
        {
            get { return _pressureLow; }
            set
            {
                _pressureLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _flowMeterSensor;
        public bool FlowMeterSensor
        {
            get { return _flowMeterSensor; }
            set
            {
                _flowMeterSensor = value;
                NotifyPropertyChanged();
            }
        }
        private bool _flowMeterLow;
        public bool FlowMeterLow
        {
            get { return _flowMeterLow; }
            set
            {
                _flowMeterLow = value;
                NotifyPropertyChanged();
            }
        }
        private bool _levelSensor;
        public bool LevelSensor
        {
            get { return _levelSensor; }
            set
            {
                _levelSensor = value;
                NotifyPropertyChanged();
            }
        }
        private bool _levelLow;
        public bool LevelLow
        {
            get { return _levelLow; }
            set
            {
                _levelLow = value;
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public BitViewModel()
        {
            Messenger.Default.Register<dcpBit>(this, OnReceiveMessageAction);
            Messenger.Default.Register<chillerMon>(this, OnReceiveMessageAction);
        }

        private void OnReceiveMessageAction(dcpBit obj)
        {
            /*SeedStatus = obj.SeedCurrentSetValue;
            AmpCurrent = obj.SeedTempSetValue;
            AmpVoltage = obj.Pa1CurrentSetValue;
            AmpTemp = obj.Pa2CurrentSetValue;
            AmpPd = obj.Pa3CurrentSetValue;*/

            VacInput = obj.vacVoltHigh | obj.vacVoltLow | obj.vacCurrHigh | obj.vacCurrLow;
            PowerBoard = obj.pbVoltHigh | obj.pbVoltLow | obj.pbCurrHigh | obj.pbCurrLow;
            Amp1_2 = obj.amp1_2VoltHigh | obj.amp1_2VoltLow | obj.amp1_2CurrHigh | obj.amp1_2CurrLow;
            Amp3 = obj.amp3VoltHigh | obj.amp3VoltLow | obj.amp3CurrHigh | obj.amp3CurrLow;
            Amp4 = obj.amp4_1VoltHigh | obj.amp4_1VoltLow | obj.amp4_1CurrHigh | obj.amp4_1CurrLow | obj.amp4_2VoltHigh | obj.amp4_2VoltLow | obj.amp4_2CurrHigh | obj.amp4_2CurrLow |
                obj.amp4_3VoltHigh | obj.amp4_3VoltLow | obj.amp4_3CurrHigh | obj.amp4_3CurrLow | obj.amp4_4VoltHigh | obj.amp4_4VoltLow | obj.amp4_4CurrHigh | obj.amp4_4CurrLow |
                obj.amp4_5VoltHigh | obj.amp4_5VoltLow | obj.amp4_5CurrHigh | obj.amp4_5CurrLow | obj.amp4_6VoltHigh | obj.amp4_6VoltLow | obj.amp4_6CurrHigh | obj.amp4_6CurrLow;
            Etc = obj.tempHigh | obj.tempLow | obj.humidityHigh | obj.humidityLow | obj.e_stop;            
        }
        private void OnReceiveMessageAction(chillerMon obj)
        {
            CompOverHeat = obj.compOverHeat;
            OverCurrent = obj.overCurrent;
            Pressure = obj.pressureHigh | obj.pressureLow;
            PressureHigh = obj.pressureHigh;
            PressureLow = obj.pressureLow;
            FlowMeter = obj.flowMeterSensor | obj.flowSwitchSensor | obj.flowMeterLow | obj.flowSwitchLow;
            FlowMeterSensor = obj.flowMeterSensor | obj.flowSwitchSensor;
            FlowMeterLow = obj.flowMeterLow | obj.flowSwitchLow;
            Level = obj.levelSensor | obj.levelLow2 | obj.levelLow1;
            LevelSensor = obj.levelSensor;
            LevelLow = obj.levelLow2 | obj.levelLow1;
            Temp = obj.tempHigh2 | obj.tempHigh1 | obj.tempLow2 | obj.tempLow1;
            TempHigh = obj.tempHigh2 | obj.tempHigh1;
            TempLow = obj.tempLow2 | obj.tempLow1;            
        }
    }
}
