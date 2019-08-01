using System;
using System.Net;

namespace CsharpListenerDemo
{
    public class HttpRequest
    {
        private HttpListener _httpListener;
        private HttpListenerContext _context ;
        private string _extractedFileName;

        public HttpRequest(HttpListener httpListener)
        {
            _httpListener = httpListener;
            _context = _httpListener.GetContext();
            _extractedFileName = _context.Request.RawUrl;
            _extractedFileName = _extractedFileName.Trim('/');
        }

        public string GetFileNameFromUrl()
        {   
            return _extractedFileName;
        }

        public HttpListenerContext GetContext()
        {   
            return _context;
        }
    }
}