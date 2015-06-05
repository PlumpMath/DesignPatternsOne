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
        public virtual void visit(NOT not) { }
        public virtual void visit(AND and) { }
        public virtual void visit(NOR nor) { }
        public virtual void visit(NAND nand) { }
        public virtual void visit(OR or) { }
        public virtual void visit(Probe probe) { }
        public virtual void visit(XOR xor) { }
        public virtual void visit(Source source) { }
    }
}
