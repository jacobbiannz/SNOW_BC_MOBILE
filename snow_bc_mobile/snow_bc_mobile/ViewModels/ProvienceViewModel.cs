using snow_bc_mobile.Models;
using snow_bc_mobile.Services.Destination;
using snow_bc_mobile.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace snow_bc_mobile.ViewModels
{
    public class ProvienceViewModel : ViewModelBase
    {
      
        private ObservableCollection<City> _cities;
        private Provience _provience;


        private IDestinationService _destinationService;

        public ProvienceViewModel(IDestinationService destinationService)
        {

            _destinationService = destinationService;
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

        public Provience Provience
        {
            get { return _provience; }
            set
            {
                _provience = value;
                RaisePropertyChanged(() => Provience);
            }
        }


        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Provience)
            {
                IsBusy = true;

                var provience = navigationData as Provience;
                await Task.Delay(10);
                Provience = provience;
                // Get order detail info
                //var authToken = _settingsService.AuthAccessToken;
                //Order = await _ordersService.GetOrderAsync(order.OrderNumber, authToken);
                //IsSubmittedOrder = Order.OrderStatus == OrderStatus.Submitted;
                //OrderStatusText = Order.OrderStatus.ToString().ToUpper();

                IsBusy = false;
            }

             

            //Cities = await _destinationService.GetCityAsync();

             
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
