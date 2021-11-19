using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVM.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.ViewModel
{
    public class SideViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public RelayCommand OnClickCommand { get; set; }

        public Socket client = null;
        private static ManualResetEvent connectDone =
        new ManualResetEvent(false);
        public RelayCommand cRunCmd { get; set; }
        public RelayCommand cTemp0Cmd { get; set; }
        public RelayCommand cTemp1Cmd { get; set; }
        public RelayCommand cTargetTempCmd { get; set; }
        public RelayCommand cHighTempWarnCmd { get; set; }
        public RelayCommand cHighTempAlarmCmd { get; set; }
        public RelayCommand cLowTempWarnCmd { get; set; }
        public RelayCommand cLowTempAlarmCmd { get; set; }

        bool cRunFlag = false;

        private bool _bitStatus;
        public bool BitStatus
        {
            get { return _bitStatus; }
            set
            {
                _bitStatus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _seedLdCurrent;
        public bool SeedLdCurrent
        {
            get { return _seedLdCurrent; }
            set
            {
                _seedLdCurrent = value;
                NotifyPropertyChanged();
            }
        }
        private bool _seedLdTemp;
        public bool SeedLdTemp
        {
            get { return _seedLdTemp; }
            set
            {
                _seedLdTemp = value;
                NotifyPropertyChanged();
            }
        }
        private bool _seedHsTemp;
        public bool SeedHsTemp
        {
            get { return _seedHsTemp; }
            set
            {
                _seedHsTemp = value;
                NotifyPropertyChanged();
            }
        }
        private bool _seedRfVmon;
        public bool SeedRfVmon
        {
            get { return _seedRfVmon; }
            set
            {
                _seedRfVmon = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa1Current;
        public bool Pa1Current
        {
            get { return _pa1Current; }
            set
            {
                _pa1Current = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa1Voltage;
        public bool Pa1Voltage
        {
            get { return _pa1Voltage; }
            set
            {
                _pa1Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa2Current;
        public bool Pa2Current
        {
            get { return _pa2Current; }
            set
            {
                _pa2Current = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa2Voltage;
        public bool Pa2Voltage
        {
            get { return _pa2Voltage; }
            set
            {
                _pa2Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa3Current;
        public bool Pa3Current
        {
            get { return _pa3Current; }
            set
            {
                _pa3Current = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa3Voltage;
        public bool Pa3Voltage
        {
            get { return _pa3Voltage; }
            set
            {
                _pa3Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_1Current;
        public bool Pa4_1Current
        {
            get { return _pa4_1Current; }
            set
            {
                _pa4_1Current = value;
                NotifyPropertyChanged();
            }
        }

        private bool _pa4_1Voltage;
        public bool Pa4_1Voltage
        {
            get { return _pa4_1Voltage; }
            set
            {
                _pa4_1Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_2Current;
        public bool Pa4_2Current
        {
            get { return _pa4_2Current; }
            set
            {
                _pa4_2Current = value;
                NotifyPropertyChanged();
            }
        }

        private bool _pa4_2Voltage;
        public bool Pa4_2Voltage
        {
            get { return _pa4_2Voltage; }
            set
            {
                _pa4_2Voltage = value;
                NotifyPropertyChanged();
            }
        }

        private bool _pa4_3Current;
        public bool Pa4_3Current
        {
            get { return _pa4_3Current; }
            set
            {
                _pa4_3Current = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_3Voltage;
        public bool Pa4_3Voltage
        {
            get { return _pa4_3Voltage; }
            set
            {
                _pa4_3Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_4Current;
        public bool Pa4_4Current
        {
            get { return _pa4_4Current; }
            set
            {
                _pa4_4Current = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_4Voltage;
        public bool Pa4_4Voltage
        {
            get { return _pa4_4Voltage; }
            set
            {
                _pa4_4Voltage = value;
                NotifyPropertyChanged();
            }
        }

        private bool _pa4_5Current;
        public bool Pa4_5Current
        {
            get { return _pa4_5Current; }
            set
            {
                _pa4_5Current = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_5Voltage;
        public bool Pa4_5Voltage
        {
            get { return _pa4_5Voltage; }
            set
            {
                _pa4_5Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_6Current;
        public bool Pa4_6Current
        {
            get { return _pa4_6Current; }
            set
            {
                _pa4_6Current = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pa4_6Voltage;
        public bool Pa4_6Voltage
        {
            get { return _pa4_6Voltage; }
            set
            {
                _pa4_6Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd1;
        public bool Pd1
        {
            get { return _pd1; }
            set
            {
                _pd1 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd2;
        public bool Pd2
        {
            get { return _pd2; }
            set
            {
                _pd2 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd3;
        public bool Pd3
        {
            get { return _pd3; }
            set
            {
                _pd3 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd4;
        public bool Pd4
        {
            get { return _pd4; }
            set
            {
                _pd4 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd5;
        public bool Pd5
        {
            get { return _pd5; }
            set
            {
                _pd5 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd6;
        public bool Pd6
        {
            get { return _pd6; }
            set
            {
                _pd6 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd7;
        public bool Pd7
        {
            get { return _pd7; }
            set
            {
                _pd7 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd8;
        public bool Pd8
        {
            get { return _pd8; }
            set
            {
                _pd8 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _seedTemp1;
        public bool SeedTemp1
        {
            get { return _seedTemp1; }
            set
            {
                _seedTemp1 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _seedTemp2;
        public bool SeedTemp2
        {
            get { return _seedTemp2; }
            set
            {
                _seedTemp2 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _seedTemp3;
        public bool SeedTemp3
        {
            get { return _seedTemp3; }
            set
            {
                _seedTemp3 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp1;
        public bool PaTemp1
        {
            get { return _paTemp1; }
            set
            {
                _paTemp1 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp2;
        public bool PaTemp2
        {
            get { return _paTemp2; }
            set
            {
                _paTemp2 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp3;
        public bool PaTemp3
        {
            get { return _paTemp3; }
            set
            {
                _paTemp3 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp4;
        public bool PaTemp4
        {
            get { return _paTemp4; }
            set
            {
                _paTemp4 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp5;
        public bool PaTemp5
        {
            get { return _paTemp5; }
            set
            {
                _paTemp5 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp6;
        public bool PaTemp6
        {
            get { return _paTemp6; }
            set
            {
                _paTemp6 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp7;
        public bool PaTemp7
        {
            get { return _paTemp7; }
            set
            {
                _paTemp7 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp8;
        public bool PaTemp8
        {
            get { return _paTemp8; }
            set
            {
                _paTemp8 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp9;
        public bool PaTemp9
        {
            get { return _paTemp9; }
            set
            {
                _paTemp9 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp10;
        public bool PaTemp10
        {
            get { return _paTemp10; }
            set
            {
                _paTemp10 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp11;
        public bool PaTemp11
        {
            get { return _paTemp11; }
            set
            {
                _paTemp11 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp12;
        public bool PaTemp12
        {
            get { return _paTemp12; }
            set
            {
                _paTemp12 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp13;
        public bool PaTemp13
        {
            get { return _paTemp13; }
            set
            {
                _paTemp13 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp14;
        public bool PaTemp14
        {
            get { return _paTemp14; }
            set
            {
                _paTemp14 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp15;
        public bool PaTemp15
        {
            get { return _paTemp15; }
            set
            {
                _paTemp15 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp16;
        public bool PaTemp16
        {
            get { return _paTemp16; }
            set
            {
                _paTemp16 = value;
                NotifyPropertyChanged();
            }
        }
        private bool _seedHumid;
        public bool SeedHumid
        {
            get { return _seedHumid; }
            set
            {
                _seedHumid = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paHumid;
        public bool PaHumid
        {
            get { return _paHumid; }
            set
            {
                _paHumid = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paLeak;
        public bool PaLeak
        {
            get { return _paLeak; }
            set
            {
                _paLeak = value;
                NotifyPropertyChanged();
            }
        }
        private bool _e_Stop;
        public bool E_Stop
        {
            get { return _e_Stop; }
            set
            {
                _e_Stop = value;
                NotifyPropertyChanged();
            }
        }
        private bool _chiller;
        public bool Chiller
        {
            get { return _chiller; }
            set
            {
                _chiller = value;
                NotifyPropertyChanged();
            }
        }
        private bool _polarization;
        public bool Polarization
        {
            get { return _polarization; }
            set
            {
                _polarization = value;
                NotifyPropertyChanged();
            }
        }
        private bool _dcPowerBit;
        public bool DcPowerBit
        {
            get { return _dcPowerBit; }
            set
            {
                _dcPowerBit = value;
                NotifyPropertyChanged();
            }
        }
        private float _vacInputVoltage;
        public float VacInputVoltage
        {
            get { return _vacInputVoltage; }
            set
            {
                _vacInputVoltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _vacInputCurrent;
        public float VacInputCurrent
        {
            get { return _vacInputCurrent; }
            set
            {
                _vacInputCurrent = value;
                NotifyPropertyChanged();
            }
        }
        private float _powerBoardVoltage;
        public float PowerBoardVoltage
        {
            get { return _powerBoardVoltage; }
            set
            {
                _powerBoardVoltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _powerBoardCurrent;
        public float PowerBoardCurrent
        {
            get { return _powerBoardCurrent; }
            set
            {
                _powerBoardCurrent = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp1_2Voltage;
        public float Amp1_2Voltage
        {
            get { return _amp1_2Voltage; }
            set
            {
                _amp1_2Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp1_2Current;
        public float Amp1_2Current
        {
            get { return _amp1_2Current; }
            set
            {
                _amp1_2Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp3Voltage;
        public float Amp3Voltage
        {
            get { return _amp3Voltage; }
            set
            {
                _amp3Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp3Current;
        public float Amp3Current
        {
            get { return _amp3Current; }
            set
            {
                _amp3Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_1Voltage;
        public float Amp4_1Voltage
        {
            get { return _amp4_1Voltage; }
            set
            {
                _amp4_1Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_1Current;
        public float Amp4_1Current
        {
            get { return _amp4_1Current; }
            set
            {
                _amp4_1Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_2Voltage;
        public float Amp4_2Voltage
        {
            get { return _amp4_2Voltage; }
            set
            {
                _amp4_2Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_2Current;
        public float Amp4_2Current
        {
            get { return _amp4_2Current; }
            set
            {
                _amp4_2Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_3Voltage;
        public float Amp4_3Voltage
        {
            get { return _amp4_3Voltage; }
            set
            {
                _amp4_3Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_3Current;
        public float Amp4_3Current
        {
            get { return _amp4_3Current; }
            set
            {
                _amp4_3Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_4Voltage;
        public float Amp4_4Voltage
        {
            get { return _amp4_4Voltage; }
            set
            {
                _amp4_4Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_4Current;
        public float Amp4_4Current
        {
            get { return _amp4_4Current; }
            set
            {
                _amp4_4Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_5Voltage;
        public float Amp4_5Voltage
        {
            get { return _amp4_5Voltage; }
            set
            {
                _amp4_5Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_5Current;
        public float Amp4_5Current
        {
            get { return _amp4_5Current; }
            set
            {
                _amp4_5Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_6Voltage;
        public float Amp4_6Voltage
        {
            get { return _amp4_6Voltage; }
            set
            {
                _amp4_6Voltage = value;
                NotifyPropertyChanged();
            }
        }
        private float _amp4_6Current;
        public float Amp4_6Current
        {
            get { return _amp4_6Current; }
            set
            {
                _amp4_6Current = value;
                NotifyPropertyChanged();
            }
        }
        private float _temp;
        public float Temp
        {
            get { return _temp; }
            set
            {
                _temp = value;
                NotifyPropertyChanged();
            }
        }
        private float _humidity;
        public float Humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                NotifyPropertyChanged();
            }
        }
        private string _cStatus;
        public string CStatus
        {
            get { return _cStatus; }
            set
            {
                _cStatus = value;
                NotifyPropertyChanged();
            }
        }
        private string _cTemp0Value;
        public string CTemp0Value
        {
            get { return _cTemp0Value; }
            set
            {
                _cTemp0Value = value;
                NotifyPropertyChanged();
            }
        }
        private string _cTemp1Value;
        public string CTemp1Value
        {
            get { return _cTemp1Value; }
            set
            {
                _cTemp1Value = value;
                NotifyPropertyChanged();
            }
        }
        private string _cTargetTempValue;
        public string CTargetTempValue
        {
            get { return _cTargetTempValue; }
            set
            {
                _cTargetTempValue = value;
                NotifyPropertyChanged();
            }
        }
        private string _cHighTempWarnValue;
        public string CHighTempWarnValue
        {
            get { return _cHighTempWarnValue; }
            set
            {
                _cHighTempWarnValue = value;
                NotifyPropertyChanged();
            }
        }
        private string _cHighTempAlarmValue;
        public string CHighTempAlarmValue
        {
            get { return _cHighTempAlarmValue; }
            set
            {
                _cHighTempAlarmValue = value;
                NotifyPropertyChanged();
            }
        }
        private string _cLowTempWarnValue;
        public string CLowTempWarnValue
        {
            get { return _cLowTempWarnValue; }
            set
            {
                _cLowTempWarnValue = value;
                NotifyPropertyChanged();
            }
        }
        private string _cLowTempAlarmValue;
        public string CLowTempAlarmValue
        {
            get { return _cLowTempAlarmValue; }
            set
            {
                _cLowTempAlarmValue = value;
                NotifyPropertyChanged();
            }
        }
        private string _cTempValue;
        public string CTempValue
        {
            get { return _cTempValue; }
            set
            {
                _cTempValue = value;
                NotifyPropertyChanged();
            }
        }
        private string _cFlowValue;
        public string CFlowValue
        {
            get { return _cFlowValue; }
            set
            {
                _cFlowValue = value;
                NotifyPropertyChanged();
            }
        }
        private bool _cBit;
        public bool CBit
        {
            get { return _cBit; }
            set
            {
                _cBit = value;
                NotifyPropertyChanged();
            }
        }
        private int _cStatusBit;
        public int CStatusBit
        {
            get { return _cStatusBit; }
            set
            {
                _cStatusBit = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public SideViewModel()
        {
            cRunCmd = new RelayCommand(cRunCmdAction, null);
            cTemp0Cmd = new RelayCommand(cTemp0CmdAction, null);
            cTemp1Cmd = new RelayCommand(cTemp1CmdAction, null);
            cTargetTempCmd = new RelayCommand(cTargetTempCmdAction, null);
            cHighTempWarnCmd = new RelayCommand(cHighTempWarnCmdAction, null);
            cHighTempAlarmCmd = new RelayCommand(cHighTempAlarmCmdAction, null);
            cLowTempWarnCmd = new RelayCommand(cLowTempWarnCmdAction, null);
            cLowTempAlarmCmd = new RelayCommand(cLowTempAlarmCmdAction, null);

            Messenger.Default.Register<LvbBitResult>(this, OnReceiveMessageAction);
            Messenger.Default.Register<errorMon>(this, OnReceiveMessageAction);
            Messenger.Default.Register<dcpMon>(this, OnReceiveMessageAction);
            Messenger.Default.Register<dcPowerBit>(this, OnReceiveMessageAction);
            Messenger.Default.Register<chillerRcv>(this, OnReceiveMessageAction);
            Messenger.Default.Register<chillerMon>(this, OnReceiveMessageAction);

            CTargetTempValue = "+21.1";
            CHighTempWarnValue = "+22.2";
            CHighTempAlarmValue = "+23.3";
            CLowTempWarnValue = "+24.4";
            CLowTempAlarmValue = "+25.5";
        }

        private void cRunCmdAction()
        {
            if (cRunFlag)
            {
                var chillerCmd = new chillerCmd()
                {
                    cmd = "stop",
                    data = ""
                };

                Messenger.Default.Send(chillerCmd);
                cRunFlag = false;
            }
            else
            {
                var chillerCmd = new chillerCmd()
                {
                    cmd = "run",
                    data = ""
                };

                Messenger.Default.Send(chillerCmd);
                cRunFlag = true;
            }
        }
        private void cTemp0CmdAction()
        {
            var chillerCmd = new chillerCmd()
            {
                cmd = "ch0_temp",
                data = ""
            };

            Messenger.Default.Send(chillerCmd);
        }
        private void cTemp1CmdAction()
        {
            var chillerCmd = new chillerCmd()
            {
                cmd = "ch1_temp",
                data = ""
            };

            Messenger.Default.Send(chillerCmd);
        }
        private void cTargetTempCmdAction()
        {
            var chillerCmd = new chillerCmd()
            {
                cmd = "target_temp",
                data = CTargetTempValue
            };

            Messenger.Default.Send(chillerCmd);
        }
        private void cHighTempWarnCmdAction()
        {
            var chillerCmd = new chillerCmd()
            {
                cmd = "high_temp_warn",
                data = CHighTempWarnValue
            };

            Messenger.Default.Send(chillerCmd);
        }
        private void cHighTempAlarmCmdAction()
        {
            var chillerCmd = new chillerCmd()
            {
                cmd = "high_temp_alarm",
                data = CHighTempAlarmValue
            };

            Messenger.Default.Send(chillerCmd);
        }
        private void cLowTempWarnCmdAction()
        {
            var chillerCmd = new chillerCmd()
            {
                cmd = "low_temp_warn",
                data = CLowTempWarnValue
            };

            Messenger.Default.Send(chillerCmd);
        }
        private void cLowTempAlarmCmdAction()
        {
            var chillerCmd = new chillerCmd()
            {
                cmd = "low_temp_alarm",
                data = CLowTempAlarmValue
            };

            Messenger.Default.Send(chillerCmd);
        }


        private void OnReceiveMessageAction(dcPowerBit obj)
        {
            DcPowerBit = obj.DcPowerBit;
        }

        private void OnReceiveMessageAction(LvbBitResult obj)
        {
            BitStatus = obj.bitStatus;
            SeedLdCurrent = obj.seedLdCurrent;
            SeedLdTemp = obj.seedLdTemp;
            SeedHsTemp = obj.seedHsTemp;
            SeedRfVmon = obj.seedRfVmon;
            Pa1Current = obj.pa1Current;
            Pa1Voltage = obj.pa1Voltage;
            Pa2Current = obj.pa2Current;
            Pa2Voltage = obj.pa2Voltage;
            Pa3Current = obj.pa3Current;
            Pa3Voltage = obj.pa3Voltage;
            Pa4_1Current = obj.pa4_1Current;
            Pa4_1Voltage = obj.pa4_1Voltage;
            Pa4_2Current = obj.pa4_2Current;
            Pa4_2Voltage = obj.pa4_2Voltage;
            Pa4_3Current = obj.pa4_3Current;
            Pa4_3Voltage = obj.pa4_3Voltage;
            Pa4_4Current = obj.pa4_4Current;
            Pa4_4Voltage = obj.pa4_4Voltage;
            Pa4_5Current = obj.pa4_5Current;
            Pa4_5Voltage = obj.pa4_5Voltage;
            Pa4_6Current = obj.pa4_6Current;
            Pa4_6Voltage = obj.pa4_6Voltage;
            Pd1 = obj.pd1;
            Pd2 = obj.pd2;
            Pd3 = obj.pd3;
            Pd4 = obj.pd4;
            Pd5 = obj.pd5;
            Pd6 = obj.pd6;
            Pd7 = obj.pd7;
            Pd8 = obj.pd8;
            SeedTemp1 = obj.seedTemp1;
            SeedTemp2 = obj.seedTemp2;
            SeedTemp3 = obj.seedTemp3;
            PaTemp1 = obj.paTemp1;
            PaTemp2 = obj.paTemp2;
            PaTemp3 = obj.paTemp3;
            PaTemp4 = obj.paTemp4;
            PaTemp5 = obj.paTemp5;
            PaTemp6 = obj.paTemp6;
            PaTemp7 = obj.paTemp7;
            PaTemp8 = obj.paTemp8;
            PaTemp9 = obj.paTemp9;
            PaTemp10 = obj.paTemp10;
            PaTemp11 = obj.paTemp11;
            PaTemp12 = obj.paTemp12;
            PaTemp13 = obj.paTemp13;
            PaTemp14 = obj.paTemp14;
            PaTemp15 = obj.paTemp15;
            PaTemp16 = obj.paTemp16;
            SeedHumid = obj.seedHumid;
            PaHumid = obj.paHumid;
            PaLeak = obj.paLeak;
            E_Stop = obj.e_Stop;
            Chiller = obj.chiller;
            Polarization = obj.polarization;
        }

        private void OnReceiveMessageAction(errorMon obj)
        {
            SeedHumid = obj.SeedHumid;
            PaHumid = obj.PaHumid;
            PaLeak = obj.LeakSensor;
            E_Stop = obj.E_Stop;
            Chiller = obj.Chiller;
        }

        private void OnReceiveMessageAction(dcpMon obj)
        {
            VacInputVoltage = obj.vacInputVoltage;
            VacInputCurrent = obj.vacInputCurrent;
            PowerBoardVoltage = obj.powerBoardVoltage;
            PowerBoardCurrent = obj.powerBoardCurrent;
            Amp1_2Voltage = obj.amp1_2Voltage;
            Amp1_2Current = obj.amp1_2Current;
            Amp3Voltage = obj.amp3Voltage;
            Amp3Current = obj.amp3Current;
            Amp4_1Voltage = obj.amp4_1Voltage;
            Amp4_1Current = obj.amp4_1Current;
            Amp4_2Voltage = obj.amp4_2Voltage;
            Amp4_2Current = obj.amp4_2Current;
            Amp4_3Voltage = obj.amp4_3Voltage;
            Amp4_3Current = obj.amp4_3Current;
            Amp4_4Voltage = obj.amp4_4Voltage;
            Amp4_4Current = obj.amp4_4Current;
            Amp4_5Voltage = obj.amp4_5Voltage;
            Amp4_5Current = obj.amp4_5Current;
            Amp4_6Voltage = obj.amp4_6Voltage;
            Amp4_6Current = obj.amp4_6Current;
            Temp = obj.temp;
            Humidity = obj.humidity;
        }

        private void OnReceiveMessageAction(chillerRcv obj)
        {
            if (obj.cmd == "status")
            {
                if(obj.data == "0")
                {
                    CStatus = "STANDBY";
                    CStatusBit = 0;
                }                    
                else if (obj.data == "1")
                {
                    CStatus = "START CHECK";
                    CStatusBit = 1;
                }                    
                else if (obj.data == "2")
                {
                    CStatus = "PUMP START";
                    CStatusBit = 1;
                }                    
                else if (obj.data == "3")
                {
                    CStatus = "PUMP DELAY";
                    CStatusBit = 1;
                }                    
                else if (obj.data == "4")
                {
                    CStatus = "PREP START";
                    CStatusBit = 1;
                }                    
                else if (obj.data == "5")
                {
                    CStatus = "PREP DELAY";
                    CStatusBit = 1;
                }                        
                else if (obj.data == "6")
                {
                    CStatus = "READY START";
                    CStatusBit = 1;
                }                    
                else if (obj.data == "7")
                {
                    CStatus = "READY DELAY";
                    CStatusBit = 1;
                }                    
                else if (obj.data == "8")
                {
                    CStatus = "RUN";
                    CStatusBit = 2;
                }                    
                else if (obj.data == "9")
                {
                    CStatus = "STOP";
                    CStatusBit = 0;
                }                    
                else if (obj.data == "@")
                {
                    CStatus = "STOP DELAY";
                    CStatusBit = 0;
                }                    
            }                
            else if (obj.cmd == "ch0_temp_value")
            {
                CTemp0Value = obj.data;
                CTempValue = obj.data;
            }               
            else if (obj.cmd == "ch1_temp_value")
                CTemp1Value = obj.data;
            else if (obj.cmd == "flow_value")
                CFlowValue = obj.data;
        }
        private void OnReceiveMessageAction(chillerMon obj)
        {
            CBit = obj.compOverHeat | obj.overCurrent | obj.pressureHigh | obj.pressureLow | obj.pressureHigh | obj.pressureLow | obj.flowMeterSensor | obj.flowSwitchSensor | obj.flowMeterLow | obj.flowSwitchLow |
                obj.flowMeterSensor | obj.flowSwitchSensor | obj.flowMeterLow | obj.flowSwitchLow | obj.levelSensor | obj.levelLow2 | obj.levelLow1 | obj.levelSensor | obj.levelLow2 | obj.levelLow1 | obj.tempHigh2 |
                obj.tempHigh1 | obj.tempLow2 | obj.tempLow1 | obj.tempHigh2 | obj.tempHigh1 | obj.tempLow2 | obj.tempLow1;
        }

    }
}
