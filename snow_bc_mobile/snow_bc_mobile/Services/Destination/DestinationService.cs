using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;

using snow_bc_mobile.Models;
using snow_bc_mobile.Services.RequestProvider;
using snow_bc_mobile.Extensions;
//using snow_bc_mobile.Services.FixUri;


namespace snow_bc_mobile.Services.Destination
{
    public class DestinationService : IDestinationService
    {
        private readonly IRequestProvider _requestProvider;
        //private readonly IFixUriService _fixUriService;

        public DestinationService(IRequestProvider requestProvider)//, IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
            //_fixUriService = fixUriService;
        }

        public async Task<ObservableCollection<Country>> GetCountryAsync()
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.CountryEndpoint);
            builder.Path = "api/countries";
            string uri = builder.ToString();

            IEnumerable<Country> countries = await _requestProvider.GetAsync<IEnumerable<Country>>(uri);

            if (countries != null)
            {
                System.Diagnostics.Debug.WriteLine("test5------------------------------------------------------------");
                System.Diagnostics.Debug.WriteLine("test5------------------------------------------------------------");
                System.Diagnostics.Debug.WriteLine("test5------------------------------------------------------------");
                return countries?.ToObservableCollection();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("test6------------------------------------------------------------");
                System.Diagnostics.Debug.WriteLine("test6------------------------------------------------------------");
                System.Diagnostics.Debug.WriteLine("test6------------------------------------------------------------");
                return new ObservableCollection<Country>();
            }           
        }


        public async Task<ObservableCollection<Provience>> GetProvienceAsync()
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.ProvienceEndpoint);
            builder.Path = "api/v1/catalog/catalogbrands";
            string uri = builder.ToString();

            IEnumerable<Provience> proviences = await _requestProvider.GetAsync<IEnumerable<Provience>>(uri);

            if (proviences != null)
                return proviences?.ToObservableCollection();
            else
                return new ObservableCollection<Provience>();
        }

        public async Task<ObservableCollection<City>> GetCityAsync()
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.CityEndpoint);
            builder.Path = "api/v1/catalog/catalogbrands";
            string uri = builder.ToString();

            IEnumerable<City> cities = await _requestProvider.GetAsync<IEnumerable<City>>(uri);

            if (cities != null)
                return cities?.ToObservableCollection();
            else
                return new ObservableCollection<City>();
        }






        //public async Task<ObservableCollection<CatalogItem>> FilterAsync(int catalogBrandId, int catalogTypeId)
        //{
        //    UriBuilder builder = new UriBuilder(GlobalSetting.Instance.CatalogEndpoint);
        //    builder.Path = string.Format("api/v1/catalog/items/type/{0}/brand/{1}", catalogTypeId, catalogBrandId);
        //    string uri = builder.ToString();

        //    CatalogRoot catalog = await _requestProvider.GetAsync<CatalogRoot>(uri);

        //    if (catalog?.Data != null)
        //        return catalog?.Data.ToObservableCollection();
        //    else
        //        return new ObservableCollection<CatalogItem>();
        //}
    }
}
