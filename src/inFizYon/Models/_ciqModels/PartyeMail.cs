using System;
using System.ComponentModel.DataAnnotations;

namespace inFizYon.PartyModels
{
    public partial class PartyeMail
    {
        [Display(Name = "email ID", Prompt = "email ID")]
        [Key]
        public int ciqPartyepostaID { get; set; }
       
        public int ciqPrID { get; set; }

        public System.DateTime ciqPartyepostavalidfrom { get; set; }
        public Nullable<System.DateTime> ciqPartyepostavalidto { get; set; }
        public string ciqPartyeposta { get; set; }
        public byte ePostaAttribute { get; set; } // main, secondary, work
                
        public virtual PartyReal emailOwner { get; set; }
    }
}