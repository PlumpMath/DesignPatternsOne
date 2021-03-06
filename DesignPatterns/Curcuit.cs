﻿using DesignPatterns.Components;
using DesignPatterns.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Curcuit
    {
        private Dictionary<string, GenericComponent> components { get; set; }

        static void Main(string[] args)
        {
            Curcuit curcuit = new Curcuit();
            curcuit.ReadLines();
            curcuit.Execute();
            curcuit.PrintComponents();
            Console.ReadLine();
        }

        public void Execute()
        {
            bool calculating = true;
		    int componentsCalculated = 0;
		    try {
			    while (calculating) {
				    bool cCalculated = false;
				    foreach(KeyValuePair<string, GenericComponent> kv in components) {
					    if(kv.Value.ReadyToCalculate()) {
                            kv.Value.Trigger();
						    componentsCalculated++;
						    cCalculated = true;
					    }
				    }
				    if(componentsCalculated == components.Count) {
					    calculating = false;
				    }
				    else if (!cCalculated) {
					    throw new Exception("Invalid circuit!");
				    }
			    }
		    } catch (Exception e) {
			    Console.WriteLine("ERROR: " + e.Message);
		    }            
        }

        public void PrintComponents()
        {
            foreach (KeyValuePair<string, GenericComponent> kv in components)
            {
                Console.WriteLine(kv.Key + " " + kv.Value.state);
            }
        }

        public void ReadLines()
        {
            components = new Dictionary<string,GenericComponent>();
            string[] lines = File.ReadAllLines("Resources/circuit4.txt");
            bool linking = false;
            foreach (string line in lines)
            {
                if (!line.StartsWith("#"))
                {
                    if (String.IsNullOrWhiteSpace(line))
                    {
                        linking = true;
                    }
                    else if (linking)
                    {
                        LinkComponents(line);
                    }
                    else {
                        CreateComponents(line);
                    }
                }
            }
        }

        public void LinkComponents(string linkLine)
        {
            string[] strings = linkLine.Split(':');
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

        public void CreateComponents(string componentLine)
        {
            string[] strings = componentLine.Split(':');
            string name = strings[0].Trim();
            string type = strings[1].Trim();
            type = type.Replace(";", "");

            GenericComponent component = GenericComponentFactory.CreateComponent(type);
            components.Add(name,component);
        }

        public static void Import()
        {
            Dictionary<string,GenericComponent> components = new Dictionary<string,GenericComponent>();

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
                            components.Add(name,component);
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
            /*foreach(KeyValuePair<string,GenericComponent> kv in components)
            {
                if (kv.Value is Source)
                {
                    kv.Value.Trigger();
                }
            }
            foreach (KeyValuePair<string, GenericComponent> kv in components)
            {
                Console.WriteLine(kv.Key + " " + kv.Value.state);
            }*/
        }
    }
}
