using System;

namespace CsharpListenerDemo
{
    public class Program
    {
        public static void Main()
        {

            WebServerApplication webServerApplication = new WebServerApplication();
            while (true)
            {
                webServerApplication.Start();
            }
        }
    }
}