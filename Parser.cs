using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadModuleTest
{
    public static class Parser
    {
        public static (List<Element> Elements, List<Net> Nets) ParseDataToObjects(string data)
        {
            List<Net> nets = new();
            List<Element> elements = new();

            List<string> temp = data.Replace("\r\n", "").
                                  Replace(",", "").
                                  Replace("(", "").
                                  Replace(")", "").
                                  Split(";").
                                  ToList();

            List<string> lines = new();


            foreach (var item in temp)
            {
                string line = string.Empty;
                foreach (var el in item.Split(" "))
                {
                    if (String.IsNullOrEmpty(el.Trim()) is false)
                    {
                        line += el + " ";
                    }
                }
                lines.Add(line);
            }

            foreach (var item in lines)
            {
                List<string> els = item.Trim().Split(' ').ToList();
                Net net = new() { Name = els[0] };
                Element el;
                for (int i = 1; i < els.Count; i++)
                {
                    string[] tempS = els[i].Split('\'');
                    (string name, int pin) = (tempS[0], int.Parse(tempS[1]));

                    if (elements.Find(item => item.Name == name) is not null)
                    {
                        el = elements.Find(item => item.Name == name);
                        el.Nets.Add((net, pin));
                        net.Elements.Add(el);
                    }
                    else
                    {
                        el = new() { Name = name };
                        el.Nets.Add((net, pin));
                        elements.Add(el);
                        net.Elements.Add(el);
                    }
                    nets.Add(net);
                }
            }

            return (elements, nets);
        }
    }
}
