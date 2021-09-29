using System;
using System.Collections.Generic;
using System.IO;

namespace ReadModuleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllTextAsync(@"C:\Users\Максим\Desktop\shema2_cl90.net").Result;

            (List<Element> elements, List<Net> nets) = Parser.ParseDataToObjects(data);

            Console.ReadKey();
        }
    }
}
