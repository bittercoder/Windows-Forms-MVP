using System;
using System.Drawing;
using System.Reflection;
using System.Resources;

namespace DevDefined.Winforms.Framework.Images
{
    public class ResourceManagerImageSource : IImageSource
    {
        #region IImageSource Members

        public Image GetImage(Uri uri)
        {
            Assembly assembly = Assembly.Load(uri.Host);
            var manager = new ResourceManager(uri.Segments[1].Replace("/", ""), assembly);
            return (Image) manager.GetObject(uri.Segments[2].Replace("/", ""));
        }

        public bool CanHandleUri(Uri uri)
        {
            return (uri.Scheme == "res");
        }

        #endregion
    }
}