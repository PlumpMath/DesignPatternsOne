using DesignPatterns.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitor
{
    public abstract class ComponentVisitor
    {
        public virtual void Visit(NOT not) { }
        public virtual void Visit(AND and) { }
        public virtual void Visit(NOR nor) { }
        public virtual void Visit(NAND nand) { }
        public virtual void Visit(OR or) { }
        public virtual void Visit(Probe probe) { }
        public virtual void Visit(XOR xor) { }
        public virtual void Visit(Source source) { }
    }
}
