using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inFizYon.Ontology
{
    public class PhraseLabel
    {
        public int phrsID { get; set; }
        public Phrase phrase { get; set; }

        public string labelID { get; set; }
        public Label label { get; set; }
    }
}
