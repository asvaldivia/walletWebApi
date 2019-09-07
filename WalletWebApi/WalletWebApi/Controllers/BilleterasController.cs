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
            if (transaccionMayorACero(billetera.monto) is false)
            {
                return BadRequest();
            }
            if (esRetiro(billetera.operacion))
            {
                var balance = GetBalance();
                if(retiroEsMenorIgualBalance(balance.balance, billetera.monto) is false)
                {
                    return BadRequest();
                }
            }
            
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
                foreach (var transaccion in transacciones)
                {
                    if (esRetiro(transaccion.operacion))
                    {
                        retiro = retiro + transaccion.monto;
                    }
                    if(esDeposito(transaccion.operacion))
                    {
                        deposito = deposito + transaccion.monto;
                    }
                }
                int balances = calcularBalance(deposito, retiro);
                Balance bal = new Balance
                {
                    balance = balances
                };
                return bal;
            }
        }

        public bool transaccionMayorACero(int monto)
        {
            if(monto > 0)
            {
                return true;
            }

            return false;
        }

        public bool retiroEsMenorIgualBalance(int balance, int retiro)
        {
            if (retiro > balance)
            {
                return false;
            }

            return true;
        }

        public int calcularBalance(int totalDeposito, int totalRetiro)
        {
            int balance = 0;
            return balance = totalDeposito - totalRetiro;

        }

        public bool esRetiro(string transaccion)
        {
            if(transaccion == "retiro")
            {
                return true;
            }
            return false;
        }

        public bool esDeposito(string transaccion)
        {
            if (transaccion == "deposito")
            {
                return true;
            }
            return false;
        }

    }
}
