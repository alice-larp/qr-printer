﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace webserver.Controllers
{
    public class PrintRequest
    {
        [Required]
        public string Label { get; set; }
        [Required]
        public string Qr { get; set; }
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
        public IActionResult Post([FromBody]PrintRequest req)
        {
            if (ModelState.IsValid)
            {
                printer.PrintQr(req.Label, req.Qr);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
