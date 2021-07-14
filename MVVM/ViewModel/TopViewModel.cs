using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MVVM.Messages;
using RealTimeGraphX;
using RealTimeGraphX.DataPoints;
using RealTimeGraphX.Renderers;
using RealTimeGraphX.WPF;

namespace MVVM.ViewModel
{
    public class TopViewModel : ViewModelBase
    {
        private bool _count;
        public bool count
        {
            get { return _count; }
            set
            {
                _count = value;
                RaisePropertyChanged("count");
            }
        }

        private string _data1;
        private string _data2;
        private string _data3;
        private string _data4;

        public string data1
        {
            get { return _data1; }
            set
            {
                _data1 = value;
                RaisePropertyChanged("data1");
            }
        }

        public string data2
        {
            get { return _data2; }
            set
            {
                _data2 = value;
                RaisePropertyChanged("data2");
            }
        }

        public string data3
        {
            get { return _data3; }
            set
            {
                _data3 = value;
                RaisePropertyChanged("data3");
            }
        }

        public string data4
        {
            get { return _data4; }
            set
            {
                _data4 = value;
                RaisePropertyChanged("data4");
            }
        }
        public WpfGraphController<TimeSpanDataPoint, DoubleDataPoint> MultiController { get; set; }

        public TopViewModel()
        {
            MultiController = new WpfGraphController<TimeSpanDataPoint, DoubleDataPoint>();
            MultiController.Range.MinimumY = 0;
            MultiController.Range.MaximumY = 1080;
            MultiController.Range.MaximumX = TimeSpan.FromSeconds(10);
            MultiController.Range.AutoY = true;

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 1",
                Stroke = Colors.Red,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 2",
                Stroke = Colors.Green,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 3",
                Stroke = Colors.Blue,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 4",
                Stroke = Colors.Yellow,
            });

            Stopwatch watch = new Stopwatch();
            watch.Start();

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Messenger.Default.Register<ViewModelMessage>(this, OnReceiveMessageAction);
                    var d1 = Convert.ToInt32(data1);
                    var d2 = Convert.ToInt32(data2);
                    var d3 = Convert.ToInt32(data3);
                    var d4 = Convert.ToInt32(data4);

                    List<DoubleDataPoint> yy = new List<DoubleDataPoint>()
                    {
                        d1,
                        d2,
                        d3,
                        d4
                    };

                    var x = watch.Elapsed;

                    List<TimeSpanDataPoint> xx = new List<TimeSpanDataPoint>()
                    {
                        x,
                        x,
                        x,
                        x
                    };

                    MultiController.PushData(xx, yy);

                    Thread.Sleep(30);
                }
            });
        }
        private void OnReceiveMessageAction(ViewModelMessage obj)
        {
            data1 = obj.d1;
            data2 = obj.d2;
            data3 = obj.d3;
            data4 = obj.d4;
            if (count == true)
                count = false;
            else
                count = true;
        }
    }
}
