using FFImageLoading.Svg.Forms;
using Microsoft.AppCenter.Crashes;
using NuMusic.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NuMusic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeContentView : ContentView
    {
        private ImageRotationAnimation _animation;
        public static readonly BindableProperty DataSourceProperty =
               BindableProperty.Create(nameof(DataSource), typeof(HomeContentViewVM),
                   typeof(HomeContentView));

        public HomeContentViewVM DataSource
        {
            get { return (HomeContentViewVM)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        public HomeContentView()
        {
            InitializeComponent();

            _animation = new ImageRotationAnimation();
            _animation.RegisterRotation(PlayingImg);

        }

        private void TypePlaySongImage_Tapped(object sender, EventArgs e)
        {
            var viewModel = DataSource;

            switch (viewModel.TypePlayMusic)
            {
                case TYPE_PLAY_MUSIC.PLAY_REPEAT_ALL:
                {
                    viewModel.TypePlayMusic = TYPE_PLAY_MUSIC.PLAY_REPEAT_ONE;
                    TypePlaySongImage.Source = SvgImageSource.FromResource("NuMusic.Resources.Svg.icon_play_repeat1.svg");
                    break;
                }
                case TYPE_PLAY_MUSIC.PLAY_REPEAT_ONE:
                {
                    viewModel.TypePlayMusic = TYPE_PLAY_MUSIC.PLAY_RANDOM;
                    TypePlaySongImage.Source = SvgImageSource.FromResource("NuMusic.Resources.Svg.icon_play_random.svg");
                    break;
                }
                case TYPE_PLAY_MUSIC.PLAY_RANDOM:
                {
                    viewModel.TypePlayMusic = TYPE_PLAY_MUSIC.PLAY_REPEAT_ALL;
                    TypePlaySongImage.Source = SvgImageSource.FromResource("NuMusic.Resources.Svg.icon_play_repeat.svg");
                    break;
                }
            }
        }

        private void PreviousSongImage_Tapped(object sender, EventArgs e)
        {

        }

        private void PlaySongImage_Tapped(object sender, EventArgs e)
        {
            var viewModel = DataSource;
            var isPlaying = viewModel.IsPlayingMusic;
            viewModel.IsPlayingMusic = !isPlaying;
            if (viewModel.IsPlayingMusic)
            {
                _animation.Start();
                PlaySongImage.Source = SvgImageSource.FromResource("NuMusic.Resources.Svg.icon_play.svg");
            } else
            {
                _animation.Stop();
                PlaySongImage.Source = SvgImageSource.FromResource("NuMusic.Resources.Svg.icon_pause.svg");
            }
        }

        private void NextSongImage_Tapped(object sender, EventArgs e)
        {

        }
    }
    class ImageRotationAnimation
    {
        int rotation = 0;
        bool IsPlaying = false;
        public ImageRotationAnimation()
        {
        }

        public void Start()
        {
            IsPlaying = true;
        }
        public void RegisterRotation(SvgCachedImage image)
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(2), () =>
            {
                Console.WriteLine("RegisterScroll1 RegisterScroll");
                if (!IsPlaying)
                    return true;

                Task.Run(async () =>
                {
                    if (rotation < 360)
                        image.Rotation = rotation++;
                    else
                        rotation = 0;
                });
                return true;
            });
        }

        public void Stop()
        {
            IsPlaying = false;
        }
    }
}