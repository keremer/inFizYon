﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace inFizYon.Ontology
{
    public class Label
    {
        public string labelID { get; set; }
        public enum MetaData : byte
        {
            Custom = 0,
            MasterFormat = 1,
            UniFormat = 2
        };
        public MetaData origin { get; set; }

        public ICollection<Phrase> phrases { get; set; }
    }
}