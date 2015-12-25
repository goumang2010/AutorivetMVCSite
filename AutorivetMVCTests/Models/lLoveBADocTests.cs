using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutorivetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutorivetMVC.Models.Tests
{
    [TestClass()]
    public class lLoveBADocTests
    {
        [TestMethod()]
        public void FetchDataTest()
        {
            lLoveBADoc f = new lLoveBADoc();
            var ff =f.FetchData("BAPS");
           
            var res = ff.Result;
           
            Assert.AreEqual(ff.Result.Count(), 5);

        }
    }
}