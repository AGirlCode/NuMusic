using NuMusic.Models;
using System.Collections.Generic;

namespace NuMusic.DependencyServices
{
    public interface IHandleFile
    {
        /// <summary>
        /// Hàm mở file mp3 với ten file
        /// </summary>
        /// <param name="stream"></param>
        void Open(string fileName, byte[] stream);
        /// <summary>
        /// Hàm xóa file pdf
        /// </summary>
        void Delete();
        /// <summary>
        /// Kiểm tra tồn tại của file hay ko
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>trả về đường dẫn file đó trong local</returns>
        string CheckExist(string fileName);
        /// <summary>
        /// Mở một file mp3 đã tồn tại rồi
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="fileName"></param>
        void OpenFileExist(string pathFile, string fileName);
        /// <summary>
        /// Lấy đường dẫn folder char ezmobiletrading
        /// </summary>
        /// <returns></returns>
        string GetPathFolder();

        IEnumerable<AudioModel> GetListAudioModel();
    }
}
