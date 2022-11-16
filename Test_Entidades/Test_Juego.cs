using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Test_Entidades
{
    [TestClass]
    public class Test_Juego
    {
        [TestMethod]
        public void Test_MezclarMazo()
        {
            // Arrange
            Carta[] mazoSinMezclar = Juego.Mazo.ToArray();
            Carta[] mazoMezclado;

            // Act 
            mazoMezclado = Juego.ObtenerMazoMezclado().ToArray();

            // Assert

            Assert.AreNotEqual(mazoSinMezclar, mazoMezclado);
        }

        [TestMethod]
        public void Test_CompararCartas()
        {
            // Arrange
            Carta cartaUno = new Carta(7, EPalo.Espada);
            Carta cartaDos = new Carta(1, EPalo.Basto);
            int valorEsperado = -1;

            // Act 
            int valorObtenido = Juego.CompararCartas(cartaUno, cartaDos);

            // Assert
            Assert.AreEqual(valorEsperado, valorObtenido);
        }

        [TestMethod]
        public void Test_CompararEnvido()
        {
            // Arrange
            Jugador j1 = new Jugador();
            Jugador j2 = new Jugador();
            
            j1.RecibirCarta(new Carta(5, EPalo.Basto));
            j1.RecibirCarta(new Carta(4, EPalo.Basto));
            j1.RecibirCarta(new Carta(12, EPalo.Espada));
            j2.RecibirCarta(new Carta(6, EPalo.Oro));
            j2.RecibirCarta(new Carta(1, EPalo.Basto));
            j2.RecibirCarta(new Carta(7, EPalo.Oro));

            int envidoJ1 = j1.CalcularEnvido();
            int envidoJ2 = j2.CalcularEnvido();
            int respuestaEsperada = -1;
            // Act
            int respuestaObtenida = Juego.CompararEnvido(envidoJ1, envidoJ2);

            // Assert
            Assert.AreEqual(respuestaEsperada, respuestaObtenida);
        }
    }
}
