using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Messages
{
    class LvbBitResult : MessageBase
    {
        public bool bitStatus { get; set; }
        public bool seedLdCurrent { get; set; }
        public bool seedLdTemp { get; set; }
        public bool seedHsTemp { get; set; }
        public bool seedRfVmon { get; set; }
        public bool pa1Current { get; set; }
        public bool pa1Voltage { get; set; }
        public bool pa2Current { get; set; }
        public bool pa2Voltage { get; set; }
        public bool pa3Current { get; set; }
        public bool pa3Voltage { get; set; }
        public bool pa4_1Current { get; set; }
        public bool pa4_1Voltage { get; set; }
        public bool pa4_2Current { get; set; }
        public bool pa4_2Voltage { get; set; }
        public bool pa4_3Current { get; set; }
        public bool pa4_3Voltage { get; set; }
        public bool pa4_4Current { get; set; }
        public bool pa4_4Voltage { get; set; }
        public bool pa4_5Current { get; set; }
        public bool pa4_5Voltage { get; set; }
        public bool pa4_6Current { get; set; }
        public bool pa4_6Voltage { get; set; }
        public bool pd1 { get; set; }
        public bool pd2 { get; set; }
        public bool pd3 { get; set; }
        public bool pd4 { get; set; }
        public bool pd5 { get; set; }
        public bool pd6 { get; set; }
        public bool pd7 { get; set; }
        public bool pd8 { get; set; }
        public bool seedTemp1 { get; set; }
        public bool seedTemp2 { get; set; }
        public bool seedTemp3 { get; set; }
        public bool paTemp1 { get; set; }
        public bool paTemp2 { get; set; }
        public bool paTemp3 { get; set; }
        public bool paTemp4 { get; set; }
        public bool paTemp5 { get; set; }
        public bool paTemp6 { get; set; }
        public bool paTemp7 { get; set; }
        public bool paTemp8 { get; set; }
        public bool paTemp9 { get; set; }
        public bool paTemp10 { get; set; }
        public bool paTemp11 { get; set; }
        public bool paTemp12 { get; set; }
        public bool paTemp13 { get; set; }
        public bool paTemp14 { get; set; }
        public bool paTemp15 { get; set; }
        public bool paTemp16 { get; set; }
        public bool seedHumid { get; set; }
        public bool paHumid { get; set; }
        public bool paLeak { get; set; }
        public bool e_Stop { get; set; }
        public bool chiller { get; set; }
        public bool polarization { get; set; }
    }

    class versionResponse : MessageBase
    {
        public int SwVer { get; set; }
        public int HwVer { get; set; }
        public int DeviceId { get; set; }
    }

    class polValue : MessageBase
    {
        public int PolAvg { get; set; }
        public int PolSts { get; set; }
        public int PolDly { get; set; }
        public int PolThh { get; set; }
    }

    class writeSetValue : MessageBase
    {
        public float SeedCurrentSetValue { get; set; }
        public float SeedTempSetValue { get; set; }
        public float HsTempSetValue { get; set; }
        public float Pa1CurrentSetValue { get; set; }
        public float Pa2CurrentSetValue { get; set; }
        public float Pa3CurrentSetValue { get; set; }
        public float Pa4_1CurrentSetValueR1 { get; set; }
        public float Pa4_1TimeSetValueR1 { get; set; }
        public float Pa4_1CurrentSetValueR2 { get; set; }
        public float Pa4_1TimeSetValueR2 { get; set; }
        public float Pa4_1CurrentSetValueR3 { get; set; }
        public float Pa4_1TimeSetValueR3 { get; set; }
        public float Pa4_2CurrentSetValueR1 { get; set; }
        public float Pa4_2TimeSetValueR1 { get; set; }
        public float Pa4_2CurrentSetValueR2 { get; set; }
        public float Pa4_2TimeSetValueR2 { get; set; }
        public float Pa4_2CurrentSetValueR3 { get; set; }
        public float Pa4_2TimeSetValueR3 { get; set; }
        public float Pa4_3CurrentSetValueR1 { get; set; }
        public float Pa4_3TimeSetValueR1 { get; set; }
        public float Pa4_3CurrentSetValueR2 { get; set; }
        public float Pa4_3TimeSetValueR2 { get; set; }
        public float Pa4_3CurrentSetValueR3 { get; set; }
        public float Pa4_3TimeSetValueR3 { get; set; }
        public float Pa4_4CurrentSetValueR1 { get; set; }
        public float Pa4_4TimeSetValueR1 { get; set; }
        public float Pa4_4CurrentSetValueR2 { get; set; }
        public float Pa4_4TimeSetValueR2 { get; set; }
        public float Pa4_4CurrentSetValueR3 { get; set; }
        public float Pa4_4TimeSetValueR3 { get; set; }
        public float Pa4_5CurrentSetValueR1 { get; set; }
        public float Pa4_5TimeSetValueR1 { get; set; }
        public float Pa4_5CurrentSetValueR2 { get; set; }
        public float Pa4_5TimeSetValueR2 { get; set; }
        public float Pa4_5CurrentSetValueR3 { get; set; }
        public float Pa4_5TimeSetValueR3 { get; set; }
        public float Pa4_6CurrentSetValueR1 { get; set; }
        public float Pa4_6TimeSetValueR1 { get; set; }
        public float Pa4_6CurrentSetValueR2 { get; set; }
        public float Pa4_6TimeSetValueR2 { get; set; }
        public float Pa4_6CurrentSetValueR3 { get; set; }
        public float Pa4_6TimeSetValueR3 { get; set; }
        public float RfVxpVoltSetValue { get; set; }
        public float RfVampVoltSetValue { get; set; }
    }
    class writeCalValue : MessageBase
    {
        public short SeedCurrentCal { get; set; }
        public short SeedTempCal { get; set; }
        public short HsTempCal { get; set; }
        public short Pa1CurrentCal { get; set; }
        public short Pa2CurrentCal { get; set; }
        public short Pa3CurrentCal { get; set; }
        public short Pa4_1CurrentCal { get; set; }
        public short Pa4_2CurrentCal { get; set; }
        public short Pa4_3CurrentCal { get; set; }
        public short Pa4_4CurrentCal { get; set; }
        public short Pa4_5CurrentCal { get; set; }
        public short Pa4_6CurrentCal { get; set; }
        public sbyte RfVxpCal { get; set; }
        public sbyte RfVampCal { get; set; }
    }
    class readCalValue : MessageBase
    {
        public short SeedCurrentCal { get; set; }
        public short SeedTempCal { get; set; }
        public short Pa1CurrentCal { get; set; }
        public short Pa2CurrentCal { get; set; }
        public short Pa3CurrentCal { get; set; }
        public short Pa4_1CurrentCal { get; set; }
        public short Pa4_2CurrentCal { get; set; }
        public short Pa4_3CurrentCal { get; set; }
        public short Pa4_4CurrentCal { get; set; }
        public short Pa4_5CurrentCal { get; set; }
        public short Pa4_6CurrentCal { get; set; }
        public short Pa1VoltageCal { get; set; }
        public short Pa2VoltageCal { get; set; }
        public short Pa3VoltageCal { get; set; }
        public short Pa4_1VoltageCal { get; set; }
        public short Pa4_2VoltageCal { get; set; }
        public short Pa4_3VoltageCal { get; set; }
        public short Pa4_4VoltageCal { get; set; }
        public short Pa4_5VoltageCal { get; set; }
        public short Pa4_6VoltageCal { get; set; }
        public short SeedTemp1Cal { get; set; }
        public short SeedTemp2Cal { get; set; }
        public short SeedTemp3Cal { get; set; }
        public short PaTemp1Cal { get; set; }
        public short PaTemp2Cal { get; set; }
        public short PaTemp3Cal { get; set; }
        public short PaTemp4Cal { get; set; }
        public short PaTemp5Cal { get; set; }
        public short PaTemp6Cal { get; set; }
        public short PaTemp7Cal { get; set; }
        public short PaTemp8Cal { get; set; }
        public short PaTemp9Cal { get; set; }
        public short PaTemp10Cal { get; set; }
        public short PaTemp11Cal { get; set; }
        public short PaTemp12Cal { get; set; }
        public short PaTemp13Cal { get; set; }
        public short PaTemp14Cal { get; set; }
        public short PaTemp15Cal { get; set; }
        public short PaTemp16Cal { get; set; }
        public short RfVmonCal { get; set; }
    }

    class setHighLimit : MessageBase
    {
        public float SeedCurrent { get; set; }
        public float SeedTemp { get; set; }
        public float Pa1Current { get; set; }
        public float Pa2Current { get; set; }
        public float Pa3Current { get; set; }
        public float Pa4_1Current { get; set; }
        public float Pa4_2Current { get; set; }
        public float Pa4_3Current { get; set; }
        public float Pa4_4Current { get; set; }
        public float Pa4_5Current { get; set; }
        public float Pa4_6Current { get; set; }
        public float Pa1Voltage { get; set; }
        public float Pa2Voltage { get; set; }
        public float Pa3Voltage { get; set; }
        public float Pa4_1Voltage { get; set; }
        public float Pa4_2Voltage { get; set; }
        public float Pa4_3Voltage { get; set; }
        public float Pa4_4Voltage { get; set; }
        public float Pa4_5Voltage { get; set; }
        public float Pa4_6Voltage { get; set; }
        public float Pd1 { get; set; }
        public float Pd2 { get; set; }
        public float Pd3 { get; set; }
        public float Pd4 { get; set; }
        public float Pd5 { get; set; }
        public float Pd6 { get; set; }
        public float Pd7 { get; set; }
        public float Pd8 { get; set; }
        public float SeedTemp1 { get; set; }
        public float SeedTemp2 { get; set; }
        public float SeedTemp3 { get; set; }
        public float PaTemp1 { get; set; }
        public float PaTemp2 { get; set; }
        public float PaTemp3 { get; set; }
        public float PaTemp4 { get; set; }
        public float PaTemp5 { get; set; }
        public float PaTemp6 { get; set; }
        public float PaTemp7 { get; set; }
        public float PaTemp8 { get; set; }
        public float PaTemp9 { get; set; }
        public float PaTemp10 { get; set; }
        public float PaTemp11 { get; set; }
        public float PaTemp12 { get; set; }
        public float PaTemp13 { get; set; }
        public float PaTemp14 { get; set; }
        public float PaTemp15 { get; set; }
        public float PaTemp16 { get; set; }
        public float RfVmon { get; set; }
        public float SeedHumid { get; set; }
        public float PaHumid { get; set; }
    }
    class setLowLimit : MessageBase
    {
        public float SeedCurrent { get; set; }
        public float SeedTemp { get; set; }
        public float Pa1Current { get; set; }
        public float Pa2Current { get; set; }
        public float Pa3Current { get; set; }
        public float Pa4_1Current { get; set; }
        public float Pa4_2Current { get; set; }
        public float Pa4_3Current { get; set; }
        public float Pa4_4Current { get; set; }
        public float Pa4_5Current { get; set; }
        public float Pa4_6Current { get; set; }
        public float Pa1Voltage { get; set; }
        public float Pa2Voltage { get; set; }
        public float Pa3Voltage { get; set; }
        public float Pa4_1Voltage { get; set; }
        public float Pa4_2Voltage { get; set; }
        public float Pa4_3Voltage { get; set; }
        public float Pa4_4Voltage { get; set; }
        public float Pa4_5Voltage { get; set; }
        public float Pa4_6Voltage { get; set; }
        public float Pd1 { get; set; }
        public float Pd2 { get; set; }
        public float Pd3 { get; set; }
        public float Pd4 { get; set; }
        public float Pd5 { get; set; }
        public float Pd6 { get; set; }
        public float Pd7 { get; set; }
        public float Pd8 { get; set; }
        public float SeedTemp1 { get; set; }
        public float SeedTemp2 { get; set; }
        public float SeedTemp3 { get; set; }
        public float PaTemp1 { get; set; }
        public float PaTemp2 { get; set; }
        public float PaTemp3 { get; set; }
        public float PaTemp4 { get; set; }
        public float PaTemp5 { get; set; }
        public float PaTemp6 { get; set; }
        public float PaTemp7 { get; set; }
        public float PaTemp8 { get; set; }
        public float PaTemp9 { get; set; }
        public float PaTemp10 { get; set; }
        public float PaTemp11 { get; set; }
        public float PaTemp12 { get; set; }
        public float PaTemp13 { get; set; }
        public float PaTemp14 { get; set; }
        public float PaTemp15 { get; set; }
        public float PaTemp16 { get; set; }
        public float RfVmon { get; set; }
        public float SeedHumid { get; set; }
        public float PaHumid { get; set; }
    }
    class pdCalibration : MessageBase
    {
        public ushort PdChennel { get; set; }
        public ushort TableLength { get; set; }
        public bool Pd1Selection { get; set; }
        public bool Pd2Selection { get; set; }
        public bool Pd3Selection { get; set; }
        public bool Pd4Selection { get; set; }
        public bool Pd5Selection { get; set; }
        public bool Pd6Selection { get; set; }
        public bool Pd7Selection { get; set; }
        public ushort PdAdc1 { get; set; }
        public ushort PdAdc2 { get; set; }
        public ushort PdAdc3 { get; set; }
        public ushort PdAdc4 { get; set; }
        public ushort PdAdc5 { get; set; }
        public ushort PdAdc6 { get; set; }
        public ushort PdAdc7 { get; set; }
        public ushort PdAdc8 { get; set; }
        public ushort PdAdc9 { get; set; }
        public ushort PdAdc10 { get; set; }
        public float PdLaserPower1 { get; set; }
        public float PdLaserPower2 { get; set; }
        public float PdLaserPower3 { get; set; }
        public float PdLaserPower4 { get; set; }
        public float PdLaserPower5 { get; set; }
        public float PdLaserPower6 { get; set; }
        public float PdLaserPower7 { get; set; }
        public float PdLaserPower8 { get; set; }
        public float PdLaserPower9 { get; set; }
        public float PdLaserPower10 { get; set; }
    }

    class readSetValue : MessageBase
    {
        public float SeedCurrentReadValue { get; set; }
        public float SeedTempReadValue { get; set; }
        public float HsTempReadValue { get; set; }
        public float Pa1CurrentReadValue { get; set; }
        public float Pa2CurrentReadValue { get; set; }
        public float Pa3CurrentReadValue { get; set; }
        public float Pa4_1CurrentReadValueR1 { get; set; }
        public float Pa4_1TimeReadValueR1 { get; set; }
        public float Pa4_1CurrentReadValueR2 { get; set; }
        public float Pa4_1TimeReadValueR2 { get; set; }
        public float Pa4_1CurrentReadValueR3 { get; set; }
        public float Pa4_1TimeReadValueR3 { get; set; }
        public float Pa4_2CurrentReadValueR1 { get; set; }
        public float Pa4_2TimeReadValueR1 { get; set; }
        public float Pa4_2CurrentReadValueR2 { get; set; }
        public float Pa4_2TimeReadValueR2 { get; set; }
        public float Pa4_2CurrentReadValueR3 { get; set; }
        public float Pa4_2TimeReadValueR3 { get; set; }
        public float Pa4_3CurrentReadValueR1 { get; set; }
        public float Pa4_3TimeReadValueR1 { get; set; }
        public float Pa4_3CurrentReadValueR2 { get; set; }
        public float Pa4_3TimeReadValueR2 { get; set; }
        public float Pa4_3CurrentReadValueR3 { get; set; }
        public float Pa4_3TimeReadValueR3 { get; set; }
        public float Pa4_4CurrentReadValueR1 { get; set; }
        public float Pa4_4TimeReadValueR1 { get; set; }
        public float Pa4_4CurrentReadValueR2 { get; set; }
        public float Pa4_4TimeReadValueR2 { get; set; }
        public float Pa4_4CurrentReadValueR3 { get; set; }
        public float Pa4_4TimeReadValueR3 { get; set; }
        public float Pa4_5CurrentReadValueR1 { get; set; }
        public float Pa4_5TimeReadValueR1 { get; set; }
        public float Pa4_5CurrentReadValueR2 { get; set; }
        public float Pa4_5TimeReadValueR2 { get; set; }
        public float Pa4_5CurrentReadValueR3 { get; set; }
        public float Pa4_5TimeReadValueR3 { get; set; }
        public float Pa4_6CurrentReadValueR1 { get; set; }
        public float Pa4_6TimeReadValueR1 { get; set; }
        public float Pa4_6CurrentReadValueR2 { get; set; }
        public float Pa4_6TimeReadValueR2 { get; set; }
        public float Pa4_6CurrentReadValueR3 { get; set; }
        public float Pa4_6TimeReadValueR3 { get; set; }
        public float RfVxpVoltReadValue { get; set; }
        public float RfVampVoltReadValue { get; set; }
    }
    class monValue : MessageBase
    {
        public float SeedCurrent { get; set; }
        public float SeedTemp { get; set; }
        public float Pa1Current { get; set; }
        public float Pa2Current { get; set; }
        public float Pa3Current { get; set; }
        public float Pa4_1Current { get; set; }
        public float Pa4_2Current { get; set; }
        public float Pa4_3Current { get; set; }
        public float Pa4_4Current { get; set; }
        public float Pa4_5Current { get; set; }
        public float Pa4_6Current { get; set; }
        public float Pa1Voltage { get; set; }
        public float Pa2Voltage { get; set; }
        public float Pa3Voltage { get; set; }
        public float Pa4_1Voltage { get; set; }
        public float Pa4_2Voltage { get; set; }
        public float Pa4_3Voltage { get; set; }
        public float Pa4_4Voltage { get; set; }
        public float Pa4_5Voltage { get; set; }
        public float Pa4_6Voltage { get; set; }
        public float Pd1 { get; set; }
        public float Pd2 { get; set; }
        public float Pd3 { get; set; }
        public float Pd4 { get; set; }
        public float Pd5 { get; set; }
        public float Pd6 { get; set; }
        public float Pd7 { get; set; }
        public float Pd8 { get; set; }
        public float SeedTemp1 { get; set; }
        public float SeedTemp2 { get; set; }
        public float SeedTemp3 { get; set; }
        public float PaTemp1 { get; set; }
        public float PaTemp2 { get; set; }
        public float PaTemp3 { get; set; }
        public float PaTemp4 { get; set; }
        public float PaTemp5 { get; set; }
        public float PaTemp6 { get; set; }
        public float PaTemp7 { get; set; }
        public float PaTemp8 { get; set; }
        public float PaTemp9 { get; set; }
        public float PaTemp10 { get; set; }
        public float PaTemp11 { get; set; }
        public float PaTemp12 { get; set; }
        public float PaTemp13 { get; set; }
        public float PaTemp14 { get; set; }
        public float PaTemp15 { get; set; }
        public float PaTemp16 { get; set; }
        public float RfVolt { get; set; }
        public float SeedHumid { get; set; }
        public float PaHumid { get; set; }
        public string PolRead { get; set; }        
    }
    class pdAdc : MessageBase
    {
        public int PdAdc1Value { get; set; }
        public int PdAdc2Value { get; set; }
        public int PdAdc3Value { get; set; }
        public int PdAdc4Value { get; set; }
        public int PdAdc5Value { get; set; }
        public int PdAdc6Value { get; set; }
        public int PdAdc7Value { get; set; }
        public int PdAdc8Value { get; set; }
    }

    class warnMon : MessageBase
    {
        public bool SeedTempHigh { get; set; }
        public bool SeedTempLow { get; set; }
        public bool SeedTemp1High { get; set; }
        public bool SeedTemp1Low { get; set; }
        public bool SeedTemp2High { get; set; }
        public bool SeedTemp2Low { get; set; }
        public bool SeedTemp3High { get; set; }
        public bool SeedTemp3Low { get; set; }
        public bool PaTemp1High { get; set; }
        public bool PaTemp1Low { get; set; }
        public bool PaTemp2High { get; set; }
        public bool PaTemp2Low { get; set; }
        public bool PaTemp3High { get; set; }
        public bool PaTemp3Low { get; set; }
        public bool PaTemp4High { get; set; }
        public bool PaTemp4Low { get; set; }
        public bool PaTemp5High { get; set; }
        public bool PaTemp5Low { get; set; }
        public bool PaTemp6High { get; set; }
        public bool PaTemp6Low { get; set; }
        public bool PaTemp7High { get; set; }
        public bool PaTemp7Low { get; set; }
        public bool PaTemp8High { get; set; }
        public bool PaTemp8Low { get; set; }
        public bool PaTemp9High { get; set; }
        public bool PaTemp9Low { get; set; }
        public bool PaTemp10High { get; set; }
        public bool PaTemp10Low { get; set; }
        public bool PaTemp11High { get; set; }
        public bool PaTemp11Low { get; set; }
        public bool PaTemp12High { get; set; }
        public bool PaTemp12Low { get; set; }
        public bool PaTemp13High { get; set; }
        public bool PaTemp13Low { get; set; }
        public bool PaTemp14High { get; set; }
        public bool PaTemp14Low { get; set; }
        public bool PaTemp15High { get; set; }
        public bool PaTemp15Low { get; set; }
        public bool PaTemp16High { get; set; }
        public bool PaTemp16Low { get; set; }
    }
    class errorMon : MessageBase
    {
        public bool SeedLdCurrentLow { get; set; }
        public bool SeedLdCurrentHigh { get; set; }
        public bool Pa1CurrentLow { get; set; }
        public bool Pa1CurrentHigh { get; set; }
        public bool Pa2CurrentLow { get; set; }
        public bool Pa2CurrentHigh { get; set; }
        public bool Pa3CurrentLow { get; set; }
        public bool Pa3CurrentHigh { get; set; }
        public bool Pa4_1CurrentLow { get; set; }
        public bool Pa4_1CurrentHigh { get; set; }
        public bool Pa4_2CurrentLow { get; set; }
        public bool Pa4_2CurrentHigh { get; set; }
        public bool Pa4_3CurrentLow { get; set; }
        public bool Pa4_3CurrentHigh { get; set; }
        public bool Pa4_4CurrentLow { get; set; }
        public bool Pa4_4CurrentHigh { get; set; }
        public bool Pa4_5CurrentLow { get; set; }
        public bool Pa4_5CurrentHigh { get; set; }
        public bool Pa4_6CurrentLow { get; set; }
        public bool Pa4_6CurrentHigh { get; set; }
        public bool Pa1VoltageLow { get; set; }
        public bool Pa1VoltageHigh { get; set; }
        public bool Pa2VoltageLow { get; set; }
        public bool Pa2VoltageHigh { get; set; }
        public bool Pa3VoltageLow { get; set; }
        public bool Pa3VoltageHigh { get; set; }
        public bool Pa4_1VoltageLow { get; set; }
        public bool Pa4_1VoltageHigh { get; set; }
        public bool Pa4_2VoltageLow { get; set; }
        public bool Pa4_2VoltageHigh { get; set; }
        public bool Pa4_3VoltageLow { get; set; }
        public bool Pa4_3VoltageHigh { get; set; }
        public bool Pa4_4VoltageLow { get; set; }
        public bool Pa4_4VoltageHigh { get; set; }
        public bool Pa4_5VoltageLow { get; set; }
        public bool Pa4_5VoltageHigh { get; set; }
        public bool Pa4_6VoltageLow { get; set; }
        public bool Pa4_6VoltageHigh { get; set; }
        public bool Pd1Low { get; set; }
        public bool Pd1High { get; set; }
        public bool Pd2Low { get; set; }
        public bool Pd2High { get; set; }
        public bool Pd3Low { get; set; }
        public bool Pd3High { get; set; }
        public bool Pd4Low { get; set; }
        public bool Pd4High { get; set; }
        public bool Pd5Low { get; set; }
        public bool Pd5High { get; set; }
        public bool Pd6Low { get; set; }
        public bool Pd6High { get; set; }
        public bool Pd7Low { get; set; }
        public bool Pd7High { get; set; }
        public bool Pd8Low { get; set; }
        public bool Pd8High { get; set; }
        public bool LeakSensor { get; set; }
        public bool E_Stop { get; set; }
        public bool Chiller { get; set; }
        public bool PaHumid { get; set; }
        public bool SeedHumid { get; set; }
        public bool RfVMon { get; set; }
    }
    class dcPowerBit : MessageBase
    {
        public bool DcPowerBit { get; set; }
    }

    class dcpMon : MessageBase
    {
        public float vacInputVoltage { get; set; }
        public float vacInputCurrent { get; set; }
        public float powerBoardVoltage { get; set; }
        public float powerBoardCurrent { get; set; }
        public float amp1_2Voltage { get; set; }
        public float amp1_2Current { get; set; }
        public float amp3Voltage { get; set; }
        public float amp3Current { get; set; }
        public float amp4_1Voltage { get; set; }
        public float amp4_1Current { get; set; }
        public float amp4_2Voltage { get; set; }
        public float amp4_2Current { get; set; }
        public float amp4_3Voltage { get; set; }
        public float amp4_3Current { get; set; }
        public float amp4_4Voltage { get; set; }
        public float amp4_4Current { get; set; }
        public float amp4_5Voltage { get; set; }
        public float amp4_5Current { get; set; }
        public float amp4_6Voltage { get; set; }
        public float amp4_6Current { get; set; }
        public float temp { get; set; }
        public float humidity { get; set; }
    }

    class dcpBit : MessageBase
    {
        public bool vacVoltHigh { get; set; }
        public bool vacVoltLow { get; set; }
        public bool vacCurrHigh { get; set; }
        public bool vacCurrLow { get; set; }
        public bool pbVoltHigh { get; set; }
        public bool pbVoltLow { get; set; }
        public bool pbCurrHigh { get; set; }
        public bool pbCurrLow { get; set; }
        public bool amp1_2VoltHigh { get; set; }
        public bool amp1_2VoltLow { get; set; }
        public bool amp1_2CurrHigh { get; set; }
        public bool amp1_2CurrLow { get; set; }
        public bool amp3VoltHigh { get; set; }
        public bool amp3VoltLow { get; set; }
        public bool amp3CurrHigh { get; set; }
        public bool amp3CurrLow { get; set; }
        public bool amp4_1VoltHigh { get; set; }
        public bool amp4_1VoltLow { get; set; }
        public bool amp4_1CurrHigh { get; set; }
        public bool amp4_1CurrLow { get; set; }
        public bool amp4_2VoltHigh { get; set; }
        public bool amp4_2VoltLow { get; set; }
        public bool amp4_2CurrHigh { get; set; }
        public bool amp4_2CurrLow { get; set; }
        public bool amp4_3VoltHigh { get; set; }
        public bool amp4_3VoltLow { get; set; }
        public bool amp4_3CurrHigh { get; set; }
        public bool amp4_3CurrLow { get; set; }
        public bool amp4_4VoltHigh { get; set; }
        public bool amp4_4VoltLow { get; set; }
        public bool amp4_4CurrHigh { get; set; }
        public bool amp4_4CurrLow { get; set; }
        public bool amp4_5VoltHigh { get; set; }
        public bool amp4_5VoltLow { get; set; }
        public bool amp4_5CurrHigh { get; set; }
        public bool amp4_5CurrLow { get; set; }
        public bool amp4_6VoltHigh { get; set; }
        public bool amp4_6VoltLow { get; set; }
        public bool amp4_6CurrHigh { get; set; }
        public bool amp4_6CurrLow { get; set; }
        public bool tempHigh { get; set; }
        public bool tempLow { get; set; }
        public bool humidityHigh { get; set; }
        public bool humidityLow { get; set; }
        public bool e_stop { get; set; }
    }
    class chillerMon : MessageBase
    {
        public bool compOverHeat { get; set; }
        public bool overCurrent { get; set; }
        public bool pressureLow { get; set; }
        public bool pressureHigh { get; set; }
        public bool flowMeterSensor { get; set; }
        public bool flowSwitchSensor { get; set; }
        public bool flowMeterLow { get; set; }
        public bool flowSwitchLow { get; set; }
        public bool tempSensor { get; set; }
        public bool levelSensor { get; set; }
        public bool levelLow2 { get; set; }
        public bool levelLow1 { get; set; }
        public bool tempLow2 { get; set; }
        public bool tempLow1 { get; set; }
        public bool tempHigh2 { get; set; }
        public bool tempHigh1 { get; set; }
    }
    class chillerCmd : MessageBase
    {
        public string cmd { get; set; }
        public string data { get; set; }
    }
    class chillerRcv : MessageBase
    {
        public string cmd { get; set; }
        public string data { get; set; }
    }
    class lcb002Cmd : MessageBase
    {
        public int reset { get; set; }
        public int seed { get; set; }
        public int amp { get; set; }
        public int cmd { get; set; }
        public string pol { get; set; }
    }
    class lcb003Cmd : MessageBase
    {
        public string cmd { get; set; }
    }

    class lcb004writeSetCmd : MessageBase
    {
        public float SeedCurrentSetValue { get; set; }
        public float SeedTempSetValue { get; set; }
        public float HsTempSetValue { get; set; }
        public float Pa1CurrentSetValue { get; set; }
        public float Pa2CurrentSetValue { get; set; }
        public float Pa3CurrentSetValue { get; set; }
        public float Pa4_1CurrentSetValueR1 { get; set; }
        public float Pa4_1TimeSetValueR1 { get; set; }
        public float Pa4_1CurrentSetValueR2 { get; set; }
        public float Pa4_1TimeSetValueR2 { get; set; }
        public float Pa4_1CurrentSetValueR3 { get; set; }
        public float Pa4_1TimeSetValueR3 { get; set; }
        public float Pa4_2CurrentSetValueR1 { get; set; }
        public float Pa4_2TimeSetValueR1 { get; set; }
        public float Pa4_2CurrentSetValueR2 { get; set; }
        public float Pa4_2TimeSetValueR2 { get; set; }
        public float Pa4_2CurrentSetValueR3 { get; set; }
        public float Pa4_2TimeSetValueR3 { get; set; }
        public float Pa4_3CurrentSetValueR1 { get; set; }
        public float Pa4_3TimeSetValueR1 { get; set; }
        public float Pa4_3CurrentSetValueR2 { get; set; }
        public float Pa4_3TimeSetValueR2 { get; set; }
        public float Pa4_3CurrentSetValueR3 { get; set; }
        public float Pa4_3TimeSetValueR3 { get; set; }
        public float Pa4_4CurrentSetValueR1 { get; set; }
        public float Pa4_4TimeSetValueR1 { get; set; }
        public float Pa4_4CurrentSetValueR2 { get; set; }
        public float Pa4_4TimeSetValueR2 { get; set; }
        public float Pa4_4CurrentSetValueR3 { get; set; }
        public float Pa4_4TimeSetValueR3 { get; set; }
        public float Pa4_5CurrentSetValueR1 { get; set; }
        public float Pa4_5TimeSetValueR1 { get; set; }
        public float Pa4_5CurrentSetValueR2 { get; set; }
        public float Pa4_5TimeSetValueR2 { get; set; }
        public float Pa4_5CurrentSetValueR3 { get; set; }
        public float Pa4_5TimeSetValueR3 { get; set; }
        public float Pa4_6CurrentSetValueR1 { get; set; }
        public float Pa4_6TimeSetValueR1 { get; set; }
        public float Pa4_6CurrentSetValueR2 { get; set; }
        public float Pa4_6TimeSetValueR2 { get; set; }
        public float Pa4_6CurrentSetValueR3 { get; set; }
        public float Pa4_6TimeSetValueR3 { get; set; }
        public float RfVxpVoltSetValue { get; set; }
        public float RfVampVoltSetValue { get; set; }
    }

    class lcb004ReadSetCmd : MessageBase
    {
        public string cmd { get; set; }
    }

    class lcb004PdCalCmd : MessageBase
    {
        public float PdChannel { get; set; }
        public float TableLength { get; set; }
        public float PdAdc1 { get; set; }
        public float PdAdc2 { get; set; }
        public float PdAdc3 { get; set; }
        public float PdAdc4 { get; set; }
        public float PdAdc5 { get; set; }
        public float PdAdc6 { get; set; }
        public float PdAdc7 { get; set; }
        public float PdAdc8 { get; set; }
        public float PdAdc9 { get; set; }
        public float PdAdc10 { get; set; }
        public float PdPower1 { get; set; }
        public float PdPower2 { get; set; }
        public float PdPower3 { get; set; }
        public float PdPower4 { get; set; }
        public float PdPower5 { get; set; }
        public float PdPower6 { get; set; }
        public float PdPower7 { get; set; }
        public float PdPower8 { get; set; }
        public float PdPower9 { get; set; }
        public float PdPower10 { get; set; }
    }
}
