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
        static string connectionString = "Data Source=LAPTOP-E49VKATT;Initial Catalog=College;Integrated Security=True;Pooling=False";
        DataClasses1DataContext collegeDataContext = new DataClasses1DataContext(connectionString);
        // GET: api/Professors
        public IHttpActionResult Get()
        {

            try
            {
                return Ok(collegeDataContext.Professors.ToList());
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

        //// GET: api/Professors/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(collegeDataContext.Professors.First((studetItem) => studetItem.Id == id));
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

        //// POST: api/Professors
        public IHttpActionResult Post([FromBody] Professor professor)
        {
            try
            {

                collegeDataContext.Professors.InsertOnSubmit(professor);
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
            }

        }

        //// PUT: api/Professors/5
        public IHttpActionResult Put(int id, [FromBody] Professor professor)
        {
            try
            {

                Professor professorFound = collegeDataContext.Professors.First((professorItem) => professorItem.Id == id);
                professorFound.FirstName = professor.FirstName;
                professorFound.LastName = professor.LastName;
                professorFound.Email = professor.Email;
                professorFound.Subject = professor.Subject;
                professorFound.Salary = professor.Salary;

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

        // DELETE: api/Professors/5
        public IHttpActionResult Delete(int id)
        {

            try
            {

                collegeDataContext.Professors.DeleteOnSubmit(collegeDataContext.Professors.First((professorItem) => professorItem.Id == id));
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



