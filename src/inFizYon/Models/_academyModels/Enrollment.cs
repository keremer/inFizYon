using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inFizYon.ciqModels;
namespace inFizYon.AcademyModels
{
        public enum Grade
        {
            A, B, C, D, F
        }

        public class Enrollment
        {
            public int enrollmentID { get; set; }
            public int courseID { get; set; }
            public int studentID { get; set; }
            public Grade? grade { get; set; }

            public Course course { get; set; }
            public PartyReal student { get; set; }
        }
}
