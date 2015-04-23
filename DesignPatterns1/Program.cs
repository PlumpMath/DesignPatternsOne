using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    class Program
    {
        static void Main(string[] args)
        {
            Source src = new Source();
            Source src2 = new Source();
            Not i= new Not();
            AND and = new AND();

            and.addInput(src);
            i.addInput(src2);
            and.addInput(i);

            Console.WriteLine("pre-trigger");
            src.printState();
            src2.printState();
            i.printState();
            and.printState();

            Console.WriteLine("post-trigger");
            src.trigger();
            src.activate(true);
            src2.activate(false);
            src.printState();
            src2.printState();
            i.printState();
            and.printState();

            Console.ReadLine();
        }
    }
}
