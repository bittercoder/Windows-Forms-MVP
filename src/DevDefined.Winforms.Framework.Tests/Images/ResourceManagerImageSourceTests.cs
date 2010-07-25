using System;
using System.Drawing;
using DevDefined.Winforms.Framework.Images;
using Xunit;

namespace DevDefined.Winforms.Framework.Tests.Images
{
    public class ResourceManagerImageSourceTests
    {
        private readonly ResourceManagerImageSource source = new ResourceManagerImageSource();

        [Fact]
        public void CanHandleUri()
        {
            Assert.True(source.CanHandleUri(new Uri(CoreImages.ActualSizeHS)));
            Assert.False(source.CanHandleUri(new Uri("http://localhost/test.html")));
        }

				[Fact]
        public void GetImage()
        {
            Image image = source.GetImage(new Uri(CoreImages.ActualSizeHS));
            Assert.NotNull(image);
        }
    }
}