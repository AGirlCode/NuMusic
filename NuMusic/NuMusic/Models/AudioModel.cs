using Prism.Mvvm;

namespace NuMusic.Models
{
    public class AudioModel : BindableBase
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
    }
}
