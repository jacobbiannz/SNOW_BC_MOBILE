using snow_bc_mobile.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace snow_bc_mobile.Services.Destination
{
    public interface IDestinationService
    {
        Task<ObservableCollection<Country>> GetCountryAsync();
        //Task<ObservableCollection<>> FilterAsync(int catalogBrandId, int catalogTypeId);
        Task<ObservableCollection<Provience>> GetProvienceAsync();
        Task<ObservableCollection<City>> GetCityAsync();
    }
}
