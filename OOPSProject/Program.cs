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
            InventoryMain inventoryManagement = new InventoryMain();
            inventoryManagement.ReadData(@"D:\BridgeLabz\Object-Oriented-Programs\OOPSProject\Inventory.json");
            inventoryManagement.Display();
            inventoryManagement.WriteData(@"D:\BridgeLabz\Object-Oriented-Programs\OOPSProject\Inventory.json");
            Console.ReadKey();
        }
    }
}
