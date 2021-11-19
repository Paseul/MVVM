using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows;
using MVVM.Messages;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

public class AsyncStateData
{    
    public byte[] Buffer;
    public Socket Socket;
}

namespace MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public Socket laserClient = null;
        public Socket dcpClient = null;
        public Socket chillerClient = null;
        private static ManualResetEvent connectDone =
        new ManualResetEvent(false);
        private bool dcPBit;

        delegate void TimerEventFiredDelegate();

        public event PropertyChangedEventHandler PropertyChanged;
        int chillerCBitNum = 0;

        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainViewModel()
        {
            connect();
            Messenger.Default.Register<chillerCmd>(this, OnReceiveMessageAction);            
        }

        


        private void connect()
        {
            Thread laserThread = new Thread(laserFunc);
            laserThread.IsBackground = true;
            laserThread.Start();
            Thread dcpThread = new Thread(dcpFunc);
            dcpThread.IsBackground = true;
            dcpThread.Start();
            Thread chillerThread = new Thread(chillerFunc);
            chillerThread.IsBackground = true;
            chillerThread.Start();
        }
        #region laser
        private void laserFunc(object obj)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);

            laserClient = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.  
            laserClient.BeginConnect(remoteEP,
                new AsyncCallback(laserConnectCallback), laserClient);
            connectDone.WaitOne();            
        }

        private void laserConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();

                AsyncStateData data = new AsyncStateData();
                data.Buffer = new byte[1024];
                data.Socket = client;
                client.BeginReceive(data.Buffer, 0, data.Buffer.Length,
                SocketFlags.None, new AsyncCallback(laserReceiveCallback), data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("증폭부 보드 연결 실패");
            }
        }

        private void laserReceiveCallback(IAsyncResult asyncResult)
        {
            AsyncStateData data = (AsyncStateData)asyncResult.AsyncState;
            Socket client = data.Socket;

            AsyncStateData rcvData = asyncResult.AsyncState as AsyncStateData;
            byte[] result = rcvData.Buffer.Skip(9).ToArray();

            if (rcvData.Buffer[0] == 172 && rcvData.Buffer[1] == 19)
            {
                if (rcvData.Buffer[2] == 2 && rcvData.Buffer[3] == 1)
                {
                    if (rcvData.Buffer[4] == 1)
                    {
                        lcbBit(result);
                    }
                    else if (rcvData.Buffer[4] == 2)
                    {
                        lcbCmd(result);
                    }
                    else if (rcvData.Buffer[4] == 3)
                    {
                        lcbVer(result);
                    }
                    else if (rcvData.Buffer[4] == 4)
                    {
                        lcbEng(result);
                    }
                    else if (rcvData.Buffer[4] == 5)
                    {
                        lcbMon(result);
                    }
                }                
            }

            data.Buffer = new byte[1024];
            data.Socket = client;
            client.BeginReceive(data.Buffer, 0, data.Buffer.Length,
                    SocketFlags.None, new AsyncCallback(laserReceiveCallback), data);
        }

        private void lcbBit(byte[] result)
        {
            BitArray bitAbstract = new BitArray(result);
            byte[] bitByte = result.Skip(1).Take(8).ToArray();
            Array.Reverse(bitByte);
            BitArray bitResult = new BitArray(bitByte);

            if (bitAbstract[2] == true)
            {
                if (bitAbstract[3] == true)
                {
                    Console.WriteLine("수행중");
                }
                else
                {
                    if (bitAbstract[0] == true && bitAbstract[1] == false)
                    {
                        Console.WriteLine("PBIT 정상");
                        Messenger.Default.Send("laserNormal");
                    }
                    else if (bitAbstract[0] == false && bitAbstract[1] == true)
                    {
                        Console.WriteLine("CBIT 정상");
                    }
                }
            }
            else if (bitAbstract[3] == true)
            {
                Console.WriteLine("비정상");
                Messenger.Default.Send("laserError");
            }
            bool BitStatus = true;

            if (bitAbstract[2] == true && bitAbstract[3] == false)
            {
                BitStatus = true;
            }
            if (bitAbstract[2] == false && bitAbstract[3] == true)
            {
                BitStatus = false;
            }


            var LvbBitResult = new LvbBitResult()
            {
                bitStatus = BitStatus,
                seedLdCurrent = bitResult[0],
                seedLdTemp = bitResult[1],
                seedHsTemp = bitResult[2],
                seedRfVmon = bitResult[3],
                pa1Current = bitResult[4],
                pa1Voltage = bitResult[5],
                pa2Current = bitResult[6],
                pa2Voltage = bitResult[7],
                pa3Current = bitResult[8],
                pa3Voltage = bitResult[9],
                pa4_1Current = bitResult[10],
                pa4_1Voltage = bitResult[11],
                pa4_2Current = bitResult[12],
                pa4_2Voltage = bitResult[13],
                pa4_3Current = bitResult[14],
                pa4_3Voltage = bitResult[15],
                pa4_4Current = bitResult[16],
                pa4_4Voltage = bitResult[17],
                pa4_5Current = bitResult[18],
                pa4_5Voltage = bitResult[19],
                pa4_6Current = bitResult[20],
                pa4_6Voltage = bitResult[21],
                pd1 = bitResult[22],
                pd2 = bitResult[23],
                pd3 = bitResult[24],
                pd4 = bitResult[25],
                pd5 = bitResult[26],
                pd6 = bitResult[27],
                pd7 = bitResult[28],
                pd8 = bitResult[29],
                seedTemp1 = bitResult[30],
                seedTemp2 = bitResult[31],
                seedTemp3 = bitResult[32],
                paTemp1 = bitResult[33],
                paTemp2 = bitResult[34],
                paTemp3 = bitResult[35],
                paTemp4 = bitResult[36],
                paTemp5 = bitResult[37],
                paTemp6 = bitResult[38],
                paTemp7 = bitResult[39],
                paTemp8 = bitResult[40],
                paTemp9 = bitResult[41],
                paTemp10 = bitResult[42],
                paTemp11 = bitResult[43],
                paTemp12 = bitResult[44],
                paTemp13 = bitResult[45],
                paTemp14 = bitResult[46],
                paTemp15 = bitResult[47],
                paTemp16 = bitResult[48],
                seedHumid = bitResult[49],
                paHumid = bitResult[50],
                paLeak = bitResult[51],
                e_Stop = bitResult[52],
                chiller = bitResult[53],
                polarization = bitResult[54]
            };

            Messenger.Default.Send(LvbBitResult);
        }
        private void lcbCmd(byte[] result)
        {            
            BitArray lcbCmdFlag = new BitArray(result);

            if (lcbCmdFlag[0] == true)
            {
                if (result[1] == 1)
                    Console.WriteLine("Program Reset");
            }
            if (lcbCmdFlag[1] == true)
            {
                byte[] seedStatus = result.Skip(1).Take(1).ToArray();
                BitArray seedResult = new BitArray(seedStatus);

                if (seedResult[0] == true && seedResult[1] == true && seedResult[2] == true)
                    Messenger.Default.Send("seedOn");
                else
                    Messenger.Default.Send("seedOff");
            }
            if (lcbCmdFlag[2] == true)
            {
                byte[] ampStatus = result.Skip(1).Take(2).ToArray();
                Array.Reverse(ampStatus);
                BitArray ampResult = new BitArray(ampStatus);

                if (ampResult[0] == true)
                    Messenger.Default.Send("amp1On");
                else
                    Messenger.Default.Send("amp1Off");
                if (ampResult[1] == true)
                    Messenger.Default.Send("amp2On");
                else
                    Messenger.Default.Send("amp2Off");
                if (ampResult[2] == true)
                    Messenger.Default.Send("amp3On");
                else
                    Messenger.Default.Send("amp3Off");
                if (ampResult[3] == true && ampResult[4] == true && ampResult[5] == true && ampResult[6] == true && ampResult[7] == true && ampResult[8] == true)
                    Messenger.Default.Send("amp4On");
                else
                    Messenger.Default.Send("amp4Off");

                if (ampResult[3] == true)
                    Messenger.Default.Send("amp4-1On");
                else
                    Messenger.Default.Send("amp4-1Off");
                if (ampResult[4] == true)
                    Messenger.Default.Send("amp4-2On");
                else
                    Messenger.Default.Send("amp4-2Off");
                if (ampResult[5] == true)
                    Messenger.Default.Send("amp4-3On");
                else
                    Messenger.Default.Send("amp4-3Off");
                if (ampResult[6] == true)
                    Messenger.Default.Send("amp4-4On");
                else
                    Messenger.Default.Send("amp4-4Off");
                if (ampResult[7] == true)
                    Messenger.Default.Send("amp4-5On");
                else
                    Messenger.Default.Send("amp4-5Off");
                if (ampResult[8] == true)
                    Messenger.Default.Send("amp4-6On");
                else
                    Messenger.Default.Send("amp4-6Off");
            }
        }

        private void lcbVer(byte[] result)
        {
            if (result[0] == 1)
            {
                var versionResponse = new versionResponse()
                {
                    SwVer = (int)result[1],
                    HwVer = (int)result[2],
                    DeviceId = (int)result[3]
                };

                Messenger.Default.Send(versionResponse);
            }
            
            /*Console.WriteLine((int)result[2]);
            Console.WriteLine((int)result[3]);
            Console.WriteLine((int)result[4]);
            Console.WriteLine((int)result[5]);
            Console.WriteLine((int)result[6]);
            Console.WriteLine((int)result[7]);
            Console.WriteLine((int)result[8]);
            byte[] tempByte = result.Skip(8).Take(2).ToArray();
            Array.Reverse(tempByte);
            ushort temp = BitConverter.ToUInt16(tempByte, 0);
            

            Console.WriteLine(temp);*/

        }
        private void lcbEng(byte[] result)
        {
            float[] realValue = new float[50];
            byte[] tempByte = new byte[2];
            byte[] strByte = new byte[10];

            if (result[0] == 1)
            {
                for (int i = 0; i < 42; i++)
                {
                    tempByte = result.Skip(2 * i + 1).Take(2).ToArray();
                    Array.Reverse(tempByte);
                    ushort tempValue = BitConverter.ToUInt16(tempByte, 0);
                    realValue[i] = (float)tempValue;
                }

                strByte = result.Skip(84).Take(10).ToArray();
                string polResponse = ByteToString(strByte);

                var writeSetValue = new writeSetValue()
                {
                    SeedCurrentSetValue =   realValue[0] / 100,
                    SeedTempSetValue =      realValue[1] / 100,
                    Pa1CurrentSetValue =    realValue[3] / 1000,
                    Pa2CurrentSetValue =    realValue[4] / 1000,
                    Pa3CurrentSetValue =    realValue[5] / 1000,
                    Pa4_1CurrentSetValueR1= realValue[6] / 1000,
                    Pa4_1TimeSetValueR1 =   realValue[7],
                    Pa4_1CurrentSetValueR2= realValue[8] / 1000,
                    Pa4_1TimeSetValueR2 =   realValue[9],
                    Pa4_1CurrentSetValueR3= realValue[10] / 1000,
                    Pa4_1TimeSetValueR3 =   realValue[11],
                    Pa4_2CurrentSetValueR1= realValue[12] / 1000,
                    Pa4_2TimeSetValueR1 =   realValue[13],
                    Pa4_2CurrentSetValueR2= realValue[14] / 1000,
                    Pa4_2TimeSetValueR2 =   realValue[15],
                    Pa4_2CurrentSetValueR3= realValue[16] / 1000,
                    Pa4_2TimeSetValueR3 =   realValue[17],
                    Pa4_3CurrentSetValueR1= realValue[18] / 1000,
                    Pa4_3TimeSetValueR1 =   realValue[19],
                    Pa4_3CurrentSetValueR2= realValue[20] / 1000,
                    Pa4_3TimeSetValueR2 =   realValue[21],
                    Pa4_3CurrentSetValueR3= realValue[22] / 1000,
                    Pa4_3TimeSetValueR3 =   realValue[23],
                    Pa4_4CurrentSetValueR1= realValue[24] / 1000,
                    Pa4_4TimeSetValueR1 =   realValue[25],
                    Pa4_4CurrentSetValueR2= realValue[26] / 1000,
                    Pa4_4TimeSetValueR2 =   realValue[27],
                    Pa4_4CurrentSetValueR3= realValue[28] / 1000,
                    Pa4_4TimeSetValueR3 =   realValue[29],
                    Pa4_5CurrentSetValueR1= realValue[30] / 1000,
                    Pa4_5TimeSetValueR1 =   realValue[31],
                    Pa4_5CurrentSetValueR2= realValue[32] / 1000,
                    Pa4_5TimeSetValueR2 =   realValue[33],
                    Pa4_5CurrentSetValueR3= realValue[34] / 1000,
                    Pa4_5TimeSetValueR3 =   realValue[35],
                    Pa4_6CurrentSetValueR1= realValue[36] / 1000,
                    Pa4_6TimeSetValueR1 =   realValue[37],
                    Pa4_6CurrentSetValueR2= realValue[38] / 1000,
                    Pa4_6TimeSetValueR2 =   realValue[39],
                    Pa4_6CurrentSetValueR3= realValue[40] / 1000,
                    Pa4_6TimeSetValueR3 =   realValue[41],
                    RfVxpVoltSetValue =     result[85],
                    RfVampVoltSetValue =    result[86],
                    PolResponseSet =        polResponse
                };
                Messenger.Default.Send(writeSetValue);
            }
            else if (result[0] == 2)
            {
                for (int i = 0; i < 12; i++)
                {
                    tempByte = result.Skip(2 * i + 1).Take(2).ToArray();
                    Array.Reverse(tempByte);
                    ushort tempValue = BitConverter.ToUInt16(tempByte, 0);
                    realValue[i] = (float)tempValue;                    
                }
                var writeCalValue = new writeCalValue()
                {
                    SeedCurrentCal =    (short)realValue[0],
                    SeedTempCal =       (short)realValue[1],
                    HsTempCal =         (short)realValue[2],
                    Pa1CurrentCal =     (short)realValue[3],
                    Pa2CurrentCal =     (short)realValue[4],
                    Pa3CurrentCal =     (short)realValue[5],
                    Pa4_1CurrentCal =   (short)realValue[6],
                    Pa4_2CurrentCal =   (short)realValue[7],
                    Pa4_3CurrentCal =   (short)realValue[8],
                    Pa4_4CurrentCal =   (short)realValue[9],
                    Pa4_5CurrentCal =   (short)realValue[10],
                    Pa4_6CurrentCal =   (short)realValue[11],
                    RfVxpCal =          (sbyte)result[25],
                    RfVampCal =         (sbyte)result[26],
                };
                Messenger.Default.Send(writeCalValue);
            }
            else if (result[0] == 4)
            {
                for (int i = 0; i < 41; i++)
                {
                    tempByte = result.Skip(2 * i + 1).Take(2).ToArray();
                    Array.Reverse(tempByte);
                    ushort tempValue = BitConverter.ToUInt16(tempByte, 0);
                    realValue[i] = (float)tempValue;
                }
                var readCalValue = new readCalValue()
                {
                    SeedCurrentCal =    (short)realValue[0],
                    SeedTempCal =       (short)realValue[1],
                    Pa1CurrentCal =     (short)realValue[3],
                    Pa2CurrentCal =     (short)realValue[4],
                    Pa3CurrentCal =     (short)realValue[5],
                    Pa4_1CurrentCal =   (short)realValue[6],
                    Pa4_2CurrentCal =   (short)realValue[7],
                    Pa4_3CurrentCal =   (short)realValue[8],
                    Pa4_4CurrentCal =   (short)realValue[9],
                    Pa4_5CurrentCal =   (short)realValue[10],
                    Pa4_6CurrentCal =   (short)realValue[11],
                    Pa1VoltageCal =     (short)realValue[12],
                    Pa2VoltageCal =     (short)realValue[13],
                    Pa3VoltageCal =     (short)realValue[14],
                    Pa4_1VoltageCal =   (short)realValue[15],
                    Pa4_2VoltageCal =   (short)realValue[16],
                    Pa4_3VoltageCal =   (short)realValue[17],
                    Pa4_4VoltageCal =   (short)realValue[18],
                    Pa4_5VoltageCal =   (short)realValue[19],
                    Pa4_6VoltageCal =   (short)realValue[20],
                    SeedTemp1Cal =      (short)realValue[21],
                    SeedTemp2Cal =      (short)realValue[22],
                    SeedTemp3Cal =      (short)realValue[23],
                    PaTemp1Cal =        (short)realValue[24],
                    PaTemp2Cal =        (short)realValue[25],
                    PaTemp3Cal =        (short)realValue[26],
                    PaTemp4Cal =        (short)realValue[27],
                    PaTemp5Cal =        (short)realValue[28],
                    PaTemp6Cal =        (short)realValue[29],
                    PaTemp7Cal =        (short)realValue[30],
                    PaTemp8Cal =        (short)realValue[31],
                    PaTemp9Cal =        (short)realValue[32],
                    PaTemp10Cal =       (short)realValue[33],
                    PaTemp11Cal =       (short)realValue[34],
                    PaTemp12Cal =       (short)realValue[35],
                    PaTemp13Cal =       (short)realValue[36],
                    PaTemp14Cal =       (short)realValue[37],
                    PaTemp15Cal =       (short)realValue[38],
                    PaTemp16Cal =       (short)realValue[39],
                    RfVmonCal =         (short)realValue[40],
                };
                Messenger.Default.Send(readCalValue);
            }
            else if (result[0] == 8)
            {
                for (int i = 0; i < 49; i++)
                {
                    tempByte = result.Skip(2 * i + 1).Take(2).ToArray();
                    Array.Reverse(tempByte);
                    ushort tempValue = BitConverter.ToUInt16(tempByte, 0);
                    realValue[i] = (float)tempValue;
                }

                var setHighLimit = new setHighLimit()
                {
                    SeedCurrent = realValue[0] / 100,
                    SeedTemp = realValue[1] / 1000,
                    Pa1Current = realValue[3] / 1000,
                    Pa2Current = realValue[4] / 1000,
                    Pa3Current = realValue[5] / 1000,
                    Pa4_1Current = realValue[6] / 1000,
                    Pa4_2Current = realValue[7] / 1000,
                    Pa4_3Current = realValue[8] / 1000,
                    Pa4_4Current = realValue[9] / 1000,
                    Pa4_5Current = realValue[10] / 1000,
                    Pa4_6Current = realValue[11] / 1000,
                    Pa1Voltage = realValue[12] / 1000,
                    Pa2Voltage = realValue[13] / 1000,
                    Pa3Voltage = realValue[14] / 1000,
                    Pa4_1Voltage = realValue[15] / 1000,
                    Pa4_2Voltage = realValue[16] / 1000,
                    Pa4_3Voltage = realValue[17] / 1000,
                    Pa4_4Voltage = realValue[18] / 1000,
                    Pa4_5Voltage = realValue[19] / 1000,
                    Pa4_6Voltage = realValue[20] / 1000,
                    Pd1 = realValue[21] / 100,
                    Pd2 = realValue[22] / 100,
                    Pd3 = realValue[23] / 100,
                    Pd4 = realValue[24] / 100,
                    Pd5 = realValue[25] / 100,
                    Pd6 = realValue[26] / 100,
                    Pd7 = realValue[27] / 100,
                    Pd8 = realValue[28] / 100,
                    SeedTemp1 = realValue[29] / 100,
                    SeedTemp2 = realValue[30] / 100,
                    SeedTemp3 = realValue[31] / 100,
                    PaTemp1 = realValue[32] / 100,
                    PaTemp2 = realValue[33] / 100,
                    PaTemp3 = realValue[34] / 100,
                    PaTemp4 = realValue[35] / 100,
                    PaTemp5 = realValue[36] / 100,
                    PaTemp6 = realValue[37] / 100,
                    PaTemp7 = realValue[38] / 100,
                    PaTemp8 = realValue[39] / 100,
                    PaTemp9 = realValue[40] / 100,
                    PaTemp10 = realValue[41] / 100,
                    PaTemp11 = realValue[42] / 100,
                    PaTemp12 = realValue[43] / 100,
                    PaTemp13 = realValue[44] / 100,
                    PaTemp14 = realValue[45] / 100,
                    PaTemp15 = realValue[46] / 100,
                    PaTemp16 = realValue[47] / 100,
                    RfVmon = realValue[48],
                    SeedHumid = result[99],
                    PaHumid = result[100]
                };
                Messenger.Default.Send(setHighLimit);
            
            }
            else if (result[0] == 16)
            {
                for (int i = 0; i < 49; i++)
                {
                    tempByte = result.Skip(2 * i + 1).Take(2).ToArray();
                    Array.Reverse(tempByte);
                    ushort tempValue = BitConverter.ToUInt16(tempByte, 0);
                    realValue[i] = (float)tempValue;
                }

                var setLowLimit = new setLowLimit()
                {
                    SeedCurrent = realValue[0] / 100,
                    SeedTemp = realValue[1] / 1000,
                    Pa1Current = realValue[3] / 1000,
                    Pa2Current = realValue[4] / 1000,
                    Pa3Current = realValue[5] / 1000,
                    Pa4_1Current = realValue[6] / 1000,
                    Pa4_2Current = realValue[7] / 1000,
                    Pa4_3Current = realValue[8] / 1000,
                    Pa4_4Current = realValue[9] / 1000,
                    Pa4_5Current = realValue[10] / 1000,
                    Pa4_6Current = realValue[11] / 1000,
                    Pa1Voltage = realValue[12] / 1000,
                    Pa2Voltage = realValue[13] / 1000,
                    Pa3Voltage = realValue[14] / 1000,
                    Pa4_1Voltage = realValue[15] / 1000,
                    Pa4_2Voltage = realValue[16] / 1000,
                    Pa4_3Voltage = realValue[17] / 1000,
                    Pa4_4Voltage = realValue[18] / 1000,
                    Pa4_5Voltage = realValue[19] / 1000,
                    Pa4_6Voltage = realValue[20] / 1000,
                    Pd1 = realValue[21] / 100,
                    Pd2 = realValue[22] / 100,
                    Pd3 = realValue[23] / 100,
                    Pd4 = realValue[24] / 100,
                    Pd5 = realValue[25] / 100,
                    Pd6 = realValue[26] / 100,
                    Pd7 = realValue[27] / 100,
                    Pd8 = realValue[28] / 100,
                    SeedTemp1 = realValue[29] / 100,
                    SeedTemp2 = realValue[30] / 100,
                    SeedTemp3 = realValue[31] / 100,
                    PaTemp1 = realValue[32] / 100,
                    PaTemp2 = realValue[33] / 100,
                    PaTemp3 = realValue[34] / 100,
                    PaTemp4 = realValue[35] / 100,
                    PaTemp5 = realValue[36] / 100,
                    PaTemp6 = realValue[37] / 100,
                    PaTemp7 = realValue[38] / 100,
                    PaTemp8 = realValue[39] / 100,
                    PaTemp9 = realValue[40] / 100,
                    PaTemp10 = realValue[41] / 100,
                    PaTemp11 = realValue[42] / 100,
                    PaTemp12 = realValue[43] / 100,
                    PaTemp13 = realValue[44] / 100,
                    PaTemp14 = realValue[45] / 100,
                    PaTemp15 = realValue[46] / 100,
                    PaTemp16 = realValue[47] / 100,
                    RfVmon = realValue[48],
                    SeedHumid = result[99],
                    PaHumid = result[100]
                };
                Messenger.Default.Send(setLowLimit);
            }
            else if (result[0] == 32)
            {
            }
            else if (result[0] == 64)
            {
                BitArray bitAbstract = new BitArray(result);
                byte[] bitByte = result.Skip(3).Take(1).ToArray();
                BitArray bitResult = new BitArray(bitByte);

                for (int i = 0; i < 20; i++)
                {
                    tempByte = result.Skip(2 * i + 4).Take(2).ToArray();
                    Array.Reverse(tempByte);
                    ushort tempValue = BitConverter.ToUInt16(tempByte, 0);
                    realValue[i] = (float)tempValue;
                }

                var pdCalibration = new pdCalibration()
                {
                    PdChennel = result[1],
                    TableLength = result[2],
                    Pd1Selection = bitResult[0],
                    Pd2Selection = bitResult[1],
                    Pd3Selection = bitResult[2],
                    Pd4Selection = bitResult[3],
                    Pd5Selection = bitResult[4],
                    Pd6Selection = bitResult[5],
                    Pd7Selection = bitResult[6],
                    PdAdc1 = (ushort)realValue[0],
                    PdAdc2 = (ushort)realValue[1],
                    PdAdc3 = (ushort)realValue[2],
                    PdAdc4 = (ushort)realValue[3],
                    PdAdc5 = (ushort)realValue[4],
                    PdAdc6 = (ushort)realValue[5],
                    PdAdc7 = (ushort)realValue[6],
                    PdAdc8 = (ushort)realValue[7],
                    PdAdc9 = (ushort)realValue[8],
                    PdAdc10 = (ushort)realValue[9],
                    PdLaserPower1 = realValue[10] / 100,
                    PdLaserPower2 = realValue[11] / 100,
                    PdLaserPower3 = realValue[12] / 100,
                    PdLaserPower4 = realValue[13] / 100,
                    PdLaserPower5 = realValue[14] / 100,
                    PdLaserPower6 = realValue[15] / 100,
                    PdLaserPower7 = realValue[16] / 100,
                    PdLaserPower8 = realValue[17] / 100,
                    PdLaserPower9 = realValue[18] / 100,
                    PdLaserPower10 = realValue[19] / 100,
                };
                Messenger.Default.Send(pdCalibration);
            }
            else if (result[0] == 128)
            {
                for (int i = 0; i < 42; i++)
                {
                    tempByte = result.Skip(2 * i + 1).Take(2).ToArray();
                    Array.Reverse(tempByte);
                    ushort tempValue = BitConverter.ToUInt16(tempByte, 0);
                    realValue[i] = (float)tempValue;
                }

                strByte = result.Skip(84).Take(10).ToArray();
                string polResponse = ByteToString(strByte);

                var readSetValue = new readSetValue()
                {
                    SeedCurrentReadValue = realValue[0] / 100,
                    SeedTempReadValue = realValue[1] / 100,
                    Pa1CurrentReadValue = realValue[3] / 1000,
                    Pa2CurrentReadValue = realValue[4] / 1000,
                    Pa3CurrentReadValue = realValue[5] / 1000,
                    Pa4_1CurrentReadValueR1 = realValue[6] / 1000,
                    Pa4_1TimeReadValueR1 = realValue[7],
                    Pa4_1CurrentReadValueR2 = realValue[8] / 1000,
                    Pa4_1TimeReadValueR2 = realValue[9],
                    Pa4_1CurrentReadValueR3 = realValue[10] / 1000,
                    Pa4_1TimeReadValueR3 = realValue[11],
                    Pa4_2CurrentReadValueR1 = realValue[12] / 1000,
                    Pa4_2TimeReadValueR1 = realValue[13],
                    Pa4_2CurrentReadValueR2 = realValue[14] / 1000,
                    Pa4_2TimeReadValueR2 = realValue[15],
                    Pa4_2CurrentReadValueR3 = realValue[16] / 1000,
                    Pa4_2TimeReadValueR3 = realValue[17],
                    Pa4_3CurrentReadValueR1 = realValue[18] / 1000,
                    Pa4_3TimeReadValueR1 = realValue[19],
                    Pa4_3CurrentReadValueR2 = realValue[20] / 1000,
                    Pa4_3TimeReadValueR2 = realValue[21],
                    Pa4_3CurrentReadValueR3 = realValue[22] / 1000,
                    Pa4_3TimeReadValueR3 = realValue[23],
                    Pa4_4CurrentReadValueR1 = realValue[24] / 1000,
                    Pa4_4TimeReadValueR1 = realValue[25],
                    Pa4_4CurrentReadValueR2 = realValue[26] / 1000,
                    Pa4_4TimeReadValueR2 = realValue[27],
                    Pa4_4CurrentReadValueR3 = realValue[28] / 1000,
                    Pa4_4TimeReadValueR3 = realValue[29],
                    Pa4_5CurrentReadValueR1 = realValue[30] / 1000,
                    Pa4_5TimeReadValueR1 = realValue[31],
                    Pa4_5CurrentReadValueR2 = realValue[32] / 1000,
                    Pa4_5TimeReadValueR2 = realValue[33],
                    Pa4_5CurrentReadValueR3 = realValue[34] / 1000,
                    Pa4_5TimeReadValueR3 = realValue[35],
                    Pa4_6CurrentReadValueR1 = realValue[36] / 1000,
                    Pa4_6TimeReadValueR1 = realValue[37],
                    Pa4_6CurrentReadValueR2 = realValue[38] / 1000,
                    Pa4_6TimeReadValueR2 = realValue[39],
                    Pa4_6CurrentReadValueR3 = realValue[40] / 1000,
                    Pa4_6TimeReadValueR3 = realValue[41],
                    RfVxpVoltReadValue = result[85],
                    RfVampVoltReadValue = result[86],
                    PolResponseRead = polResponse
                };
                Messenger.Default.Send(readSetValue);
            }
        }
        private void lcbMon(byte[] result)
        {
            float[] realValue = new float[50];
            byte[] tempByte = new byte[2];
            byte[] strByte = new byte[10];
            ushort tempValue;

            if (result[0] == 1)
            {
                for (int i = 0; i < 48; i++)
                {
                    tempByte = result.Skip(2 * i + 1).Take(2).ToArray();
                    Array.Reverse(tempByte);
                    tempValue = BitConverter.ToUInt16(tempByte, 0);
                    realValue[i] = (float)tempValue;
                }
                tempByte = result.Skip(98).Take(2).ToArray();
                Array.Reverse(tempByte);
                tempValue = BitConverter.ToUInt16(tempByte, 0);
                realValue[48] = (float)tempValue;
                tempByte = result.Skip(100).Take(2).ToArray();
                Array.Reverse(tempByte);
                tempValue = BitConverter.ToUInt16(tempByte, 0);
                realValue[49] = (float)tempValue;

                var monValue = new monValue()
                {
                    SeedCurrent = realValue[0] / 100,
                    SeedTemp = realValue[1] / 1000,
                    Pa1Current = realValue[3] / 1000,
                    Pa2Current = realValue[4] / 1000,
                    Pa3Current = realValue[5] / 1000,
                    Pa4_1Current = realValue[6] / 1000,
                    Pa4_2Current = realValue[7] / 1000,
                    Pa4_3Current = realValue[8] / 1000,
                    Pa4_4Current = realValue[9] / 1000,
                    Pa4_5Current = realValue[10] / 1000,
                    Pa4_6Current = realValue[11] / 1000,
                    Pa1Voltage = realValue[12] / 1000,
                    Pa2Voltage = realValue[13] / 1000,
                    Pa3Voltage = realValue[14] / 1000,
                    Pa4_1Voltage = realValue[15] / 1000,
                    Pa4_2Voltage = realValue[16] / 1000,
                    Pa4_3Voltage = realValue[17] / 1000,
                    Pa4_4Voltage = realValue[18] / 1000,
                    Pa4_5Voltage = realValue[19] / 1000,
                    Pa4_6Voltage = realValue[20] / 1000,
                    Pd1 = realValue[21] / 100,
                    Pd2 = realValue[22] / 100,
                    Pd3 = realValue[23] / 100,
                    Pd4 = realValue[24] / 100,
                    Pd5 = realValue[25] / 100,
                    Pd6 = realValue[26] / 100,
                    Pd7 = realValue[27] / 100,
                    Pd8 = realValue[28] / 100,
                    SeedTemp1 = realValue[29] / 100,
                    SeedTemp2 = realValue[30] / 100,
                    SeedTemp3 = realValue[31] / 100,
                    PaTemp1 = realValue[32] / 100,
                    PaTemp2 = realValue[33] / 100,
                    PaTemp3 = realValue[34] / 100,
                    PaTemp4 = realValue[35] / 100,
                    PaTemp5 = realValue[36] / 100,
                    PaTemp6 = realValue[37] / 100,
                    PaTemp7 = realValue[38] / 100,
                    PaTemp8 = realValue[39] / 100,
                    PaTemp9 = realValue[40] / 100,
                    PaTemp10 = realValue[41] / 100,
                    PaTemp11 = realValue[42] / 100,
                    PaTemp12 = realValue[43] / 100,
                    PaTemp13 = realValue[44] / 100,
                    PaTemp14 = realValue[45] / 100,
                    PaTemp15 = realValue[46] / 100,
                    PaTemp16 = realValue[47] / 100,
                    RfVolt = result[97],
                    SeedHumid = realValue[48] / 100,
                    PaHumid = realValue[49] / 100,
                };
                Messenger.Default.Send(monValue);
            }
            if (result[0] == 2)
            {
                BitArray bitAbstract = new BitArray(result);
                byte[] bitByte = result.Skip(1).Take(8).ToArray();
                Array.Reverse(bitByte);
                BitArray bitResult = new BitArray(bitByte);

                var warnMon = new warnMon()
                {
                    SeedTempHigh =  bitResult[0],
                    SeedTempLow =   bitResult[1],
                    SeedTemp1High = bitResult[4],
                    SeedTemp1Low =  bitResult[5],
                    SeedTemp2High = bitResult[6], 
                    SeedTemp2Low =  bitResult[7],
                    SeedTemp3High = bitResult[8],
                    SeedTemp3Low =  bitResult[9],
                    PaTemp1High =   bitResult[10],
                    PaTemp1Low =    bitResult[11],
                    PaTemp2High =   bitResult[12],
                    PaTemp2Low =    bitResult[13],
                    PaTemp3High =   bitResult[14],
                    PaTemp3Low =    bitResult[15],
                    PaTemp4High =   bitResult[16],
                    PaTemp4Low =    bitResult[17],
                    PaTemp5High =   bitResult[18],
                    PaTemp5Low =    bitResult[19],
                    PaTemp6High =   bitResult[20],
                    PaTemp6Low =    bitResult[21],
                    PaTemp7High =   bitResult[22],
                    PaTemp7Low =    bitResult[23],
                    PaTemp8High =   bitResult[24],
                    PaTemp8Low =    bitResult[25],
                    PaTemp9High =   bitResult[26],
                    PaTemp9Low =    bitResult[27],
                    PaTemp10High =  bitResult[28],
                    PaTemp10Low =   bitResult[29],
                    PaTemp11High =  bitResult[30],
                    PaTemp11Low =   bitResult[31],
                    PaTemp12High =  bitResult[32],
                    PaTemp12Low =   bitResult[33],
                    PaTemp13High =  bitResult[34],
                    PaTemp13Low =   bitResult[35],
                    PaTemp14High =  bitResult[36],
                    PaTemp14Low =   bitResult[37],
                    PaTemp15High =  bitResult[38],
                    PaTemp15Low =   bitResult[39],
                    PaTemp16High =  bitResult[40],
                    PaTemp16Low =   bitResult[41]
                };

                Messenger.Default.Send(warnMon);
            }
            if (result[0] == 4)
            {
                BitArray bitAbstract = new BitArray(result);
                byte[] bitByte = result.Skip(1).Take(8).ToArray();
                Array.Reverse(bitByte);
                BitArray bitResult = new BitArray(bitByte);

                var errorMon = new errorMon()
                {
                    SeedLdCurrentLow = bitResult[0],
                    SeedLdCurrentHigh = bitResult[1],
                    Pa1CurrentLow = bitResult[6],
                    Pa1CurrentHigh = bitResult[7],
                    Pa2CurrentLow = bitResult[8],
                    Pa2CurrentHigh = bitResult[9],
                    Pa3CurrentLow = bitResult[10],
                    Pa3CurrentHigh = bitResult[11],
                    Pa4_1CurrentLow = bitResult[12],
                    Pa4_1CurrentHigh = bitResult[13],
                    Pa4_2CurrentLow = bitResult[14],
                    Pa4_2CurrentHigh = bitResult[15],
                    Pa4_3CurrentLow = bitResult[16],
                    Pa4_3CurrentHigh = bitResult[17],
                    Pa4_4CurrentLow = bitResult[18],
                    Pa4_4CurrentHigh = bitResult[19],
                    Pa4_5CurrentLow = bitResult[20],
                    Pa4_5CurrentHigh = bitResult[21],
                    Pa4_6CurrentLow = bitResult[22],
                    Pa4_6CurrentHigh = bitResult[23],
                    Pa1VoltageLow = bitResult[24],
                    Pa1VoltageHigh = bitResult[25],
                    Pa2VoltageLow = bitResult[26],
                    Pa2VoltageHigh = bitResult[27],
                    Pa3VoltageLow = bitResult[28],
                    Pa3VoltageHigh = bitResult[29],
                    Pa4_1VoltageLow = bitResult[30],
                    Pa4_1VoltageHigh = bitResult[31],
                    Pa4_2VoltageLow = bitResult[32],
                    Pa4_2VoltageHigh = bitResult[33],
                    Pa4_3VoltageLow = bitResult[34],
                    Pa4_3VoltageHigh = bitResult[35],
                    Pa4_4VoltageLow = bitResult[36],
                    Pa4_4VoltageHigh = bitResult[37],
                    Pa4_5VoltageLow = bitResult[38],
                    Pa4_5VoltageHigh = bitResult[39],
                    Pa4_6VoltageLow = bitResult[40],
                    Pa4_6VoltageHigh = bitResult[41],
                    Pd1Low = bitResult[42],
                    Pd1High = bitResult[43],
                    Pd2Low = bitResult[44],
                    Pd2High = bitResult[45],
                    Pd3Low = bitResult[46],
                    Pd3High = bitResult[47],
                    Pd4Low = bitResult[48],
                    Pd4High = bitResult[49],
                    Pd5Low = bitResult[50],
                    Pd5High = bitResult[51],
                    Pd6Low = bitResult[52],
                    Pd6High = bitResult[53],
                    Pd7Low = bitResult[54],
                    Pd7High = bitResult[55],
                    Pd8Low = bitResult[56],
                    Pd8High = bitResult[57],
                    LeakSensor = bitResult[58],
                    E_Stop = bitResult[59],
                    Chiller = bitResult[60],
                    PaHumid = bitResult[61],
                    SeedHumid = bitResult[62]
                };

                Messenger.Default.Send(errorMon);
            }
        }

        private string ByteToString(byte[] strByte)
        {
            string str = Encoding.Default.GetString(strByte);
            return str;
        }
        #endregion
        #region dcp
        private void dcpFunc(object obj)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 10000);

            dcpClient = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.  
            dcpClient.BeginConnect(remoteEP,
                new AsyncCallback(dcpConnectCallback), dcpClient);
            connectDone.WaitOne();            
        }

        private void dcpConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();

                AsyncStateData data = new AsyncStateData();
                data.Buffer = new byte[1024];
                data.Socket = client;
                client.BeginReceive(data.Buffer, 0, data.Buffer.Length,
                SocketFlags.None, new AsyncCallback(dcpReceiveCallback), data);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("전원공급기 통신 연결 실패");
            }
        }

        private void dcpReceiveCallback(IAsyncResult asyncResult)
        {
            AsyncStateData data = (AsyncStateData)asyncResult.AsyncState;
            Socket client = data.Socket;

            AsyncStateData rcvData = asyncResult.AsyncState as AsyncStateData;
            byte[] result = rcvData.Buffer.Skip(9).ToArray();

            if (rcvData.Buffer[0] == 172 && rcvData.Buffer[1] == 19)
            {
                if (rcvData.Buffer[2] == 3 && rcvData.Buffer[3] == 1)
                {
                    if (rcvData.Buffer[4] == 1)
                    {
                        dcpBit(result);
                    }
                    else if (rcvData.Buffer[4] == 2)
                    {
                        dcpCmd(result);
                    }
                    else if (rcvData.Buffer[4] == 3)
                    {
                        dcpVer(result);
                    }
                    else if (rcvData.Buffer[4] == 5)
                    {
                        dcpMon(result);
                    }
                }
            }            

            data.Buffer = new byte[1024];
            data.Socket = client;
            client.BeginReceive(data.Buffer, 0, data.Buffer.Length,
                    SocketFlags.None, new AsyncCallback(dcpReceiveCallback), data);
        }

        private void dcpBit(byte[] result)
        {
            if (result[0] == 5 || result[0] == 6)
            {
                dcPBit = false;
            }
            else if (result[0] == 9 || result[0] == 10)
            {
                dcPBit = true;
            }
            else if (result[0] == 13 || result[0] == 14)
            {
                Console.WriteLine("수행중");
            }
            var dcPowerBit = new dcPowerBit()
            {
                DcPowerBit = dcPBit
            };
            Messenger.Default.Send(dcPowerBit);
        }

        private void dcpCmd(byte[] result)
        {
            Console.WriteLine("DCP CMD");
        }

        private void dcpVer(byte[] result)
        {
            Console.WriteLine("DCP VER");
        }

        private void dcpMon(byte[] result)
        {
            float[] realValue = new float[22];
            byte[] tempByte = new byte[2];

            if (result[0] == 1)
            {
                for (int i = 0; i < 22; i++)
                {
                    tempByte = result.Skip(2 * i + 1).Take(2).ToArray();
                    Array.Reverse(tempByte);
                    ushort tempValue = BitConverter.ToUInt16(tempByte, 0);
                    realValue[i] = (float)tempValue;
                }

                var dcpMon = new dcpMon()
                {
                    vacInputVoltage = realValue[0] / 100,
                    vacInputCurrent = realValue[1] / 100,
                    powerBoardVoltage = realValue[2] / 100,
                    powerBoardCurrent = realValue[3] / 100,
                    amp1_2Voltage = realValue[4] / 100,
                    amp1_2Current = realValue[5] / 100,
                    amp3Voltage = realValue[6] / 100,
                    amp3Current = realValue[7] / 100,
                    amp4_1Voltage = realValue[8] / 100,
                    amp4_1Current = realValue[9] / 100,
                    amp4_2Voltage = realValue[10] / 100,
                    amp4_2Current = realValue[11] / 100,
                    amp4_3Voltage = realValue[12] / 100,
                    amp4_3Current = realValue[13] / 100,
                    amp4_4Voltage = realValue[14] / 100,
                    amp4_4Current = realValue[15] / 100,
                    amp4_5Voltage = realValue[16] / 100,
                    amp4_5Current = realValue[17] / 100,
                    amp4_6Voltage = realValue[18] / 100,
                    amp4_6Current = realValue[19] / 100,
                    temp = realValue[20] / 100,
                    humidity = realValue[21] / 100
                };

                Messenger.Default.Send(dcpMon);

            }
            else if (result[0] == 2)
            {
                if (result[1] == 0 && result[2] == 0 && result[3] == 0 && result[4] == 0 && result[5] == 0 && result[6] == 0)
                {
                    dcPBit = false;
                }
                else
                {
                    dcPBit = true;
                }
                var dcPowerBit = new dcPowerBit()
                {
                    DcPowerBit = dcPBit
                };
                Messenger.Default.Send(dcPowerBit);

                BitArray bitAbstract = new BitArray(result);
                byte[] bitByte = result.Skip(1).Take(6).ToArray();
                Array.Reverse(bitByte);
                BitArray bitResult = new BitArray(bitByte);

                var dcpBit = new dcpBit()
                {
                    vacVoltHigh = bitResult[0],
                    vacVoltLow = bitResult[1],
                    vacCurrHigh = bitResult[2],
                    vacCurrLow = bitResult[3],
                    pbVoltHigh = bitResult[4],
                    pbVoltLow = bitResult[5],
                    pbCurrHigh = bitResult[6],
                    pbCurrLow = bitResult[7],
                    amp1_2VoltHigh = bitResult[8],
                    amp1_2VoltLow = bitResult[9],
                    amp1_2CurrHigh = bitResult[10],
                    amp1_2CurrLow = bitResult[11],
                    amp3VoltHigh = bitResult[12],
                    amp3VoltLow = bitResult[13],
                    amp3CurrHigh = bitResult[14],
                    amp3CurrLow = bitResult[15],
                    amp4_1VoltHigh = bitResult[16],
                    amp4_1VoltLow = bitResult[17],
                    amp4_1CurrHigh = bitResult[18],
                    amp4_1CurrLow = bitResult[19],
                    amp4_2VoltHigh = bitResult[20],
                    amp4_2VoltLow = bitResult[21],
                    amp4_2CurrHigh = bitResult[22],
                    amp4_2CurrLow = bitResult[23],
                    amp4_3VoltHigh = bitResult[24],
                    amp4_3VoltLow = bitResult[25],
                    amp4_3CurrHigh = bitResult[26],
                    amp4_3CurrLow = bitResult[27],
                    amp4_4VoltHigh = bitResult[28],
                    amp4_4VoltLow = bitResult[29],
                    amp4_4CurrHigh = bitResult[30],
                    amp4_4CurrLow = bitResult[31],
                    amp4_5VoltHigh = bitResult[32],
                    amp4_5VoltLow = bitResult[33],
                    amp4_5CurrHigh = bitResult[34],
                    amp4_5CurrLow = bitResult[35],
                    amp4_6VoltHigh = bitResult[36],
                    amp4_6VoltLow = bitResult[37],
                    amp4_6CurrHigh = bitResult[38],
                    amp4_6CurrLow = bitResult[39],
                    tempHigh = bitResult[40],
                    tempLow = bitResult[41],
                    humidityHigh = bitResult[42],
                    humidityLow = bitResult[43],
                    e_stop = bitResult[44]
                };

                Messenger.Default.Send(dcpBit);
            }
        }
        #endregion

        #region chiller
        private void chillerFunc(object obj)
        {
            IPAddress ipAddress = IPAddress.Parse("192.168.10.103");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1470);

            chillerClient = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.  
            chillerClient.BeginConnect(remoteEP,
                new AsyncCallback(chillerConnectCallback), chillerClient);
            connectDone.WaitOne();
        }

        private void chillerConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();

                AsyncStateData data = new AsyncStateData();
                data.Buffer = new byte[1024];
                data.Socket = client;
                client.BeginReceive(data.Buffer, 0, data.Buffer.Length,
                SocketFlags.None, new AsyncCallback(chillerReceiveCallback), data);

                System.Threading.Timer timer = new System.Threading.Timer(chillerCbit);
                timer.Change(0, 100);                                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("냉각기 통신 연결 실패");
            }
        }

        private void chillerReceiveCallback(IAsyncResult asyncResult)
        {
            AsyncStateData data = (AsyncStateData)asyncResult.AsyncState;
            Socket client = data.Socket;

            AsyncStateData rcvData = asyncResult.AsyncState as AsyncStateData;
            if (rcvData.Buffer[0] == 2)
            {
                if (rcvData.Buffer[1] == 48 && rcvData.Buffer[2] == 52)
                {
                    if (rcvData.Buffer[3] == 48)
                    {
                        byte[] result = rcvData.Buffer.Skip(7).Take(5).ToArray();
                        Console.WriteLine(result);
                    }
                    else if (rcvData.Buffer[3] == 49)
                    {
                        if (rcvData.Buffer[4] == 51)
                            Console.WriteLine("SET OK");
                        else if (rcvData.Buffer[4] == 52)
                            Console.WriteLine("SET FAIL");
                    }
                    else if (rcvData.Buffer[3] == 50)
                    {
                        if (rcvData.Buffer[4] == 51)
                            Console.WriteLine("SET OK");
                        else if (rcvData.Buffer[4] == 52)
                            Console.WriteLine("SET FAIL");
                    }
                    else if (rcvData.Buffer[3] == 51)
                    {
                        if (rcvData.Buffer[4] == 51)
                            Console.WriteLine("SET OK");
                        else if (rcvData.Buffer[4] == 52)
                            Console.WriteLine("SET FAIL");
                    }
                    else if (rcvData.Buffer[3] == 52)
                    {
                        if (rcvData.Buffer[4] == 51)
                            Console.WriteLine("SET OK");
                        else if (rcvData.Buffer[4] == 52)
                            Console.WriteLine("SET FAIL");
                    }
                }
                else if (rcvData.Buffer[1] == 49 && rcvData.Buffer[2] == 53)
                {
                    if (rcvData.Buffer[3] == 48)
                    {
                        byte[] result = rcvData.Buffer.Skip(7).Take(5).ToArray();

                        var chillerRcv = new chillerRcv()
                        {
                            cmd = "ch0_temp_value",
                            data = ByteToString(result)
                        };

                        Messenger.Default.Send(chillerRcv);
                    }
                    else if (rcvData.Buffer[3] == 49)
                    {
                        byte[] result = rcvData.Buffer.Skip(7).Take(5).ToArray();

                        var chillerRcv = new chillerRcv()
                        {
                            cmd = "ch1_temp_value",
                            data = ByteToString(result)
                        };

                        Messenger.Default.Send(chillerRcv);
                    }
                    else if (rcvData.Buffer[3] == 52)
                    {                        
                        if (rcvData.Buffer[4] == 51)
                            Console.WriteLine("SET OK");
                        else if (rcvData.Buffer[4] == 52)
                            Console.WriteLine("SET FAIL");

                        byte[] result = rcvData.Buffer.Skip(7).Take(1).ToArray();

                        var chillerRcv = new chillerRcv()
                        {
                            cmd = "status",
                            data = ByteToString(result)
                        };

                        Messenger.Default.Send(chillerRcv);
                    }
                    else if (rcvData.Buffer[3] == 54)
                    {
                        byte[] result = rcvData.Buffer.Skip(7).Take(5).ToArray();
                        string temp = ByteToString(result);
                        int temp2 = Int32.Parse(temp);
                        byte[] intBytes = BitConverter.GetBytes(temp2);
 
                        BitArray bitResult = new BitArray(intBytes);
                        var chillerMon = new chillerMon()
                        {
                            compOverHeat = bitResult[0],
                            overCurrent = bitResult[1],
                            pressureLow = bitResult[2],
                            pressureHigh = bitResult[3],
                            flowMeterSensor = bitResult[4],
                            flowSwitchSensor = bitResult[5],
                            flowMeterLow = bitResult[6],
                            flowSwitchLow = bitResult[7],
                            tempSensor = bitResult[8],
                            levelSensor = bitResult[9],
                            levelLow2 = bitResult[10],
                            levelLow1 = bitResult[11],
                            tempLow2 = bitResult[12],
                            tempLow1 = bitResult[13],
                            tempHigh2 = bitResult[14],
                            tempHigh1 = bitResult[15]                           
                        };

                        Messenger.Default.Send(chillerMon);                        
                    }
                    else if (rcvData.Buffer[3] == 55)
                    {
                        byte[] result = rcvData.Buffer.Skip(7).Take(5).ToArray();
                        var chillerRcv = new chillerRcv()
                        {
                            cmd = "flow_value",
                            data = ByteToString(result)
                        };

                        Messenger.Default.Send(chillerRcv);
                    }
                    else if (rcvData.Buffer[3] == 56)
                    {
                        byte[] result = rcvData.Buffer.Skip(7).Take(5).ToArray();
                        var chillerRcv = new chillerRcv()
                        {
                            cmd = "pid_value",
                            data = ByteToString(result)
                        };

                        Messenger.Default.Send(chillerRcv);
                    }
                }
            }

            data.Buffer = new byte[1024];
            data.Socket = client;
            client.BeginReceive(data.Buffer, 0, data.Buffer.Length,
                    SocketFlags.None, new AsyncCallback(chillerReceiveCallback), data);
        }

        private void OnReceiveMessageAction(chillerCmd obj)
        {
            if (obj.cmd == "run")
            {
                byte[] bytesToSend = new byte[9] { 0x02, 0x31, 0x35, 0x34, 0x32, 0x30, 0x31, 0x31, 0x03 };
                chillerClient.Send(bytesToSend);
            }

            else if (obj.cmd == "stop")
            {
                byte[] bytesToSend = new byte[9] { 0x02, 0x31, 0x35, 0x34, 0x32, 0x30, 0x31, 0x39, 0x03 };
                chillerClient.Send(bytesToSend);
            }

            else if (obj.cmd == "ch0_temp")
            {
                byte[] bytesToSend = new byte[8] { 0x02, 0x31, 0x35, 0x30, 0x30, 0x30, 0x30, 0x03 };
                chillerClient.Send(bytesToSend);
            }
            else if(obj.cmd == "ch1_temp")
            {
                byte[] bytesToSend = new byte[8] { 0x02, 0x31, 0x35, 0x31, 0x30, 0x30, 0x30, 0x03 };
                chillerClient.Send(bytesToSend);
            }
            else if (obj.cmd == "target_temp")
            {
                byte[] target_temp_byte = System.Text.Encoding.UTF8.GetBytes(obj.data);
                byte[] bytesToSend = new byte[13] { 0x02, 0x30, 0x34, 0x30, 0x32, 0x30, 0x35, target_temp_byte[0], target_temp_byte[1], target_temp_byte[2], target_temp_byte[3], target_temp_byte[4], 0x03 };
                chillerClient.Send(bytesToSend);
            }
            else if (obj.cmd == "high_temp_warn")
            {
                byte[] high_temp_warn_byte = System.Text.Encoding.UTF8.GetBytes(obj.data);
                byte[] bytesToSend = new byte[13] { 0x02, 0x30, 0x34, 0x31, 0x32, 0x30, 0x35, high_temp_warn_byte[0], high_temp_warn_byte[1], high_temp_warn_byte[2], high_temp_warn_byte[3], high_temp_warn_byte[4], 0x03 };
                chillerClient.Send(bytesToSend);
            }
            else if (obj.cmd == "high_temp_alarm")
            {
                byte[] high_temp_alarm_byte = System.Text.Encoding.UTF8.GetBytes(obj.data);
                byte[] bytesToSend = new byte[13] { 0x02, 0x30, 0x34, 0x32, 0x32, 0x30, 0x35, high_temp_alarm_byte[0], high_temp_alarm_byte[1], high_temp_alarm_byte[2], high_temp_alarm_byte[3], high_temp_alarm_byte[4], 0x03 };
                chillerClient.Send(bytesToSend);
            }
            else if (obj.cmd == "low_temp_warn")
            {
                byte[] low_temp_warn_byte = System.Text.Encoding.UTF8.GetBytes(obj.data);
                byte[] bytesToSend = new byte[13] { 0x02, 0x30, 0x34, 0x33, 0x32, 0x30, 0x35, low_temp_warn_byte[0], low_temp_warn_byte[1], low_temp_warn_byte[2], low_temp_warn_byte[3], low_temp_warn_byte[4], 0x03 };
                chillerClient.Send(bytesToSend);
            }
            else if (obj.cmd == "low_temp_alarm")
            {
                byte[] low_temp_alarm_byte = System.Text.Encoding.UTF8.GetBytes(obj.data);
                byte[] bytesToSend = new byte[13] { 0x02, 0x30, 0x34, 0x34, 0x32, 0x30, 0x35, low_temp_alarm_byte[0], low_temp_alarm_byte[1], low_temp_alarm_byte[2], low_temp_alarm_byte[3], low_temp_alarm_byte[4], 0x03 };
                chillerClient.Send(bytesToSend);
            }
        }

        private void chillerCbit(Object state)
        {
            byte[] bytesToSend = new byte[8] { 0x02, 0x31, 0x35, 0x30, 0x30, 0x30, 0x30, 0x03 };
            if (chillerCBitNum == 0)
            {
                bytesToSend = new byte[8] { 0x02, 0x31, 0x35, 0x30, 0x30, 0x30, 0x30, 0x03 };
                chillerCBitNum += 1;
            }                
            else if (chillerCBitNum == 1)
            {
                bytesToSend = new byte[8] { 0x02, 0x31, 0x35, 0x31, 0x30, 0x30, 0x30, 0x03 };
                chillerCBitNum += 1;
            }
            else if (chillerCBitNum == 2)
            {
                bytesToSend = new byte[8] { 0x02, 0x31, 0x35, 0x34, 0x30, 0x30, 0x30, 0x03 };
                chillerCBitNum += 1;
            }
            else if (chillerCBitNum == 3)
            {
                bytesToSend = new byte[8] { 0x02, 0x31, 0x35, 0x36, 0x30, 0x30, 0x30, 0x03 };
                chillerCBitNum += 1;
            }
            else if (chillerCBitNum == 4)
            {
                bytesToSend = new byte[8] { 0x02, 0x31, 0x35, 0x37, 0x30, 0x30, 0x30, 0x03 };
                chillerCBitNum = 0;
            }
            chillerClient.Send(bytesToSend);
        }
        #endregion
    }
}