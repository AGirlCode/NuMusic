using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Diagnostics;

namespace NuMusic.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible, IInitialize
    {

        protected INavigationService NavigationService { get; private set; }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        /// <summary>
        /// Gọi khi chuyển sang Page khác
        /// Stop timer, truyền tín hiệu tới page khác
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        { 
        }
        /// <summary>
        /// Gọi khi mở Page
        /// get data from Parameters, start timer
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            var currentUri = NavigationService.GetNavigationUriPath(); 
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
            //MessagingCenter.Unsubscribe<App>((App)Application.Current,
            //    AppSettings.NetworkDownMessaging);
        }

        public void DisplayPopupPage(string popupPage)
        {
            var navigationUriPath = NavigationService.GetNavigationUriPath();

            Debug.WriteLine($"{DateTime.Now} : Display popup <{popupPage}>");
            Debug.WriteLine($"{DateTime.Now} : Navigation stack before <{navigationUriPath}>");

            if (!string.IsNullOrWhiteSpace(popupPage))
                NavigationService.NavigateAsync(popupPage);

            navigationUriPath = NavigationService.GetNavigationUriPath();
            Debug.WriteLine($"{DateTime.Now} : Navigation stack after <{navigationUriPath}>");

        }
        public void DisposePopupPage(string popupPage)
        {
            Debug.WriteLine($"{DateTime.Now} : Dispose popup <{popupPage}>");

            var navigationUriPath = NavigationService.GetNavigationUriPath();

            Debug.WriteLine($"{DateTime.Now} : Navigation stack before <{navigationUriPath}>");


            if (!string.IsNullOrWhiteSpace(popupPage) && navigationUriPath.Contains(popupPage))
                NavigationService.GoBackAsync();

            navigationUriPath = NavigationService.GetNavigationUriPath();
            Debug.WriteLine($"{DateTime.Now} : Navigation stack after <{navigationUriPath}>");

        }

        public void Initialize(INavigationParameters parameters)
        {
            OnNavigatingTo(parameters);
        }
    }
}
