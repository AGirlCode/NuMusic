using FFImageLoading.Svg.Forms;
using NuMusic.ViewModels;
using System;
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
    }
    class ImageRotationAnimation
    {
        int rotation = 0;
        public ImageRotationAnimation()
        {
        }

        public void RegisterRotation(SvgCachedImage image)
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(2), () =>
            {
                Console.WriteLine("RegisterScroll1 RegisterScroll");


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
        }
    }
}