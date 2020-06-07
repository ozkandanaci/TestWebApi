using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Repositories
{
    public class InvoiceRepository
    {
        public IEnumerable<InvoiceHeader> GetList()
        {
            return new List<InvoiceHeader>() {

                new InvoiceHeader(){ Id = 1, No = "1", CustomerCode = "1" },
                new InvoiceHeader(){ Id = 2, No = "2", CustomerCode = "2" },
                new InvoiceHeader(){ Id = 3, No = "3", CustomerCode = "3" }
            };
        }
    }
}
