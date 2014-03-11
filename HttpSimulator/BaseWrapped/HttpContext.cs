using System.Web;

namespace Http.TestLibrary.BaseWrapped
{
    internal class HttpContext:HttpContextBase
    {
        private readonly HttpRequestBase _workerRequest;
        private readonly HttpSessionStateBase _fakeHttpSessionState;
        private readonly HttpServerUtility _fakeHttpServerUtility;
        public HttpContext(HttpRequestBase workerRequest, HttpSessionStateBase fakeHttpSessionState, HttpServerUtility fakeHttpServerUtility)
        {
            _workerRequest = workerRequest;
            _fakeHttpSessionState = fakeHttpSessionState;
            _fakeHttpServerUtility = fakeHttpServerUtility;
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
    }
}
