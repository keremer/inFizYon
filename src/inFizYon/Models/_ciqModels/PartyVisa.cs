using System.ComponentModel.DataAnnotations;

namespace inFizYon.PartyModels
{
    public class PartyVisa //: IEnumerable<PartyVisa>, IList<PartyVisa>
    {
        [Display(Name = "Vize ID", Prompt = "Vize ID")]
        [Key]
        public int ciqPartyVisaID { get; set; }

        public int ciqPartyPasID { get; set; }
        public int ciqPrID { get; set; }
        
        [Display(Name = "Vize Türü", Prompt = "Vize Tipi")]
        public string ciqPartyVizetipi { get; set; }

        [Display(Name = "Vize Başlangıcı", Prompt = "Vize başlangıç tarihi")]
        public System.DateTime ciqPartyVizebas { get; set; }

        [Display(Name = "Vize Bitişi", Prompt = "Vize bitiş tarihi")]
        public System.DateTime ciqPartyVizeson { get; set; }

        [Display(Name = "Ülke", Prompt = "Vize hangi ülke için alındı?")]
        public string ciqPartyVizecnt { get; set; }

        [Display(Name = "Vize No", Prompt = "Vize No")]
        public string ciqPartyVizeno { get; set; }

        [Display(Name = "G/Ç Sayısı", Prompt = "Vizece izin verilen; ülkeye giriş çıkış sayısı")]
        public string ciqPartyVizeEnt { get; set; }

        [Display(Name = "Vize Görüntüsü", Prompt = "Vizenin taranmış görüntüsü")]
        public byte[] ciqPartyVizeimg { get; set; }

        public virtual PartyPassport partyPassport { get; set; }
        public virtual PartyReal partyReal { get; set; }
      
    }
}