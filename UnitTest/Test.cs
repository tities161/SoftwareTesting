using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;



namespace UnitTest
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void A()
        {
            Assert.AreEqual(10, 10);
        }
    }
}
