using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inFizYon.ciqModels;

namespace inFizYon.Ontology
{
    public class PhoneOwner
    {
        public int ciqPrID { get; set; }
        public PartyReal person {get;set;}

        public string ciqPhoneNrID { get; set; }
        public PartyPhone phoneNumber { get; set; }
    }
}
