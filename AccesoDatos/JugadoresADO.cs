using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace AccesoDatos
{
    public class JugadoresADO
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        
        public JugadoresADO()
        {
            conexion = new SqlConnection("Server=DESKTOP-A3F48MG;Database=JuegoTrucoBD;Trusted_Connection=True;encrypt=false");
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
        }

        public string ObtenerListaJugadores()
        {
            string retorno = "Demoro la conexión a la base de datos. Intentelo nuevamente...";
            try
            {
                conexion.Open();
                comando.CommandText = "SELECT * FROM Jugadores";
                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        string nombre = dataReader["nombre"].ToString();
                        int partidasJugadas = (int)dataReader["partidasJugadas"];
                        int partidasGanadas = (int)dataReader["partidasGanadas"];
                        int partidasPerdidas = (int)dataReader["partidasPerdidas"];
                        Jugador auxJugador = new Jugador(nombre, partidasJugadas, partidasGanadas, partidasPerdidas);
                        Juego.Jugadores.Add(auxJugador);
                    }
                }
                retorno = "Conexion a base de datos exitosa";
            }
            catch(Exception)
            {
                
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }         
            }
            return retorno;
        }


    }
}
