using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Juego
    {
        private static List<Carta> mazo;
        private static List<Jugador> jugadores;

        static Juego()
        {
            mazo = InicializarMazo();
            jugadores = new JugadoresADO().ObtenerJugadores();
        }  

        public static List<Carta> Mazo { get => mazo; }
        public static List<Jugador> Jugadores { get => jugadores; }

        private static List<Carta> InicializarMazo()
        {
            List<Carta> mazo;

            SerializadorJSON<List<Carta>> serializadorJson = new SerializadorJSON<List<Carta>>();
            mazo = serializadorJson.Deserializar("MazoDeCartas");

            if(mazo is null)
            {
                mazo = new List<Carta>();

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j < 8; j++)
                    {
                        switch (i)
                        {
                            case 0:
                                mazo.Add(new Carta(j, EPalo.Espada));
                                break;
                            case 1:
                                mazo.Add(new Carta(j, EPalo.Basto));
                                break;
                            case 2:
                                mazo.Add(new Carta(j, EPalo.Oro));
                                break;
                            case 3:
                                mazo.Add(new Carta(j, EPalo.Copa));
                                break;
                        }
                    }
                    for (int j = 10; j < 13; j++)
                    {
                        switch (i)
                        {
                            case 0:
                                mazo.Add(new Carta(j, EPalo.Espada));
                                break;
                            case 1:
                                mazo.Add(new Carta(j, EPalo.Basto));
                                break;
                            case 2:
                                mazo.Add(new Carta(j, EPalo.Oro));
                                break;
                            case 3:
                                mazo.Add(new Carta(j, EPalo.Copa));
                                break;
                        }
                    }
                }
                new SerializadorJSON<List<Carta>>().Serializar(mazo, "mazoDeCartas");
            }

            return mazo;
        }

        public static Stack<Carta> ObtenerMazoMezclado()
        {
            Stack<Carta> mazoMezclado = Juego.MezclarMazo();
            return mazoMezclado;
        }

        private static Stack<Carta> MezclarMazo()
        {
            Carta[] mazoAMezclar = new Carta[40];
            mazo.CopyTo(mazoAMezclar);
            Random rnd = new Random();

            for (int i = mazoAMezclar.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i);

                Carta aux = mazoAMezclar[i];
                mazoAMezclar[i] = mazoAMezclar[j];
                mazoAMezclar[j] = aux;
            }

            Stack<Carta> mazoMezclado = new Stack<Carta>();
            foreach (Carta item in mazoAMezclar)
            {
                mazoMezclado.Push(item);
            }
            return mazoMezclado;
        }

        /// <summary>
        /// Compara las cartas por valor
        /// </summary>
        /// <param name="carta1"></param>
        /// <param name="carta2"></param>
        /// <returns>1 = si carta1 mata a carta2. -1 = carta2 mata a carta1. 0; si pardan</returns>
        public static int CompararCartas(Carta carta1, Carta carta2)
        {
            int retorno = 0;
            int valor1 = carta1.ValorJerarquico;
            int valor2 = carta2.ValorJerarquico;

            if (valor1 < valor2)
            {
                retorno = 1;
            }
            else if(valor1 > valor2)
            {
                retorno = -1;
            }
            return retorno;
        }

        public static int CompararEnvido(int envidoDelQueCanto, int envidoDelQueResponde)
        {
            int retorno = 0;
            
            if(envidoDelQueCanto > envidoDelQueResponde)
            {
                retorno = 1;
            }
            else if (envidoDelQueResponde > envidoDelQueCanto)
            {
                retorno = -1;
            }
            return retorno;
        }

        public static Jugador ObtenerJugadorDisponible()
        {
            int indiceRandom;
            do
            {
                if (!Juego.HayJugadorDisponibles())
                {
                    return null;
                }
                indiceRandom = new Random().Next(0, Juego.Jugadores.Count);
            } while (Juego.Jugadores[indiceRandom].EstaJugando);

            Juego.Jugadores[indiceRandom].EstaJugando = true;
            return Juego.Jugadores[indiceRandom];
        }

        private static bool HayJugadorDisponibles()
        {
            foreach (Jugador item in Juego.Jugadores)
            {
                if (!item.EstaJugando)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
