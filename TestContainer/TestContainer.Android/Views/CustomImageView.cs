using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Support.V7.Widget;
using Android.Graphics;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ContentView), typeof(TestContainer.Droid.Views.CustomImageView))]
namespace TestContainer.Droid.Views
{
    public class CustomImageView : Android.Views.View
    {
        string ImageSource;
        Bitmap bitmap;
        public CustomImageView(Context context) : base (context)
        {
            
        }

        public CustomImageView(Context context, IAttributeSet attrs) : base(context, attrs)
        {

        }

        private void Initialize(Context context, IAttributeSet attrs = null)
        {
            
            if(attrs != null)
            {
                //Contains the values set for the styleable attributes declared in attrs.xml
                var array = context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.CustomImageView, 0, 0);
                ImageSource = array.GetString(Resource.Styleable.CustomImageView_Source);

                bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.p1);
            }
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            canvas.DrawBitmap(bitmap, 0, 0, null);
        }
    }
}