using snow_bc_mobile.Extensions;
using snow_bc_mobile.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace snow_bc_mobile.Services.Destination
{
    public class DestinationMockService : IDestinationService
    {
        private ObservableCollection<Country> MockCountries = new ObservableCollection<Country>
        {
            new Country { Id = "15709BB8-54AE-4232-E98A-08D593B7C178", Name = "CHINA" },
        };

        private ObservableCollection<Provience> MockProviences = new ObservableCollection<Provience>
        {
            new Provience { Id = "F20672B0-2BE4-4F7B-9E92-08D593B7C18E", Name = "Beijing" },
            new Provience { Id = "69AF7451-8ADB-455F-9E93-08D593B7C18E", Name = "Shanghai" },
            new Provience { Id = "43330D19-68C1-491E-9E94-08D593B7C18E", Name = "Xizang" },

        };

        public async Task<ObservableCollection<Country>> GetCountryAsync()
        {
            await Task.Delay(10);
            return MockCountries;
        }


        public async Task<ObservableCollection<Provience>> GetProvienceAsync()
        {
            await Task.Delay(10);
            return MockProviences;
        }

        public async Task<ObservableCollection<City>> GetCityAsync()
        {
            await Task.Delay(10);
            return new ObservableCollection<City>();

        }

    }
}
