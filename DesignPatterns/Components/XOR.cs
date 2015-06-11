using DesignPatterns.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Components
{
    public class XOR : GenericComponent
    {
        public XOR()
        {
            input = new List<GenericComponent>(2);
        }

        public override void Accept(ComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Execute()
        {
            if (input[0].state != input[1].state)
            {
                this.state = true;
            }
            notifyOutput();
        }
    }
}
