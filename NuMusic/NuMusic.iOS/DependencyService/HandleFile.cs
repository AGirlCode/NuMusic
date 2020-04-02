using NuMusic.DependencyServices;
using NuMusic.iOS.DependencyService;
using NuMusic.Models;
using QuickLook;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(HandleFile))]
namespace NuMusic.iOS.DependencyService
{
    public class HandleFile : IHandleFile
    {
        public string CheckExist(string fileName)
        {
            string root = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
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

            return null;
        }

        public void Delete()
        {
            try
            {
                //string fileName = "news.pdf";
                string root = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                //đường dẫn folder chính chưa tin tức
                string pathDirectory = root + "/NuMusic";
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
            } catch (Exception e)
            {

            }
        }

        public IEnumerable<AudioModel> GetListAudioModel()
        {
            throw new NotImplementedException();
        }

        public string GetPathFolder()
        {
            string root = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (!Directory.Exists(root + "/NuMusic"))
            {
                Directory.CreateDirectory(root + "/NuMusic");
            }
            if (!Directory.Exists(root + "/NuMusic/" + DateTime.Now.ToString("dd-MM-yyyy")))
            {
                Directory.CreateDirectory(root + "/NuMusic/" + DateTime.Now.ToString("dd-MM-yyyy"));
            }
            return root + "/NuMusic/" + DateTime.Now.ToString("dd-MM-yyyy");
        }

        public void Open(string fileName, byte[] stream)
        {
            string exception = string.Empty;
            string path = GetPathFolder();
            string filePath = Path.Combine(path, fileName);

            try
            {
                FileStream fileStream = File.Open(filePath, FileMode.Create);
                var streamMemory = new MemoryStream(stream);
                streamMemory.Position = 0;
                streamMemory.CopyTo(fileStream);
                fileStream.Flush();
                fileStream.Close();
            } catch (Exception e)
            {
                exception = e.ToString();
            }
            if (exception != string.Empty)
                return;
            UIViewController currentController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (currentController.PresentedViewController != null)
                currentController = currentController.PresentedViewController;
            UIView currentView = currentController.View;

            QLPreviewController qlPreview = new QLPreviewController();
            QLPreviewItem item = new QLPreviewItemBundle(fileName, filePath);
            qlPreview.DataSource = new PreviewControllerDS(item);

            //UIViewController uiView = currentView as UIViewController;

            currentController.PresentViewController((UIViewController)qlPreview, true, (Action)null);
        }

        public void OpenFileExist(string pathFile, string fileName)
        {

            UIViewController currentController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (currentController.PresentedViewController != null)
                currentController = currentController.PresentedViewController;
            UIView currentView = currentController.View;

            QLPreviewController qlPreview = new QLPreviewController();
            QLPreviewItem item = new QLPreviewItemBundle(fileName, pathFile);
            qlPreview.DataSource = new PreviewControllerDS(item);

            //UIViewController uiView = currentView as UIViewController;

            currentController.PresentViewController((UIViewController)qlPreview, true, (Action)null);
        }
    }
}