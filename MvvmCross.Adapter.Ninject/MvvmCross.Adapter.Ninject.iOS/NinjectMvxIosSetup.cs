using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace MvvmCross.Adapter.Ninject.iOS
{
    public abstract class NinjectMvxIosSetup : MvxIosSetup
    {
        private readonly NinjectDependenciesProvider _dependenciesProvider;

        protected NinjectMvxIosSetup(IMvxApplicationDelegate applicationDelegate, UIWindow window, NinjectDependenciesProvider dependenciesProvider) : base(applicationDelegate, window)
        {
            _dependenciesProvider = dependenciesProvider;
        }

        protected NinjectMvxIosSetup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter) : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            throw new NotImplementedException();
        }
    }
}
