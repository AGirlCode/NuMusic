using NuMusic.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Forms;

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
        private bool _isStopped;

        private IAudioPlayerService _audioPlayer;
        /// <summary>
        /// Playing or pause
        /// </summary>
        public bool IsPlayingMusic { get => _isPlayingMusic; set => SetProperty(ref _isPlayingMusic, value); }

        public TYPE_PLAY_MUSIC TypePlayMusic { get => _typePlayMusic; set => SetProperty(ref _typePlayMusic, value); }

        public HomeContentViewVM(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            IsPlayingMusic = false;
            TypePlayMusic = TYPE_PLAY_MUSIC.PLAY_REPEAT_ALL;
            _audioPlayer = DependencyService.Get<IAudioPlayerService>();
            _audioPlayer.OnFinishedPlaying = () =>
            {
                _isStopped = true;
            };
            _isStopped = true;
        }

        public void PlaySongImageClick()
        {
            if (_audioPlayer == null)
                _audioPlayer = DependencyService.Get<IAudioPlayerService>();

            if (IsPlayingMusic)
            {
                if (_isStopped)
                {
                    _isStopped = false;
                    _audioPlayer.Play("huongtocmanon.mp3");
                } else
                    _audioPlayer.Play();
            } else
            {
                _audioPlayer.Pause();
            }
        }

        public void PreviousSongImageClicked()
        {
        }

        public void NextSongImageClicked()
        {
        }

        public void TypePlaysongImageClicked()
        {

        }
    }
}
