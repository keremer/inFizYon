using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inFizYon.AcademyModels
{
    public class Criterion
    {
        public int CriteriaID { get; set; }
        public string CriteriaDef { get; set; }
        public int CriteriaPts { get; set; }

        public Assignment Assignment { get; set; } 
    }
}
