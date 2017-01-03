using inFizYon.ciqModels;

namespace inFizYon.AcademyModels
{
    public class PartyEvaluation
    {
        public int evaluationID { get; set; }
        public Assignment forAssignment { get; set; }
        public PartyReal forStudent { get; set; }
        public Criterion forCriteria { get; set; }
        public int counter { get; set; }
        public int score { get; set; }
    }
}
