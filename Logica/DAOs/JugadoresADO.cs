using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
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

        public List<Jugador> ObtenerJugadores()
        {
            List<Jugador> listaJugadores = new List<Jugador>();
            try
            {                
                conexion.Open();
                comando.CommandText = "SELECT * FROM Jugadores";
                comando.CommandText = "SELECT id,nombre,partidasJugadas,partidasGanadas,partidasPerdidas,esUsuario " +
                    "FROM Jugadores";
                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        int id = (int)dataReader["id"];
                        string nombre = dataReader["nombre"].ToString();
                        int partidasJugadas = (int)dataReader["partidasJugadas"];
                        int partidasGanadas = (int)dataReader["partidasGanadas"];
                        int partidasPerdidas = (int)dataReader["partidasPerdidas"];
                        bool esUsuario = (bool)dataReader["esUsuario"];

                        Jugador auxJugador = new Jugador(id,nombre, partidasJugadas, partidasGanadas, partidasPerdidas, esUsuario);
                        listaJugadores.Add(auxJugador);
                    }
                }

            }
            catch(Exception)
            {
                throw new Exception("No se ha podido obtener la lista de jugadores de la base de datos");
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }         
            }
            return listaJugadores;
        }

        public bool Actualizar(Jugador jugador)
        {
            bool seActualizo = false;
            try
            {
                conexion.Open();
                comando.CommandText = "UPDATE Jugadores SET partidasJugadas = @partidasJugadas, partidasGanadas = @partidasGanadas, partidasPerdidas = @partidasPerdidas WHERE id = @id";

                comando.Parameters.AddWithValue("@id", jugador.idBaseDeDatos);
                comando.Parameters.AddWithValue("@partidasJugadas", jugador.PartidasJugadas);
                comando.Parameters.AddWithValue("@partidasGanadas", jugador.PartidasGanadas);
                comando.Parameters.AddWithValue("@partidasPerdidas", jugador.PartidasPerdidas);
                
                if(comando.ExecuteNonQuery() == 1)
                { 
                    seActualizo = true;
                }
                comando.Parameters.Clear();
                
            }
            catch (Exception )
            {
                throw new Exception("No se ha podido actualizar el jugador en base de datos");
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return seActualizo;
        }
        
        public bool Eliminar(int idJugador)
        { 
            bool seElimino = false;

            try
            {
               conexion.Open();
               comando.CommandText = "DELETE Jugadores WHERE id = @id";
               comando.Parameters.AddWithValue("@id", idJugador);
               if(comando.ExecuteNonQuery() == 1)
               {
                    seElimino = true;
               }
                comando.Parameters.Clear();
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido eliminar al jugador de la base de datos");
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return seElimino;

        }

        public bool Agregar(string nombre, int esUsuario)
        {
            bool seAgrego = false;
            try
            {
               conexion.Open();

               comando.CommandText = "INSERT INTO Jugadores VALUES (@nombre, 0, 0, 0, @esUsuario)";
               comando.Parameters.AddWithValue("@nombre", nombre);
               comando.Parameters.AddWithValue("@esUsuario", esUsuario);
               if(comando.ExecuteNonQuery() == 1)
               {
                    seAgrego = true;
               }
               comando.Parameters.Clear();
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido agregar al jugador a la base de datos");
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return seAgrego;
        }

    }


}
