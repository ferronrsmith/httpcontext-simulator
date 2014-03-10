httpcontext-simulator [![Build Status](https://travis-ci.org/ferronrsmith/httpcontext-simulator.png)](https://travis-ci.org/ferronrsmith/httpcontext-simulator)
=====================

a simulator used to simulate http context during integration testing


###Introduction
The following shows how to use HttpSimulator?.

View the [Sample App](https://github.com/ferronrsmith/-httpcontext-simulator-example)

```csharp
using System;
using System.Collections.Specialized;

/**
 *
 * The following spike was created to show an example of how to use the HttpSimuator library
 *
 *
 */
using System.Web;
using NUnit.Framework;
using Http.TestLibrary;

namespace UsingHttpSimulator
{
    [TestFixture]
    public class UsingHttpSimulatorTest
    {
        /// <summary>
        /// Determines whether this instance [can get set session].
        /// </summary>
        [Test]
        public void CanGetSetSession()
        {
            using (new HttpSimulator("/", @"c:\inetpub\").SimulateRequest())
            {
                HttpContext.Current.Session["Test"] = "Success";
                Assert.AreEqual("Success", HttpContext.Current.Session["Test"]);
            }
        }

        /// <summary>
        /// Determines whether this instance [can simulate form post].
        /// </summary>
        [Test]
        public void CanSimulateFormPost()
        {
            using (HttpSimulator simulator = new HttpSimulator())
            {
                NameValueCollection form = new NameValueCollection();
                form.Add("Test1", "Value1");
                form.Add("Test2", "Value2");
                simulator.SimulateRequest(new Uri("http://localhost/Test.aspx"), form);

                Assert.AreEqual("Value1", HttpContext.Current.Request.Form["Test1"]);
                Assert.AreEqual("Value2", HttpContext.Current.Request.Form["Test2"]);
            }

            using (HttpSimulator simulator = new HttpSimulator())
            {
                simulator.SetFormVariable("Test1", "Value1")
                  .SetFormVariable("Test2", "Value2")
                  .SimulateRequest(new Uri("http://localhost/Test.aspx"));

                Assert.AreEqual("Value1", HttpContext.Current.Request.Form["Test1"]);
                Assert.AreEqual("Value2", HttpContext.Current.Request.Form["Test2"]);
            }
        }
    }
}
```

### Nuget Plugin

[HttpSimulator 1.0.0](http://www.nuget.org/packages/HttpSimulator/)
