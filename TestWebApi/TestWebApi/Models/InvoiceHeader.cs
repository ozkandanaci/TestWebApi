using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
    public class InvoiceHeader
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string CustomerCode { get; set; }
        public string Address { get; set; }

    }
}
