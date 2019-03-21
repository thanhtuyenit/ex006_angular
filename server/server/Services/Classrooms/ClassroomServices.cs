using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using server.Databases;
using server.DTO;
using server.Models;
using server.Services.Classrooms;

namespace server.Services.Classrooms
{
    public class ClassroomServices : IClassroomServices
    {
        public DataContext DataContext { get; }
        public IMapper Mapper { get; }
        public ClassroomServices(DataContext dataContext,
                                 IMapper mapper)
        {
            DataContext = dataContext;
            Mapper = mapper;
        }
        public List<ClassroomDTO> ClassroomList()
        {
            return Mapper.Map<List<Classroom>, List<ClassroomDTO>>
                   (DataContext.Classrooms.Where(classroom => !classroom.DeleteFlag).ToList());
        }

        public ClassroomDTO GetClassroomDTOByID(long id)
        {
            return Mapper.Map<ClassroomDTO>(GetClassroomByID(id));
        }

        public Classroom GetClassroomByID(long id)
        {
           return DataContext.Classrooms.FirstOrDefault(classroom => classroom.ID == id && (!classroom.DeleteFlag));
        }
    }
}
