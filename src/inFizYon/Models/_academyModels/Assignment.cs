using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inFizYon.AcademyModels
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public string AssignmentDef { get; set; }  
        public DateTime GivenDate { get; set; }
        public DateTime DueDate { get; set; }

        public Course Course { get; set; }
    }
}
