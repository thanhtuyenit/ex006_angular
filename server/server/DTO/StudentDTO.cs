using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTO
{
    public class StudentDTO : CRUDCommonDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public long ClassroomID { get; set; }
        public ClassroomDTO Classroom { get; set; }
    }
}
