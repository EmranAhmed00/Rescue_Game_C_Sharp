using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescue_Game
{
   public class Room
    {
        public List<Item> RoomInventory { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public List<Door> ListOfDoors { get; set; }
        public bool GameOver { get; set; }


        public Room(string name, string description)
        {
            RoomName = name;
            RoomDescription = description;
            RoomInventory = new List<Item>() { };
            ListOfDoors = new List<Door>() { };
        }
        public Room(string name, string description, bool gameOver)
        {
            RoomName = name;
            RoomDescription = description;
            RoomInventory = new List<Item>() { };
            ListOfDoors = new List<Door>() { };
            GameOver = true;
        }

        public void PrintDescription(Room room)
        {
            Console.WriteLine(RoomName);
            Console.WriteLine(RoomDescription);
            Console.WriteLine("\nThe items you can see in this room are: ");
            foreach (Item item in RoomInventory)
            {
                Console.WriteLine(item.ItemName); //listar rummets föremål
            }

            Console.WriteLine("\nThe exits from this room are: ");
            foreach (Door door in ListOfDoors)
            {
                Console.WriteLine(door.DoorName + ", leads to: " + door.LeadsTo.RoomName); //listar rummets dörrar
            }
        }

        public void PrintRoomInventory(Room presentLocation)
        {
            Console.WriteLine("The items you can see in this room are: ");
            foreach (Item item in RoomInventory)
            {
                Console.WriteLine(item.ItemName);
            }
        }
        public void FindDoor(Room presentLocation)
        {
            foreach (Door door in ListOfDoors)
            {
                Console.WriteLine(door.DoorName + ", leads to: " + door.LeadsTo.RoomName); //listar rummets dörrar
                door.Locked = false;
                Console.WriteLine("Door unlocked.");
            }
        }
        public void GiveCat(string input)
        {
            string text = input;
            string[] inputs = text.Split(' ');

            if (inputs.Contains("CAT") && inputs.Contains("TOY"))
            {
                Console.WriteLine("The toy worked. The cat lets you pick it up. " +
                    inputs[1] + " taken.");
                foreach (Door door in ListOfDoors)
                {
                    if (door.DoorName == "Exit")
                    {
                        door.Locked = false;
                    }
                }
            }


        }
    }
}
