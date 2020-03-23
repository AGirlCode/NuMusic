using NuMusic.Configurations;
using NuMusic.Services;
using NuMusic.ViewModels;
using NuMusic.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;

namespace NuMusic
{
    public partial class App : PrismApplication
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new MainPage();
        }

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(AppSettings.SyncFusionLicenseKey);
            InitializeComponent(); 
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainContentPageVM>();

        }
    }
}