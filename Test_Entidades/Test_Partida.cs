using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Test_Entidades
{
    [TestClass]
    public class Test_Partida
    {
        [TestMethod]
        public void Test_RepartirCartas()
        {
            // Arrange
            Jugador j1 = new Jugador();
            Jugador j2 = new Jugador();
            Partida partida = new Partida(j1, j2);
            int cantidadCartasEnManoEsperada = 3;
            int cantidadCartasEnManoJ1;
            int cantidadCartasEnManoJ2;

            // Act 
            partida.RepartirCartas(j1,j2);
            cantidadCartasEnManoJ1 = j1.CartasEnMano.Count;
            cantidadCartasEnManoJ2 = j2.CartasEnMano.Count;
            // Assert
            Assert.AreEqual(cantidadCartasEnManoEsperada, cantidadCartasEnManoJ1);
            Assert.AreEqual(cantidadCartasEnManoEsperada, cantidadCartasEnManoJ2);
        }

        [TestMethod]
        public void Test_CambiarMano()
        {
            // Arrange
            Jugador j1 = new Jugador();
            Jugador j2 = new Jugador();
            Partida partida = new Partida(j1, j2);
            Jugador jugadorManoEsperado = j2;
            Jugador jugadorManoObtenido;

            // Act 
            partida.CambiarMano();
            jugadorManoObtenido = partida.JugadorMano;
            // Assert

            Assert.AreEqual<Jugador>(jugadorManoEsperado, jugadorManoObtenido);          
        }

    }
}
