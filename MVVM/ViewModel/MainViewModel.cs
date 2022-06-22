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
using System.IO;

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
        private UInt16 seqNum = 0;
        private int laserBit = 1;

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
            Messenger.Default.Register<string>(this, MessageReceived);
            Messenger.Default.Register<chillerCmd>(this, OnReceiveMessageAction);
            Messenger.Default.Register<lcb002Cmd>(this, OnReceiveMessageAction);
            Messenger.Default.Register<lcb003Cmd>(this, OnReceiveMessageAction);
            Messenger.Default.Register<lcb004writeSetCmd>(this, OnReceiveMessageAction);
            Messenger.Default.Register<lcb004ReadSetCmd>(this, OnReceiveMessageAction);
            Messenger.Default.Register<lcb004PdCalCmd>(this, OnReceiveMessageAction);
            Messenger.Default.Register<setHighLimit>(this, OnReceiveMessageAction);
            Messenger.Default.Register<setLowLimit>(this, OnReceiveMessageAction);
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
            IPAddress ipAddress = IPAddress.Parse("192.168.10.101");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 36000);

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

                System.Threading.Timer timer = new System.Threading.Timer(laserCbit);
                timer.Change(0, 500);
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

            string currentTime = DateTime.Now.ToString("MM/dd/yyyy");

            FileStream fs = new FileStream(currentTime + "_Logging" + ".csv", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

            currentTime = DateTime.Now.ToString("HH:mm:ss:fff");

            sw.Write(currentTime + "\t" + "laser" + "\t");
            for (int i = 0; i < 1024; i++)
            {
                if (rcvData.Buffer[i] == 232 && rcvData.Buffer[i-1] == 231)
                {
                    sw.WriteLine(rcvData.Buffer[i]);
                    break;
                }                    
                else
                    sw.Write(rcvData.Buffer[i] + ",");
            }
            sw.Close();
            fs.Close();

            for (int i = 0; i < 1024; i++)
            {
                if (rcvData.Buffer[i] == 172 && rcvData.Buffer[i + 1] == 19)
                {
                    if (rcvData.Buffer[i + 2] == 2 && rcvData.Buffer[i + 3] == 1)
                    {
                        byte[] result = rcvData.Buffer.Skip(i+9).ToArray();
                        if (rcvData.Buffer[i + 4] == 1)
                        {
                            lcbBit(result);
                        }
                        else if (rcvData.Buffer[i + 4] == 2)
                        {
                            lcbCmd(result);
                        }
                        else if (rcvData.Buffer[i + 4] == 3)
                        {
                            lcbVer(result);
                        }
                        else if (rcvData.Buffer[i + 4] == 4)
                        {
                            lcbEng(result);
                        }
                        else if (rcvData.Buffer[i + 4] == 5)
                        {
                            lcbMon(result);
                        }
                    }
                }
            }

            try
            {
                data.Buffer = new byte[1024];
                data.Socket = client;
                client.BeginReceive(data.Buffer, 0, data.Buffer.Length,
                        SocketFlags.None, new AsyncCallback(laserReceiveCallback), data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void lcbBit(byte[] result)
        {
            BitArray bitAbstract = new BitArray(result);
            byte[] bitByte = result.Skip(1).Take(8).ToArray();
            Array.Reverse(bitByte);
            BitArray bitResult = new BitArray(bitByte);
            bool BitStatus = false;            

            if (bitAbstract[2] == true && bitAbstract[3] == false)
            {
                if (bitAbstract[0] == true && bitAbstract[1] == false)
                {
                    Console.WriteLine("PBIT 완료");
                    laserBit = 2;
                }
                BitStatus = false;                
            }
            if (bitAbstract[2] == false && bitAbstract[3] == true)
            {
                BitStatus = true;
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
            byte[] strByte = new byte[10];
            if (result[1] == 1)
                Console.WriteLine("Program Reset");

            byte[] seedStatus = result.Skip(2).Take(1).ToArray();
            BitArray seedResult = new BitArray(seedStatus);

            if (seedResult[0] == true && seedResult[1] == true && seedResult[2] == true)
                Messenger.Default.Send("seedOn");
            else
                Messenger.Default.Send("seedOff");

            byte[] ampStatus = result.Skip(3).Take(2).ToArray();
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
            if (ampResult[3] == true || ampResult[4] == true || ampResult[5] == true || ampResult[6] == true || ampResult[7] == true || ampResult[8] == true)
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
            strByte = result.Skip(5).Take(10).ToArray();
            string polResponse = ByteToString(strByte);
            Messenger.Default.Send(polResponse);
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

                var writeSetValue = new writeSetValue()
                {
                    SeedCurrentSetValue =   realValue[0] / 100,
                    SeedTempSetValue =      realValue[1] / 1000,
                    HsTempSetValue =        realValue[2] / 100,
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
                    RfVxpVoltSetValue =     (float)result[85] / 100,
                    RfVampVoltSetValue =    (float)result[86] / 100
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
            }
            else if (result[0] == 32)
            {
                MessageBox.Show("설정 수행 결과 비정상");
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

                var readSetValue = new readSetValue()
                {
                    SeedCurrentReadValue = realValue[0] / 100,
                    SeedTempReadValue = realValue[1] / 1000,
                    HsTempReadValue = realValue[2] / 100,
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
                    RfVxpVoltReadValue = (float)result[85] / 100,
                    RfVampVoltReadValue = (float)result[86] / 100                 
                };
                Messenger.Default.Send(readSetValue);
            }
        }
        private void lcbMon(byte[] result)
        {
            float[] realValue = new float[52];
            byte[] tempByte = new byte[2];
            byte[] strByte = new byte[24];
            ushort tempValue;

            if (result[0] == 1)
            {
                for (int i = 0; i < 51; i++)
                {
                    tempByte = result.Skip(2 * i + 1).Take(2).ToArray();
                    Array.Reverse(tempByte);
                    tempValue = BitConverter.ToUInt16(tempByte, 0);
                    realValue[i] = (float)tempValue;
                }

                strByte = result.Skip(103).Take(24).ToArray();
                string polResponse = ByteToString(strByte);

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
                    RfVolt = realValue[48] / 100,
                    SeedHumid = realValue[49] / 100,
                    PaHumid = realValue[50] / 100,
                    PolRead = polResponse
                };
                Messenger.Default.Send(monValue);
            }
            if (result[0] == 2)
            {
                BitArray bitAbstract = new BitArray(result);
                byte[] bitByte = result.Skip(1).Take(6).ToArray();
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

                string currentTime = DateTime.Now.ToString("MM/dd/yyyy");

                FileStream fs = new FileStream(currentTime + "_Logging" + ".csv", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

                currentTime = DateTime.Now.ToString("HH:mm:ss:fff");

                if (bitResult[0] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "SeedTempHigh");
                if (bitResult[1] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "SeedTempLow");
                if (bitResult[4] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "SeedTemp1High");
                if (bitResult[5] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "SeedTemp1Low");
                if (bitResult[6] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "SeedTemp2High");
                if (bitResult[7] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "SeedTemp2Low");
                if (bitResult[8] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "SeedTemp3High");
                if (bitResult[9] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "SeedTemp3Low");
                if (bitResult[10] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp1High");
                if (bitResult[11] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp1Low");
                if (bitResult[12] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp2High");
                if (bitResult[13] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp2Low");
                if (bitResult[14] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp3High");
                if (bitResult[15] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp3Low");
                if (bitResult[16] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp4High");
                if (bitResult[17] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp4Low");
                if (bitResult[18] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp5High");
                if (bitResult[19] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp5Low");
                if (bitResult[20] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp6High");
                if (bitResult[21] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp6Low");
                if (bitResult[22] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp7High");
                if (bitResult[23] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp7Low");
                if (bitResult[24] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp8High");
                if (bitResult[25] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp8Low");
                if (bitResult[26] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp9High");
                if (bitResult[27] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp9Low");
                if (bitResult[28] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp10High");
                if (bitResult[29] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp10Low");
                if (bitResult[30] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp11High");
                if (bitResult[31] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp11Low");
                if (bitResult[32] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp12High");
                if (bitResult[33] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp12Low");
                if (bitResult[34] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp13High");
                if (bitResult[35] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp13Low");
                if (bitResult[36] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp14High");
                if (bitResult[37] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp14Low");
                if (bitResult[38] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp15High");
                if (bitResult[39] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp15Low");
                if (bitResult[40] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp16High");
                if (bitResult[41] == true) sw.Write(currentTime + "\t" + "wornMon" + "\t" + "PaTemp16Low");

                sw.Close();
                fs.Close();
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
                    Pa1CurrentLow = bitResult[2],
                    Pa1CurrentHigh = bitResult[3],
                    Pa2CurrentLow = bitResult[4],
                    Pa2CurrentHigh = bitResult[5],
                    Pa3CurrentLow = bitResult[6],
                    Pa3CurrentHigh = bitResult[7],
                    Pa4_1CurrentLow = bitResult[8],
                    Pa4_1CurrentHigh = bitResult[9],
                    Pa4_2CurrentLow = bitResult[10],
                    Pa4_2CurrentHigh = bitResult[11],
                    Pa4_3CurrentLow = bitResult[12],
                    Pa4_3CurrentHigh = bitResult[13],
                    Pa4_4CurrentLow = bitResult[14],
                    Pa4_4CurrentHigh = bitResult[15],
                    Pa4_5CurrentLow = bitResult[16],
                    Pa4_5CurrentHigh = bitResult[17],
                    Pa4_6CurrentLow = bitResult[18],
                    Pa4_6CurrentHigh = bitResult[19],
                    Pa1VoltageLow = bitResult[20],
                    Pa1VoltageHigh = bitResult[21],
                    Pa2VoltageLow = bitResult[22],
                    Pa2VoltageHigh = bitResult[23],
                    Pa3VoltageLow = bitResult[24],
                    Pa3VoltageHigh = bitResult[25],
                    Pa4_1VoltageLow = bitResult[26],
                    Pa4_1VoltageHigh = bitResult[27],
                    Pa4_2VoltageLow = bitResult[28],
                    Pa4_2VoltageHigh = bitResult[29],
                    Pa4_3VoltageLow = bitResult[30],
                    Pa4_3VoltageHigh = bitResult[31],
                    Pa4_4VoltageLow = bitResult[32],
                    Pa4_4VoltageHigh = bitResult[33],
                    Pa4_5VoltageLow = bitResult[34],
                    Pa4_5VoltageHigh = bitResult[35],
                    Pa4_6VoltageLow = bitResult[36],
                    Pa4_6VoltageHigh = bitResult[37],
                    Pd1Low = bitResult[38],
                    Pd1High = bitResult[39],
                    Pd2Low = bitResult[40],
                    Pd2High = bitResult[41],
                    Pd3Low = bitResult[42],
                    Pd3High = bitResult[43],
                    Pd4Low = bitResult[44],
                    Pd4High = bitResult[45],
                    Pd5Low = bitResult[46],
                    Pd5High = bitResult[47],
                    Pd6Low = bitResult[48],
                    Pd6High = bitResult[49],
                    Pd7Low = bitResult[50],
                    Pd7High = bitResult[51],
                    Pd8Low = bitResult[52],
                    Pd8High = bitResult[53],
                    LeakSensor = bitResult[54],
                    E_Stop = bitResult[55],
                    Chiller = bitResult[56],
                    PaHumid = bitResult[57],
                    SeedHumid = bitResult[58],
                    RfVMon = bitResult[59]
                };

                Messenger.Default.Send(errorMon);

                string currentTime = DateTime.Now.ToString("MM/dd/yyyy");

                FileStream fs = new FileStream(currentTime + "_Logging" + ".csv", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

                currentTime = DateTime.Now.ToString("HH:mm:ss:fff");

                if (bitResult[0] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "SeedLdCurrentLow");
                if (bitResult[1] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "SeedLdCurrentHigh");
                if (bitResult[2] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa1CurrentLow");
                if (bitResult[3] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa1CurrentHigh");
                if (bitResult[4] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa2CurrentLow");
                if (bitResult[5] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa2CurrentHigh");
                if (bitResult[6] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa3CurrentLow");
                if (bitResult[7] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa3CurrentHigh");
                if (bitResult[8] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_1CurrentLow");
                if (bitResult[9] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_1CurrentHigh");
                if (bitResult[10] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_2CurrentLow");
                if (bitResult[11] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_2CurrentHigh");
                if (bitResult[12] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_3CurrentLow");
                if (bitResult[13] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_3CurrentHigh");
                if (bitResult[14] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_4CurrentLow");
                if (bitResult[15] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_4CurrentHigh");
                if (bitResult[16] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_5CurrentLow");
                if (bitResult[17] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_5CurrentHigh");
                if (bitResult[18] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_6CurrentLow");
                if (bitResult[19] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_6CurrentHigh");
                if (bitResult[20] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa1VoltageLow");
                if (bitResult[21] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa1VoltageHigh");
                if (bitResult[22] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa2VoltageLow");
                if (bitResult[23] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa2VoltageHigh");
                if (bitResult[24] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa3VoltageLow");
                if (bitResult[25] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa3VoltageHigh");
                if (bitResult[26] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_1VoltageLow");
                if (bitResult[27] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_1VoltageHigh");
                if (bitResult[28] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_2VoltageLow");
                if (bitResult[29] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_2VoltageHigh");
                if (bitResult[30] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_3VoltageLow");
                if (bitResult[31] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_3VoltageHigh");
                if (bitResult[32] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_4VoltageLow");
                if (bitResult[33] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_4VoltageHigh");
                if (bitResult[34] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_5VoltageLow");
                if (bitResult[35] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_5VoltageHigh");
                if (bitResult[36] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_6VoltageLow");
                if (bitResult[37] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pa4_6VoltageHigh");
                if (bitResult[38] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd1Low");
                if (bitResult[39] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd1High");
                if (bitResult[40] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd2Low");
                if (bitResult[41] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd2High");
                if (bitResult[42] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd3Low");
                if (bitResult[43] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd3High");
                if (bitResult[44] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd4Low");
                if (bitResult[45] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd4High");
                if (bitResult[46] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd5Low");
                if (bitResult[47] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd5High");
                if (bitResult[48] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd6Low");
                if (bitResult[49] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd6High");
                if (bitResult[50] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd7Low");
                if (bitResult[51] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd7High");
                if (bitResult[52] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd8Low");
                if (bitResult[53] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Pd8High");
                if (bitResult[54] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "LeakSensor");
                if (bitResult[55] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "E_Stop");
                if (bitResult[56] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "Chiller");
                if (bitResult[57] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "PaHumid");
                if (bitResult[58] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "SeedHumid");
                if (bitResult[59] == true) sw.Write(currentTime + "\t" + "errorMon" + "\t" + "RfVMon");

                sw.Close();
                fs.Close();
            }
        }

        private void MessageReceived(string message)
        {            
            if (message == "save")
            {
                Console.WriteLine("save");
            }
        }

        private void OnReceiveMessageAction(lcb002Cmd obj)
        {            
            try
            {
                byte[] Ack = new byte[2] { 0xAC, 0x13 };
                byte source = 0x01;
                byte destination = 0x02;
                byte opcode = 0x02;
                byte[] dataSize = BitConverter.GetBytes((ushort)15);
                byte[] seqNumBytes = BitConverter.GetBytes(seqNum);
                byte cmdFlag = Convert.ToByte(obj.cmd);
                byte reset = Convert.ToByte(obj.reset);
                byte seedControl = Convert.ToByte(obj.seed);
                byte[] ampControl = BitConverter.GetBytes(obj.amp);
                byte[] polControl = StringToByte(obj.pol);
                byte checkSum = 0x00;
                byte[] Etx = new byte[2] { 0xE7, 0xE8 };

                checkSum = (byte)(Ack[0] + Ack[1] + source + destination + opcode + dataSize[0] + dataSize[1] + seqNumBytes[0] + seqNumBytes[1] + cmdFlag + reset + seedControl + ampControl[0] + ampControl[1]
                    + polControl[0] + polControl[1] + polControl[2] + polControl[3] + polControl[4] + polControl[5] + polControl[6] + polControl[7] + polControl[8] + polControl[9]);
                byte[] bytesToSend = new byte[27] { Ack[0], Ack[1], source, destination, opcode, dataSize[1], dataSize[0], seqNumBytes[1], seqNumBytes[0], cmdFlag, reset, seedControl, ampControl[1], ampControl[0],
                    polControl[0], polControl[1], polControl[2], polControl[3], polControl[4], polControl[5], polControl[6], polControl[7], polControl[8], polControl[9], checkSum, Etx[0], Etx[1] };
                /*for (int i = 0; i < 17; i++)
                    Console.WriteLine(bytesToSend[i]);*/
                laserClient.Send(bytesToSend);

                seqNum += 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void OnReceiveMessageAction(lcb003Cmd obj)
        {           
            try
            {
                byte[] Ack = new byte[2] { 0xAC, 0x13 };
                byte source = 0x01;
                byte destination = 0x02;
                byte opcode = 0x03;
                byte[] dataSize = BitConverter.GetBytes((ushort)2);
                byte[] seqNumBytes = BitConverter.GetBytes(seqNum);
                byte cmdFlag = 0x01;
                byte reqVer = 0x01;
                byte checkSum = 0x00;
                byte[] Etx = new byte[2] { 0xE7, 0xE8 };

                if (obj.cmd == "verReq")
                {
                    Console.WriteLine("verReq");
                    checkSum = (byte)(Ack[0] + Ack[1] + source + destination + opcode + dataSize[0] + dataSize[1] + seqNumBytes[0] + seqNumBytes[1] + cmdFlag + reqVer);
                    byte[] bytesToSend = new byte[14] { Ack[0], Ack[1], source, destination, opcode, dataSize[1], dataSize[0], seqNumBytes[1], seqNumBytes[0], cmdFlag, reqVer, checkSum, Etx[0], Etx[1] };
                    /*for (int i = 0; i < 14; i++)
                        Console.WriteLine(bytesToSend[i]);*/
                    laserClient.Send(bytesToSend);
                }
                seqNum += 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void OnReceiveMessageAction(lcb004ReadSetCmd obj)
        {
            try
            {
                byte[] Ack = new byte[2] { 0xAC, 0x13 };
                byte source = 0x01;
                byte destination = 0x02;
                byte opcode = 0x04;
                byte[] dataSize = BitConverter.GetBytes((ushort)0);
                byte[] seqNumBytes = BitConverter.GetBytes(seqNum);
                byte cmdFlag = 0x80;
                byte readSet = 0x01;
                byte checkSum = 0x00;
                byte[] Etx = new byte[2] { 0xE7, 0xE8 };

                if (obj.cmd == "readSet")
                {
                    Console.WriteLine("readSet");
                    dataSize = BitConverter.GetBytes((ushort)2);
                    checkSum = (byte)(Ack[0] + Ack[1] + source + destination + opcode + dataSize[0] + dataSize[1] + seqNumBytes[0] + seqNumBytes[1] + cmdFlag + readSet);
                    byte[] bytesToSend = new byte[14] { Ack[0], Ack[1], source, destination, opcode, dataSize[1], dataSize[0], seqNumBytes[1], seqNumBytes[0], cmdFlag, readSet, checkSum, Etx[0], Etx[1] };
                    /*for (int i = 0; i < 14; i++)
                        Console.WriteLine(bytesToSend[i]);*/
                    laserClient.Send(bytesToSend);
                }
                seqNum += 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void OnReceiveMessageAction(lcb004PdCalCmd obj)
        {
            try
            {
                byte[] Ack = new byte[2] { 0xAC, 0x13 };
                byte source = 0x01;
                byte destination = 0x02;
                byte opcode = 0x04;
                byte[] dataSize = BitConverter.GetBytes((ushort)43);
                byte[] seqNumBytes = BitConverter.GetBytes(seqNum);
                byte cmdFlag = 0x40;
                byte PdChannel = (byte)obj.PdChannel;
                byte TableLength = (byte)obj.TableLength;
                byte[] PdAdc1 = BitConverter.GetBytes((ushort)obj.PdAdc1);
                byte[] PdAdc2 = BitConverter.GetBytes((ushort)obj.PdAdc2);
                byte[] PdAdc3 = BitConverter.GetBytes((ushort)obj.PdAdc3);
                byte[] PdAdc4 = BitConverter.GetBytes((ushort)obj.PdAdc4);
                byte[] PdAdc5 = BitConverter.GetBytes((ushort)obj.PdAdc5);
                byte[] PdAdc6 = BitConverter.GetBytes((ushort)obj.PdAdc6);
                byte[] PdAdc7 = BitConverter.GetBytes((ushort)obj.PdAdc7);
                byte[] PdAdc8 = BitConverter.GetBytes((ushort)obj.PdAdc8);
                byte[] PdAdc9 = BitConverter.GetBytes((ushort)obj.PdAdc9);
                byte[] PdAdc10 = BitConverter.GetBytes((ushort)obj.PdAdc10);
                byte[] PdPower1 = BitConverter.GetBytes((ushort)(obj.PdPower1 * 100));
                byte[] PdPower2 = BitConverter.GetBytes((ushort)(obj.PdPower2 * 100));
                byte[] PdPower3 = BitConverter.GetBytes((ushort)(obj.PdPower3 * 100));
                byte[] PdPower4 = BitConverter.GetBytes((ushort)(obj.PdPower4 * 100));
                byte[] PdPower5 = BitConverter.GetBytes((ushort)(obj.PdPower5 * 100));
                byte[] PdPower6 = BitConverter.GetBytes((ushort)(obj.PdPower6 * 100));
                byte[] PdPower7 = BitConverter.GetBytes((ushort)(obj.PdPower7 * 100));
                byte[] PdPower8 = BitConverter.GetBytes((ushort)(obj.PdPower8 * 100));
                byte[] PdPower9 = BitConverter.GetBytes((ushort)(obj.PdPower9 * 100));
                byte[] PdPower10 = BitConverter.GetBytes((ushort)(obj.PdPower10 * 100)); 
                byte checkSum = (byte)(Ack[0] + Ack[1] + source + destination + opcode + dataSize[0] + dataSize[1] + seqNumBytes[0] + seqNumBytes[1] + cmdFlag + PdChannel + TableLength + PdAdc1[0] + PdAdc1[1] + PdAdc2[0] + PdAdc2[1] + PdAdc3[0] + PdAdc3[1]
                    + PdAdc4[0] + PdAdc4[1] + PdAdc5[0] + PdAdc5[1] + PdAdc6[0] + PdAdc6[1] + PdAdc7[0] + PdAdc7[1] + PdAdc8[0] + PdAdc8[1] + PdAdc9[0] + PdAdc9[1] + PdAdc10[0] + PdAdc10[1] + PdPower1[0] + PdPower1[1] + PdPower2[0] + PdPower2[1]
                     + PdPower3[0] + PdPower3[1] + PdPower4[0] + PdPower4[1] + PdPower5[0] + PdPower5[1] + PdPower6[0] + PdPower6[1] + PdPower7[0] + PdPower7[1] + PdPower8[0] + PdPower8[1] + PdPower9[0] + PdPower9[1] + PdPower10[0] + PdPower10[1]);
                byte[] Etx = new byte[2] { 0xE7, 0xE8 };
                byte[] bytesToSend = new byte[55] { Ack[0], Ack[1], source, destination, opcode, dataSize[1], dataSize[0], seqNumBytes[1], seqNumBytes[0], cmdFlag, PdChannel, TableLength, PdAdc1[1], PdAdc1[0], PdAdc2[1], PdAdc2[0], PdAdc3[1], PdAdc3[0]
                    ,PdAdc4[1], PdAdc4[0], PdAdc5[1], PdAdc5[0], PdAdc6[1], PdAdc6[0], PdAdc7[1], PdAdc7[0], PdAdc8[1], PdAdc8[0], PdAdc9[1], PdAdc9[0], PdAdc10[1], PdAdc10[0], PdPower1[1], PdPower1[0], PdPower2[1], PdPower2[0], PdPower3[1], PdPower3[0]
                    ,PdPower4[1], PdPower4[0], PdPower5[1], PdPower5[0], PdPower6[1], PdPower6[0], PdPower7[1], PdPower7[0], PdPower8[1], PdPower8[0], PdPower9[1], PdPower9[0], PdPower10[1], PdPower10[0], checkSum, Etx[0], Etx[1] };
                /*for (int i = 0; i < 55; i++)
                    Console.WriteLine(bytesToSend[i]);*/
                laserClient.Send(bytesToSend);

                seqNum += 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void OnReceiveMessageAction(lcb004writeSetCmd obj)
        {
            try
            {
                byte[] Ack = new byte[2] { 0xAC, 0x13 };
                byte source = 0x01;
                byte destination = 0x02;
                byte opcode = 0x04;
                byte[] dataSize = BitConverter.GetBytes((ushort)87);
                byte[] seqNumBytes = BitConverter.GetBytes(seqNum);
                byte cmdFlag = 0x01;
                byte[] SeedCurrentSetValue = BitConverter.GetBytes((ushort)(obj.SeedCurrentSetValue * 100));
                byte[] SeedTempSetValue = BitConverter.GetBytes((ushort)(obj.SeedTempSetValue * 1000));
                byte[] HsTempSetValue = BitConverter.GetBytes((ushort)(obj.HsTempSetValue * 100));
                byte[] Pa1CurrentSetValue = BitConverter.GetBytes((ushort)(obj.Pa1CurrentSetValue * 1000));
                byte[] Pa2CurrentSetValue = BitConverter.GetBytes((ushort)(obj.Pa2CurrentSetValue * 1000));
                byte[] Pa3CurrentSetValue = BitConverter.GetBytes((ushort)(obj.Pa3CurrentSetValue * 1000));
                byte[] Pa4_1CurrentSetValueR1 = BitConverter.GetBytes((ushort)(obj.Pa4_1CurrentSetValueR1 * 1000));
                byte[] Pa4_1TimeSetValueR1 = BitConverter.GetBytes((ushort)obj.Pa4_1TimeSetValueR1);
                byte[] Pa4_1CurrentSetValueR2 = BitConverter.GetBytes((ushort)(obj.Pa4_1CurrentSetValueR2 * 1000));
                byte[] Pa4_1TimeSetValueR2 = BitConverter.GetBytes((ushort)obj.Pa4_1TimeSetValueR2);
                byte[] Pa4_1CurrentSetValueR3 = BitConverter.GetBytes((ushort)(obj.Pa4_1CurrentSetValueR3 * 1000));
                byte[] Pa4_1TimeSetValueR3 = BitConverter.GetBytes((ushort)obj.Pa4_1TimeSetValueR3);
                byte[] Pa4_2CurrentSetValueR1 = BitConverter.GetBytes((ushort)(obj.Pa4_2CurrentSetValueR1 * 1000));
                byte[] Pa4_2TimeSetValueR1 = BitConverter.GetBytes((ushort)obj.Pa4_2TimeSetValueR1);
                byte[] Pa4_2CurrentSetValueR2 = BitConverter.GetBytes((ushort)(obj.Pa4_2CurrentSetValueR2 * 1000));
                byte[] Pa4_2TimeSetValueR2 = BitConverter.GetBytes((ushort)obj.Pa4_2TimeSetValueR2);
                byte[] Pa4_2CurrentSetValueR3 = BitConverter.GetBytes((ushort)(obj.Pa4_2CurrentSetValueR3 * 1000));
                byte[] Pa4_2TimeSetValueR3 = BitConverter.GetBytes((ushort)obj.Pa4_2TimeSetValueR3);
                byte[] Pa4_3CurrentSetValueR1 = BitConverter.GetBytes((ushort)(obj.Pa4_3CurrentSetValueR1 * 1000));
                byte[] Pa4_3TimeSetValueR1 = BitConverter.GetBytes((ushort)obj.Pa4_3TimeSetValueR1);
                byte[] Pa4_3CurrentSetValueR2 = BitConverter.GetBytes((ushort)(obj.Pa4_3CurrentSetValueR2 * 1000));
                byte[] Pa4_3TimeSetValueR2 = BitConverter.GetBytes((ushort)obj.Pa4_3TimeSetValueR2);
                byte[] Pa4_3CurrentSetValueR3 = BitConverter.GetBytes((ushort)(obj.Pa4_3CurrentSetValueR3 * 1000));
                byte[] Pa4_3TimeSetValueR3 = BitConverter.GetBytes((ushort)obj.Pa4_3TimeSetValueR3);
                byte[] Pa4_4CurrentSetValueR1 = BitConverter.GetBytes((ushort)(obj.Pa4_4CurrentSetValueR1 * 1000));
                byte[] Pa4_4TimeSetValueR1 = BitConverter.GetBytes((ushort)obj.Pa4_4TimeSetValueR1);
                byte[] Pa4_4CurrentSetValueR2 = BitConverter.GetBytes((ushort)(obj.Pa4_4CurrentSetValueR2 * 1000));
                byte[] Pa4_4TimeSetValueR2 = BitConverter.GetBytes((ushort)obj.Pa4_4TimeSetValueR2);
                byte[] Pa4_4CurrentSetValueR3 = BitConverter.GetBytes((ushort)(obj.Pa4_4CurrentSetValueR3 * 1000));
                byte[] Pa4_4TimeSetValueR3 = BitConverter.GetBytes((ushort)obj.Pa4_4TimeSetValueR3);
                byte[] Pa4_5CurrentSetValueR1 = BitConverter.GetBytes((ushort)(obj.Pa4_5CurrentSetValueR1 * 1000));
                byte[] Pa4_5TimeSetValueR1 = BitConverter.GetBytes((ushort)obj.Pa4_5TimeSetValueR1);
                byte[] Pa4_5CurrentSetValueR2 = BitConverter.GetBytes((ushort)(obj.Pa4_5CurrentSetValueR2 * 1000));
                byte[] Pa4_5TimeSetValueR2 = BitConverter.GetBytes((ushort)obj.Pa4_5TimeSetValueR2);
                byte[] Pa4_5CurrentSetValueR3 = BitConverter.GetBytes((ushort)(obj.Pa4_5CurrentSetValueR3 * 1000));
                byte[] Pa4_5TimeSetValueR3 = BitConverter.GetBytes((ushort)obj.Pa4_5TimeSetValueR3);
                byte[] Pa4_6CurrentSetValueR1 = BitConverter.GetBytes((ushort)(obj.Pa4_6CurrentSetValueR1 * 1000));
                byte[] Pa4_6TimeSetValueR1 = BitConverter.GetBytes((ushort)obj.Pa4_6TimeSetValueR1);
                byte[] Pa4_6CurrentSetValueR2 = BitConverter.GetBytes((ushort)(obj.Pa4_6CurrentSetValueR2 * 1000));
                byte[] Pa4_6TimeSetValueR2 = BitConverter.GetBytes((ushort)obj.Pa4_6TimeSetValueR2);
                byte[] Pa4_6CurrentSetValueR3 = BitConverter.GetBytes((ushort)(obj.Pa4_6CurrentSetValueR3 * 1000));
                byte[] Pa4_6TimeSetValueR3 = BitConverter.GetBytes((ushort)obj.Pa4_6TimeSetValueR3);
                byte[] RfVxpVoltSetValue = BitConverter.GetBytes((ushort)(obj.RfVxpVoltSetValue * 100));
                byte[] RfVampVoltSetValue = BitConverter.GetBytes((ushort)(obj.RfVampVoltSetValue * 100));

                byte checkSum = (byte)(Ack[0] + Ack[1] + source + destination + opcode + dataSize[0] + dataSize[1] + seqNumBytes[0] + seqNumBytes[1] + cmdFlag + SeedCurrentSetValue[0] + SeedCurrentSetValue[1] + SeedTempSetValue[0] + SeedTempSetValue[1]
                    + HsTempSetValue[0] + HsTempSetValue[1] + Pa1CurrentSetValue[0] + Pa1CurrentSetValue[1] + Pa2CurrentSetValue[0] + Pa2CurrentSetValue[1] + Pa3CurrentSetValue[0] + Pa3CurrentSetValue[1] + Pa4_1CurrentSetValueR1[0] + Pa4_1CurrentSetValueR1[1]
                    + Pa4_1TimeSetValueR1[0] + Pa4_1TimeSetValueR1[1] + Pa4_1CurrentSetValueR2[0] + Pa4_1CurrentSetValueR2[1] + Pa4_1TimeSetValueR2[0] + Pa4_1TimeSetValueR2[1] + Pa4_1CurrentSetValueR3[0] + Pa4_1CurrentSetValueR3[1] + Pa4_1TimeSetValueR3[0] 
                    + Pa4_1TimeSetValueR3[1] + Pa4_2CurrentSetValueR1[0] + Pa4_2CurrentSetValueR1[1] + Pa4_2TimeSetValueR1[0] + Pa4_2TimeSetValueR1[1] + Pa4_2CurrentSetValueR2[0] + Pa4_2CurrentSetValueR2[1] + Pa4_2TimeSetValueR2[0] + Pa4_2TimeSetValueR2[1]
                    + Pa4_2CurrentSetValueR3[0] + Pa4_2CurrentSetValueR3[1] + Pa4_2TimeSetValueR3[0] + Pa4_2TimeSetValueR3[1] + Pa4_3CurrentSetValueR1[0] + Pa4_3CurrentSetValueR1[1] + Pa4_3TimeSetValueR1[0] + Pa4_3TimeSetValueR1[1] + Pa4_3CurrentSetValueR2[0]
                    + Pa4_3CurrentSetValueR2[1] + Pa4_3TimeSetValueR2[0] + Pa4_3TimeSetValueR2[1] + Pa4_3CurrentSetValueR3[0] + Pa4_3CurrentSetValueR3[1] + Pa4_3TimeSetValueR3[0] + Pa4_3TimeSetValueR3[1] + Pa4_4CurrentSetValueR1[0] + Pa4_4CurrentSetValueR1[1]
                    + Pa4_4TimeSetValueR1[0] + Pa4_4TimeSetValueR1[1] + Pa4_4CurrentSetValueR2[0] + Pa4_4CurrentSetValueR2[1] + Pa4_4TimeSetValueR2[0] + Pa4_4TimeSetValueR2[1] + Pa4_4CurrentSetValueR3[0] + Pa4_4CurrentSetValueR3[1] + Pa4_4TimeSetValueR3[0]
                    + Pa4_4TimeSetValueR3[1] + Pa4_5CurrentSetValueR1[0] + Pa4_5CurrentSetValueR1[1] + Pa4_5TimeSetValueR1[0] + Pa4_5TimeSetValueR1[1] + Pa4_5CurrentSetValueR2[0] + Pa4_5CurrentSetValueR2[1] + Pa4_5TimeSetValueR2[0] + Pa4_5TimeSetValueR2[1]
                    + Pa4_5CurrentSetValueR3[0] + Pa4_5CurrentSetValueR3[1] + Pa4_5TimeSetValueR3[0] + Pa4_5TimeSetValueR3[1] + Pa4_6CurrentSetValueR1[0] + Pa4_6CurrentSetValueR1[1] + Pa4_6TimeSetValueR1[0] + Pa4_6TimeSetValueR1[1] + Pa4_6CurrentSetValueR2[0]
                    + Pa4_6CurrentSetValueR2[1] + Pa4_6TimeSetValueR2[0] + Pa4_6TimeSetValueR2[1] + Pa4_6CurrentSetValueR3[0] + Pa4_6CurrentSetValueR3[1] + Pa4_6TimeSetValueR3[0] + Pa4_6TimeSetValueR3[1] + RfVxpVoltSetValue[0] + RfVampVoltSetValue[0]);
                Console.WriteLine(checkSum);
                byte[] Etx = new byte[2] { 0xE7, 0xE8 };
                byte[] bytesToSend = new byte[99] { Ack[0], Ack[1], source, destination, opcode, dataSize[1], dataSize[0], seqNumBytes[1], seqNumBytes[0], cmdFlag, SeedCurrentSetValue[1], SeedCurrentSetValue[0], SeedTempSetValue[1], SeedTempSetValue[0]
                    ,HsTempSetValue[1], HsTempSetValue[0], Pa1CurrentSetValue[1], Pa1CurrentSetValue[0], Pa2CurrentSetValue[1], Pa2CurrentSetValue[0], Pa3CurrentSetValue[1], Pa3CurrentSetValue[0], Pa4_1CurrentSetValueR1[1], Pa4_1CurrentSetValueR1[0]
                    ,Pa4_1TimeSetValueR1[1], Pa4_1TimeSetValueR1[0], Pa4_1CurrentSetValueR2[1], Pa4_1CurrentSetValueR2[0], Pa4_1TimeSetValueR2[1], Pa4_1TimeSetValueR2[0], Pa4_1CurrentSetValueR3[1], Pa4_1CurrentSetValueR3[0], Pa4_1TimeSetValueR3[1]
                    ,Pa4_1TimeSetValueR3[0], Pa4_2CurrentSetValueR1[1], Pa4_2CurrentSetValueR1[0], Pa4_2TimeSetValueR1[1], Pa4_2TimeSetValueR1[0], Pa4_2CurrentSetValueR2[1], Pa4_2CurrentSetValueR2[0], Pa4_2TimeSetValueR2[1], Pa4_2TimeSetValueR2[0]
                    ,Pa4_2CurrentSetValueR3[1], Pa4_2CurrentSetValueR3[0], Pa4_2TimeSetValueR3[1], Pa4_2TimeSetValueR3[0], Pa4_3CurrentSetValueR1[1], Pa4_3CurrentSetValueR1[0], Pa4_3TimeSetValueR1[1], Pa4_3TimeSetValueR1[0], Pa4_3CurrentSetValueR2[1]
                    ,Pa4_3CurrentSetValueR2[0], Pa4_3TimeSetValueR2[1], Pa4_3TimeSetValueR2[0], Pa4_3CurrentSetValueR3[1], Pa4_3CurrentSetValueR3[0], Pa4_3TimeSetValueR3[1], Pa4_3TimeSetValueR3[0], Pa4_4CurrentSetValueR1[1], Pa4_4CurrentSetValueR1[0]
                    ,Pa4_4TimeSetValueR1[1], Pa4_4TimeSetValueR1[0], Pa4_4CurrentSetValueR2[1], Pa4_4CurrentSetValueR2[0], Pa4_4TimeSetValueR2[1], Pa4_4TimeSetValueR2[0], Pa4_4CurrentSetValueR3[1], Pa4_4CurrentSetValueR3[0], Pa4_4TimeSetValueR3[1]
                    ,Pa4_4TimeSetValueR3[0], Pa4_5CurrentSetValueR1[1], Pa4_5CurrentSetValueR1[0], Pa4_5TimeSetValueR1[1], Pa4_5TimeSetValueR1[0], Pa4_5CurrentSetValueR2[1], Pa4_5CurrentSetValueR2[0], Pa4_5TimeSetValueR2[1], Pa4_5TimeSetValueR2[0]
                    ,Pa4_5CurrentSetValueR3[1], Pa4_5CurrentSetValueR3[0], Pa4_5TimeSetValueR3[1], Pa4_5TimeSetValueR3[0], Pa4_6CurrentSetValueR1[1], Pa4_6CurrentSetValueR1[0], Pa4_6TimeSetValueR1[1], Pa4_6TimeSetValueR1[0], Pa4_6CurrentSetValueR2[1]
                    ,Pa4_6CurrentSetValueR2[0], Pa4_6TimeSetValueR2[1], Pa4_6TimeSetValueR2[0], Pa4_6CurrentSetValueR3[1], Pa4_6CurrentSetValueR3[0], Pa4_6TimeSetValueR3[1], Pa4_6TimeSetValueR3[0], RfVxpVoltSetValue[0], RfVampVoltSetValue[0]
                    ,checkSum, Etx[0], Etx[1] };
                /*for (int i = 0; i < 109; i++)
                    Console.WriteLine(bytesToSend[i]);*/
                laserClient.Send(bytesToSend);

                seqNum += 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        private void OnReceiveMessageAction(setHighLimit obj)
        {
            try
            {
                byte[] Ack = new byte[2] { 0xAC, 0x13 };
                byte source = 0x01;
                byte destination = 0x02;
                byte opcode = 0x04;
                byte[] dataSize = BitConverter.GetBytes((ushort)101);
                byte[] seqNumBytes = BitConverter.GetBytes(seqNum);
                byte cmdFlag = 0x08;

                byte[] SeedCurrent = BitConverter.GetBytes((ushort)(obj.SeedCurrent * 100));
                byte[] SeedTemp = BitConverter.GetBytes((ushort)(obj.SeedTemp * 1000));
                byte[] Pa1Current = BitConverter.GetBytes((ushort)(obj.Pa1Current * 1000));
                byte[] Pa2Current = BitConverter.GetBytes((ushort)(obj.Pa2Current * 1000));
                byte[] Pa3Current = BitConverter.GetBytes((ushort)(obj.Pa3Current * 1000));
                byte[] Pa4_1Current = BitConverter.GetBytes((ushort)(obj.Pa4_1Current * 1000));
                byte[] Pa4_2Current = BitConverter.GetBytes((ushort)(obj.Pa4_2Current * 1000));
                byte[] Pa4_3Current = BitConverter.GetBytes((ushort)(obj.Pa4_3Current * 1000));
                byte[] Pa4_4Current = BitConverter.GetBytes((ushort)(obj.Pa4_4Current * 1000));
                byte[] Pa4_5Current = BitConverter.GetBytes((ushort)(obj.Pa4_5Current * 1000));
                byte[] Pa4_6Current = BitConverter.GetBytes((ushort)(obj.Pa4_6Current * 1000));
                byte[] Pa1Voltage = BitConverter.GetBytes((ushort)(obj.Pa1Voltage * 1000));
                byte[] Pa2Voltage = BitConverter.GetBytes((ushort)(obj.Pa2Voltage * 1000));
                byte[] Pa3Voltage = BitConverter.GetBytes((ushort)(obj.Pa3Voltage * 1000));
                byte[] Pa4_1Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_1Voltage * 1000));
                byte[] Pa4_2Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_2Voltage * 1000));
                byte[] Pa4_3Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_3Voltage * 1000));
                byte[] Pa4_4Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_4Voltage * 1000));
                byte[] Pa4_5Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_5Voltage * 1000));
                byte[] Pa4_6Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_6Voltage * 1000));
                byte[] Pd1 = BitConverter.GetBytes((ushort)(obj.Pd1 * 100));
                byte[] Pd2 = BitConverter.GetBytes((ushort)(obj.Pd2 * 100));
                byte[] Pd3 = BitConverter.GetBytes((ushort)(obj.Pd3 * 100));
                byte[] Pd4 = BitConverter.GetBytes((ushort)(obj.Pd4 * 100));
                byte[] Pd5 = BitConverter.GetBytes((ushort)(obj.Pd5 * 100));
                byte[] Pd6 = BitConverter.GetBytes((ushort)(obj.Pd6 * 100));
                byte[] Pd7 = BitConverter.GetBytes((ushort)(obj.Pd7 * 100));
                byte[] Pd8 = BitConverter.GetBytes((ushort)(obj.Pd8 * 100));
                byte[] SeedTemp1 = BitConverter.GetBytes((ushort)(obj.SeedTemp1 * 100));
                byte[] SeedTemp2 = BitConverter.GetBytes((ushort)(obj.SeedTemp2 * 100));
                byte[] SeedTemp3 = BitConverter.GetBytes((ushort)(obj.SeedTemp3 * 100));
                byte[] PaTemp1 = BitConverter.GetBytes((ushort)(obj.PaTemp1 * 100));
                byte[] PaTemp2 = BitConverter.GetBytes((ushort)(obj.PaTemp2 * 100));
                byte[] PaTemp3 = BitConverter.GetBytes((ushort)(obj.PaTemp3 * 100));
                byte[] PaTemp4 = BitConverter.GetBytes((ushort)(obj.PaTemp4 * 100));
                byte[] PaTemp5 = BitConverter.GetBytes((ushort)(obj.PaTemp5 * 100));
                byte[] PaTemp6 = BitConverter.GetBytes((ushort)(obj.PaTemp6 * 100));
                byte[] PaTemp7 = BitConverter.GetBytes((ushort)(obj.PaTemp7 * 100));
                byte[] PaTemp8 = BitConverter.GetBytes((ushort)(obj.PaTemp8 * 100));
                byte[] PaTemp9 = BitConverter.GetBytes((ushort)(obj.PaTemp9 * 100));
                byte[] PaTemp10 = BitConverter.GetBytes((ushort)(obj.PaTemp10 * 100));
                byte[] PaTemp11 = BitConverter.GetBytes((ushort)(obj.PaTemp11 * 100));
                byte[] PaTemp12 = BitConverter.GetBytes((ushort)(obj.PaTemp12 * 100));
                byte[] PaTemp13 = BitConverter.GetBytes((ushort)(obj.PaTemp13 * 100));
                byte[] PaTemp14 = BitConverter.GetBytes((ushort)(obj.PaTemp14 * 100));
                byte[] PaTemp15 = BitConverter.GetBytes((ushort)(obj.PaTemp15 * 100));
                byte[] PaTemp16 = BitConverter.GetBytes((ushort)(obj.PaTemp16 * 100));
                byte[] RfVmon = BitConverter.GetBytes((ushort)obj.RfVmon);
                byte SeedHumid = (byte)obj.SeedHumid;
                byte PaHumid = (byte)obj.PaHumid;

                byte checkSum = (byte)(Ack[0] + Ack[1] + source + destination + opcode + dataSize[0] + dataSize[1] + seqNumBytes[0] + seqNumBytes[1] + cmdFlag + SeedCurrent[0] + SeedCurrent[1] + SeedTemp[0] + SeedTemp[1]
                    + Pa1Current[0] + Pa1Current[1] + Pa2Current[0] + Pa2Current[1] + Pa3Current[0] + Pa3Current[1] + Pa4_1Current[0] + Pa4_1Current[1] + Pa4_2Current[0] + Pa4_2Current[1] + Pa4_3Current[0] + Pa4_3Current[1]
                    + Pa4_4Current[0] + Pa4_4Current[1] + Pa4_5Current[0] + Pa4_5Current[1] + Pa4_6Current[0] + Pa4_6Current[1] + Pa1Voltage[0] + Pa1Voltage[1] + Pa2Voltage[0] + Pa2Voltage[1] + Pa3Voltage[0] + Pa3Voltage[1]
                    + Pa4_1Voltage[0] + Pa4_1Voltage[1] + Pa4_2Voltage[0] + Pa4_2Voltage[1] + Pa4_3Voltage[0] + Pa4_3Voltage[1] + Pa4_4Voltage[0] + Pa4_4Voltage[1] + Pa4_5Voltage[0] + Pa4_5Voltage[1] + Pa4_6Voltage[0] + Pa4_6Voltage[1] 
                    + Pd1[0] + Pd1[1] + Pd2[0] + Pd2[1] + Pd3[0] + Pd3[1] + Pd4[0] + Pd4[1] + Pd5[0] + Pd5[1] + Pd6[0] + Pd6[1] + Pd7[0] + Pd7[1] + Pd8[0] + Pd8[1] + SeedTemp1[0] + SeedTemp1[1] + SeedTemp2[0] + SeedTemp2[1]
                    + SeedTemp3[0] + SeedTemp3[1] + PaTemp1[0] + PaTemp1[1] + PaTemp2[0] + PaTemp2[1] + PaTemp3[0] + PaTemp3[1] + PaTemp4[0] + PaTemp4[1] + PaTemp5[0] + PaTemp5[1] + PaTemp6[0] + PaTemp6[1] + PaTemp7[0] + PaTemp7[1] 
                    + PaTemp8[0] + PaTemp8[1] + PaTemp9[0] + PaTemp9[1] + PaTemp10[0] + PaTemp10[1] + PaTemp11[0] + PaTemp11[1] + PaTemp12[0] + PaTemp12[1] + PaTemp13[0] + PaTemp13[1] + PaTemp14[0] + PaTemp14[1] + PaTemp15[0] + PaTemp15[1]
                    + PaTemp16[0] + PaTemp16[1] + RfVmon[0] + RfVmon[1] + SeedHumid + PaHumid);
                byte[] Etx = new byte[2] { 0xE7, 0xE8 };
                byte[] bytesToSend = new byte[113] { Ack[0], Ack[1], source, destination, opcode, dataSize[1], dataSize[0], seqNumBytes[1], seqNumBytes[0], cmdFlag, SeedCurrent[1] , SeedCurrent[0] , SeedTemp[1] , SeedTemp[0], 0x00, 0x00
                    , Pa1Current[1] , Pa1Current[0] , Pa2Current[1] , Pa2Current[0] , Pa3Current[1] , Pa3Current[0] , Pa4_1Current[1] , Pa4_1Current[0] , Pa4_2Current[1] , Pa4_2Current[0] , Pa4_3Current[1] , Pa4_3Current[0]
                    , Pa4_4Current[1] , Pa4_4Current[0] , Pa4_5Current[1] , Pa4_5Current[0] , Pa4_6Current[1] , Pa4_6Current[0] , Pa1Voltage[1] , Pa1Voltage[0] , Pa2Voltage[1] , Pa2Voltage[0] , Pa3Voltage[1] , Pa3Voltage[0]
                    , Pa4_1Voltage[1] , Pa4_1Voltage[0] , Pa4_2Voltage[1] , Pa4_2Voltage[0] , Pa4_3Voltage[1] , Pa4_3Voltage[0] , Pa4_4Voltage[1] , Pa4_4Voltage[0] , Pa4_5Voltage[1] , Pa4_5Voltage[0] , Pa4_6Voltage[1] , Pa4_6Voltage[0] 
                    , Pd1[1] , Pd1[0] , Pd2[1] , Pd2[0] , Pd3[1] , Pd3[0] , Pd4[1] , Pd4[0] , Pd5[1] , Pd5[0] , Pd6[1] , Pd6[0] , Pd7[1] , Pd7[0] , Pd8[1] , Pd8[0] , SeedTemp1[1] , SeedTemp1[0] , SeedTemp2[1] , SeedTemp2[0]
                    , SeedTemp3[1] , SeedTemp3[0] , PaTemp1[1] , PaTemp1[0] , PaTemp2[1] , PaTemp2[0] , PaTemp3[1] , PaTemp3[0] , PaTemp4[1] , PaTemp4[0] , PaTemp5[1] , PaTemp5[0] , PaTemp6[1] , PaTemp6[0] , PaTemp7[1] , PaTemp7[0] 
                    , PaTemp8[1] , PaTemp8[0] , PaTemp9[1] , PaTemp9[0] , PaTemp10[1] , PaTemp10[0] , PaTemp11[1] , PaTemp11[0] , PaTemp12[1] , PaTemp12[0] , PaTemp13[1] , PaTemp13[0] , PaTemp14[1] , PaTemp14[0] , PaTemp15[1] , PaTemp15[0]
                    , PaTemp16[1] , PaTemp16[0] , RfVmon[1] , RfVmon[0] , SeedHumid , PaHumid, checkSum, Etx[0], Etx[1] };
                /*for (int i = 0; i < 109; i++)
                    Console.WriteLine(bytesToSend[i]);*/
                laserClient.Send(bytesToSend);

                seqNum += 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void OnReceiveMessageAction(setLowLimit obj)
        {
            try
            {
                byte[] Ack = new byte[2] { 0xAC, 0x13 };
                byte source = 0x01;
                byte destination = 0x02;
                byte opcode = 0x04;
                byte[] dataSize = BitConverter.GetBytes((ushort)101);
                byte[] seqNumBytes = BitConverter.GetBytes(seqNum);
                byte cmdFlag = 0x10;

                byte[] SeedCurrent = BitConverter.GetBytes((ushort)(obj.SeedCurrent * 100));
                byte[] SeedTemp = BitConverter.GetBytes((ushort)(obj.SeedTemp * 1000));
                byte[] Pa1Current = BitConverter.GetBytes((ushort)(obj.Pa1Current * 1000));
                byte[] Pa2Current = BitConverter.GetBytes((ushort)(obj.Pa2Current * 1000));
                byte[] Pa3Current = BitConverter.GetBytes((ushort)(obj.Pa3Current * 1000));
                byte[] Pa4_1Current = BitConverter.GetBytes((ushort)(obj.Pa4_1Current * 1000));
                byte[] Pa4_2Current = BitConverter.GetBytes((ushort)(obj.Pa4_2Current * 1000));
                byte[] Pa4_3Current = BitConverter.GetBytes((ushort)(obj.Pa4_3Current * 1000));
                byte[] Pa4_4Current = BitConverter.GetBytes((ushort)(obj.Pa4_4Current * 1000));
                byte[] Pa4_5Current = BitConverter.GetBytes((ushort)(obj.Pa4_5Current * 1000));
                byte[] Pa4_6Current = BitConverter.GetBytes((ushort)(obj.Pa4_6Current * 1000));
                byte[] Pa1Voltage = BitConverter.GetBytes((ushort)(obj.Pa1Voltage * 1000));
                byte[] Pa2Voltage = BitConverter.GetBytes((ushort)(obj.Pa2Voltage * 1000));
                byte[] Pa3Voltage = BitConverter.GetBytes((ushort)(obj.Pa3Voltage * 1000));
                byte[] Pa4_1Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_1Voltage * 1000));
                byte[] Pa4_2Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_2Voltage * 1000));
                byte[] Pa4_3Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_3Voltage * 1000));
                byte[] Pa4_4Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_4Voltage * 1000));
                byte[] Pa4_5Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_5Voltage * 1000));
                byte[] Pa4_6Voltage = BitConverter.GetBytes((ushort)(obj.Pa4_6Voltage * 1000));
                byte[] Pd1 = BitConverter.GetBytes((ushort)(obj.Pd1 * 100));
                byte[] Pd2 = BitConverter.GetBytes((ushort)(obj.Pd2 * 100));
                byte[] Pd3 = BitConverter.GetBytes((ushort)(obj.Pd3 * 100));
                byte[] Pd4 = BitConverter.GetBytes((ushort)(obj.Pd4 * 100));
                byte[] Pd5 = BitConverter.GetBytes((ushort)(obj.Pd5 * 100));
                byte[] Pd6 = BitConverter.GetBytes((ushort)(obj.Pd6 * 100));
                byte[] Pd7 = BitConverter.GetBytes((ushort)(obj.Pd7 * 100));
                byte[] Pd8 = BitConverter.GetBytes((ushort)(obj.Pd8 * 100));
                byte[] SeedTemp1 = BitConverter.GetBytes((ushort)(obj.SeedTemp1 * 100));
                byte[] SeedTemp2 = BitConverter.GetBytes((ushort)(obj.SeedTemp2 * 100));
                byte[] SeedTemp3 = BitConverter.GetBytes((ushort)(obj.SeedTemp3 * 100));
                byte[] PaTemp1 = BitConverter.GetBytes((ushort)(obj.PaTemp1 * 100));
                byte[] PaTemp2 = BitConverter.GetBytes((ushort)(obj.PaTemp2 * 100));
                byte[] PaTemp3 = BitConverter.GetBytes((ushort)(obj.PaTemp3 * 100));
                byte[] PaTemp4 = BitConverter.GetBytes((ushort)(obj.PaTemp4 * 100));
                byte[] PaTemp5 = BitConverter.GetBytes((ushort)(obj.PaTemp5 * 100));
                byte[] PaTemp6 = BitConverter.GetBytes((ushort)(obj.PaTemp6 * 100));
                byte[] PaTemp7 = BitConverter.GetBytes((ushort)(obj.PaTemp7 * 100));
                byte[] PaTemp8 = BitConverter.GetBytes((ushort)(obj.PaTemp8 * 100));
                byte[] PaTemp9 = BitConverter.GetBytes((ushort)(obj.PaTemp9 * 100));
                byte[] PaTemp10 = BitConverter.GetBytes((ushort)(obj.PaTemp10 * 100));
                byte[] PaTemp11 = BitConverter.GetBytes((ushort)(obj.PaTemp11 * 100));
                byte[] PaTemp12 = BitConverter.GetBytes((ushort)(obj.PaTemp12 * 100));
                byte[] PaTemp13 = BitConverter.GetBytes((ushort)(obj.PaTemp13 * 100));
                byte[] PaTemp14 = BitConverter.GetBytes((ushort)(obj.PaTemp14 * 100));
                byte[] PaTemp15 = BitConverter.GetBytes((ushort)(obj.PaTemp15 * 100));
                byte[] PaTemp16 = BitConverter.GetBytes((ushort)(obj.PaTemp16 * 100));
                byte[] RfVmon = BitConverter.GetBytes((ushort)obj.RfVmon);
                byte SeedHumid = (byte)obj.SeedHumid;
                byte PaHumid = (byte)obj.PaHumid;

                byte checkSum = (byte)(Ack[0] + Ack[1] + source + destination + opcode + dataSize[0] + dataSize[1] + seqNumBytes[0] + seqNumBytes[1] + cmdFlag + SeedCurrent[0] + SeedCurrent[1] + SeedTemp[0] + SeedTemp[1]
                    + Pa1Current[0] + Pa1Current[1] + Pa2Current[0] + Pa2Current[1] + Pa3Current[0] + Pa3Current[1] + Pa4_1Current[0] + Pa4_1Current[1] + Pa4_2Current[0] + Pa4_2Current[1] + Pa4_3Current[0] + Pa4_3Current[1]
                    + Pa4_4Current[0] + Pa4_4Current[1] + Pa4_5Current[0] + Pa4_5Current[1] + Pa4_6Current[0] + Pa4_6Current[1] + Pa1Voltage[0] + Pa1Voltage[1] + Pa2Voltage[0] + Pa2Voltage[1] + Pa3Voltage[0] + Pa3Voltage[1]
                    + Pa4_1Voltage[0] + Pa4_1Voltage[1] + Pa4_2Voltage[0] + Pa4_2Voltage[1] + Pa4_3Voltage[0] + Pa4_3Voltage[1] + Pa4_4Voltage[0] + Pa4_4Voltage[1] + Pa4_5Voltage[0] + Pa4_5Voltage[1] + Pa4_6Voltage[0] + Pa4_6Voltage[1]
                    + Pd1[0] + Pd1[1] + Pd2[0] + Pd2[1] + Pd3[0] + Pd3[1] + Pd4[0] + Pd4[1] + Pd5[0] + Pd5[1] + Pd6[0] + Pd6[1] + Pd7[0] + Pd7[1] + Pd8[0] + Pd8[1] + SeedTemp1[0] + SeedTemp1[1] + SeedTemp2[0] + SeedTemp2[1]
                    + SeedTemp3[0] + SeedTemp3[1] + PaTemp1[0] + PaTemp1[1] + PaTemp2[0] + PaTemp2[1] + PaTemp3[0] + PaTemp3[1] + PaTemp4[0] + PaTemp4[1] + PaTemp5[0] + PaTemp5[1] + PaTemp6[0] + PaTemp6[1] + PaTemp7[0] + PaTemp7[1]
                    + PaTemp8[0] + PaTemp8[1] + PaTemp9[0] + PaTemp9[1] + PaTemp10[0] + PaTemp10[1] + PaTemp11[0] + PaTemp11[1] + PaTemp12[0] + PaTemp12[1] + PaTemp13[0] + PaTemp13[1] + PaTemp14[0] + PaTemp14[1] + PaTemp15[0] + PaTemp15[1]
                    + PaTemp16[0] + PaTemp16[1] + RfVmon[0] + RfVmon[1] + SeedHumid + PaHumid);
                byte[] Etx = new byte[2] { 0xE7, 0xE8 };
                byte[] bytesToSend = new byte[113] { Ack[0], Ack[1], source, destination, opcode, dataSize[1], dataSize[0], seqNumBytes[1], seqNumBytes[0], cmdFlag, SeedCurrent[1] , SeedCurrent[0] , SeedTemp[1] , SeedTemp[0], 0x00, 0x00
                    , Pa1Current[1] , Pa1Current[0] , Pa2Current[1] , Pa2Current[0] , Pa3Current[1] , Pa3Current[0] , Pa4_1Current[1] , Pa4_1Current[0] , Pa4_2Current[1] , Pa4_2Current[0] , Pa4_3Current[1] , Pa4_3Current[0]
                    , Pa4_4Current[1] , Pa4_4Current[0] , Pa4_5Current[1] , Pa4_5Current[0] , Pa4_6Current[1] , Pa4_6Current[0] , Pa1Voltage[1] , Pa1Voltage[0] , Pa2Voltage[1] , Pa2Voltage[0] , Pa3Voltage[1] , Pa3Voltage[0]
                    , Pa4_1Voltage[1] , Pa4_1Voltage[0] , Pa4_2Voltage[1] , Pa4_2Voltage[0] , Pa4_3Voltage[1] , Pa4_3Voltage[0] , Pa4_4Voltage[1] , Pa4_4Voltage[0] , Pa4_5Voltage[1] , Pa4_5Voltage[0] , Pa4_6Voltage[1] , Pa4_6Voltage[0]
                    , Pd1[1] , Pd1[0] , Pd2[1] , Pd2[0] , Pd3[1] , Pd3[0] , Pd4[1] , Pd4[0] , Pd5[1] , Pd5[0] , Pd6[1] , Pd6[0] , Pd7[1] , Pd7[0] , Pd8[1] , Pd8[0] , SeedTemp1[1] , SeedTemp1[0] , SeedTemp2[1] , SeedTemp2[0]
                    , SeedTemp3[1] , SeedTemp3[0] , PaTemp1[1] , PaTemp1[0] , PaTemp2[1] , PaTemp2[0] , PaTemp3[1] , PaTemp3[0] , PaTemp4[1] , PaTemp4[0] , PaTemp5[1] , PaTemp5[0] , PaTemp6[1] , PaTemp6[0] , PaTemp7[1] , PaTemp7[0]
                    , PaTemp8[1] , PaTemp8[0] , PaTemp9[1] , PaTemp9[0] , PaTemp10[1] , PaTemp10[0] , PaTemp11[1] , PaTemp11[0] , PaTemp12[1] , PaTemp12[0] , PaTemp13[1] , PaTemp13[0] , PaTemp14[1] , PaTemp14[0] , PaTemp15[1] , PaTemp15[0]
                    , PaTemp16[1] , PaTemp16[0] , RfVmon[1] , RfVmon[0] , SeedHumid , PaHumid, checkSum, Etx[0], Etx[1] };
                /*for (int i = 0; i < 109; i++)
                    Console.WriteLine(bytesToSend[i]);*/
                laserClient.Send(bytesToSend);

                seqNum += 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void laserCbit(Object state)
        {
            try
            {
                byte[] Ack = new byte[2] { 0xAC, 0x13 };
                byte source = 0x01;
                byte destination = 0x02;
                byte opcode = 0x01;
                byte[] dataSize = BitConverter.GetBytes((ushort)1);
                byte[] seqNumBytes = BitConverter.GetBytes(seqNum);
                byte reqBit = (byte)laserBit;

                byte checkSum = (byte)(Ack[0] + Ack[1] + source + destination + opcode + dataSize[1] + dataSize[0] + seqNumBytes[1] + seqNumBytes[0] + reqBit);
                byte[] Etx = new byte[2] { 0xE7, 0xE8 };
                byte[] bytesToSend = new byte[13] { Ack[0], Ack[1], source, destination, opcode, dataSize[1], dataSize[0], seqNumBytes[1], seqNumBytes[0], reqBit, checkSum, Etx[0], Etx[1] };
                /*for (int i = 0; i < 109; i++)
                    Console.WriteLine(bytesToSend[i]);*/
                //laserClient.Send(bytesToSend);

                seqNum += 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private string ByteToString(byte[] strByte)
        {
            string str = Encoding.Default.GetString(strByte);
            return str;
        }
        private byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }

        #endregion
        #region dcp
        private void dcpFunc(object obj)
        {
            IPAddress ipAddress = IPAddress.Parse("192.168.10.102");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 30000);

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

            string currentTime = DateTime.Now.ToString("MM/dd/yyyy");

            FileStream fs = new FileStream(currentTime + "_Logging" + ".csv", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

            currentTime = DateTime.Now.ToString("HH:mm:ss:fff");

            sw.Write(currentTime + "\t" + "dcp" + "\t");
            for (int i = 0; i < 1024; i++)
            {
                if (rcvData.Buffer[i] == 232 && rcvData.Buffer[i - 1] == 231)
                {
                    sw.WriteLine(rcvData.Buffer[i]);
                    break;
                }
                else
                    sw.Write(rcvData.Buffer[i] + ",");
            }
            sw.Close();
            fs.Close();

            for (int i = 0; i < 1024; i++)
            {              
                if (rcvData.Buffer[i] == 172 && rcvData.Buffer[i + 1] == 19)
                {
                    if (rcvData.Buffer[i + 2] == 3 && rcvData.Buffer[i + 3] == 1)
                    {
                        byte[] result = rcvData.Buffer.Skip(i + 9).ToArray();

                        if (rcvData.Buffer[i + 4] == 1)
                        {
                            dcpBit(result);
                        }
                        else if (rcvData.Buffer[i + 4] == 2)
                        {
                            dcpCmd(result);
                        }
                        else if (rcvData.Buffer[i + 4] == 3)
                        {
                            dcpVer(result);
                        }
                        else if (rcvData.Buffer[i + 4] == 5)
                        {
                            dcpMon(result);
                        }
                    }
                }
            }

            try
            {
                data.Buffer = new byte[1024];
                data.Socket = client;
                client.BeginReceive(data.Buffer, 0, data.Buffer.Length,
                        SocketFlags.None, new AsyncCallback(dcpReceiveCallback), data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
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

            string currentTime = DateTime.Now.ToString("MM/dd/yyyy");

            /*FileStream fs = new FileStream(currentTime + "_Logging" + ".csv", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

            currentTime = DateTime.Now.ToString("HH:mm:ss:fff");

            sw.Write(currentTime + "\t" + "chiller" + "\t");
            for (int i = 0; i < 13; i++)
            {
                if (i == 12)
                {
                    sw.WriteLine(rcvData.Buffer[i]);
                }
                else
                    sw.Write(rcvData.Buffer[i] + ",");
            }
            sw.Close();
            fs.Close();*/

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
            try
            { 
                data.Buffer = new byte[1024];
                data.Socket = client;
                client.BeginReceive(data.Buffer, 0, data.Buffer.Length,
                        SocketFlags.None, new AsyncCallback(chillerReceiveCallback), data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void OnReceiveMessageAction(chillerCmd obj)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }        

        private void chillerCbit(Object state)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion
    }
}