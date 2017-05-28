using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using UwpApp.DataAccess.Repositories;
using UwpApp.Models;
using UwpApp.Services;
using GalaSoft.MvvmLight.Views;
using UwpApp.Views;

namespace UwpApp.ViewModels
{
    public class ViewModelLocator
    {
        public const string StartPageKey = "StartPage";
        public const string DetailsPageKey = "DetailsPage";
        public const string UnitTestPageKey = "UnitTestPage";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var nav = new NavigationService();
            nav.Configure(StartPageKey, typeof(StartPage));
            nav.Configure(DetailsPageKey, typeof(DetailsPage));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<StartPageViewModel>();
            SimpleIoc.Default.Register<DetailsPageViewModel>();
            SimpleIoc.Default.Register<IRepository<City>, CityRepository>();
            SimpleIoc.Default.Register<IDataProviderService<City>, DataProviderService>();
                 
        }

        /// <summary>
        /// The StartPage view model.
        /// </summary>
        public StartPageViewModel StartPageInstance => ServiceLocator.Current.GetInstance<StartPageViewModel>();

        /// <summary>
        /// The DetailsPage view model.
        /// </summary>
        public DetailsPageViewModel DetailsPageInstance => ServiceLocator.Current.GetInstance<DetailsPageViewModel>();

        /// <summary>
        ///  The cleanup.
        /// </summary>
        public static void Cleanup()
        {
            //  TODO Clear the ViewModels
        }
    }
}
