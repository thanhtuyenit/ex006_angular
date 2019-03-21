using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Classroom : CRUDCommon
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
