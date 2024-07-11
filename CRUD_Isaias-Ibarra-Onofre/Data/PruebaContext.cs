using CRUD_Isaias_Ibarra_Onofre.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CRUD_Isaias_Ibarra_Onofre.Data
{
    public class PruebaContext : DbContext
    {
        private readonly string _connection;

        public PruebaContext(IConfiguration configuration) => _connection = configuration.GetConnectionString("DefaultConnection");
        public IEnumerable<Prueba> GetAll()
        {
            var entidades = new List<Prueba>();

            using (SqlConnection con = new SqlConnection(_connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Prueba", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var entidad = new Prueba
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Numero = Convert.ToInt32(rdr["Numero"]),
                        FechaHora = Convert.ToDateTime(rdr["FechaHora"]),
                        NombreApellido = rdr["NombreApellido"].ToString()
                    };
                    entidades.Add(entidad);
                }

                con.Close();
            }

            return entidades;
        }

        public void Add(Prueba prueba)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Prueba (Numero, FechaHora, NombreApellido) VALUES (@Numero, @FechaHora, @NombreApellido)", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Numero", prueba.Numero);
                cmd.Parameters.AddWithValue("@FechaHora", prueba.FechaHora);
                cmd.Parameters.AddWithValue("@NombreApellido", prueba.NombreApellido);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(Prueba prueba)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Prueba SET Numero = @Numero, FechaHora = @FechaHora, NombreApellido = @NombreApellido WHERE Id = @Id", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", prueba.Id);
                cmd.Parameters.AddWithValue("@Numero", prueba.Numero);
                cmd.Parameters.AddWithValue("@FechaHora", prueba.FechaHora);
                cmd.Parameters.AddWithValue("@NombreApellido", prueba.NombreApellido);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Prueba WHERE Id = @Id", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }


}
