using System;
using System.Net;

namespace CsharpListenerDemo
{
    public class Server
    {
        public string UrlName { get; set; }
        public string Port { get; set; }
        private string _link;
        private HttpListener _httpListener;
        
        public void Start()
        {
            _httpListener = new HttpListener();
            _link = "http://" + UrlName + ":" + Port + "/";
            _httpListener.Prefixes.Add(_link);
            Console.WriteLine("Started Server....");
            _httpListener.Start();
        }
        public HttpListener GetHttpListener()
        {
            return _httpListener;
        }
    }
}