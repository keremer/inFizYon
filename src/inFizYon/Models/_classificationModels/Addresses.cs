using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inFizYon.ciqModels;

namespace inFizYon.Ontology
{
    public class PartyinAdress
    {
        public int ciqAdresPID { get; set; }
        public PartyPostalAdress postalAdress { get; set; }

        public int ciqPrID { get; set; }
        public PartyReal adressOwner { get; set; }
    }
}
