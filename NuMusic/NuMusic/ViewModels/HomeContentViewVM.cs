using Prism.Navigation;

namespace NuMusic.ViewModels
{
    public class HomeContentViewVM : ViewModelBase
    {
        private string _tesst;
        private readonly INavigationService _navigationService;

        public string Tesst { get => _tesst; set => SetProperty(ref _tesst, value); }
        public HomeContentViewVM(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Tesst = "Home";
        }
    }
}
