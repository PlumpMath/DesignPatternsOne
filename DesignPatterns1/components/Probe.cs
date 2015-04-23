﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.components
{
    class Probe : GenericComponent
    {
        
        public Probe()
        {
            input = new GenericComponent[1];
        }

        public override void trigger()
        {
            this.state = input[0].state;
            notifyOutput();
        }
    }
}