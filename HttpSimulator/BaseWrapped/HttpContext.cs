using System.IO;
using System.Web;

namespace Http.TestLibrary.BaseWrapped
{
    internal class HttpContext : HttpContextBase
    {
        private readonly HttpRequestBase _workerRequest;
        private readonly HttpSessionStateBase _fakeHttpSessionState;
        private readonly HttpServerUtility _fakeHttpServerUtility;
        private readonly HttpResponseBase _fakeHttpResponse;

        public HttpContext(HttpRequestBase workerRequest, HttpSessionStateBase fakeHttpSessionState, HttpServerUtility fakeHttpServerUtility, HttpResponse response)
        {
            _workerRequest = workerRequest;
            _fakeHttpSessionState = fakeHttpSessionState;
            _fakeHttpServerUtility = fakeHttpServerUtility;
            _fakeHttpResponse = new HttpResponseWrapper(response);
        }

        public override HttpSessionStateBase Session
        {
            get { return _fakeHttpSessionState; }
        }

        public override HttpRequestBase Request
        {
            get { return _workerRequest; }
        }

        public override HttpServerUtilityBase Server
        {
            get { return _fakeHttpServerUtility; }
        }

        public override HttpResponseBase Response {
            get {
                return _fakeHttpResponse;
            }
        }
    }
}
