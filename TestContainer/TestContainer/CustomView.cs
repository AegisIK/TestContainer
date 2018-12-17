using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace TestContainer
{
    public class CustomView : View
    {
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
    propertyName: "Source",
    returnType: typeof(FileImageSource),
    declaringType: typeof(string));

        public FileImageSource Source
        {
            get { return (FileImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
    }
}
