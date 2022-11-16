using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test_Entidades
{
    [TestClass]
    public class Test_Jugador
    {

        [TestMethod]
        public void Test_CalcularEnvido()
        {
            // Arrange
            Jugador j1 = new Jugador();
            int envidoEsperado = 29;
            int envido;

            j1.RecibirCarta(new Carta(5, EPalo.Basto));
            j1.RecibirCarta(new Carta(4, EPalo.Basto));
            j1.RecibirCarta(new Carta(12, EPalo.Espada));
            
            // Act
            envido = j1.CalcularEnvido();

            // Assert
            Assert.AreEqual(envidoEsperado, envido);
        }

        [TestMethod]
        public void Test_TirarCartaMasBaja()
        {
            // Arrange
            Jugador j1 = new Jugador();
            

            j1.RecibirCarta(new Carta(7, EPalo.Oro));
            j1.RecibirCarta(new Carta(6, EPalo.Basto));
            j1.RecibirCarta(new Carta(5, EPalo.Espada));

            Carta cartaEsperada = new Carta(5, EPalo.Espada);
            Carta carta;

            // Act
            carta = j1.TirarCartaMasBaja();

            // Assert
            Assert.AreEqual(cartaEsperada, carta);
        }

        [TestMethod]
        public void Test_TirarCartaMasAlta()
        {
            // Arrange
            Jugador j1 = new Jugador();


            j1.RecibirCarta(new Carta(7, EPalo.Oro));
            j1.RecibirCarta(new Carta(6, EPalo.Basto));
            j1.RecibirCarta(new Carta(5, EPalo.Espada));

            Carta cartaEsperada = new Carta(7, EPalo.Oro);
            Carta carta;

            // Act
            carta = j1.TirarCartaMasAlta();

            // Assert
            Assert.AreEqual(cartaEsperada, carta);
        }
      
    }
}
