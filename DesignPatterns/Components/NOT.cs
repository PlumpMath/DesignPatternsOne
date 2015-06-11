using DesignPatterns.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Components
{
    public class NOT : GenericComponent
    {
        public NOT()
        {
            input = input = new List<GenericComponent>(1);
        }

        public override void Accept(ComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Execute()
        {
            GenericComponent source = input[0];
            this.state = !source.state;
            notifyOutput();
        }
    }
}
