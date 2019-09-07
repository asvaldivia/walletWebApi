using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WalletWebApi.Controllers;

namespace WalletWebApi.Tests.Controllers
{
    [TestClass]
    public class BilleteraTest
    {
        [TestMethod]
        public void transaccionCero()
        {
            BilleterasController billeterasController = new BilleterasController();

            bool resultado = billeterasController.transaccionMayorACero(0);

            Assert.AreEqual(false, resultado);
        }

        [TestMethod]
        public void transaccionNegativa()
        {
            BilleterasController billeterasController = new BilleterasController();

            bool resultadoNegativo = billeterasController.transaccionMayorACero(-5);
            bool resultadoPositivo = billeterasController.transaccionMayorACero(5);

            Assert.AreEqual(false, resultadoNegativo);
            Assert.AreEqual(true, resultadoPositivo);
        }

        [TestMethod]
        public void retiroEsMayorQueBalance()
        {
            BilleterasController billeterasController = new BilleterasController();

            bool resultado = billeterasController.retiroEsMenorIgualBalance(100, 150);

            Assert.AreEqual(false, resultado);
        }


        [TestMethod]
        public void calculoBalance()
        {
            BilleterasController billeterasController = new BilleterasController();

            int resultado = billeterasController.calcularBalance(150,100);
            int resultadoNegativo = billeterasController.calcularBalance(150, 100);

            Assert.AreEqual(50, resultado);
            Assert.AreNotEqual(30,resultadoNegativo);
        }

        [TestMethod]
        public void esDeposito()
        {
            BilleterasController billeterasController = new BilleterasController();

            bool resultado = billeterasController.esDeposito("deposito");
            bool resultadoNegativo = billeterasController.esDeposito("dtr");

            Assert.AreEqual(true, resultado);
            Assert.AreNotEqual(true, resultadoNegativo);
        }

        [TestMethod]
        public void esRetiro()
        {
            BilleterasController billeterasController = new BilleterasController();

            bool resultado = billeterasController.esRetiro("retiro");
            bool resultadoNegativo = billeterasController.esRetiro("deposito");

            Assert.AreEqual(true, resultado);
            Assert.AreNotEqual(true, resultadoNegativo);
        }


    }
}
