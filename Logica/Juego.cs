﻿using System;
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
        private static List<RegistroPartida> registroPartidasBotVsBotXML;
        private static List<RegistroPartida> registroPartidasUserVsBotXML; 
        private static List<RegistroPartida> registroPartidasBotVsBotJSON;
        private static List<RegistroPartida> registroPartidasUserVsBotJSON;

        static Juego()
        {
            mazo = InicializarMazo();
            jugadores = new JugadoresADO().ObtenerJugadores();
            Juego.IncializarRegistros();
           
        }

        public static void IncializarRegistros()
        {
            registroPartidasBotVsBotXML = new List<RegistroPartida>();
            registroPartidasUserVsBotXML = new List<RegistroPartida>();
            registroPartidasBotVsBotJSON = new List<RegistroPartida>();
            registroPartidasUserVsBotJSON = new List<RegistroPartida>();
            try
            {
                registroPartidasBotVsBotXML = Juego.ObtenerRegistrosPartidas("xml", true);
            }
            catch (Exception) { }
            try
            {              
                registroPartidasUserVsBotXML = Juego.ObtenerRegistrosPartidas("xml", false);
  
            }
            catch (Exception){ }
            try
            {
                registroPartidasBotVsBotJSON = Juego.ObtenerRegistrosPartidas("json", true);
            }
            catch (Exception) { }
            try
            {
                registroPartidasUserVsBotJSON = Juego.ObtenerRegistrosPartidas("json", false);

            }
            catch (Exception) { }


        }

        public static List<Carta> Mazo { get => mazo; }
        public static List<Jugador> Jugadores { get => jugadores; }
        public static List<RegistroPartida> RegistroPartidasBotVsBotXML { get => registroPartidasBotVsBotXML; }
        public static List<RegistroPartida> RegistroPartidasUserVsBotXML { get => registroPartidasUserVsBotXML; }
        public static List<RegistroPartida> RegistroPartidasBotVsBotJSON { get => registroPartidasBotVsBotJSON; }
        public static List<RegistroPartida> RegistroPartidasUserVsBotJSON { get => registroPartidasUserVsBotJSON; }

        private static List<Carta> InicializarMazo()
        {
            List<Carta> mazo;

            SerializadorJSON<List<Carta>> serializadorJson = new SerializadorJSON<List<Carta>>();
            mazo = serializadorJson.Deserializar("MazoDeCartas");
            if (mazo is null)
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

        public static Jugador ObtenerJugadorBotDisponible()
        {
            int indiceRandom;
            do
            {
                if (!Juego.HayJugadoresBotsDisponibles())
                {
                    return null;
                }
                indiceRandom = new Random().Next(0, Juego.Jugadores.Count);
            } while (Juego.Jugadores[indiceRandom].EstaJugando || Juego.Jugadores[indiceRandom].EsUsuario);

            Juego.Jugadores[indiceRandom].EstaJugando = true;
            return Juego.Jugadores[indiceRandom];
        }

        public static Jugador ObtenerJugadorUsuarioDisponible()
        {
            foreach(Jugador item in Juego.Jugadores)
            {
                if(item.EsUsuario && !item.EstaJugando)
                {
                    return item;
                }
            }
            return null;
        }

        private static bool HayJugadoresBotsDisponibles()
        {
            int jugadores = 0;
            foreach (Jugador item in Juego.Jugadores)
            {
                if (!item.EstaJugando && !item.EsUsuario)
                {
                    jugadores++;
                }
            }
            if(jugadores > 1)
            {
                return true;
            }
            return false;
        }

        public static string ActualizarJugadorEnBaseDeDatos(Jugador jugador)
        {
            string retorno = $"Jugador con id: {jugador.idBaseDeDatos} actualizado correctamente";
            try
            {
                new JugadoresADO().Actualizar(jugador);
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return retorno;
        }

        public static RegistroPartida GenerarRegistroPartida(Partida partida)
        {
            int codigo =(int)new Random().Next(0, 5555);
            RegistroPartida registro = new RegistroPartida(codigo, DateTime.Now, partida.HayGanador.Nombre, partida.ObtenerOponente(partida.HayGanador).Nombre, partida.ManosJugadas);
            return registro;
        }

        public static string GuardarRegistroPartidaXML(Partida partida, bool esPartidasBotVsBot)
        {          
            bool seAgrego = false;
            string retorno = $"Partida serializada en xml EXITOSAMENTE";
                        
            RegistroPartida registro = Juego.GenerarRegistroPartida(partida);
            string archivo = $"Registros_Partidas_UserVsBotXML";
           
            List<RegistroPartida> listaRegistros = Juego.registroPartidasUserVsBotXML;
            if (esPartidasBotVsBot)
            {
                listaRegistros = Juego.registroPartidasBotVsBotXML;
                archivo = "Registros_Partidas_BotVsBotXML";
            }
            //string nombreArchivo = $"Partida_{registro.CodigoPartida}";
            listaRegistros.Add(registro);

            try
            {
                seAgrego = new SerializadorXML<List<RegistroPartida>>().Serializar(listaRegistros, archivo);
            }
            catch(Exception e)
            {
                retorno = e.Message;
            }
            
            return retorno;
        }

        public static string GuardarRegistroPartidaJSON(Partida partida, bool esPartidasBotVsBot)
        {
            bool seAgrego = false;
            string retorno = $"Partida serializada en json EXITOSAMENTE";
            RegistroPartida registro = Juego.GenerarRegistroPartida(partida);

            string archivo = $"Registros_Partidas_UserVsBotJSON";
            List<RegistroPartida> listaRegistros = Juego.registroPartidasUserVsBotJSON;
            if (esPartidasBotVsBot)
            {
                listaRegistros = Juego.registroPartidasBotVsBotJSON;
                archivo = "Registros_Partidas_BotVsBotJSON";
            }
            listaRegistros.Add(registro);

            try
            {
                seAgrego = new SerializadorJSON<List<RegistroPartida>>().Serializar(listaRegistros, archivo);
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }

            return retorno;
        }

        public static List<RegistroPartida> ObtenerRegistrosPartidas(string tipoArchivo, bool partidasBotVsBot)
        {
            List<RegistroPartida> listaRegistros = null;
            string nombreArchivo = "Registros_Partidas_UserVsBot" + tipoArchivo.ToUpper();

            if (partidasBotVsBot)
            {
                nombreArchivo = "Registros_Partidas_BotVsBot" + tipoArchivo.ToUpper();
            }

            try
            {
                if(tipoArchivo == "xml")
                {
                    listaRegistros = new SerializadorXML<List<RegistroPartida>>().Deserializar(nombreArchivo);
                }
                else if(tipoArchivo == "json")
                {
                    listaRegistros = new SerializadorJSON<List<RegistroPartida>>().Deserializar(nombreArchivo);
                }
            }
            catch (Exception e)
            {
               throw new Exception(e.Message);
            }

            return listaRegistros;  
        }

    }
}
