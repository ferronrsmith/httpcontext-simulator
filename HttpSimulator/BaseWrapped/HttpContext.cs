using System.Web;

namespace Http.TestLibrary.BaseWrapped
{
    internal class HttpContext:HttpContextBase
    {
        private readonly HttpRequestBase _workerRequest;
        private readonly HttpSessionStateBase _fakeHttpSessionState;

        public HttpContext(HttpRequestBase workerRequest, HttpSessionStateBase fakeHttpSessionState)
        {
            _workerRequest = workerRequest;
            _fakeHttpSessionState = fakeHttpSessionState;
        }

        public override HttpSessionStateBase Session
        {
            get { return _fakeHttpSessionState; }
        }

        public override HttpRequestBase Request
        {
            get { return _workerRequest; }
        }
    }
}
