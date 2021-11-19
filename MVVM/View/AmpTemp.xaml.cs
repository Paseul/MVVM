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
    /// AmpTemp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AmpTemp : Window, INotifyPropertyChanged
    {
        private bool _paTemp1High;
        public bool PaTemp1High
        {
            get { return _paTemp1High; }
            set
            {
                _paTemp1High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp1Low;
        public bool PaTemp1Low
        {
            get { return _paTemp1Low; }
            set
            {
                _paTemp1Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp2High;
        public bool PaTemp2High
        {
            get { return _paTemp2High; }
            set
            {
                _paTemp2High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp2Low;
        public bool PaTemp2Low
        {
            get { return _paTemp2Low; }
            set
            {
                _paTemp2Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp3High;
        public bool PaTemp3High
        {
            get { return _paTemp3High; }
            set
            {
                _paTemp3High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp3Low;
        public bool PaTemp3Low
        {
            get { return _paTemp3Low; }
            set
            {
                _paTemp3Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp4High;
        public bool PaTemp4High
        {
            get { return _paTemp4High; }
            set
            {
                _paTemp4High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp4Low;
        public bool PaTemp4Low
        {
            get { return _paTemp4Low; }
            set
            {
                _paTemp4Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp5High;
        public bool PaTemp5High
        {
            get { return _paTemp5High; }
            set
            {
                _paTemp5High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp5Low;
        public bool PaTemp5Low
        {
            get { return _paTemp5Low; }
            set
            {
                _paTemp5Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp6High;
        public bool PaTemp6High
        {
            get { return _paTemp6High; }
            set
            {
                _paTemp6High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp6Low;
        public bool PaTemp6Low
        {
            get { return _paTemp6Low; }
            set
            {
                _paTemp6Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp7High;
        public bool PaTemp7High
        {
            get { return _paTemp7High; }
            set
            {
                _paTemp7High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp7Low;
        public bool PaTemp7Low
        {
            get { return _paTemp7Low; }
            set
            {
                _paTemp7Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp8High;
        public bool PaTemp8High
        {
            get { return _paTemp8High; }
            set
            {
                _paTemp8High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp8Low;
        public bool PaTemp8Low
        {
            get { return _paTemp8Low; }
            set
            {
                _paTemp8Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp9High;
        public bool PaTemp9High
        {
            get { return _paTemp9High; }
            set
            {
                _paTemp9High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp9Low;
        public bool PaTemp9Low
        {
            get { return _paTemp9Low; }
            set
            {
                _paTemp9Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp10High;
        public bool PaTemp10High
        {
            get { return _paTemp10High; }
            set
            {
                _paTemp10High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp10Low;
        public bool PaTemp10Low
        {
            get { return _paTemp10Low; }
            set
            {
                _paTemp10Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp11High;
        public bool PaTemp11High
        {
            get { return _paTemp11High; }
            set
            {
                _paTemp11High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp11Low;
        public bool PaTemp11Low
        {
            get { return _paTemp11Low; }
            set
            {
                _paTemp11Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp12High;
        public bool PaTemp12High
        {
            get { return _paTemp12High; }
            set
            {
                _paTemp12High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp12Low;
        public bool PaTemp12Low
        {
            get { return _paTemp12Low; }
            set
            {
                _paTemp12Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp13High;
        public bool PaTemp13High
        {
            get { return _paTemp13High; }
            set
            {
                _paTemp13High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp13Low;
        public bool PaTemp13Low
        {
            get { return _paTemp13Low; }
            set
            {
                _paTemp13Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp14High;
        public bool PaTemp14High
        {
            get { return _paTemp14High; }
            set
            {
                _paTemp14High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp14Low;
        public bool PaTemp14Low
        {
            get { return _paTemp14Low; }
            set
            {
                _paTemp14Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp15High;
        public bool PaTemp15High
        {
            get { return _paTemp15High; }
            set
            {
                _paTemp15High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp15Low;
        public bool PaTemp15Low
        {
            get { return _paTemp15Low; }
            set
            {
                _paTemp15Low = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp16High;
        public bool PaTemp16High
        {
            get { return _paTemp16High; }
            set
            {
                _paTemp16High = value;
                NotifyPropertyChanged();
            }
        }
        private bool _paTemp16Low;
        public bool PaTemp16Low
        {
            get { return _paTemp16Low; }
            set
            {
                _paTemp16Low = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public AmpTemp()
        {
            InitializeComponent();
            Messenger.Default.Register<warnMon>(this, OnReceiveMessageAction);
            ApplyLamp();
        }

        private void OnReceiveMessageAction(warnMon obj)
        {
            PaTemp1High = obj.PaTemp1High;
            PaTemp1Low = obj.PaTemp1Low;
            PaTemp2High = obj.PaTemp2High;
            PaTemp2Low = obj.PaTemp2Low;
            PaTemp3High = obj.PaTemp3High;
            PaTemp3Low = obj.PaTemp3Low;
            PaTemp4High = obj.PaTemp4High;
            PaTemp4Low = obj.PaTemp4Low;
            PaTemp5High = obj.PaTemp5High;
            PaTemp5Low = obj.PaTemp5Low;
            PaTemp6High = obj.PaTemp6High;
            PaTemp6Low = obj.PaTemp6Low;
            PaTemp7High = obj.PaTemp7High;
            PaTemp7Low = obj.PaTemp7Low;
            PaTemp8High = obj.PaTemp8High;
            PaTemp8Low = obj.PaTemp8Low;
            PaTemp9High = obj.PaTemp9High;
            PaTemp9Low = obj.PaTemp9Low;
            PaTemp10High = obj.PaTemp10High;
            PaTemp10Low = obj.PaTemp10Low;
            PaTemp11High = obj.PaTemp11High;
            PaTemp11Low = obj.PaTemp11Low;
            PaTemp12High = obj.PaTemp12High;
            PaTemp12Low = obj.PaTemp12Low;
            PaTemp13High = obj.PaTemp13High;
            PaTemp13Low = obj.PaTemp13Low;
            PaTemp14High = obj.PaTemp14High;
            PaTemp14Low = obj.PaTemp14Low;
            PaTemp15High = obj.PaTemp15High;
            PaTemp15Low = obj.PaTemp15Low;
            PaTemp16High = obj.PaTemp16High;
            PaTemp16Low = obj.PaTemp16Low;
            ApplyLamp();
        }

        private void ApplyLamp()
        {
            if (PaTemp1High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld1High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld1High.Background = Brushes.Lime; }));

            if (PaTemp1Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld1Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld1Low.Background = Brushes.Lime; }));

            if (PaTemp2High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld2High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld2High.Background = Brushes.Lime; }));

            if (PaTemp2Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld2Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld2Low.Background = Brushes.Lime; }));

            if (PaTemp3High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld3High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld3High.Background = Brushes.Lime; }));

            if (PaTemp3Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld3Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld3Low.Background = Brushes.Lime; }));

            if (PaTemp4High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld4High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld4High.Background = Brushes.Lime; }));

            if (PaTemp4Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld4Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld4Low.Background = Brushes.Lime; }));

            if (PaTemp5High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld5High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld5High.Background = Brushes.Lime; }));

            if (PaTemp5Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld5Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld5Low.Background = Brushes.Lime; }));

            if (PaTemp6High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld6High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld6High.Background = Brushes.Lime; }));

            if (PaTemp6Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld6Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld6Low.Background = Brushes.Lime; }));

            if (PaTemp7High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld7High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld7High.Background = Brushes.Lime; }));

            if (PaTemp7Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld7Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld7Low.Background = Brushes.Lime; }));

            if (PaTemp8High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld8High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld8High.Background = Brushes.Lime; }));

            if (PaTemp8Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld8Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld8Low.Background = Brushes.Lime; }));

            if (PaTemp9High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld9High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld9High.Background = Brushes.Lime; }));

            if (PaTemp9Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld9Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld9Low.Background = Brushes.Lime; }));

            if (PaTemp10High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld10High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld10High.Background = Brushes.Lime; }));

            if (PaTemp10Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld10Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld10Low.Background = Brushes.Lime; }));

            if (PaTemp11High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld11High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld11High.Background = Brushes.Lime; }));

            if (PaTemp11Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld11Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld11Low.Background = Brushes.Lime; }));

            if (PaTemp12High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld12High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld12High.Background = Brushes.Lime; }));

            if (PaTemp12Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld12Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld12Low.Background = Brushes.Lime; }));

            if (PaTemp13High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld13High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld13High.Background = Brushes.Lime; }));

            if (PaTemp13Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld13Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld13Low.Background = Brushes.Lime; }));

            if (PaTemp14High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld14High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld14High.Background = Brushes.Lime; }));

            if (PaTemp14Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld14Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld14Low.Background = Brushes.Lime; }));

            if (PaTemp15High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld15High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld15High.Background = Brushes.Lime; }));

            if (PaTemp15Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld15Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld15Low.Background = Brushes.Lime; }));

            if (PaTemp16High)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld16High.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld16High.Background = Brushes.Lime; }));

            if (PaTemp16Low)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld16Low.Background = Brushes.Red; }));
            else
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { pa4Ld16Low.Background = Brushes.Lime; }));
        }

    }
}
