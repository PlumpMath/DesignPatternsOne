using DesignPatterns.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitor
{
    public class MakeSourceListVisitor : ComponentVisitor
    {
        private LinkedList<Source> sourceList;

        public MakeSourceListVisitor( LinkedList<Source> sourceList )
        {
            this.sourceList = sourceList;
            this.sourceList.Clear();
        }

        public override void Visit(Source source )
        {
            sourceList.AddLast(source);
        }
    }
}
