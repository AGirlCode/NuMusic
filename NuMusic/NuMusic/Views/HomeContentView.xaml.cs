using NuMusic.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NuMusic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeContentView : ContentView
    {
        public static readonly BindableProperty DataSourceProperty =
               BindableProperty.Create(nameof(DataSource), typeof(HomeContentViewVM),
                   typeof(HomeContentView));

        public HomeContentViewVM DataSource
        {
            get { return (HomeContentViewVM)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        public HomeContentView()
        {
            InitializeComponent();
        }
    }
}