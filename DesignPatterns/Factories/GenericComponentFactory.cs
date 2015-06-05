using DesignPatterns.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factories
{
    public static class GenericComponentFactory
    {
        public static GenericComponent CreateComponent(String type)
        {
            switch (type)
            {
                case "INPUT_HIGH":
                    return new Source(true);
                case "INPUT_LOW":
                    return new Source(false);
                case "PROBE":
                    return new Probe();
                case "AND":
                    return new AND();
                case "NAND":
                    return new NAND();
                case "NOR":
                    return new NOR();
                case "NOT":
                    return new NOT();
                case "OR":
                    return new OR();
                case "XOR":
                    return new XOR();
            }
            return null;
        }
    }
}
