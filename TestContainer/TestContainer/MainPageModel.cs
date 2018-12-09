using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestContainer
{
    public class MainPageModel
    {

        public void ImageZoomedIn(bool zoomedIn)
        {
            MainPage currPage;

            int index = Application.Current.MainPage.Navigation.NavigationStack.Count - 1;
            currPage = (MainPage)Application.Current.MainPage.Navigation.NavigationStack[index];

            //currPage.ImageZoomedIn(zoomedIn);
        }
    }
}
