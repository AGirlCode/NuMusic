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
        private LabelScrollAnimation _labelAnimation;
        private string _titlePrev;
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

        private async void TitleLabel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                if (e != null && e.PropertyName == "Text")
                {
                    Debug.WriteLine("Property " + e.PropertyName);
                    if (_animation != null)
                        _animation.Stop();
                    await TitleLabel.TranslateTo(0, 0, 100);
                    var label = (Label)sender;
                    if (!string.IsNullOrEmpty(label.Text) && label.Text != _titlePrev)
                    {
                        _titlePrev = label.Text;
                        _labelAnimation = new LabelScrollAnimation();
                        _labelAnimation.RegisterScroll(TitleLabel, TitleScrollView);
                    }
                }
            } catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }
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


    /// <summary>
    /// Lớp chứa animation để cuộn tên bài hát
    /// </summary>
    class LabelScrollAnimation
    {
        private bool _isRight;
        public bool IsReturn;

        public LabelScrollAnimation()
        {
            IsReturn = true;
        }

        public void RegisterScroll(Label nameStock, ScrollView viewScroll)
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(5000), () =>
            {
                Console.WriteLine("RegisterScroll Title Song");
                if (!IsReturn)
                    return IsReturn;
                if (nameStock.Text == null || viewScroll.Width >= nameStock.Width)
                    return false;
                Task.Run(async () =>
                {
                    if (_isRight)
                    {
                        _isRight = false;
                        await nameStock.TranslateTo(16, 0, 5000);
                    } else
                    {
                        _isRight = true;
                        await nameStock.TranslateTo((-1) * ((nameStock.Width - viewScroll.Width) + 16), 0, 5000);
                    }
                });
                return IsReturn;
            });
        }
         

        public void Stop()
        {
            IsReturn = false;
        }
    }
}