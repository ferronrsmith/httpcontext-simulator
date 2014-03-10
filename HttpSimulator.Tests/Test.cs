using System;
using System.Collections.Specialized;
using NUnit.Framework;
using Http.TestLibrary;
using System.Web;
namespace HttpSimulatorTests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void CurrentIsNotNull()
        {
            using (new HttpSimulator("/", @"c:\inetpub\").SimulateRequest())
            {
                Assert.NotNull(HttpContext.Current);
            }
        }

        /// <summary>
        /// Determines whether this instance [can get set session].
        /// </summary>
        [Test]
        public void CanGetSetSession()
        {
            using (var simulator = new HttpSimulator("/", @"c:\inetpub\").SimulateRequest())
            {
                simulator.Context.Session["Test"] = "Success";
                Assert.AreEqual("Success", simulator.Context.Session["Test"]);
            }
        }

        /// <summary>
        /// Determines whether this instance [can simulate form post].
        /// </summary>
        [Test]
        public void CanSimulateFormPost()
        {
            using (var simulator = new HttpSimulator())
            {
                var form = new NameValueCollection();
                form.Add("Test1", "Value1");
                form.Add("Test2", "Value2");
                simulator.SimulateRequest(new Uri("http://localhost/Test.aspx"), form);

                Assert.AreEqual("Value1", simulator.Context.Request.Form["Test1"]);
                Assert.AreEqual("Value2", simulator.Context.Request.Form["Test2"]);
                Assert.AreEqual(new Uri("http://localhost/Test.aspx"), simulator.Context.Request.Url);
            }

            using (var simulator = new HttpSimulator())
            {
                simulator.SetFormVariable("Test1", "Value1")
                  .SetFormVariable("Test2", "Value2")
                  .SimulateRequest(new Uri("http://localhost/Test.aspx"));

                Assert.AreEqual("Value1", simulator.Context.Request.Form["Test1"]);
                Assert.AreEqual("Value2", simulator.Context.Request.Form["Test2"]);
                Assert.AreEqual(new Uri("http://localhost/Test.aspx"), simulator.Context.Request.Url);
            }
        }
        /// <summary>
        /// Determines whether this instance [can simulate form post].
        /// </summary>
        [Test,Ignore("Does not work on mono")]
        public void CanSimulateFormPostOnHttpContext()
        {
            using (var simulator = new HttpSimulator())
            {
                var form = new NameValueCollection();
                form.Add("Test1", "Value1");
                form.Add("Test2", "Value2");
                simulator.SimulateRequest(new Uri("http://localhost/Test.aspx"), form);

                Assert.AreEqual("Value1", HttpContext.Current.Request.Form["Test1"]);
                Assert.AreEqual("Value2", HttpContext.Current.Request.Form["Test2"]);
                Assert.AreEqual(new Uri("http://localhost/Test.aspx"), HttpContext.Current.Request.Url);
            }

            using (var simulator = new HttpSimulator())
            {
                simulator.SetFormVariable("Test1", "Value1")
                  .SetFormVariable("Test2", "Value2")
                  .SimulateRequest(new Uri("http://localhost/Test.aspx"));

                Assert.AreEqual("Value1", HttpContext.Current.Request.Form["Test1"]);
                Assert.AreEqual("Value2", HttpContext.Current.Request.Form["Test2"]);
                Assert.AreEqual(new Uri("http://localhost/Test.aspx"), HttpContext.Current.Request.Url);
            }
        }
    }
}

