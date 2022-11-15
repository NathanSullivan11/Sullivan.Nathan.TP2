using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Test_Entidades
{
    [TestClass]
    public class Test_Carta
    {
        [TestMethod]
        public void Test_EsFigura_Success()
        {
            // Arrange
            Carta carta = new Carta(12, EPalo.Basto);
            bool respuestaEsperada = true;

            // Act 
            bool respuestaUno = carta.EsFigura();

            // Assert
            Assert.AreEqual(respuestaEsperada, respuestaUno);
        }

        [TestMethod]
        public void Test_EsFigura_Fail()
        {
            // Arrange
            Carta carta = new Carta(2, EPalo.Basto);
            bool respuestaEsperada = false;

            // Act 
            bool respuesta = carta.EsFigura();

            // Assert
            Assert.AreEqual(respuestaEsperada, respuesta);
        }

        [TestMethod]
        public void Test_Equals_Fail()
        {
            // Arrange
            Carta cartaUno = new Carta(5, EPalo.Basto);
            Carta cartaDos = new Carta(5, EPalo.Oro);

            bool respuestaEsperada = false;

            // Act 
            bool respuesta = cartaUno.Equals(cartaDos);

            // Assert

            Assert.AreEqual(respuestaEsperada, respuesta);
        }

        [TestMethod]
        public void Test_Equals_Success()
        {
            // Arrange
            Carta cartaUno = new Carta(4, EPalo.Oro);
            Carta cartaDos = new Carta(4, EPalo.Oro);

            bool respuestaEsperada = true;

            // Act 
            bool respuesta = cartaUno.Equals(cartaDos);

            // Assert

            Assert.AreEqual(respuestaEsperada, respuesta);


        }
    }
}
