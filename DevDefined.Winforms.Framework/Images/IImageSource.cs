using System;
using System.Drawing;

namespace DevDefined.Winforms.Framework.Images
{
    public interface IImageSource
    {
        Image GetImage(Uri uri);
        bool CanHandleUri(Uri uri);
    }
}