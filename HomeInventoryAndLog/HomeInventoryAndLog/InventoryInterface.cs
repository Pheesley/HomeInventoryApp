using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInventoryAndLog
{
    // Act as a plan for the operations of this app.
    internal interface InventoryInterface
    {
        void addNew(string newItem);

        void Add(string newItem, int number);

        void Subtract(string newItem, int number);

        void Remove(string newItem);
    }
}
