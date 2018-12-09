using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestContainer
{
    public partial class MainPage : ContentPage
    {
        bool t = true;

        public MainPage()
        {
            InitializeComponent();
        }
            /*List<string> pageList = new List<string>
            {
                "p1.jpg",
                "p2.jpg",
                "p3.jpg"
            };
        
            view.ItemsSource = pageList;
        }


        private double width = 0;
        private double height = 0;
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            App.ScreenWidth = width;
            App.ScreenHeight = height;


            if (!Equals(this.width, width) || !Equals(this.height, height))
            {
                this.width = width;
                this.height = height;

                //reconfigure layout if android
                if (Device.RuntimePlatform == Device.Android)
                {
                    view.Orientation = CarouselView.FormsPlugin.Abstractions.CarouselViewOrientation.Vertical;
                    view.Orientation = CarouselView.FormsPlugin.Abstractions.CarouselViewOrientation.Horizontal;
                }
            }

        }

        public void ImageZoomedIn(bool zoomedIn)
        {
            if(zoomedIn == true)
            {
                view.IsSwipeEnabled = false;
            }
            else if(zoomedIn == false)
            {
                view.IsSwipeEnabled = true;
            }
        }*/
    }
}
