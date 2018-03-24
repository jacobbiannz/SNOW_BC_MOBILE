using Xamarin.Forms;

namespace snow_bc_mobile.Views
{
    public partial class CustomNavigationView : NavigationPage
    {
        public CustomNavigationView() : base()
        {
            InitializeComponent();
            
        }

        public CustomNavigationView(Page root) : base(root)
        {
            InitializeComponent();
            
        }
    }
}