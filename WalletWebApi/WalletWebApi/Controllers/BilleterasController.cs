using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WalletWebApi.Controllers
{
    public class BilleterasController : ApiController
    {
        private BilleteraEntities dbContext = new BilleteraEntities();

        [HttpGet]
        public IEnumerable<Billetera> Get()
        {
            using (BilleteraEntities billetrasEntities = new BilleteraEntities())
            {
                return billetrasEntities.Billeteras.ToList();
            }
        }
    }
}
