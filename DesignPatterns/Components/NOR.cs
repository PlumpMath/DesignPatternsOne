using DesignPatterns.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Components
{
    public class NOR : GenericComponent
    {
        public NOR()
        {
            input = new GenericComponent[2];
        }

        public override void accept(ComponentVisitor visitor)
        {
            visitor.visit(this);
        }

        public override void Execute()
        {
            if (!input[0].state && !input[1].state)
            {
                this.state = true;
            }
            notifyOutput();
        }
    }
}
