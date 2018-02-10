using System.Collections;
using System.Linq;
using Android.Content;
using Appoxidelab.MvvmCross.Ninject.Shared;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform.IoC;

namespace Appoxidelab.MvvmCross.Ninject.Android
{
    public abstract class NinjectMvxDroidSetup : MvxAndroidSetup
    {
        protected NinjectMvxDroidSetup(Context applicationContext) : base(applicationContext)
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