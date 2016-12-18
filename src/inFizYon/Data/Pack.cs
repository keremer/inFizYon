using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inFizYon.Ontology
{
    public class Pack
    {
        private List<NLine> specLines = new List<NLine>();

        public void AddNLine(int node, int lvl, int parent, string content)
        {
            NLine line = new NLine();
            line.LineID = node;
            line.ParentID = parent;
            line.Lvl = lvl;
            line.Content = content;
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
            public int LineID { get; set; }
            public int ParentID { get; set; }
            public int Lvl { get; set; }
            public string Content { get; set; }

            //public double OrderLineTotal()
            //{
            //    return Child * Lvl;
            //}
        }
    }
}