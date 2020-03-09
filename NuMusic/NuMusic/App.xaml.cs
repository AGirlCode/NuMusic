using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NuMusic.Services;
using NuMusic.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism;

namespace NuMusic
{
    public partial class App : PrismApplication
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

        }

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(AppSettings.SyncFusionLicenseKey);
            InitializeComponent();
            // Đặt ngôn ngữ cho App dựa vào property đã lưu, nếu không có thì đặt tiếng Việt làm mặc định
            SetAppLanguage();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {


        }
    }
}