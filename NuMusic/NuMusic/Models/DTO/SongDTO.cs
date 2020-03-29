using Prism.Mvvm;

namespace NuMusic.Models.DTO
{
    public class SongDTO : BindableBase
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Comments { get; set; }
        /// <summary>
        /// lời bài hát
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// thời lượng file (ex: 4:30s)
        /// </summary>
        public string Length { get; set; }
        /// <summary>
        /// kích thước file (ex: 2.34M)
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// nghệ sỹ biểu diễn
        /// </summary>
        public string ContributingArtists { get; set; }
        /// <summary>
        /// thuộc album nào
        /// </summary>
        public string Album { get; set; }
        /// <summary>
        /// định dạng file .mp3, .mp4
        /// </summary>
        public string ItemType { get; set; }
    }
}
