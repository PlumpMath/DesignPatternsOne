using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class NOT : GenericComponent
    {
        public NOT()
        {
            input = new GenericComponent[1];
        }

        public override void trigger()
        {
            GenericComponent source = input[0];
            this.state = !source.state;
            notifyOutput();
        }
    }
}
