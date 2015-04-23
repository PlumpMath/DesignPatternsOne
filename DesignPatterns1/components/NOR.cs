using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.components
{
    class NOR : GenericComponent
    {
        public NOR()
        {
            input = new GenericComponent[2];
        }

        public override void trigger()
        {
            if (!input[0].state && !input[1].state)
            {
                this.state = true;
            }
            notifyOutput();
        }
    }
}
