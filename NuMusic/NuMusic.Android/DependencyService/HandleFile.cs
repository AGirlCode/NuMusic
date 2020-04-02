using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Java.IO;
using NuMusic.DependencyServices;
using NuMusic.Droid.DependencyService;
using NuMusic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(HandleFile))]
namespace NuMusic.Droid.DependencyService
{
    public class HandleFile : IHandleFile
    {
        public void Delete()
        {
            try
            {
                //yeu cau truy cao vung nho
                if (!CheckPermissionGranted(Manifest.Permission.WriteExternalStorage) ||
                   !CheckPermissionGranted(Manifest.Permission.ReadExternalStorage))
                {
                    RequestPermission();
                } else
                {
                    string root = GetPathSystem();
                    //đường dẫn folder chính chưa tin tức
                    string pathDirectory = root + "/EzMobileTrading";
                    //lấy danh sách các đường dẫn subfolder chưa tin tức theo ngày
                    string[] pathSubDirectory = Directory.GetDirectories(pathDirectory);
                    //Kiểm với 1 ngày trước đó
                    DateTime dateCompare = DateTime.Now.AddDays(-2);
                    if (pathSubDirectory.Length > 0)
                    {
                        //truy vấn danh sách tên folder
                        foreach (var nameFolder in pathSubDirectory)
                        {
                            var directoryInfo = new DirectoryInfo(nameFolder);
                            try
                            {
                                IFormatProvider culture = new CultureInfo("en-US", true);
                                DateTime oDate = DateTime.ParseExact(directoryInfo.Name, "dd-MM-yyyy", culture);
                                //xóa nếu ngày folder 1 ngày trước ngày hiện tại
                                if (DateTime.Compare(dateCompare, oDate) >= 0)
                                {
                                    //string[] filePaths = Directory.GetFiles(pathDirectory + "/" + nameFolder);
                                    ////xóa file
                                    //foreach (string filePath in filePaths)
                                    //    System.IO.File.Delete(filePath);
                                    //xóa folder
                                    directoryInfo.Delete(true);
                                }
                            } catch (Exception e)
                            {

                            }

                        }
                    }
                }
            } catch (Exception e)
            {

            }

        }
        public void Open(string fileName, byte[] stream)
        {
            string exception = string.Empty;
            //Mở folder với đường đãn cho trước
            Java.IO.File myDir = new Java.IO.File(GetPathFolder());
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);
            //yeu cau truy cao vung nho
            if (!CheckPermissionGranted(Manifest.Permission.WriteExternalStorage) ||
               !CheckPermissionGranted(Manifest.Permission.ReadExternalStorage))
            {
                RequestPermission();
            } else
            {
                try
                {
                    FileOutputStream outs = new FileOutputStream(file);
                    outs.Write(stream);
                    outs.Flush();
                    outs.Close();
                } catch (Exception e)
                {
                    exception = e.ToString();
                }

                if (file.Exists())
                {
                    string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                    string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                    Intent intent = new Intent(Intent.ActionView);
                    Android.Net.Uri path = FileProvider.GetUriForFile(Android.App.Application.Context, Android.App.Application.Context.PackageName + ".provider", file);
                    intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                    intent.SetDataAndType(path, mimeType);
                    intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                    Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
                }
            }


        }
        public bool CheckPermissionGranted(string Permissions)
        {
            // Check if the permission is already available.
            if (ActivityCompat.CheckSelfPermission(Forms.Context, Permissions) != Permission.Granted)
            {
                return false;
            } else
            {
                return true;
            }


        }
        /// <summary>
        /// 0 la ghi file, 1 la doc file
        /// </summary>
        /// <param name="readOrWrite"></param>
        private void RequestPermission()
        {
            ActivityCompat.RequestPermissions((Activity)Forms.Context, new String[] { Manifest.Permission.WriteExternalStorage, Manifest.Permission.ReadExternalStorage }, 0);

        }
        public string CheckExist(string fileName)
        {
            //yeu cau truy cao vung nho
            if (!CheckPermissionGranted(Manifest.Permission.WriteExternalStorage) ||
                !CheckPermissionGranted(Manifest.Permission.ReadExternalStorage))
            {
                RequestPermission();
            } else
            {
                string root = GetPathSystem();
                //đường dẫn folder chính chưa tin tức
                string pathDirectory = root + "/NuMusic/";
                try
                {
                    // tìm kiếm tên file trong folder
                    string[] filePaths = Directory.GetFiles(pathDirectory, fileName,
                                         SearchOption.AllDirectories);
                    if (filePaths != null && filePaths.Length > 0)
                    {
                        return filePaths[0];
                    }
                } catch (Exception e)
                {

                }
            }
            return null;
        }
        public void OpenFileExist(string filePath, string fileName)
        {
            //yeu cau truy cao vung nho
            if (!CheckPermissionGranted(Manifest.Permission.WriteExternalStorage) ||
               !CheckPermissionGranted(Manifest.Permission.ReadExternalStorage))
            {
                RequestPermission();
            } else
            {
                //kiểm tra đường đãn cho file
                Java.IO.File file = new Java.IO.File(filePath);
                if (file.Exists())
                {

                    string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                    string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                    Android.Net.Uri path = FileProvider.GetUriForFile(Android.App.Application.Context, Android.App.Application.Context.PackageName + ".provider", file);
                    intent.SetDataAndType(path, mimeType);
                    intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                    Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
                }
            }

        }
        public string GetPathFolder()
        {
            string root = GetPathSystem();
            //yeu cau truy cao vung nho
            if (!CheckPermissionGranted(Manifest.Permission.WriteExternalStorage) ||
               !CheckPermissionGranted(Manifest.Permission.ReadExternalStorage))
            {
                RequestPermission();
            } else
            {

                // If directory does not exist, create it. 
                if (!Directory.Exists(root + "/NuMusic"))
                {
                    try
                    {
                        Directory.CreateDirectory(root + "/NuMusic");
                    } catch (Exception e)
                    {
                        System.Console.WriteLine(e.Message);
                    }
                }
            }
            return root + "/NuMusic/" + DateTime.Now.ToString("dd-MM-yyyy");

        }
        /// <summary>
        /// Theem duong dan file 
        /// </summary>
        /// <returns></returns>
        private string GetPathSystem()
        {
            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            } else
            {
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            }
            return root;
        }

        public IEnumerable<AudioModel> GetListAudioModel()
        {
            throw new System.NotImplementedException();
        }
    }
}