using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace inFizYon.ciqModels
{
    public partial class PartyPassport //: IEnumerable<PartyPassport>, IList<PartyPassport>
    {
        [Display(Name = "PasaportID", Prompt = "Pasaport Veritabanı Kayıt No")]
        [Key]
        public int ciqPartyPasID { get; set; }

        public int ciqPrID { get; set; }
       
        [Display(Name = "Pasaport No", Prompt = "Pasaport No")]
        public string ciqPartyPasno { get; set; }

        [Display(Name = "Veriliş Tarihi", Prompt = "Pasaport veriliş tarihi")]
        public System.DateTime ciqPartyPasvert { get; set; }

        [Display(Name = "Geçerlilik Tarihi", Prompt = "Pasaport aşağıdaki tarihe kadar geçerlidir")]
        public System.DateTime ciqPartyPasgec { get; set; }

        [Display(Name = "Verildiği Yer", Prompt = "Pasaportu veren yer")]
        public string ciqPartyPasvery { get; set; }

        [Display(Name = "Taranmış Pasaport Görüntüsü", Prompt = "Pasaportun taranmış sayfaları")]
        public byte[] ciqPartyPasimg { get; set; }

        public virtual PartyReal partyReal { get; set; }
        public virtual ICollection<PartyVisa> partyVisas { get; set; }

    }
}