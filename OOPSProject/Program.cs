using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.ReadData(@"D:\BridgeLabz\Object-Oriented-Programs\OOPSProject\Inventory.json");
            Console.ReadKey();
        }
    }
}
