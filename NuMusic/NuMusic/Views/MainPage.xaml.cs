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
                    break;
                case 1:
                {

                    break;
                }
            }
        }
    }
}