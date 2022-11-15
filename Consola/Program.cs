using System;
using Entidades;
using System.Collections.Generic;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {/*
            JugadoresADO dao = new JugadoresADO();
             Console.WriteLine(dao.ObtenerListaJugadores());


             foreach(Jugador item in Juego.Jugadores)
             {
                 Console.WriteLine(item.ToString());
             }*/
             /*
             Juego.Jugadores[0].IdJugador = 1;
             Juego.Jugadores[1].IdJugador = 2;
             Sala miSala = new Sala(Juego.Jugadores[0], Juego.Jugadores[1]);
             miSala.actualizarSeguimientoDePartida += Actualizar;
             miSala.ComenzarSala();*/
            
            List<Carta> mazo = Juego.Mazo;

            //new SerializadorJSON<List<Carta>>().Serializar(mazo, "mazoDeCartas");
            
            //List<Carta> mazoLeido = new SerializadorJSON<List<Carta>>().Deserializar("mazoDeCartas");
            
            foreach(Carta item in mazo)
            {
                Console.WriteLine(item.Numero + " " + item.Palo + " " + item.ValorJerarquico);
            }
            /*
            Console.WriteLine(j1.MostrarCartasEnMano());
            Console.WriteLine(Juego.CalcularEnvido(j1));

            Console.WriteLine(j2.MostrarCartasEnMano());
            Console.WriteLine(Juego.CalcularEnvido(j2));


            Jugador j11 = new Jugador("Pepe",1);
            Jugador j22 = new Jugador("Carlitos",2);

            Sala miSala2 = new Sala(j11, j22);

            miSala2.RepartirCartas();

            Console.WriteLine(j11.MostrarCartasEnMano());
            Console.WriteLine(Juego.CalcularEnvido(j11));

            Console.WriteLine(j22.MostrarCartasEnMano());
            Console.WriteLine(Juego.CalcularEnvido(j22));*/
         
            //Console.WriteLine(miSala.SeguimientoPartida);

            
        }

        private static void Actualizar(string obj)
        {
            Console.WriteLine(obj);
        }
    }
}
