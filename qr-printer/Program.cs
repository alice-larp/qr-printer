using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine(request.HttpMethod);
            StreamReader getPostParam = new StreamReader(request.InputStream, true);
            var postData = JsonConvert.DeserializeObject<Dictionary<string, string>>(getPostParam.ReadToEnd());
            Console.WriteLine(postData);
            new Printer("Brother QL-810W").PrintQr(postData["label"], postData["qr"]);
            return "QR printed!";
        }
    }
}
