using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.DTO;
using server.Models;
using server.Responses;
using server.Services.Students;

namespace server.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentServices StudentServices {get;}
        private APIResponses APIResponses { get;}
        public StudentController(IStudentServices studentService)
        {
            StudentServices = studentService;
        }

        [Route("students")]
        public APIResponses StudentList()
        {
            return new APIResponses(200, "Success", StudentServices.StudentList());
        }

        [HttpGet, Route("students/{id}")]
        public APIResponses GetStudentByID(int id)
        {
            return new APIResponses(200, "Success", StudentServices.GetStudentDTOByID(id));
        }

        [HttpPut, Route("students/{id}")]
        public APIResponses Update([FromBody] Student student)
        {
            StudentServices.UpdateStudent(student);
            return new APIResponses(200, "Success", null);
        }

        [HttpPost, Route("students/create")]
        public APIResponses Create([FromBody] Student student)
        {
            StudentServices.Create(student);

            return new APIResponses(200, "Success", null);
        }

        [HttpDelete, Route("students/{id}")]
        public APIResponses Delete(int id)
        {
            StudentServices.DeleteStudent(id);

            return new APIResponses(200, "Success", null);
        }
    }
}