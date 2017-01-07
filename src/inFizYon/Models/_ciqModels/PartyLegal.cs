using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using inFizYon.Ontology;

namespace inFizYon.ciqModels
{
    public class PartyLegal
    {
        [Display(Name = "Kurum ID", Prompt = "Kurum ID")]
        [Key]
        public int ciqPtID { get; set; }

        [Display(Name = "Ticari Ünvan", Prompt = "Ticari Ünvan")]
        public string ciqPartyTuzelTicariUnvan { get; set; }

        [Display(Name = "Kayıt Giriş Tarihi", Prompt = "Kayıt Giriş Tarihi")]
        public DateTime ciqPartTuzelvalfrom { get; set; }

        [Display(Name = "Geçerlilik Tarihi", Prompt = "Geçerlilik Tarihi")]
        public Nullable<System.DateTime> ciqPartyvalto { get; set; }

        [Display(Name = "Vergi Dairesi", Prompt = "Vergi Dairesi")]
        public string ciqPartyvergid { get; set; }

        [Display(Name = "Vergi No", Prompt = "Vergi No")]
        public string ciqPartyTuzelvergino { get; set; }

        [Display(Name = "Kurum Türü", Prompt = "Kurum Türü")]
        public string ciqPartyTuzelintype { get; set; }

        public virtual ICollection<Affiliation> humanResources { get; set; }
        
    }
}