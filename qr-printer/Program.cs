using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qr_printer
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new bpac.DocumentClass();
            if (doc.Open("labels/test.lbx"))
            {
                doc.GetObject("label").Text = "FooText";
                doc.GetObject("qr").Text = "FooQr";
                doc.SetPrinter("Brother QL-810W", false);
                doc.SetMediaById(doc.Printer.GetMediaId(), true);
                doc.StartPrint("", bpac.PrintOptionConstants.bpoDefault);
                doc.PrintOut(1, bpac.PrintOptionConstants.bpoDefault);
                doc.EndPrint();
                doc.Close();
                Console.WriteLine("Label printed");
            }
            else
            {
                Console.WriteLine("Can't open label file!");
            }
        }
    }
}
