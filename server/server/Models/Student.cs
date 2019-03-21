using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Student : CRUDCommon
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long ClassroomID { get; set; }
        public DateTime DOB { get; set; }

        [ForeignKey("ClassroomID")]
        public virtual Classroom Classroom { get; set; }
    }
}
