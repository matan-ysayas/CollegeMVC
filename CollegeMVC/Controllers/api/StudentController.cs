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
    public class StudentController : ApiController
    {
        string connectionString = "Data Source=LAPTOP-E49VKATT;Initial Catalog=College;Integrated Security=True;Pooling=False";
        // GET: api/Student
        public IHttpActionResult Get()
        {
        List<Student> studentsList = new List<Student>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Student";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            studentsList.Add(new Student(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), reader.GetInt32(5)));
                        }
                        return Ok(new { studentsList });
                    }
                    connection.Close();
                    return Ok(new { studentsList });

                   
                }
                

            }

            catch (SqlException )
            {
                throw; 
            }
            catch (Exception )
            {
                throw;
            }
        }

        // GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Student WHERE Id={id}";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Student studentFind = new Student(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), reader.GetInt32(5));
                            return Ok(new { studentFind });
                        }

                    }
                    connection.Close();
                    return Ok( new{ Message= "not found"});
                    
                }

            } catch (SqlException ex)
            {
                throw;
            } catch (Exception)
            {
                throw;
            }

        }

        // POST: api/Student
        public IHttpActionResult Post([FromBody] Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    string query = $@"INSERT INTO Student(FirstName,LastName,BirthDay,Email,YearOfStudey) VALUES('{student.Firstname}','{student.LastName}','{student.BirthDay}','{student.Email}',{student.YearOfStudy}) ";
                    SqlCommand cmd = new SqlCommand(query,connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return Ok(new { message="add student" }); 
                    

                }

            }catch (SqlException ex)
            {
                return Ok(new{ex.Message});
               
            }
            catch (Exception ex)
            {
                return Ok(new {ex.Message });
                throw;
            }
            
        }

        // PUT: api/Student/5
        public IHttpActionResult Put(int id, [FromBody] Student student)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open ();
                    string query = $@"UPDATE Student SET  FirstName='{student.Firstname}',LastName='{student.LastName}',BirthDay='{student.BirthDay}',Email='{student.Email}',YearOfStudey='{student.YearOfStudy}'  WHERE Id={id} ";
                    SqlCommand cmd= new SqlCommand(query,connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();                
                    return Ok(new { message = "the student was update" });

                }

            }catch (SqlException ex)
            {
                return Ok(new {ex.Message});
            }catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }
            
        }

        // DELETE: api/Student/5
        public IHttpActionResult Delete(int id)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"DELETE FROM Student WHERE Id={id} ";
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
