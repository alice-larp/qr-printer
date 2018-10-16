using Microsoft.AspNetCore.Mvc;

namespace webserver.Controllers
{
    public class PrintRequest
    {
        public string label;
        public string qr;
    }

    [Route("[controller]")]
    public class PrintController : Controller
    {
        qr_printer.Printer printer = new qr_printer.Printer("Brother QL-810W");

        [HttpGet]
        public string Get()
        {
            return "Webserver is running.";
        }

        [HttpPost]
        public void Post([FromBody]PrintRequest req)
        {
            printer.PrintQr(req.label, req.qr);
        }
    }
}
