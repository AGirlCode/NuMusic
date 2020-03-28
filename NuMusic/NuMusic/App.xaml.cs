using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using Microsoft.AppCenter.Push;
using NuMusic.Configurations;
using NuMusic.Core;
using NuMusic.Infrastructure;
using NuMusic.Resources;
using NuMusic.Services;
using NuMusic.ViewModels;
using NuMusic.Views;
using Plugin.Multilingual;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Device = Xamarin.Forms.Device;

namespace NuMusic
{
    public partial class App : PrismApplication
    {
        private static string _appVersion;

        /// <summary>
        /// Trạng thái của app: true đang chạy/false không chạy
        /// </summary>
        private bool _isAppRunning;

        internal static string AppVersion => _appVersion; 

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(AppSettings.SyncFusionLicenseKey);
            
            // Đặt ngôn ngữ cho App dựa vào property đã lưu, nếu không có thì đặt tiếng Việt làm mặc định
            SetAppLanguage();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IPropertyService, PropertyService>();
            containerRegistry.RegisterForNavigation<MainPage, MainContentPageVM>();

        }

        protected override async void OnStart()
        {
            base.OnStart();
            // Init AppCenter service
            InitializeAppCenterService();

            // Thực hiện kiểm tra trạng thái kết nối internet của thiêt bị
            InitializeNetworkMonitor();

            // Version Tracking
            InitialVersionTracking();

            
            await NavigationService.NavigateAsync("/MainPage",
                new NavigationParameters($"?{AppConstants.NavigationParameter.OnAppStart}=true"));
        }
        private void InitialVersionTracking()
        {
            VersionTracking.Track();

            _appVersion = $"{VersionTracking.CurrentVersion}({VersionTracking.CurrentBuild})";
        }

        private void InitializeAppCenterService()
        {
            // add SDK support for AppCenter.ms
            if (!AppCenter.Configured)
                Push.PushNotificationReceived += OnPushNotificationReceived;

            // AppCenter.start after
            AppCenter.Start(AppCenterConfigurations.iOSAppSecrect +
                            AppCenterConfigurations.AndroidAppSecrect,
                typeof(Analytics), typeof(Crashes), typeof(Distribute), typeof(Push));
        }
        private void OnPushNotificationReceived(object sender, PushNotificationReceivedEventArgs e)
        {
            // Add the notification message and title to the message
            var summary = "Push notification received:" + $"\n\tNotification title: {e.Title}" +
                          $"\n\tMessage: {e.Message}";

            // If there is custom data associated with the notification,
            // print the entries
            if (e.CustomData != null)
            {
                summary += "\n\tCustom data:\n";
                foreach (var key in e.CustomData.Keys)
                    summary += $"\t\t{key} : {e.CustomData[key]}\n";
            }

            // Send the notification summary to debug output
            Debug.WriteLine(summary);

            // Trên iOS thì dùng alert của system luôn, nên không cần show notify lên nữa.
            // Android thì cần show
            //if (Device.RuntimePlatform == Device.Android)
            //    CrossLocalNotifications.Current.Show(e.Title, e.Message, 0);
        }
        private void InitializeNetworkMonitor()
        {
            if (!_isAppRunning)
                _isAppRunning = true;

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        /// <summary>
        /// Kiểm tra trạng thái kết nối internet của thiết bị
        /// </summary>
        public void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            //if (_isAppRunning)
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        if (!NetworkStateMonitor.NetworkIsReady() && !IsNetworkDownPopupDisplayed)
            //        {
            //            IsNetworkDownPopupDisplayed = true;
            //            DisplayPopupPage(nameof(NetworkErrorPopupPage));
            //        } else if (NetworkStateMonitor.NetworkIsReady() && IsNetworkDownPopupDisplayed)
            //        {
            //            IsNetworkDownPopupDisplayed = false;
            //            DisposePopupPage(nameof(NetworkErrorPopupPage));
            //        }
            //    });
            //}
        }
        private void SetAppLanguage()
        {
            var propertyService = Container.Resolve<IPropertyService>();
            var currentLanguageId = propertyService.Exists(AppSettings.Language)
                ? propertyService.GetValueAsync<int>(AppSettings.Language)
                : AppSettings.LanguageVI.Id;

            CrossMultilingual.Current.CurrentCultureInfo =
                new CultureInfo(AppSettings.LanguageList.First(l => l.Id == currentLanguageId).CultureName);

            AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
        }
    }
}