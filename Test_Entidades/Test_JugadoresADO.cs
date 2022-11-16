using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Test_Entidades
{
    [TestClass]
    public class Test_JugadoresADO
    {
        [TestMethod]
        public void Test_ObtenerJugadores()
        {
            // Arrange
            JugadoresADO accesoDatos = new JugadoresADO(Juego.nombreServer,Juego.nombreBaseDeDatos);

            // Act 
            List<Jugador> lista = accesoDatos.ObtenerJugadores();

            // Assert
            Assert.IsNotNull(lista);
        }

    }
}
