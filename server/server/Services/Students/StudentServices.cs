using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Databases;
using server.DTO;
using server.Models;
using server.Services.Classrooms;

namespace server.Services.Students
{
    public class StudentServices : IStudentServices
    {
        public DataContext DataContext { get; }
        public IClassroomServices IClassroomServices { get; }
        public IMapper Mapper { get; }
        public StudentServices(DataContext dataContext,
                               IClassroomServices classroomServices,
                               IMapper mapper)
        {
            DataContext = dataContext;
            IClassroomServices = classroomServices;
            Mapper = mapper;
        }
        public List<StudentDTO> StudentList()
        {
            List<StudentDTO> result = new List<StudentDTO>();
            ClassroomDTO classroomDTO = new ClassroomDTO();
            StudentDTO studentDTO = new StudentDTO();
            List<Student> students = DataContext.Students.Where(student => !student.DeleteFlag).Include(x => x.Classroom).ToList();
            foreach (Student student in students)
            {
                studentDTO = Mapper.Map<StudentDTO>(student);
                studentDTO.Classroom = Mapper.Map<ClassroomDTO>(student.Classroom);
                result.Add(studentDTO);
            }
            return result;
        }

        public StudentDTO GetStudentDTOByID(int id)
        {
            StudentDTO studentDTO = new StudentDTO();
            ClassroomDTO classroomDTO = new ClassroomDTO();
            Student student = GetStudentByID(id);
            studentDTO = Mapper.Map<StudentDTO>(student);
            studentDTO.Classroom = Mapper.Map<ClassroomDTO>(student.Classroom);
            return studentDTO;
        }

        public Student GetStudentByID(int id)
        {
            return DataContext.Students.Include(x => x.Classroom).FirstOrDefault(student => !student.DeleteFlag && student.ID == id);
        }

        public void Create(Student student)
        {
            DataContext.Add(student);
            DataContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student studentDel = GetStudentByID(id);
            studentDel.DeleteFlag = true;
            DataContext.Students.Update(studentDel);
            DataContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            student.Classroom = IClassroomServices.GetClassroomByID(student.ClassroomID);
            DataContext.Students.Update(student);
            DataContext.SaveChanges();
        }
    }
}
