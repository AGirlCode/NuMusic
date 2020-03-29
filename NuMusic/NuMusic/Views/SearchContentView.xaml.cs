using NuMusic.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NuMusic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchContentView : ContentView
    {
        public static readonly BindableProperty DataSourceProperty =
                 BindableProperty.Create(nameof(DataSource), typeof(SearchContentViewVM),
                     typeof(SearchContentView));

        public SearchContentViewVM DataSource
        {
            get { return (SearchContentViewVM)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        public SearchContentView()
        {
            InitializeComponent();
        }
    }
}