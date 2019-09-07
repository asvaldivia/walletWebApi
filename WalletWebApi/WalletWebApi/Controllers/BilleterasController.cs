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
        [Route("list")]
        [HttpGet]
        public IEnumerable<Billetera> Get()
        {
            using (BilleteraEntities billetrasEntities = new BilleteraEntities())
            {
                return billetrasEntities.Billeteras.ToList();
            }
        }
        //[Route("add_transaction")]
        [HttpPost]
        public IHttpActionResult AgregarTransaccion([FromBody]Billetera billetera)
        {
            if (ModelState.IsValid)
            {
                dbContext.Billeteras.Add(billetera);
                dbContext.SaveChanges();
                return Ok(billetera);
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("get_balance")]
        [HttpGet]
        public Balance GetBalance()
        {

            Billetera billetera = new Billetera();
            using (BilleteraEntities billetrasEntities = new BilleteraEntities())
            {
                var transacciones = billetrasEntities.Billeteras.ToList();
                int retiro = 0;
                int deposito = 0;
                int balances = 0;
                foreach (var transaccion in transacciones)
                {
                    if (transaccion.operacion == "retiro")
                    {
                        retiro = retiro + transaccion.monto;
                    }
                    else
                    {
                        deposito = deposito + transaccion.monto;
                    }
                }
                balances = deposito - retiro;
                Balance bal = new Balance
                {
                    balance = balances
                };
                return bal;
            }
        }
    }
}
