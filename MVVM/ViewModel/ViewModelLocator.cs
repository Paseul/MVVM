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


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}