//using snow_bc_mobile.Models.Location;
using snow_bc_mobile.Services.Dependency;
//using snow_bc_mobile.Services.Location;
using snow_bc_mobile.Services.Settings;
using snow_bc_mobile.ViewModels.Base;
using snow_bc_mobile.Services;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace snow_bc_mobile
{
	public partial class App : Application
	{

        //public App ()
        //{
        //	InitializeComponent();

        //	MainPage = new snow_bc_mobile.MainPage();
        //}

        //protected override void OnStart ()
        //{
        //	// Handle when your app starts
        //}

        //protected override void OnSleep ()
        //{
        //	// Handle when your app sleeps
        //}

        //protected override void OnResume ()
        //{
        //	// Handle when your app resumes
        //}



        ISettingsService _settingsService;

        public App()
        {
            InitializeComponent();

            InitApp();
            if (Device.RuntimePlatform == Device.UWP)
            {
                InitNavigation();
            }
        }

        private void InitApp()
        {
            _settingsService = ViewModelLocator.Resolve<ISettingsService>();
            if (!_settingsService.UseMocks)
                ViewModelLocator.UpdateDependencies(_settingsService.UseMocks);
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            if (Device.RuntimePlatform != Device.UWP)
            {
                await InitNavigation();
            }

            /*
            if (_settingsService.AllowGpsLocation && !_settingsService.UseFakeLocation)
            {
                await GetGpsLocation();
            }
            if (!_settingsService.UseMocks && !string.IsNullOrEmpty(_settingsService.AuthAccessToken))
            {
                await SendCurrentLocation();
            }
            */

            base.OnResume();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /*
        private async Task GetGpsLocation()
        {
            var dependencyService = ViewModelLocator.Resolve<IDependencyService>();
            var locator = dependencyService.Get<ILocationServiceImplementation>();

            if (locator.IsGeolocationEnabled && locator.IsGeolocationAvailable)
            {
                locator.DesiredAccuracy = 50;

                try
                {
                    var position = await locator.GetPositionAsync();
                    _settingsService.Latitude = position.Latitude.ToString();
                    _settingsService.Longitude = position.Longitude.ToString();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            else
            {
                _settingsService.AllowGpsLocation = false;
            }
        }

        private async Task SendCurrentLocation()
        {
            var location = new Location
            {
                Latitude = double.Parse(_settingsService.Latitude, CultureInfo.InvariantCulture),
                Longitude = double.Parse(_settingsService.Longitude, CultureInfo.InvariantCulture)
            };

            var locationService = ViewModelLocator.Resolve<ILocationService>();
            await locationService.UpdateUserLocation(location, _settingsService.AuthAccessToken);
        }
        */
    }
}
