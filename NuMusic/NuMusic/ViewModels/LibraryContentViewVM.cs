using Prism.Navigation;

namespace NuMusic.ViewModels
{
    public class LibraryContentViewVM : ViewModelBase
    {
        private string _tesst;
        private readonly INavigationService _navigationService;

        public string Tesst => "3242424";
        public LibraryContentViewVM(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        } 
    }
}
