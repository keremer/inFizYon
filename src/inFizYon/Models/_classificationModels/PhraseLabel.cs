using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inFizYon.Ontology
{
    public class PhraseLabel
    {
        public int phrsID { get; set; }
        public Phrase Phrase { get; set; }

        public int labelID { get; set; }
        public Label Label { get; set; }
    }
}
