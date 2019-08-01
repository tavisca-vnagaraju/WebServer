using System;
using System.IO;
using System.Net;

namespace CsharpListenerDemo
{
    public class HttpResponse
    {
        private string _extractedFileName;
        private HttpListenerResponse _response;
        private string _filePath;
        public void WriteResponse(HttpRequest httpRequest)
        {
            _extractedFileName = httpRequest.GetFileNameFromUrl();
            _response = httpRequest.GetContext().Response;
            try
            {
                if (string.IsNullOrEmpty(_extractedFileName))
                {
                    _filePath = "WebPages/index.html";
                }
                else
                {
                    _filePath = "WebPages/" + _extractedFileName + ".html";
                }
                RenderFileToBrowser();
            }
            catch(FileNotFoundException e)
            {
                _filePath = "WebPages/NotFound.html";
                RenderFileToBrowser();
            }
        }
        private void RenderFileToBrowser()
        {
            FileStream fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            var buffer = File.ReadAllBytes(_filePath);
            fileStream.Read(buffer, 0, Convert.ToInt32(fileStream.Length));
            _response.ContentLength64 = buffer.Length;
            var output = _response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}