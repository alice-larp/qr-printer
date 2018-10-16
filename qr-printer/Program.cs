namespace qr_printer
{
    class Program
    {
        static void Main(string[] args)
        {
            new Printer("Brother QL-810W").PrintQr("Hello", "123");
        }
    }
}
