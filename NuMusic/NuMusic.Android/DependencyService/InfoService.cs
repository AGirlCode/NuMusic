using Android.Provider;
using Java.IO;
using NuMusic.Droid.DependencyService;
using NuMusic.Models;
using NuMusic.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Dependency(typeof(InfoService))]
namespace NuMusic.Droid.DependencyService
{
    public class InfoService : IInfoService
    {
        public IEnumerable<AudioModel> GetListAudioModel()
        {
            //try
            //{
            //    File rootFolder = new File("/audio");
            //    File[] files = rootFolder.ListFiles(); //here you will get NPE if directory doesn't contains  any file,handle it like this.
            //    foreach (File file in files)
            //    {
            //        if (file.IsDirectory)
            //        {
            //            var temp = GetListAudioModel(file.AbsolutePath);
            //            if (temp != null)
            //            {
            //                fileList.addAll(temp);
            //            } else
            //            {
            //                break;
            //            }
            //        } else if (file.Name.EndsWith(".mp3"))
            //        {
            //            HashMap<String, String> song = new HashMap<>();
            //            song.put("file_path", file.AbsolutePath);
            //            song.put("file_name", file.Name);
            //            fileList.add();
            //        }
            //    }
            //    return fileList;
            //} catch (Exception e)
            //{
            //    return null;
            //}
           
        }
    }

        private object getPlayList(object p)
        {
            throw new NotImplementedException();
        }

        private object GetListAudioModel(object p)
        {
            throw new NotImplementedException();
        }
    }