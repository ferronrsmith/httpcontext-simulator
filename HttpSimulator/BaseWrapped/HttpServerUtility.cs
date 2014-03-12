using System.Web;

namespace Http.TestLibrary.BaseWrapped
{
    internal class HttpServerUtility : HttpServerUtilityBase
    {
        private readonly HttpSimulator.ConfigMapPath _configMap;

        public HttpServerUtility(HttpSimulator.ConfigMapPath configMap)
        {
            _configMap = configMap;
        }

        public override string MapPath(string path)
        {
            return _configMap.MapPath(string.Empty, path);
        }
    }
}