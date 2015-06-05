using DesignPatterns.Components;
using DesignPatterns.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Curcuit
    {
        static void Main(string[] args)
        {
            
            Curcuit.Import();
            Console.ReadLine();
        }

        public static void Import()
        {
            Dictionary<string, GenericComponent> components = new Dictionary<string, GenericComponent>();

            string[] lines = System.IO.File.ReadAllLines("Resources/circuit1.txt");
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
                            GenericComponent component = GenericComponentFactory.CreateComponent(type);
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
            foreach(KeyValuePair<string,GenericComponent> kv in components)
            {
                if (kv.Value is Source)
                {
                    kv.Value.Trigger();
                }
            }
            foreach (KeyValuePair<string, GenericComponent> kv in components)
            {
                Console.WriteLine(kv.Key + " " + kv.Value.state);
            }
        }
    }
}
