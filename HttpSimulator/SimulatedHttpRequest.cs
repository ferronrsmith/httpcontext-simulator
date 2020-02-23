using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace Http.TestLibrary
{
    /// <summary>
    /// Used to simulate an HttpRequest.
    /// </summary>
    public class SimulatedHttpRequest : SimpleWorkerRequest
    {
        Uri _referer;
        string _host;
        string _verb;
        int _port;
        string _physicalFilePath;

        /// <summary>
        /// Creates a new <see cref="SimulatedHttpRequest"/> instance.
        /// </summary>
        /// <param name="applicationPath">App virtual dir.</param>
        /// <param name="physicalAppPath">Physical Path to the app.</param>
        /// <param name="physicalFilePath">Physical Path to the file.</param>
        /// <param name="page">The Part of the URL after the application.</param>
        /// <param name="query">Query.</param>
        /// <param name="output">Output.</param>
        /// <param name="host">Host.</param>
        /// <param name="port">Port to request.</param>
        /// <param name="verb">The HTTP Verb to use.</param>
        /// <param name="url"></param>
        public SimulatedHttpRequest(string applicationPath, string physicalAppPath, string physicalFilePath, string page, string query, TextWriter output, string host, int port, string verb, Uri url)
            : base(applicationPath, physicalAppPath, page, query, output)
        {
            if (host == null)
                throw new ArgumentNullException("host", "Host cannot be null.");

            if (host.Length == 0)
                throw new ArgumentException("Host cannot be empty.", "host");

            if (applicationPath == null)
                throw new ArgumentNullException("applicationPath", "Can't create a request with a null application path. Try empty string.");

            _host = host;
            _verb = verb;
            _port = port;
            _physicalFilePath = physicalFilePath;
            this.Uri = url;
        }

        internal void SetReferer(Uri referer)
        {
            _referer = referer;
        }

        /// <summary>
        /// Returns the specified member of the request header.
        /// </summary>
        /// <returns>
        /// The HTTP verb returned in the request
        /// header.
        /// </returns>
        public override string GetHttpVerbName()
        {
            return _verb;
        }

        /// <summary>
        /// Gets the name of the server.
        /// </summary>
        /// <returns></returns>
        public override string GetServerName()
        {
            return _host;
        }

        public override int GetLocalPort()
        {
            return this._port;
        }

        /// <summary>
        /// Gets the headers.
        /// </summary>
        /// <value>The headers.</value>
        public NameValueCollection Headers
        {
            get
            {
                return this.headers;
            }
        }

        private NameValueCollection headers = new NameValueCollection();

        /// <summary>
        /// Gets the Form.
        /// </summary>
        /// <value>The Form.</value>
        public NameValueCollection Form
        {
            get
            {
                return formVariables;
            }
        }

        public Uri Uri { get; private set; }

        private NameValueCollection formVariables = new NameValueCollection();

        public HttpBrowserCapabilities Browser
        {
            get
            {
                return browser;
            }
        }

        private HttpBrowserCapabilities browser = new HttpBrowserCapabilities{ Capabilities = new Dictionary<string,string>() };

        /// <summary>
        /// Get all nonstandard HTTP header name-value pairs.
        /// </summary>
        /// <returns>An array of header name-value pairs.</returns>
        public override string[][] GetUnknownRequestHeaders()
        {
            if (this.headers == null || this.headers.Count == 0)
            {
                return null;
            }
            string[][] headersArray = new string[this.headers.Count][];
            for (int i = 0; i < this.headers.Count; i++)
            {
                headersArray[i] = new string[2];
                headersArray[i][0] = this.headers.Keys[i];
                headersArray[i][1] = this.headers[i];
            }
            return headersArray;
        }

        public override string GetKnownRequestHeader(int index)
        {
            switch (index) {
                case HttpWorkerRequest.HeaderReferer:
                    return _referer == null ? string.Empty : _referer.ToString();
                case HttpWorkerRequest.HeaderContentType:
                    string ct = headers["Content-Type"] ?? (_verb == "POST" ? "application/x-www-form-urlencoded" : null);
                    if (ct != null)
                        return ct;
                    break;
                case HttpWorkerRequest.HeaderAcceptLanguage:
                    return headers["Accept-Language"];
                case HttpWorkerRequest.HeaderUserAgent:
                    return headers["User-Agent"];
                case HttpWorkerRequest.HeaderCookie:
                    return headers["Cookie"];
            }
            return base.GetKnownRequestHeader(index);
        }

        public override string GetServerVariable(string name)
        {
            switch (name) {
                case "HTTP_USER_AGENT":
                    return GetKnownRequestHeader(HttpWorkerRequest.HeaderUserAgent);
            }   
            return base.GetServerVariable(name);
        }

        /// <summary>
        /// Returns the virtual path to the currently executing
        /// server application.
        /// </summary>
        /// <returns>
        /// The virtual path of the current application.
        /// </returns>
        public override string GetAppPath()
        {
            string appPath = base.GetAppPath();
            return appPath;
        }

        public override string GetAppPathTranslated()
        {
            string path = base.GetAppPathTranslated();
            return path;
        }

        public override string GetUriPath()
        {
            string uriPath = base.GetUriPath();
            return uriPath;
        }

        public override string GetFilePathTranslated()
        {
            return _physicalFilePath;
        }

        /// <summary>
        /// Reads request data from the client (when not preloaded).
        /// </summary>
        /// <returns>The number of bytes read.</returns>
        public override byte[] GetPreloadedEntityBody()
        {
            string formText = string.Empty;

            foreach (string key in this.formVariables.Keys)
            {
                formText += string.Format("{0}={1}&", key, this.formVariables[key]);
            }

            return Encoding.UTF8.GetBytes(formText);
        }

        /// <summary>
        /// Returns a value indicating whether all request data
        /// is available and no further reads from the client are required.
        /// </summary>
        /// <returns>
        /// 	<see langword="true"/> if all request data is available; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public override bool IsEntireEntityBodyIsPreloaded()
        {
            return true;
        }
    }
}
