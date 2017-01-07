namespace inFizYon
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Package
    {
        [Key]
        public int inputID { get; set; }

        public int inPackageParent { get; set; }//Why? Documentation required
        public int parentID { get; set; }       //Why? Documentation required
        public int inPackageChild { get; set; } //Why? Documentation required

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public enum parLevel : byte //may not be necessary - data model changed to a recursive layout.
        {
            Package = 0,
            Division = 1,
            Section = 2,
            Part = 3,
            Article = 4,
            Indent1 = 5,
            Indent2 = 6,
            Indent3 = 7,
            Indent4 = 8,
            Indent5 = 9,            
            Smalltext = 10,
            Caption = 11,
            TableText = 12
        } 
        public enum parType : byte //may not be necessary - data model changed to a recursive layout. 
        { 
            title = 0, 
            heading = 1, 
            article = 2,
            paragraph = 3, 
            nulst = 4,
            bulst = 5,
            standard = 6, 
            table = 7, 
            footnote = 8, 
            endnote = 9, 
            caption = 10, 
            reference = 11 
        }
        public parLevel pLevel { get; set; }
        public parType pType { get; set; }
        public short parOrder { get; set; }

        public int inProjectID { get; set; }
        [ForeignKey("inProjectID")]
        public virtual InProject inProject { get; set; }

        public int childID { get; set; }
        [ForeignKey("childID")]
        public virtual Phrase phrases { get; set; }
    }
}
