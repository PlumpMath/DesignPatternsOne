using DesignPatterns.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitor
{
    public class MakeProbeListVisitor : ComponentVisitor
    {
        private LinkedList<Probe> probeList;

        public MakeProbeListVisitor( LinkedList<Probe> probeList )
        {
            this.probeList = probeList;
            this.probeList.Clear();
        }

        public override void Visit(Probe probe )
        {
            probeList.AddLast(probe);
        }
    }
}
