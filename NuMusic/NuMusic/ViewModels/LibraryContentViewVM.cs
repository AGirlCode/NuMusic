using Microsoft.AppCenter.Crashes;
using NuMusic.Models;
using NuMusic.Models.DTO;
using NuMusic.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NuMusic.ViewModels
{
    public class LibraryContentViewVM : ViewModelBase
    {
        private string _tesst;
        private ObservableCollection<AudioModel> _audioModels;
        private readonly INavigationService _navigationService;
        private readonly IInfoService _infoService;

        public ObservableCollection<AudioModel> AudioModels { get => _audioModels; set => SetProperty(ref _audioModels, value); }

        public LibraryContentViewVM(INavigationService navigationService, IInfoService infoService) : base(navigationService)
        {
            _navigationService = navigationService;
            _infoService = infoService;

        }
        public IEnumerable<AudioModel> getAllAudioFromDevice()
        {
            var audioList = new ObservableCollection<AudioModel>();
            try
            {
                 audioList = _infoService.GetListAudioModel( );


                
            }catch(Exception e)
            {
                Crashes.TrackError(e);
            }
            return audioList;
        }
    }
}
