using snow_bc_mobile.ViewModels;
using snow_bc_mobile.ViewModels.Base;
using Xamarin.Forms;

namespace snow_bc_mobile.Views
{
    public partial class MainView : TabbedPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage.SetHasNavigationBar(this, false);

            MessagingCenter.Subscribe<MainViewModel, int>(this, MessageKeys.ChangeTab, (sender, arg) =>
            {
                switch (arg)
                {
                    case 0:
                        CurrentPage = MainHomeView;
                        break;
                    case 1:
                        CurrentPage = MainLoginView;
                        break;
                    case 2:
                        //CurrentPage = BasketView;
                        break;
                    case 3:
                        //CurrentPage = CampaignView;
                        break;
                }
            });

            await ((HomeViewModel)MainHomeView.BindingContext).InitializeAsync(null);
            await ((LoginViewModel)MainLoginView.BindingContext).InitializeAsync(null);
            //await ((ProfileViewModel)ProfileView.BindingContext).InitializeAsync(null);
            //await ((CampaignViewModel)CampaignView.BindingContext).InitializeAsync(null);
        }

        protected override async void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            if (CurrentPage is HomeView)
            {
                // Force basket view refresh every time we access it
                await (MainHomeView.BindingContext as ViewModelBase).InitializeAsync(null);
            }
            
            else if (CurrentPage is LoginView)
            {
                // Force campaign view refresh every time we access it
                await (MainLoginView.BindingContext as ViewModelBase).InitializeAsync(null);
            }
            /*
            else if (CurrentPage is ProfileView)
            {
                // Force profile view refresh every time we access it
                await (ProfileView.BindingContext as ViewModelBase).InitializeAsync(null);
            }
            */
        }
    }
}