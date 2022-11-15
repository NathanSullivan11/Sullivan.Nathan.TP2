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
            string retorno = "Demoro la conexión a la base de datos. Intentelo nuevamente...";
            List<Jugador> listaJugadores = new List<Jugador>();
            try
            {                
                conexion.Open();
                comando.CommandText = "SELECT id,nombre,partidasJugadas,partidasGanadas,partidasPerdidas " +
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
                        Jugador auxJugador = new Jugador(id,nombre, partidasJugadas, partidasGanadas, partidasPerdidas);
                        listaJugadores.Add(auxJugador);
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
            catch (Exception e)
            {

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

        public bool Agregar(string nombre)
        {
            bool seAgrego = false;
            try
            {
               conexion.Open();

               comando.CommandText = "INSERT INTO Jugadores VALUES (@nombre, 0, 0, 0)";
               comando.Parameters.AddWithValue("@nombre", nombre);
               if(comando.ExecuteNonQuery() == 1)
               {
                    seAgrego = true;
               }
               comando.Parameters.Clear();
            }
            catch (Exception)
            {

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
