using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTO;
using server.Models;

namespace server.Services.Students
{
    public interface IStudentServices
    {
        List<StudentDTO> StudentList();
        Student GetStudentByID(int id);
        StudentDTO GetStudentDTOByID(int id);
        void Create(Student student);
        void DeleteStudent(int id);
        void UpdateStudent(Student student);
    }
}
