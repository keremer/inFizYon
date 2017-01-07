using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using inFizYon.Ontology;

namespace inFizYon.ciqModels
{
    public partial class PartyReal
    {
        [Display(Name = "studentID", Prompt = "student No")]
        [Key]
        public int ciqPrID { get; set; }

        [Display(Name = "Ünvan", Prompt = "Ünvan")]
        public int ciqPrtitle { get; set; }

        [Display(Name = "First Name", Prompt = "First Name")]
        public int ciqPrname { get; set; }

        [Display(Name = "Maiden Name", Prompt = "Maiden Name")]
        public int ciqPrmidname { get; set; }

        [Display(Name = "Surname", Prompt = "Surname")]
        public int ciqPrsurname { get; set; }

        [Display(Name = "Nationality", Prompt = "Nationality")]
        public int ciqPruyruk { get; set; }

        [Display(Name = "Birth Date", Prompt = "Birthday")]
        public DateTime ciqPrdt { get; set; }

        [Display(Name = "Place of Birth", Prompt = "Place of Birth")]
        public int ciqPrdy { get; set; }

        [Display(Name = "Father Name", Prompt = "Father Name")]
        public int ciqPrbabaad { get; set; }

        [Display(Name = "Mother Name", Prompt = "Mother Name")]
        public int ciqPrannead { get; set; }

        [Display(Name = "Social Security Nr", Prompt = "Social Security Number")]
        public string ciqPrssec { get; set; }

        [Display(Name = "TR ID Nr", Prompt = "TC Kimlik No")]
        public string ciqPrkimlikmaster { get; set; }

        [Display(Name = "Photo", Prompt = "Photo")]
        public byte[] ciqPrResim { get; set; }

        [Display(Name = "Notes", Prompt = "Notes")]
        public int Not { get; set; }

        //public virtual ICollection<PartyAffiliation> PartyAffiliations { get; set; }

        public virtual ICollection<Phrase> phraseRepository { get; set; }

        public virtual ICollection<PartyPassport> partyPassports { get; set; }
        public virtual ICollection<PartyVisa> partyVisas { get; set; }
        public virtual ICollection<Affiliation> partyEmployment { get; set; }
        public virtual ICollection<PartyeMail> partyeMails { get; set; }
        public virtual ICollection<PartyinAdress> adressHost { get; set; }
        public virtual List<PhoneOwner> phoneNumber { get; set; }
        // public virtual ICollection<M3PCostItems> servemats { get; set; }
        // public virtual ICollection<PartyEmploymentData> partyEmploymentDetails { get; set; }
    }
}