using System;
using System.Collections.Generic;
using System.Linq;
using inFizYon.PartyModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace inFizYon.Render
{
    public class EmployeeList
    {
        [Display(Name = "Adı", Prompt = "İlk Adı")]
        public string ad { get; set; }
        [Display(Name = "Soyadı", Prompt = "Soyadı")]
        public string sd { get; set; }
        [Display(Name = "Pasaport No", Prompt = "Pasaport No")]
        public string pn { get; set; }
        [Display(Name = "Vize No", Prompt = "Vize No")]
        public string vn { get; set; }
        [Display(Name = "Pasaport Süresi", Prompt = "Pasaport geçerlilik tarihi")]
        public DateTime pt { get; set; }
        [Display(Name = "Vize Süresi", Prompt = "Vize geçerlilik tarihi")]
        public DateTime vt { get; set; }
    }
}