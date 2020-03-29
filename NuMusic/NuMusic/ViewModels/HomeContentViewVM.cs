using Prism.Commands;
using Prism.Navigation;
using System;
using System.Windows.Input;

namespace NuMusic.ViewModels
{
    public enum TYPE_PLAY_MUSIC
    {
        PLAY_REPEAT_ALL,
        PLAY_REPEAT_ONE,
        PLAY_RANDOM
    }
    public class HomeContentViewVM : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private bool _isPlayingMusic;
        private TYPE_PLAY_MUSIC _typePlayMusic;

        /// <summary>
        /// Playing or pause
        /// </summary>
        public bool IsPlayingMusic { get => _isPlayingMusic; set => SetProperty(ref _isPlayingMusic, value); }

        public TYPE_PLAY_MUSIC TypePlayMusic { get => _typePlayMusic; set => SetProperty(ref _typePlayMusic, value); }

        public ICommand TypePlaysongImageClickedCommand
        { get; set; }
        public ICommand PreviousSongImageClickedCommand { get; set; }
        public ICommand PlaySongImageClickCommand { get; set; }
        public ICommand NextSongImageClickedCommand { get; set; }
        public HomeContentViewVM(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            IsPlayingMusic = false;
            TypePlayMusic = TYPE_PLAY_MUSIC.PLAY_REPEAT_ALL;
            TypePlaysongImageClickedCommand = new DelegateCommand(() => TypePlaysongImageClicked());
            PreviousSongImageClickedCommand = new DelegateCommand(() => PreviousSongImageClicked());
            PlaySongImageClickCommand = new DelegateCommand(() => PlaySongImageClick());
            NextSongImageClickedCommand = new DelegateCommand(() => NextSongImageClicked());
        }

        private void PlaySongImageClick()
        {
        }

        private void PreviousSongImageClicked()
        {
        }

        private void NextSongImageClicked()
        {
        }

        private void TypePlaysongImageClicked()
        {

        }
    }
}
