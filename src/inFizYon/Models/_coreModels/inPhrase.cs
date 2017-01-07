namespace inFizYon
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ontology;

    public partial class Phrase
    {
        [Key]
        public int phrsID { get; set; }
        public string phrsTRtxt { get; set; }
        public string phrsENtxt { get; set; }
        public byte phrsComp { get; set; }
        public byte phrsReliance { get; set; }
    
        public virtual InMF inMFSection { get; set; }
        public virtual ICollection<InProject> inProjects { get; set; }
        public virtual ICollection<Comment> comments { get; set; }
        public virtual ICollection<Package> inPackages { get; set; }

        public List<PhraseLabel> phraselabels { get; set; }
    }
}
