using server.DTO;
using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.Classrooms
{
    public interface IClassroomServices
    {
        List<ClassroomDTO> ClassroomList();
        ClassroomDTO GetClassroomDTOByID(long id);
        Classroom GetClassroomByID(long classroomID);
    }
}
