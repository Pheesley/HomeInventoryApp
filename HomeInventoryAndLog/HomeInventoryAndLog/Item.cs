using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HomeInventoryAndLog
{
    internal class Item
    {
        //TODO
        // House items - this can be a base class
        private string name;
        private string note; // or notes
        private int count;

        public string Name { get; set; }
        public string Note { get; set; }
        public int Count { get; set; }

        public Item(string name)
        {
            this.name = name;
            this.count = 0;
        }

        public string DisplayText(string name, string count) =>
            Name + " :" + count;
    }
}
