using NUnit.Framework;
using System.Drawing;
using System;
using View;

namespace ViewTest
{
    //[TestFixture()]
    public class TextureFactoryTest
    {
        [Test()]
        public void TestFactory()
        {
			Assert.IsInstanceOfType(typeof(TextureBrush), TextureFactory.CreateBrush("je n'existe pas"));
			Assert.IsInstanceOfType(typeof(TextureBrush), TextureFactory.CreateBrush("tile"));
        }
    }
}
