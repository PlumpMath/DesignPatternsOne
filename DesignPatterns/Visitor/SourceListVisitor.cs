using DesignPatterns.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitor
{
    public class SourceListVisitor : ComponentVisitor
    {
        private LinkedList<Source> sourceList;

        public SourceListVisitor(LinkedList<Source> sourceList)
        {
            this.sourceList = sourceList;
            this.sourceList.Clear();
        }

        public LinkedList<Source> SourceList { get { return sourceList; } }

        public override void Visit(Source source )
        {
            sourceList.AddLast(source);
        }


    }
}
