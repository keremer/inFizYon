using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inFizYon.Ontology
{
    public class Pack
    // Class to pack phrases into a spec document with basic style information.
    {
        private List<NLine> specLines = new List<NLine>();

        public void AddNLine(int node, int lvl, int parent, string content)
        {
            NLine line = new NLine();
            line.lineID = node;
            line.parentID = parent;
            line.lvl = lvl;
            line.content = content;
            specLines.Add(line);
        }

        //public double OrderTotal()
        //{
        //    double total = 0;
        //    foreach (NLine line in _orderLines)
        //    {
        //        total += line.OrderLineTotal();
        //    }
        //    return total;
        //}

        // Nested class
        private class NLine
        {
            public int lineID { get; set; }
            public int parentID { get; set; }
            public int lvl { get; set; }
            public string content { get; set; }

            //public double OrderLineTotal()
            //{
            //    return Child * lvl;
            //}
        }
    }
}