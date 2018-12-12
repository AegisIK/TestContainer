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
using Xamarin.Forms.Platform.Android;
using static Android.Views.ScaleGestureDetector;
using Android.Views.Animations;
using Xamarin.Forms;

using TestContainer.Droid;
using Android.Graphics;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ScrollView), typeof(ZoomScrollViewRenderer))]
namespace TestContainer.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class ZoomScrollViewRenderer: ScrollViewRenderer, IOnScaleGestureListener
    {
        private ScaleGestureDetector mScaleDetector;
        private float mScaleFactor = 1.0f;



        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {

            base.OnElementChanged(e);
            mScaleDetector = new ScaleGestureDetector(Context, this);

        }

        public override bool OnTouchEvent(MotionEvent ev)
        {
            //Let the ScaleGestureDetector inspect all events.
            mScaleDetector.OnTouchEvent(ev);
            return true;
        }

        public override void OnDrawForeground(Canvas canvas)
        {
            base.OnDrawForeground(canvas);

            canvas.Save();
            canvas.Scale(5, 5);

            canvas.Restore();
        }

        public bool OnScale(ScaleGestureDetector detector)
        {
            mScaleFactor *= detector.ScaleFactor;

            //Don't let the object get too small or too large
            mScaleFactor = Math.Max(0.1f, Math.Min(mScaleFactor, 5.0f));

            Invalidate();
            
            return true;
        }

        public bool OnScaleBegin(ScaleGestureDetector detector)
        {
            return true;
        }

        public void OnScaleEnd(ScaleGestureDetector detector)
        {

        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}