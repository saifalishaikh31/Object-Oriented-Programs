using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSProject
{
    public class InventoryMain
    {
        List<InventoryData> riceList = new List<InventoryData>();
        List<InventoryData> wheatList = new List<InventoryData>();
        List<InventoryData> pulsesList = new List<InventoryData>();
        public void ReadData(string filepath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    var json = reader.ReadToEnd();
                    var itemsPresent = JsonConvert.DeserializeObject<InventoryFactory>(json);
                    this.riceList = itemsPresent.RiceList;
                    this.wheatList = itemsPresent.WheatList;
                    this.pulsesList = itemsPresent.PulsesList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Display()
        {
            if (this.riceList != null)
            {
                Console.WriteLine("\n               *******RiceList******\n");
                Console.WriteLine("Name                    Price Per Kg.           Weight");

                foreach (var item in this.riceList)
                {
                    Console.WriteLine(item.Name.PadRight(15) + "\t\t" + item.Price.ToString().PadRight(15) + "\t\t" + item.Weight);
                }
            }

            if (this.wheatList != null)
            {
                Console.WriteLine("\n               *******WheatList******\n");
                Console.WriteLine("Name                    Price Per Kg.           Weight");

                foreach (var item in this.wheatList)
                {
                    Console.WriteLine(item.Name.PadRight(15) + "\t\t" + item.Price.ToString().PadRight(15) + "\t\t" + item.Weight);
                }
            }

            if (this.pulsesList != null)
            {
                Console.WriteLine("\n               *******PulsesList******\n");
                Console.WriteLine("Name                    Price Per Kg.           Weight");

                foreach (var item in this.pulsesList)
                {
                    Console.WriteLine(item.Name.PadRight(15) + "\t\t" + item.Price.ToString().PadRight(15) + "\t\t" + item.Weight);
                }
            }
        }
        public bool IsDuplicate(List<InventoryData> inventory, string name)
        {
            foreach (var data in inventory)
            {
                if (data.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public void WriteData(string filePath)
        {
            try
            {
                Console.WriteLine("\nEnter the option: Enter\n1 for Rice\n2 for Wheat\n3 for Pulses");
                int option = Convert.ToInt32(Console.ReadLine());
                InventoryData inventory = new InventoryData();
                switch (option)
                {
                    case 1:
                        inventory.Name = "Indrayani";
                        inventory.Price = 50;
                        inventory.Weight = 30;
                        if (!IsDuplicate(this.riceList, inventory.Name))
                        {
                            this.riceList.Add(inventory);
                        }
                        else
                        {
                            Console.WriteLine("The added item already exists!");
                        }
                        break;

                    case 2:
                        inventory.Name = "Golden Lokwan";
                        inventory.Price = 40;
                        inventory.Weight = 30;
                        if (!IsDuplicate(this.wheatList, inventory.Name))
                        {
                            this.wheatList.Add(inventory);
                        }
                        else
                        {
                            Console.WriteLine("The added item already exists!");
                        }
                        break;

                    case 3:
                        inventory.Name = "Chana Dal";
                        inventory.Price = 130;
                        inventory.Weight = 30;
                        if (!IsDuplicate(this.pulsesList, inventory.Name))
                        {
                            this.pulsesList.Add(inventory);
                        }
                        else
                        {
                            Console.WriteLine("The added item already exists!");
                        }
                        break;
                }

                InventoryFactory inventoryFactory = new InventoryFactory();
                inventoryFactory.RiceList = this.riceList;
                inventoryFactory.WheatList = this.wheatList;
                inventoryFactory.PulsesList = this.pulsesList;

                var jsonData = JsonConvert.SerializeObject(inventoryFactory);
                File.WriteAllText(filePath, jsonData);

                ReadData(filePath);
                Display();
                WriteData(@"D:\BridgeLabz\Object-Oriented-Programs\OOPSProject\Inventory.json");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
            
}
