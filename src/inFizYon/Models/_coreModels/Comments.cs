
namespace inFizYon
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Comment
    {
        public int commentID { get; set; }
        public string commentTxt { get; set; }
        public virtual Phrase commented { get; set; }
    }
}
