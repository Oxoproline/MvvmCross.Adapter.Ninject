using System.Linq;
using Android.Content;
using Appoxidelab.MvvmCross.Ninject.Shared;
using MvvmCross.Forms.Droid.Platform;
using MvvmCross.Platform.IoC;

namespace Appoxidelab.MvvmCross.Forms.Ninject.Android
{
    public abstract class NinjectMvxFormsDroidSetup : MvxFormsAndroidSetup
    {
        protected NinjectMvxFormsDroidSetup(Context applicationContext) : base(applicationContext)
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
