using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MVVM.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class EngineeringView2Model : ViewModelBase
    {
        private int _swVer;
        public int SwVer
        {
            get { return _swVer; }
            set
            {
                _swVer = value;
                RaisePropertyChanged("SwVer");
            }
        }
        private int _hwVer;
        public int HwVer
        {
            get { return _hwVer; }
            set
            {
                _hwVer = value;
                RaisePropertyChanged("HwVer");
            }
        }
        private int _deviceId;
        public int DeviceId
        {
            get { return _deviceId; }
            set
            {
                _deviceId = value;
                RaisePropertyChanged("DeviceId");
            }
        }

        public EngineeringView2Model()
        {
            Messenger.Default.Register<versionResponse>(this, OnReceiveMessageAction);
        }

        private void OnReceiveMessageAction(versionResponse obj)
        {
            SwVer = obj.SwVer;
            HwVer = obj.HwVer;
            DeviceId = obj.DeviceId;
        }
    }
}
