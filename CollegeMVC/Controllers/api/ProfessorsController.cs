using CollegeMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollegeMVC.Controllers.api
{
    public class ProfessorsController : ApiController
    {
        string connectionString = "Data Source=LAPTOP-E49VKATT;Initial Catalog=College;Integrated Security=True;Pooling=False";
        // GET: api/Professors
        public IHttpActionResult Get()
        {
            List<Professor> professorsList = new List<Professor>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"SELECT * FROM Professors";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            professorsList.Add(new Professor(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5)));
                        }
                        return Ok(new { professorsList });
                    }
                    connection.Close();
                    return Ok(new { professorsList });
                }


            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }

        }

        // GET: api/Professors/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT * FROM Professors WHERE Id={id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Professor professor = new Professor(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                            return Ok(new { professor });
                        }

                    }
                    connection.Close();
                    return Ok(new { Message = "not found" });
                }
            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }
        }

        // POST: api/Professors
        public IHttpActionResult Post([FromBody] Professor professor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"INSERT INTO Professors(FirstName,LastName,Subject,Email,Salary) VALUES('{professor.FirstName}','{professor.LastName}','{professor.Subject}','{professor.Email}',{professor.Salary}) ";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return Ok(new { message = "Professor add" });
                }

            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }

        }

        // PUT: api/Professors/5
        public IHttpActionResult Put(int id, [FromBody] Professor professor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"UPDATE Professors SET  FirstName='{professor.FirstName}',LastName='{professor.LastName}',Subject='{professor.Subject}',Email='{professor.Email}',Salary={professor.Salary} WHERE Id={id} ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return Ok(new { message = "the Professor was update" });

                }

            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }

        }

        // DELETE: api/Professors/5
        public IHttpActionResult Delete(int id)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"DELETE FROM Professors WHERE Id={id} ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return Ok(new { message = "item was Deleted" });

                }

            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }
        }
    }
}



