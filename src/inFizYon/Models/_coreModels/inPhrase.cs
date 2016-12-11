namespace inFizYon
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    // using inFizYon.Migrations;
    // using inFizYon.DataModel;
    using inFizYon.Ontology;

    public partial class Phrase
    {
        [Key]
        public int phrsID { get; set; }
        public string phrsTRtxt { get; set; }
        public string phrsENtxt { get; set; }
        public byte phrsComp { get; set; }
        public byte phrsReliance { get; set; }
    
        public virtual inMF MFSection { get; set; }
        public virtual ICollection<inProject> inProjects { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Package> inPackages { get; set; }
        public virtual ICollection<Label> Labels { get; set; }
    }
}
