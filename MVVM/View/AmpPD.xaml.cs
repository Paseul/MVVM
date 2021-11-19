using GalaSoft.MvvmLight.Messaging;
using MVVM.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MVVM.View
{
    /// <summary>
    /// AmpPD.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AmpPD : Window, INotifyPropertyChanged
    {
        private bool _pd1High;
        public bool Pd1High
        {
            get { return _pd1High; }
            set
            {
                _pd1High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd1Low;
        public bool Pd1Low
        {
            get { return _pd1Low; }
            set
            {
                _pd1Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd2High;
        public bool Pd2High
        {
            get { return _pd2High; }
            set
            {
                _pd2High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd2Low;
        public bool Pd2Low
        {
            get { return _pd2Low; }
            set
            {
                _pd2Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd3High;
        public bool Pd3High
        {
            get { return _pd3High; }
            set
            {
                _pd3High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd3Low;
        public bool Pd3Low
        {
            get { return _pd3Low; }
            set
            {
                _pd3Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd4High;
        public bool Pd4High
        {
            get { return _pd4High; }
            set
            {
                _pd4High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd4Low;
        public bool Pd4Low
        {
            get { return _pd4Low; }
            set
            {
                _pd4Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd5High;
        public bool Pd5High
        {
            get { return _pd5High; }
            set
            {
                _pd5High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd5Low;
        public bool Pd5Low
        {
            get { return _pd5Low; }
            set
            {
                _pd5Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd6High;
        public bool Pd6High
        {
            get { return _pd6High; }
            set
            {
                _pd6High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd6Low;
        public bool Pd6Low
        {
            get { return _pd6Low; }
            set
            {
                _pd6Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd7High;
        public bool Pd7High
        {
            get { return _pd7High; }
            set
            {
                _pd7High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd7Low;
        public bool Pd7Low
        {
            get { return _pd7Low; }
            set
            {
                _pd7Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd8High;
        public bool Pd8High
        {
            get { return _pd8High; }
            set
            {
                _pd8High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _pd8Low;
        public bool Pd8Low
        {
            get { return _pd8Low; }
            set
            {
                _pd8Low = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public AmpPD()
        {
            InitializeComponent();
            Messenger.Default.Register<errorMon>(this, OnReceiveMessageAction);
            ApplyLamp();
        }

        private void OnReceiveMessageAction(errorMon obj)
        {
            Pd1High = obj.Pd1High;
            Pd1Low = obj.Pd1Low;
            Pd2High = obj.Pd2High;
            Pd2Low = obj.Pd2Low;
            Pd3High = obj.Pd3High;
            Pd3Low = obj.Pd3Low;
            Pd4High = obj.Pd4High;
            Pd4Low = obj.Pd4Low;
            Pd5High = obj.Pd5High;
            Pd5Low = obj.Pd5Low;
            Pd6High = obj.Pd6High;
            Pd6Low = obj.Pd6Low;
            Pd7High = obj.Pd7High;
            Pd7Low = obj.Pd7Low;
            Pd8High = obj.Pd8High;
            Pd8Low = obj.Pd8Low;

            ApplyLamp();
        }

        private void ApplyLamp()
        {
            if (Pd1High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd1High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd1High.Background = Brushes.Lime; }));

            if (Pd1Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd1Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd1Low.Background = Brushes.Lime; }));

            if (Pd2High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd2High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd2High.Background = Brushes.Lime; }));

            if (Pd2Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd2Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd2Low.Background = Brushes.Lime; }));

            if (Pd3High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd3High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd3High.Background = Brushes.Lime; }));

            if (Pd3Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd3Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd3Low.Background = Brushes.Lime; }));

            if (Pd4High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd4High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd4High.Background = Brushes.Lime; }));

            if (Pd4Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd4Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd4Low.Background = Brushes.Lime; }));

            if (Pd5High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd5High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd5High.Background = Brushes.Lime; }));

            if (Pd5Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd5Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd5Low.Background = Brushes.Lime; }));

            if (Pd6High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd6High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd6High.Background = Brushes.Lime; }));

            if (Pd6Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd6Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd6Low.Background = Brushes.Lime; }));

            if (Pd7High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd7High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd7High.Background = Brushes.Lime; }));

            if (Pd7Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd7Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pd7Low.Background = Brushes.Lime; }));
        }
    }
}
