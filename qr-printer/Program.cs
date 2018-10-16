using System;
using System.Net;

namespace qr_printer
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServer ws = new WebServer(SendResponse, "http://localhost:8091/print/");
            ws.Run();
            Console.WriteLine("A simple webserver. Press a key to quit.");
            Console.ReadKey();
            ws.Stop();
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            new Printer("Brother QL-810W").PrintQr("Hello", "123");
            return "QR printed!";
        }
    }
}
