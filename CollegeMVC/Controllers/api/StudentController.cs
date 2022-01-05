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
       static string connectionString = "Data Source=LAPTOP-E49VKATT;Initial Catalog=College;Integrated Security=True;Pooling=False";

       DataClasses1DataContext collegeDataContext=new DataClasses1DataContext(connectionString);
        // GET: api/Student
        public IHttpActionResult Get()
        {
       
            try
            {
                return Ok(collegeDataContext.Students.ToList());
            }

            catch (SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex )
            {
                return Ok(new { ex.Message });
            }
        }

        //GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
            try
            {
               
                return Ok(collegeDataContext.Students.First((studetItem) => studetItem.Id == id));

            }
            catch (SqlException ex)
            {
                return Ok(new {ex.Message});
            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }

        }

        // POST: api/Student
        public IHttpActionResult Post([FromBody] Student student)
        {
            try
            {
              collegeDataContext.Students.InsertOnSubmit(student);
                collegeDataContext.SubmitChanges();
                return Ok("item was add");
            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });

            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
                throw;
            }

            }

        //// PUT: api/Student/5
        public IHttpActionResult Put(int id, [FromBody] Student student)
        {

            try
            {
                Student studentFound = collegeDataContext.Students.First((studentItem) => studentItem.Id == id);
                studentFound.FirstName= student.FirstName;
                studentFound.LastName= student.LastName;
                studentFound.Email= student.Email;
                studentFound.BirthDay= student.BirthDay;
                studentFound.YearOfStudey= student.YearOfStudey;
                collegeDataContext.SubmitChanges();
                return Ok(" item was update");


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

        //// DELETE: api/Student/5
        public IHttpActionResult Delete(int id)
        {

            try
            {

             collegeDataContext.Students.DeleteOnSubmit(collegeDataContext.Students.First((studentItem) => studentItem.Id == id));
                collegeDataContext.SubmitChanges();

                return Ok("item was daleted");

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
