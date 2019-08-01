using System;
using System.IO;

namespace CsharpListenerDemo
{
    public class HttpResponse
    {
        public void WriteResponse(HttpRequest httpRequest)
        {
            var extractedFileName = httpRequest.GetFileNameFromUrl();
            var response = httpRequest.GetContext().Response;
            try
            {
                FileStream fileStream = new FileStream(extractedFileName + ".html", FileMode.Open, FileAccess.Read);
                var buffer = File.ReadAllBytes(extractedFileName + ".html");
                fileStream.Read(buffer, 0, Convert.ToInt32(fileStream.Length));
                response.ContentLength64 = buffer.Length;

                var output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
            catch(FileNotFoundException e)
            {
                FileStream fileStream = new FileStream("NotFound.html", FileMode.Open, FileAccess.Read);
                var buffer = File.ReadAllBytes("NotFound.html");
                fileStream.Read(buffer, 0, Convert.ToInt32(fileStream.Length));
                response.ContentLength64 = buffer.Length;

                var output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
    }
}