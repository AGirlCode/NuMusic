using Android.Provider;
using Java.IO;
using NuMusic.Droid.DependencyService;
using NuMusic.Models;
using NuMusic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

[assembly: Dependency(typeof(InfoService))]
namespace NuMusic.Droid.DependencyService
{
    public class InfoService : IInfoService
    {
        public ObservableCollection<AudioModel> GetListAudioModel( )
        {
            final String MEDIA_PATH = Environment.getExternalStorageDirectory() + "";

            var fileList = new ObservableCollection<AudioModel>();

            try
            {
                File rootFolder = new File(filePath);
                File[] files = rootFolder.ListFiles(); //here you will get NPE if directory doesn't contains  any file,handle it like this.
                foreach (File file in files)
                {
                    if (file.IsDirectory)
                    {
                        var itemFile = GetListAudioModel(file.AbsolutePath);
                        if (itemFile != null)
                        {
                            foreach (var item in itemFile)
                                fileList.Add(item);
                        } else
                        {
                            break;
                        }
                    } else if (file.Name.EndsWith(".mp3"))
                    {
                        fileList.Add(new AudioModel() { Name = file.Name, Path = file.Path });
                    }
                }
                return fileList;
            } catch (Exception e)
            {
                return new ObservableCollection<AudioModel>();
            }

        }
    }
}