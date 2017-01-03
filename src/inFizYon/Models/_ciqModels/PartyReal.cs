using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace inFizYon.ciqModels
{
    public partial class PartyReal
    {
        [Display(Name = "studentID", Prompt = "student No")]
        [Key]
        public int ciqPrID { get; set; }

        [Display(Name = "Ünvan", Prompt = "Ünvan")]
        public string ciqPrtitle { get; set; }

        [Display(Name = "First Name", Prompt = "First Name")]
        public string ciqPrname { get; set; }

        [Display(Name = "Maiden Name", Prompt = "Maiden Name")]
        public string ciqPrmidname { get; set; }

        [Display(Name = "Surname", Prompt = "Surname")]
        public string ciqPrsurname { get; set; }

        [Display(Name = "Nationality", Prompt = "Nationality")]
        public string ciqPruyruk { get; set; }

        [Display(Name = "Birth Date", Prompt = "Birthday")]
        public DateTime ciqPrdt { get; set; }

        [Display(Name = "Place of Birth", Prompt = "Place of Birth")]
        public string ciqPrdy { get; set; }

        [Display(Name = "Father Name", Prompt = "Father Name")]
        public string ciqPrbabaad { get; set; }

        [Display(Name = "Mother Name", Prompt = "Mother Name")]
        public string ciqPrannead { get; set; }

        [Display(Name = "Social Security Nr", Prompt = "Social Security Number")]
        public string ciqPrssec { get; set; }

        [Display(Name = "TR ID Nr", Prompt = "TC Kimlik No")]
        public string ciqPrkimlikmaster { get; set; }

        [Display(Name = "Photo", Prompt = "Photo")]
        public byte[] ciqPrResim { get; set; }

        [Display(Name = "Notes", Prompt = "Notes")]
        public string Not { get; set; }

        //public virtual ICollection<PartyAffiliation> PartyAffiliations { get; set; }
        
        public virtual ICollection<PartyPassport> partyPassports { get; set; }
        public virtual ICollection<PartyVisa> partyVisas { get; set; }
        public virtual ICollection<PartyLegal> partyEmployment { get; set; }
        public virtual ICollection<PartyeMail> partyeMails { get; set; }
        public virtual ICollection<PartyPostalAdress> partyAdresses { get; set; }
        public virtual ICollection<PartyPhone> partyPhones { get; set; }
        // public virtual ICollection<M3PCostItems> servemats { get; set; }
        // public virtual ICollection<PartyEmploymentData> partyEmploymentDetails { get; set; }
    }
}