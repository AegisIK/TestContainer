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

            List<string> pageList = new List<string>
            {
                "p1.jpg",
                "p2.jpg",
                "p3.jpg"
            };
        
            view.ItemsSource = pageList;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            App.ScreenWidth = width;
            App.ScreenHeight = height;

            double _width;
            double _height;


            if( width > height & t == true)
            {
                _width = width;
                _height = height;
                t = false;
                ForceLayout();
            }
            
        }
    }
}
