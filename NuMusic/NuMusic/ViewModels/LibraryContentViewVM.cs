using NuMusic.Models.DTO;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace NuMusic.ViewModels
{
    public class LibraryContentViewVM : ViewModelBase
    {
        private string _tesst;
        private ObservableCollection<SongDTO> _songList;
        private readonly INavigationService _navigationService;


        public ObservableCollection<SongDTO> SongList { get => _songList; set => SetProperty(ref _songList, value); }

        public LibraryContentViewVM(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;


            SongList = new ObservableCollection<SongDTO>()
            {
                new SongDTO(){Title = "Hương tóc mạ non", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Về đâu mái tóc người thương", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non 1", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non 2", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non3 ", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non4", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non5", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non6", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non7", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non8", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non9", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non9", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non91", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non92", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non93", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non94", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non95", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non96", ContributingArtists ="Quốc Đại", Length ="4:30"},
                new SongDTO(){Title = "Hương tóc mạ non97", ContributingArtists ="Quốc Đại", Length ="4:30"}
            };
        }
    }
}
