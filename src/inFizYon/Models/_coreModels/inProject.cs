//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace inFizYon
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class InProject // This class will be merged with the IFC_Project later
    {
        //public inProje()
        //{
        //    this.specSection = new HashSet<specSection>();
        //}
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int prjID { get; set; } //Project ID is same as dedicated name phrase ID
        [ForeignKey("phraseRepositoryprjID")]
        public virtual Phrase projectName { get; set; }

        public string prjCode { get; set; } //dedicated project codepublic string prjName
        public int prjPlace { get; set; } //i.e. Istanbul Finance Centre
        
        public virtual ICollection<Package> packageRepository { get; set; }
        //public virtual inLocation inLocation { get; set; }
    }
}
