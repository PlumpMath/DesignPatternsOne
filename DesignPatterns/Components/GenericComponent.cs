using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Components
{
    public abstract class GenericComponent
    {
        public bool state;
        protected bool AlreadyCalculated { get; set; }

        protected List<GenericComponent> input;

        public List<GenericComponent> output = new List<GenericComponent>();

        public abstract void Execute();
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
            if (input.Count != input.Capacity)
            {
                return false;
            }
            if (InputsCalculated() && !AlreadyCalculated)
            {
                return true;
            }
            return false;
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
