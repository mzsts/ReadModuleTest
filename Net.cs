using System.Collections.Generic;

namespace ReadModuleTest
{
    public class Net
    {
        public string Name { get; set; }
        public List<Element> Elements { get; } = new();
    }
}
