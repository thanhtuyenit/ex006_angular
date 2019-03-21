using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.DTO;
using server.Models;
using server.Responses;
using server.Services.Classrooms;
using server.Services.Students;

namespace server.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private IClassroomServices ClassroomServices { get;}
        private APIResponses APIResponses { get;}
        public ClassroomController(IClassroomServices classroomServices)
        {
            ClassroomServices = classroomServices;
        }

        [Route("classrooms")]
        public APIResponses ClassroomList()
        {
            return new APIResponses(200, "Success", ClassroomServices.ClassroomList());
        }

        [HttpGet, Route("classrooms/{id}")]
        public APIResponses GetClassroomByID(int id)
        {
            return new APIResponses(200, "Success", ClassroomServices.GetClassroomDTOByID(id));
        }
    }
}