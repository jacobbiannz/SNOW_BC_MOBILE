using snow_bc_mobile.Models;
using snow_bc_mobile.Services.Destination;
using snow_bc_mobile.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace snow_bc_mobile.ViewModels
{
    //public class DestinationViewModel : ViewModelBase
    //{ }
    public class DestinationViewModel : ViewModelBase
    {
        private ObservableCollection<Country> _countries;
        private ObservableCollection<Provience> _proviences;
        private ObservableCollection<City> _cities;

        private Country _country;
        private Provience _provience;
        private City _city;

        private IDestinationService _destinationService;

        public DestinationViewModel(IDestinationService destinationService)
        {
            

            _destinationService = destinationService;
        }

        public ObservableCollection<Country> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                RaisePropertyChanged(() => Countries);
            }
        }

        public ObservableCollection<Provience> Proviences
        {
            get { return _proviences; }
            set
            {
                _proviences = value;
                RaisePropertyChanged(() => Proviences);
            }
        }

        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }

        public Country Country
        {
            get { return _country; }
            set
            {
                _country = value;
                RaisePropertyChanged(() => Country);
            }
        }

        public Provience Provience
        {
            get { return _provience; }
            set
            {
                _provience = value;
                RaisePropertyChanged(() => Provience);
            }
        }

        public City City
        {
            get { return _city; }
            set
            {
                _city = value;
                RaisePropertyChanged(() => City);
            }
        }

        //public bool IsFilter { get { return Brand != null || Type != null; } }

        //public ICommand AddCatalogItemCommand => new Command<CatalogItem>(AddCatalogItem);

        //public ICommand FilterCommand => new Command(async () => await FilterAsync());

        //public ICommand ClearFilterCommand => new Command(async () => await ClearFilterAsync());

        //----
        public ICommand TestCommand => new Command(async() => await TestAsync());

        private async Task TestAsync()
        {
            await NavigationService.NavigateToAsync<ProvienceViewModel>();
        }
        //----
        public ICommand ProvienceCommand => new Command<Provience>(async (provience) => await ProvienceAsync(provience));
     
        private async Task ProvienceAsync(Provience provience)
        {
            await NavigationService.NavigateToAsync<ProvienceViewModel>(provience);
        }
     




        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;



            // Get Catalog, Brands and Types
            Countries = await _destinationService.GetCountryAsync();
            Proviences = await _destinationService.GetProvienceAsync();
            //Cities = await _destinationService.GetCityAsync();

            IsBusy = false;
        }

        //private void AddCatalogItem(CatalogItem catalogItem)
        //{
        //    // Add new item to Basket
        //    MessagingCenter.Send(this, MessageKeys.AddProduct, catalogItem);
        //}

        //private async Task FilterAsync()
        //{
        //    if (Brand == null || Type == null)
        //    {
        //        return;
        //    }

        //    IsBusy = true;

        //    // Filter catalog products
        //    MessagingCenter.Send(this, MessageKeys.Filter);
        //    Products = await _productsService.FilterAsync(Brand.Id, Type.Id);

        //    IsBusy = false;
        //}

        //private async Task ClearFilterAsync()
        //{
        //    IsBusy = true;

        //    Brand = null;
        //    Type = null;
        //    Products = await _productsService.GetCatalogAsync();

        //    IsBusy = false;
        //}
    }
}
