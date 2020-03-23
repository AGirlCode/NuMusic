using System;
using System.Collections.Generic;
using System.Text;

namespace NuMusic.Services
{
    public interface IAudioPlayerService
    {
        void Play(string pathToAudioFile);
        void Play();
        void Pause();
        Action OnFinishedPlaying { get; set; }
    }
}
