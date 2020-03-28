using NuMusic.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NuMusic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryContentView : ContentView
    {
        public static readonly BindableProperty DataSourceProperty =
                 BindableProperty.Create(nameof(DataSource), typeof(LibraryContentViewVM),
                     typeof(LibraryContentView));

        public LibraryContentViewVM DataSource
        {
            get { return (LibraryContentViewVM)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        public LibraryContentView()
        {
            InitializeComponent();

        }
    }
    class AnimationText
    {
        private bool _isRight;
        public bool IsReturn;

        public AnimationText()
        {
            IsReturn = true;
        }

        public void RegisterScroll(Label nameStock, ScrollView viewScroll)
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(5000), () =>
            {
                Console.WriteLine("RegisterScroll RegisterScrol");
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