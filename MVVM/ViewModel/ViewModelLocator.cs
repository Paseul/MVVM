using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;

namespace MVVM.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TopViewModel>();
            SimpleIoc.Default.Register<SideViewModel>();
            SimpleIoc.Default.Register<ControlViewModel>();
            SimpleIoc.Default.Register<EngineeringViewModel>();
            SimpleIoc.Default.Register<EngineeringView2Model>();
            SimpleIoc.Default.Register<BitViewModel>();
            SimpleIoc.Default.Register<AmpCurrentModel>();
            SimpleIoc.Default.Register<AmpPDModel>();
            SimpleIoc.Default.Register<AmpTempModel>();
            SimpleIoc.Default.Register<AmpVoltageModel>();
            SimpleIoc.Default.Register<PowerBitModel>();
            SimpleIoc.Default.Register<SeedStatusModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public TopViewModel Top
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TopViewModel>();
            }
        }

        public SideViewModel Side
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SideViewModel>();
            }
        }

        public ControlViewModel Control
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ControlViewModel>();
            }
        }

        public EngineeringViewModel Engineering
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EngineeringViewModel>();
            }
        }

        public EngineeringView2Model Engineering2
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EngineeringView2Model>();
            }
        }

        public BitViewModel Bit
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BitViewModel>();
            }
        }

        public AmpCurrentModel AmpCurrent
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AmpCurrentModel>();
            }
        }

        public AmpPDModel AmpPD
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AmpPDModel>();
            }
        }

        public AmpTempModel AmpTemp
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AmpTempModel>();
            }
        }

        public AmpVoltageModel AmpVoltage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AmpVoltageModel>();
            }
        }

        public PowerBitModel PowerBit
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PowerBitModel>();
            }
        }

        public SeedStatusModel SeedStatus
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SeedStatusModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}