using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inFizYon.AcademyModels
{
    public class Criterion
    {
        public enum CriteriaType
        { goodbad, pScore, pPercent, aScore, aPercent }
        public int CriteriaID { get; set; }
        public string CriteriaDef { get; set; }
        public CriteriaType? cType { get; set; }

        public Assignment Assignment { get; set; } 
    }
}
