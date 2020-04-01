using NuMusic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuMusic.Services
{
    public interface IInfoService
    {
        IEnumerable<AudioModel> GetListAudioModel();
       
    }
}
