using DesignPatterns.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Components
{
    public class Probe : GenericComponent
    {
        
        public Probe()
        {
            input = new GenericComponent[1];
        }

        public override void accept(ComponentVisitor visitor)
        {
            visitor.visit(this);
        }

        public override void Execute()
        {
            this.state = input[0].state;
            notifyOutput();
        }
    }
}
