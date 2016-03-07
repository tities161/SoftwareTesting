using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;
using Testing;
using System.IO;




namespace UnitTest
{
    [TestFixture]
    public class Test
    {

        private Controller controller;

        [SetUp]
        public void Setup()
        {
            controller = new Controller();
        }

        [Test]
        public void LoadList_Test()
        {
            // Act
            controller.LoadList();

            // Assert
            Assert.AreEqual(2,controller.Exps.Count);
            Assert.AreEqual("banh ngot", controller.Exps.FirstOrDefault().Title);
        }

        [Test]
        public void Add_Test()
        {
            // Arrange
            string title = "A";
            float cost = 10000;
            string date = DateTime.Now.ToString();
           
            // Act
            controller.add(date,title,cost);
           
            // Assert
            Assert.AreEqual(1, controller.Exps.Count);
            Assert.AreEqual("A", controller.Exps.FirstOrDefault().Title);

        }

        [Test]
        public void CalTotal_Test()
        {
            // Arrange
            controller.add(DateTime.Now.ToString(), "A", 10000);
            controller.add(DateTime.Now.ToString(), "B", 20000);


            // Act
            float total = controller.CalTotal();

            // Assert
            Assert.AreEqual(30000, total);
        }

        [Test]
        public void CalAva_Test()
        {
            // Arrange
            controller.add(DateTime.Now.ToString(), "A", 5000);
            controller.add(DateTime.Now.ToString(), "B", 3000);


            // Act
            float ava = controller.CalAva();

            // Assert
            Assert.AreEqual(12000, ava);
        }

        [Test]
        public void CalAva_Negative_Test()
        {
            // Arrange
            controller.add(DateTime.Now.ToString(), "A", 18000);
            controller.add(DateTime.Now.ToString(), "B", 3000);


            // Act
            float ava = controller.CalAva();

            // Assert
            Assert.AreEqual(-1000, ava);
        }
    }
}
