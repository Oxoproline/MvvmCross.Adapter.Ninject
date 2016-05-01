using System.Linq;
using Windows.UI.Xaml.Controls;
using MvvmCross.Platform.IoC;
using MvvmCross.WindowsCommon.Platform;
using MvvmCross.WindowsCommon.Views;

namespace MvvmCross.Adapter.Ninject.WP81
{
    public abstract class NinjectMvxWindowsSetup : MvxWindowsSetup
    {
        protected NinjectMvxWindowsSetup(Frame rootFrame, string suspensionManagerSessionStateKey = null) : base(rootFrame, suspensionManagerSessionStateKey)
        {
        }

        protected NinjectMvxWindowsSetup(IMvxWindowsFrame rootFrame) : base(rootFrame)
        {
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            (NinjectMvxIoCProvider.Instance as NinjectMvxIoCProvider).ExecuteDelayedCallback();
        }

        protected abstract NinjectDependenciesProvider GetNinjectDependenciesProvider();

        protected sealed override IMvxIoCProvider CreateIocProvider()
            => new NinjectMvxIoCProvider(GetNinjectDependenciesProvider().GetNinjectModules().ToArray());
    }
}
