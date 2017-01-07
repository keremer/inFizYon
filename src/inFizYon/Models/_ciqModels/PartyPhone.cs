using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using inFizYon.Ontology;

namespace inFizYon.ciqModels
{
    public class PartyPhone
    {
        [Display(Name = "phone ID", Prompt = "phone ID")]
        [Key]
        public string ciqPhoneNrID { get; set; }

        public DateTime? ciqPoolPhonevalto { get; set; }
        public DateTime ciqPoolPhonevalfrom { get; set; }
        public string ciqPager { get; set; }
        public byte ciqPoolPhonetype { get; set; }
        public byte ciqPoolDatarel { get; set; }
        public byte ciqPoolRelstate { get; set; } // not reachable, wrong number, phonetype mismatch
        public string ciqPoolpswitchboardtype { get; set; } // i.e. PBX
        public string ciqPoolpnrpoolrange { get; set; } // i.e. PBX pool - last two digits ie. 00 thru 40

        public virtual List<PhoneOwner> phoneOwner { get; set; }
    }
}