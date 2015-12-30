using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutorivetMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorivetMVC.Controllers.Tests
{
    [TestClass()]
    public class PartSearchControllerTests
    {
        [TestMethod()]
        public void JsonDetailsTest()
        {
            PartSearchController f = new PartSearchController();
            var  data= f.JsonDetails("CATDrawing", "C01322100" );
            Assert.AreNotEqual(data, null);
        }
    }
}