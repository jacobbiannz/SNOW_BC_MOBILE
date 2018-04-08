
//using snow_bc_mobile.Services.Basket;
//using snow_bc_mobile.Services.Catalog;
using snow_bc_mobile.Services.Dependency;
//using snow_bc_mobile.Services.FixUri;
//using snow_bc_mobile.Services.Identity;
//using snow_bc_mobile.Services.Location;
//using snow_bc_mobile.Services.Marketing;
//using snow_bc_mobile.Services.OpenUrl;
//using snow_bc_mobile.Services.Order;
//using snow_bc_mobile.Services.RequestProvider;
using snow_bc_mobile.Services.Settings;
using snow_bc_mobile.Services.Navigation;
using snow_bc_mobile.Services.Destination;
using snow_bc_mobile.Services.RequestProvider;
//using snow_bc_mobile.Services.User;
using snow_bc_mobile.Services;


using System;
using System.Globalization;
using System.Reflection;
using TinyIoC;
using Xamarin.Forms;

namespace snow_bc_mobile.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static TinyIoCContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();

            // View models - by default, TinyIoC will register concrete classes as multi-instance.

            //_container.Register<BasketViewModel>();
            //_container.Register<CatalogViewModel>();
            //_container.Register<CheckoutViewModel>();
            //_container.Register<LoginViewModel>();
            _container.Register<MainViewModel>();
            _container.Register<DestinationViewModel>();
            _container.Register<ProvienceViewModel>();
            //_container.Register<OrderDetailViewModel>();
            //_container.Register<ProfileViewModel>();
            //_container.Register<SettingsViewModel>();
            //_container.Register<CampaignViewModel>();
            //_container.Register<CampaignDetailsViewModel>();

            // Services - by default, TinyIoC will register interface registrations as singletons.
            _container.Register<INavigationService, NavigationService>();
            
            //_container.Register<IDialogService, DialogService>();
            //_container.Register<IOpenUrlService, OpenUrlService>();
            //_container.Register<IIdentityService, IdentityService>();
            _container.Register<IRequestProvider, RequestProvider>();
            _container.Register<IDependencyService, Services.Dependency.DependencyService>();
            _container.Register<ISettingsService, SettingsService>();
            //_container.Register<IFixUriService, FixUriService>();
            //_container.Register<ILocationService, LocationService>();
            //_container.Register<ICatalogService, CatalogMockService>();
            //_container.Register<IBasketService, BasketMockService>();
            //_container.Register<IOrderService, OrderMockService>();
            //_container.Register<IUserService, UserMockService>();
            //_container.Register<ICampaignService, CampaignMockService>();
        }

        public static void UpdateDependencies(bool useMockServices)
        {
            // Change injected dependencies
            if (useMockServices)
            {
                //_container.Register<ICatalogService, CatalogMockService>();
                //_container.Register<IBasketService, BasketMockService>();
                //_container.Register<IOrderService, OrderMockService>();
                //_container.Register<IUserService, UserMockService>();
                //_container.Register<ICampaignService, CampaignMockService>();
                _container.Register<IDestinationService, DestinationMockService>();
                UseMockService = true;
            }
            else
            {
                //_container.Register<ICatalogService, CatalogService>();
                //_container.Register<IBasketService, BasketService>();
                //_container.Register<IOrderService, OrderService>();
                //_container.Register<IUserService, UserService>();
                //_container.Register<ICampaignService, CampaignService>();
                _container.Register<IDestinationService, DestinationService>();
                UseMockService = false;
            }
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}