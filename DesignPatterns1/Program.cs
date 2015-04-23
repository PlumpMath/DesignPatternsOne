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
            /*
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
            */
            Import();
            Console.ReadLine();
        }

        public static void Import()
        {
            Dictionary<string, GenericComponent> components = new Dictionary<string, GenericComponent>();

            string[] lines = System.IO.File.ReadAllLines(@"circuit1.txt");
            bool linking = false;
            foreach (string line in lines)
            {
                if(! line.StartsWith("#"))
                {
                    if (String.IsNullOrWhiteSpace(line))
                    {
                        linking = true;
                    }
                    else
                    {
                        if (!linking)
                        {
                            string[] strings = line.Split(':');
                            string name = strings[0].Trim();
                            string type = strings[1].Trim();
                            type = type.Replace(";","");
                            GenericComponent component = GenericComponent.CreateComponent(type);
                            components.Add(name, component);
                        }
                        else
                        {
                            string[] strings = line.Split(':');
                            string componentName = strings[0].Trim();
                            string outputString = strings[1].Trim();
                            outputString = outputString.Replace(";", "");

                            string[] outputList = outputString.Split(',');
                            GenericComponent source = components[componentName];
                            foreach (string target in outputList)
                            {
                                components[target].addInput(source);
                            }
                        }
                    }
                }
            }
            Source cin = (Source)components["Cin"];
            Source a = (Source)components["A"];
            Source b = (Source)components["B"];
            cin.trigger();
            a.trigger();
            b.trigger();
            foreach (KeyValuePair<string, GenericComponent> kv in components)
            {
                Console.WriteLine(kv.Key + " " + kv.Value.state);
            }
        }
    }
}
