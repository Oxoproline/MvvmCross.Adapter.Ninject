using System.Linq;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.IoC;
using UIKit;

namespace MvvmCross.Adapter.Ninject.iOS
{
    public abstract class NinjectMvxIosSetup : MvxIosSetup
    {
        protected NinjectMvxIosSetup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected NinjectMvxIosSetup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter) : base(applicationDelegate, presenter)
        {

        }

        protected abstract NinjectDependenciesProvider GetNinjectDependenciesProvider();

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            (NinjectMvxIoCProvider.Instance as NinjectMvxIoCProvider).ExecuteDelayedCallback();
        }


        protected sealed override IMvxIoCProvider CreateIocProvider()
            => new NinjectMvxIoCProvider(GetNinjectDependenciesProvider().GetNinjectModules().ToArray());
    }
}
