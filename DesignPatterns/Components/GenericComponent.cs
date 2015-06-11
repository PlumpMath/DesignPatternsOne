using DesignPatterns.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Components
{
    public abstract class GenericComponent
    {
        public bool state { get; set; }
        protected bool AlreadyCalculated { get; set; }
        protected List<GenericComponent> input;
        public List<GenericComponent> output = new List<GenericComponent>();
        public GenericComponent()
        {
            AlreadyCalculated = false;
            state = false;
        }
        public abstract void Execute();
        public abstract void Accept(ComponentVisitor visitor);
        public void addInput(GenericComponent component)
        {
            if (modifyArray(null, component))
            {
                component.output.Add(this);
            }
        }
        public void Trigger()
        {
            if (ReadyToCalculate())
            {
                AlreadyCalculated = true;
                Execute();
            }
            else if (!AlreadyCalculated)
            {
                Console.WriteLine("FOUT FOUT FOUT JIJ KUT");
            }
        }
        public bool InputsCalculated()
        {
            foreach(GenericComponent component in input)
            {
                if(!component.AlreadyCalculated)
                {
                    return false;
                }
            }
            return true;
        }
        public bool ReadyToCalculate()
        {
            if (!AlreadyCalculated && InputsCalculated())
            {
                return true;
            }
            return false;
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
        //executes a generic modification on the array, replacing the target component with the value
        private bool modifyArray(GenericComponent target, GenericComponent value)
        {
            int size = input.Count;
            input.Add(value);
            if (input.Count == size)
            {
                return false;
            }
            return true;
        }
    }
}
