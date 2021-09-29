using System.Collections.Generic;

namespace ReadModuleTest
{
    public class Element
    {
        public string Name { get; set; }
        public List<(Net Net, int Pin)> Nets { get; } = new();
    }
}
