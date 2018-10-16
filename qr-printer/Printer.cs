using bpac;
using System;
using System.Collections.Generic;

namespace qr_printer
{
    public class Printer
    {
        private string printerName;

        public Printer(string printerName)
        {
            this.printerName = printerName;
        }

        public void PrintQr(string label, string qr)
        {
            Print("qr", new Dictionary<string, string>() { { "label", label }, { "qr", qr } });
        }

        public void Print(string labelName, Dictionary<String, String> substitutions)
        {
            var doc = new DocumentClass();
            if (doc.Open("labels/" + labelName + ".lbx"))
            {
                foreach(var s in substitutions)
                {
                    doc.GetObject(s.Key).Text = s.Value;
                }
                doc.SetPrinter(printerName, false);
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
