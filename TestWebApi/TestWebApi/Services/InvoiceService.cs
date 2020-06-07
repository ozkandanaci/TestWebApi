using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using TestWebApi.Models;
using TestWebApi.Repositories;

namespace TestWebApi.Services
{
    public class InvoiceService
    {
        public InvoiceService()
        {

        }
        public Response<IEnumerable<InvoiceHeader>> GetList()
        {
            try
            {
                return new Response<IEnumerable<InvoiceHeader>>() { Success = true, Result = new InvoiceRepository().GetList() };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<InvoiceHeader>>() { Success = false, Message = ex.Message };
            }

        }

    }
   

}
