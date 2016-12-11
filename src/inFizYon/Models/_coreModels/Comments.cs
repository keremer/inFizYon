
namespace inFizYon
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Comment
    {
        public int CommentID { get; set; }
        public String Commenttxt { get; set; }
        public virtual Phrase Commented { get; set; }
    }
}
