using NuMusic.Services;
using Prism.Navigation;
using Xamarin.Forms;

namespace NuMusic.ViewModels
{
    public class MainContentPageVM : ViewModelBase
    {
        private HomeContentViewVM _homeContentViewVM;
        private SearchContentViewVM _searchContentViewVM;
        private LibraryContentViewVM _libraryContentViewVM;
        private readonly INavigationService _navigationService;
        private readonly IInfoService _infoService;
         public HomeContentViewVM HomeContentViewVM { get => _homeContentViewVM; set => SetProperty(ref _homeContentViewVM, value); }

        public SearchContentViewVM SearchContentViewVM { get => _searchContentViewVM; set => SetProperty(ref _searchContentViewVM, value); }
        public LibraryContentViewVM LibraryContentViewVM { get => _libraryContentViewVM; set => SetProperty(ref _libraryContentViewVM, value); }
        public string Tesst => "main";
        public MainContentPageVM(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            _infoService = DependencyService.Get<IInfoService>();   
            HomeContentViewVM = new HomeContentViewVM(_navigationService);
            SearchContentViewVM = new SearchContentViewVM(_navigationService);
            LibraryContentViewVM = new LibraryContentViewVM(_navigationService, _infoService);



        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            LibraryContentViewVM.getAllAudioFromDevice();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);


        }
    }
}
