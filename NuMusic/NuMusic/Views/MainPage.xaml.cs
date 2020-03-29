using NuMusic.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NuMusic.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainContentPageVM _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = (MainContentPageVM)BindingContext;
            TabContents.SelectedIndex = 1;
            TabContents.Items[0].ImageSource = "ic_library.png";
            TabContents.Items[1].ImageSource = "ic_home_selected.png";
            TabContents.Items[2].ImageSource = "ic_search.png";
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        private void TabContents_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    TabContents.Items[0].ImageSource = "ic_library_selected.png";
                    TabContents.Items[1].ImageSource = "ic_home.png";
                    TabContents.Items[2].ImageSource = "ic_search.png";
                    break;
                case 1:
                {
                    TabContents.Items[0].ImageSource = "ic_library.png";
                    TabContents.Items[1].ImageSource = "ic_home_selected.png";
                    TabContents.Items[2].ImageSource = "ic_search.png";
                    break;
                }
                case 2:
                {
                    TabContents.Items[0].ImageSource = "ic_library.png";
                    TabContents.Items[1].ImageSource = "ic_home.png";
                    TabContents.Items[2].ImageSource = "ic_search_selected.png";
                    break;
                }
            }
        }
    }
}