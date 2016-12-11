using System;
using System.Collections.Generic;
using System.Linq;

namespace inFizYon.Ontology
{
    public class Label
    {
        public int LabelID { get; set; }
        public string Labeltxt { get; set; }
        public enum MetaData : byte
        {
            Custom = 0,
            MasterFormat = 1,
            UniFormat = 2
        };
        public MetaData Origin { get; set; }
        public virtual ICollection<Phrase> Phrases { get; set; }
    }
}