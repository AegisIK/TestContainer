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
using TestContainer;

using TestContainer.Droid;
using Android.Graphics;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ScrollView), typeof(ZoomScrollViewRenderer))]
namespace TestContainer.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class ZoomScrollViewRenderer : ScrollViewRenderer, IOnScaleGestureListener
    {
        private float mScale = 1f;
        private static int INVALID_POINTER_ID = 999;
        private int mActivePointerId = INVALID_POINTER_ID;

        private float mLastTouchX;
        private float mLastTouchY;

        private float mPosX = 0;
        private float mPosY = 0;


        private ScaleGestureDetector mScaleDetector;


        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {

            base.OnElementChanged(e);
            mScaleDetector = new ScaleGestureDetector(Context, this);

        }

        
        public override bool DispatchTouchEvent(MotionEvent e)
        {
            base.DispatchTouchEvent(e);

            MotionEventActions action = e.ActionMasked;

            switch(action)
            {
                case MotionEventActions.Down:
                    int pointerIndex = e.ActionIndex;
                    float x = e.GetX(pointerIndex);
                    float y = e.GetY(pointerIndex);

                    //Remember where we started (for dragging)
                    mLastTouchX = x;
                    mLastTouchY = y;

                    //Save the ID of this pointer (for dragging)
                    mActivePointerId = e.GetPointerId(0);
                    break;

                case MotionEventActions.Move:
                    //Find the index of the active pointer and fetch its position
                    int activePointerIndex = e.GetPointerId(mActivePointerId);

                    float x2 = e.GetX(activePointerIndex);
                    float y2 = e.GetY(activePointerIndex);

                    //Calculate the distance moved
                    float dx = x2 - mLastTouchX;
                    float dy = y2 - mLastTouchY;

                    mPosX += dx;
                    mPosY += dy;

                    TranslateAnimation translateAnimation = new TranslateAnimation(mPosX, dx, mPosY, dy);
                    translateAnimation.Duration = 0;
                    translateAnimation.FillAfter = true;
                    StartAnimation(translateAnimation);
                    //Remember this touch position for the next move event
                    mLastTouchX = x2;
                    mLastTouchY = y2;
                    break;

                case MotionEventActions.Up:
                    mActivePointerId = INVALID_POINTER_ID;
                    break;

                case MotionEventActions.Cancel:
                    mActivePointerId = INVALID_POINTER_ID;
                    break;

                case MotionEventActions.PointerUp:
                    int pointerIndex2 = e.ActionIndex;
                    int pointerId2 = e.GetPointerId(pointerIndex2);

                    if(pointerId2 == mActivePointerId)
                    {
                        //This was our active pointer going up. Choose a new active pointer and adjust accordingly
                        int newPointerIndex = pointerIndex2 == 0 ? 1 : 0;
                        mLastTouchX = e.GetX(newPointerIndex);
                        mLastTouchY = e.GetY(newPointerIndex);
                        mActivePointerId = e.GetPointerId(newPointerIndex);
                    
                    }
                    break;
            }
            
            return mScaleDetector.OnTouchEvent(e);
        }

        public bool OnScale(ScaleGestureDetector detector)
        {
            float scale = 1 - detector.ScaleFactor;

            float prevScale = mScale;
            mScale += scale;

            if (mScale < 0.5f) // Minimum scale condition:
                mScale = 0.5f;

            if (mScale > 1f) // Maximum scale condition:
                mScale = 1f;
            ScaleAnimation scaleAnimation = new ScaleAnimation(1f / prevScale, 1f / mScale, 1f / prevScale, 1f / mScale, detector.FocusX, detector.FocusY);
            scaleAnimation.Duration = 0;
            scaleAnimation.FillAfter = true;
            StartAnimation(scaleAnimation);
            return true;
        }

        public bool OnScaleBegin(ScaleGestureDetector detector)
        {
            return true;
        }

        public void OnScaleEnd(ScaleGestureDetector detector)
        {

        }

       /* Bitmap GetBitmap(Xamarin.Forms.Image image)
        {
            var handler = new ImageLoaderSourceHandler();
        //    return handler.LoadImageAsync(image.Source, Context, null);
        }*/


    }
#pragma warning restore CS0618 // Type or member is obsolete
}