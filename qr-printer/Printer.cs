using bpac;
using System;

namespace qr_printer
{
    class Printer
    {
        public static void Print()
        {
            var doc = new DocumentClass();
            if (doc.Open("labels/test.lbx"))
            {
                doc.GetObject("label").Text = "FooText";
                doc.GetObject("qr").Text = "FooQr";
                doc.SetPrinter("Brother QL-810W", false);
                doc.SetMediaById(doc.Printer.GetMediaId(), true);
                doc.StartPrint("", PrintOptionConstants.bpoDefault);
                doc.PrintOut(1, PrintOptionConstants.bpoDefault);
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
