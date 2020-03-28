using NuMusic.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NuMusic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryContentView : ContentView
    {
        public static readonly BindableProperty DataSourceProperty =
                 BindableProperty.Create(nameof(DataSource), typeof(LibraryContentViewVM),
                     typeof(LibraryContentView));

        public LibraryContentViewVM DataSource
        {
            get { return (LibraryContentViewVM)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        public LibraryContentView()
        {
            InitializeComponent();
        }
    }
}