using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    class Source : GenericComponent
    {
        public Source()
        {
            input = new GenericComponent[0];
        }

        public override void trigger()
        {
            notifyOutput();
        }

        public void activate(bool value)
        {
            this.state = value;
            trigger();
        }
    }
}
