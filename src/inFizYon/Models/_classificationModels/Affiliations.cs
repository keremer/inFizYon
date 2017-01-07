using System;
using System.Collections.Generic;
using System.Linq;
using inFizYon.ciqModels;

namespace inFizYon.Ontology
{
    public class Affiliation
    {
        public int ciqPrID { get; set; }
        public PartyReal worker { get; set; }

        public int ciqPtID { get; set; }
        public PartyLegal employer { get; set; }
    }
}
