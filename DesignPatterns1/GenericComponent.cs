using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public abstract class GenericComponent
    {
        public bool state { get; set; }

        protected GenericComponent[] input;
        public void addInput(GenericComponent component)
        {
            if (modifyArray(null, component))
            {
                component.output.Add(this);
            }
        }

        public void removeInput(GenericComponent component)
        {
            if (modifyArray(component, null))
            {
                component.output.Remove(this);
            }
        }

        //executes a generic modification on the array, replacing the target component with the value
        private bool modifyArray(GenericComponent target, GenericComponent value)
        {
            for (int i = 0; i < input.Length; i++)
            {
                GenericComponent c = input[i];
                if (c == target)
                {
                    input[i] = value;
                    return true;
                }
            }
            return false;
        }

        public List<GenericComponent> output = new List<GenericComponent>();


        public GenericComponent()
        {
            state = false;
        }

        public abstract void Execute();

        public void Trigger()
        {
            try
            {
                Execute();
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine("Exception! Exception! We hebben een Exception!");
            }
        }

        protected void notifyOutput()
        {
            for (int i = 0; i < output.Count; i++)
            {
                output[i].Trigger();
            }
        }

        public void printState()
        {
            Console.WriteLine(this.state);
        }

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
