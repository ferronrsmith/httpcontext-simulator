using System;
using System.Collections.Specialized;
using System.Web;

namespace Http.TestLibrary.BaseWrapped
{
    internal class SimulatedHttpRequest:HttpRequestBase
    {
        private readonly TestLibrary.SimulatedHttpRequest _request;

        internal void SetReferer(Uri referer)
        {
            _request.SetReferer(referer);
        }
        /// <summary>
        /// Returns the specified member of the request header.
        /// </summary>
        /// <returns>
        /// The HTTP verb returned in the request
        /// header.
        /// </returns>
        public override string HttpMethod
        {
            get { return _request.GetHttpVerbName(); }
        }


        /// <summary>
        /// Gets the name of the server.
        /// </summary>
        /// <returns></returns>
        public string GetServerName()
        {
            return _request.GetServerName();
        }

        public int GetLocalPort()
        {
            return _request.GetLocalPort();
        }

        /// <summary>
        /// Gets the headers.
        /// </summary>
        /// <value>The headers.</value>
        public override NameValueCollection Headers
        {
            get
            {
                return _request.Headers;
            }
        }

            
        /// <summary>
        /// Gets the format exception.
        /// </summary>
        /// <value>The format exception.</value>
        public override NameValueCollection Form
        {
            get
            {
                return _request.Form;
            }
        }

            
        public SimulatedHttpRequest(TestLibrary.SimulatedHttpRequest request)
        {
            _request = request;
        }
        /// <summary>
        /// Returns the virtual path to the currently executing
        /// server application.
        /// </summary>
        /// <returns>
        /// The virtual path of the current application.
        /// </returns>
        public override string ApplicationPath
        {
            get { return _request.GetAppPath(); }
        }

        public override string PhysicalApplicationPath
        {
            get { return _request.GetAppPathTranslated(); }
        }

        public override Uri Url
        {
            get { return _request.Uri; }
        }

    }
}