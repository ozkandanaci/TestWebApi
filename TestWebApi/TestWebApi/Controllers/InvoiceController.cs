using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        public InvoiceController()
        {

        }

        [HttpGet]
        public IActionResult FilterRows()
        {
            Response<IEnumerable<InvoiceHeader>> response = new InvoiceService().GetList();
            return Ok(response);
        }


    }
}