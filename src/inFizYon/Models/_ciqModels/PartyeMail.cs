using System;
using System.ComponentModel.DataAnnotations;

namespace inFizYon.ciqModels
{
    public partial class PartyeMail
    {
        [Display(Name = "email ID", Prompt = "email ID")]
        [Key]
        public int ciqPartyepostaID { get; set; }
       
        public int ciqPrID { get; set; }

        public DateTime ciqPartyepostavalidfrom { get; set; }
        public DateTime? ciqPartyepostavalidto { get; set; }
        public string ciqPartyeposta { get; set; }

        public enum ePostaAttribute : byte
        {
            main = 0,
            secondary = 1,
            work = 2
        };

        public ePostaAttribute ePostis { get; set; } // main, secondary, work
                
        public virtual PartyReal emailOwner { get; set; }
    }
}