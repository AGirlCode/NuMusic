using NuMusic.Models;
using System.Collections.ObjectModel;

namespace NuMusic.Services
{
    public interface IInfoService
    {
        ObservableCollection<AudioModel> GetListAudioModel( );
       
    }
}
