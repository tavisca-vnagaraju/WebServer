namespace CsharpListenerDemo
{
    public class WebServerApplication
    {
        public void Start()
        {
            Server server = new Server();
            server.UrlName = "localhost";
            server.Port = "8080";
            server.Start();
            var httpListener = server.GetHttpListener();
            HttpRequest httpRequest = new HttpRequest(httpListener);
            HttpResponse httpResponse = new HttpResponse();
            httpResponse.WriteResponse(httpRequest);
            httpListener.Stop();
        }
    }
}