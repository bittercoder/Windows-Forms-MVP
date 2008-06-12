using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevDefined.Winforms.Framework.Images
{
    public class ImageFactory : IImageFactory
    {
        private readonly List<IImageSource> _sources = new List<IImageSource>();

        public ImageFactory(params IImageSource[] sources)
        {
            _sources.AddRange(sources);
        }

        #region IImageFactory Members

        public Image GetImageByUri(Uri uri)
        {
            foreach (IImageSource source in _sources)
            {
                if (source.CanHandleUri(uri))
                {
                    return source.GetImage(uri);
                }
            }

            throw Error.NoImageSourceFoundToHandleUri(uri);
        }

        #endregion
    }
}