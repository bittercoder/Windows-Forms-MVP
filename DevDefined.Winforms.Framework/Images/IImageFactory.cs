using System;
using System.Drawing;

namespace DevDefined.Winforms.Framework.Images
{
    public interface IImageFactory
    {
        Image GetImageByUri(Uri uri);
    }
}