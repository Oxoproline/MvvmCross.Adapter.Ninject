using System.Linq;
using Appoxidelab.MvvmCross.Ninject.Shared;
using MvvmCross.Forms.iOS;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.IoC;
using UIKit;

namespace Appoxidelab.MvvmCross.Forms.Ninject.iOS
{
    public abstract class NinjectMvxFormsIosSetup : MvxFormsIosSetup
    {
        protected NinjectMvxFormsIosSetup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected NinjectMvxFormsIosSetup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
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
