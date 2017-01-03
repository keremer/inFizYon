using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace inFizYon.AcademyModels
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int courseID { get; set; }
        public string title { get; set; }
        public int credits { get; set; }

        public ICollection<Enrollment> enrollment { get; set; }
    }
}
