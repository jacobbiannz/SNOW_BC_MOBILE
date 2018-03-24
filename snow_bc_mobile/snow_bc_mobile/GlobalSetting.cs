namespace snow_bc_mobile
{
    public class GlobalSetting
    {
        public const string AzureTag = "Azure";
        public const string MockTag = "Mock";
        public const string DefaultEndpoint = "http://localhost:61125";

        private string _baseEndpoint;
        private static readonly GlobalSetting _instance = new GlobalSetting();

        public GlobalSetting()
        {
            //AuthToken = "INSERT AUTHENTICATION TOKEN";
            BaseEndpoint = DefaultEndpoint;
        }

        public static GlobalSetting Instance
        {
            get { return _instance; }
        }

        public string BaseEndpoint
        {
            get { return _baseEndpoint; }
            set
            {
                _baseEndpoint = value;
                UpdateEndpoint(_baseEndpoint);
            }
        }

        //public string ClientId { get { return "snow_bc_client"; } }

        //public string ClientSecret { get { return "secret"; } }

        //public string AuthToken { get; set; }

        //public string RegisterWebsite { get; set; }

        public string CountryEndpoint { get; set; }

        public string ProvienceEndpoint { get; set; }

        public string CityEndpoint { get; set; }

        //public string UserInfoEndpoint { get; set; }

        //public string TokenEndpoint { get; set; }

        //public string LogoutEndpoint { get; set; }

        public string IdentityCallback { get; set; }

        public string LogoutCallback { get; set; }

        private void UpdateEndpoint(string baseEndpoint)
        {
            //RegisterWebsite = $"{baseEndpoint}:5105/Account/Register";
            CountryEndpoint = $"{baseEndpoint}";
            ProvienceEndpoint = $"{baseEndpoint}";
            CityEndpoint = $"{baseEndpoint}";
            //IdentityEndpoint = $"{baseEnd point}:5105/connect/authorize";
            //UserInfoEndpoint = $"{baseEndpoint}:5105/connect/userinfo";
            //TokenEndpoint = $"{baseEndpoint}:5105/connect/token";
            //LogoutEndpoint = $"{baseEndpoint}:5105/connect/endsession";
            //IdentityCallback = $"{baseEndpoint}:5105/xamarincallback";
            //LogoutCallback = $"{baseEndpoint}:5105/Account/Redirecting";
           
        }
    }
}