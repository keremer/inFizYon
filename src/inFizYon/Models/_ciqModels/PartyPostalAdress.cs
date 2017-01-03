using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace inFizYon.ciqModels
{
    public class PartyPostalAdress

//ENTITY IfcPostalAddress
	
//  SUBTYPE OF ( 	IfcAddress);
	
//      InternalLocation    :  	OPTIONAL IfcLabel;
//      AddressLines 	    :  	OPTIONAL LIST [1:?] OF IfcLabel;
//      PostalBox 	        :  	OPTIONAL IfcLabel;
//      Town 	            :  	OPTIONAL IfcLabel;
//      Region 	            :  	OPTIONAL IfcLabel;
//      PostalCode 	        :  	OPTIONAL IfcLabel;
//      Country 	        :  	OPTIONAL IfcLabel;
//  WHERE
	
//      WR1 	            :  	EXISTS (InternalLocation) OR EXISTS (AddressLines) OR EXISTS (PostalBox) OR EXISTS (PostalCode) OR EXISTS (Town) OR EXISTS (Region) OR EXISTS (Country);
//END_ENTITY; 

    {
        [Display(Name = "adres ID", Prompt = "adres ID")]
        [Key]
        public int ciqAdresPID { get; set; }

        public string ciqPooladrtype { get; set; }
        public string ciqPoolinternalLocation { get; set; }
        public string ciqPooladrline1 { get; set; }
        public string ciqPooladrline2 { get; set; }
        public string ciqPoolpostalbox { get; set; }
        public string ciqPooltown { get; set; }
        public string ciqPoolregion { get; set; }
        public string ciqZIP { get; set; }
        public string ciqPoolcountry { get; set; }
        public DateTime ciqPooladrValidfrom { get; set; }
        public DateTime? ciqPooladrValidto { get; set; }
        public short ciqLocalizationIndex { get; set; }

        public virtual ICollection<PartyReal> adresOwners { get; set; }
    }
}