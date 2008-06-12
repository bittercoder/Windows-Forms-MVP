using System;
using System.Drawing;
using DevDefined.Winforms.Framework.Images;
using NUnit.Framework;

namespace DevDefined.Winforms.Framework.Tests.Images
{
    [TestFixture]
    public class ResourceManagerImageSourceTests
    {
        private readonly ResourceManagerImageSource source = new ResourceManagerImageSource();

        [Test]
        public void CanHandleUri()
        {
            Assert.IsTrue(source.CanHandleUri(new Uri(CoreImages.ActualSizeHS)));
            Assert.IsFalse(source.CanHandleUri(new Uri("http://localhost/test.html")));
        }

        [Test]
        public void GetImage()
        {
            Image image = source.GetImage(new Uri(CoreImages.ActualSizeHS));
            Assert.IsNotNull(image);
        }
    }
}