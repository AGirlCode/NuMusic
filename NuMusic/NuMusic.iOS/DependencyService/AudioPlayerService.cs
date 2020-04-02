using AVFoundation;
using Foundation;
using NuMusic.DependencyServices;
using NuMusic.iOS.DependencyService;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioPlayerService))]
namespace NuMusic.iOS.DependencyService
{
    public class AudioPlayerService : IAudioPlayerService
    {
        private AVAudioPlayer _audioPlayer = null;
        public Action OnFinishedPlaying { get; set; }

        public void Play(string pathToAudioFile)
        {
            // Check if _audioPlayer is currently playing  
            if (_audioPlayer != null)
            {
                _audioPlayer.FinishedPlaying -= Player_FinishedPlaying;
                _audioPlayer.Stop();
            }

            string localUrl = pathToAudioFile;
            _audioPlayer = AVAudioPlayer.FromUrl(NSUrl.FromFilename(localUrl));
            _audioPlayer.FinishedPlaying += Player_FinishedPlaying;
            _audioPlayer.Play();
        }
        private void Player_FinishedPlaying(object sender, AVStatusEventArgs e)
        {
            OnFinishedPlaying?.Invoke();
        }
        public void Play()
        {
            _audioPlayer?.Play();
        }
        public void Pause()
        {
            _audioPlayer?.Pause();
        }

    }
}