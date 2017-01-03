using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inFizYon.AcademyModels
{
    public class Assignment
    {
        public int assignmentID { get; set; }
        public string assignmentDef { get; set; }  
        public DateTime givenDate { get; set; }
        public DateTime dueDate { get; set; }

        public Course course { get; set; }
    }
}
