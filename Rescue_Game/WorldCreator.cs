using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescue_Game
{
   public class WorldCreator
    {
        public WorldCreator() //i constructorn ska bara vara basic saker, 
        {
        }

        public World BuildWorld()// internal
        {
            World world = new World();

            Room roomA = new Room("Hallway", "You stand at the entrance of a long hallway, " +
                "increasingly filled with smoke. " +
                "At the end of the hallway there is an old wooden door. " +
                "Can you find a key to unlock it? ");
            Room roomB = new Room("Kitchen", "You are standing in a big and smokefilled kitchen. " +
                "You can almost see nothing... ");
            Room roomC = new Room("Diner", "You have reached the dining room. On the table you see a cat, " +
                "terrified of the flames rising up from the floor..." +
                "On the other side of the room you see a door leading out! But you must get the cat first...");
            Room finalRoom = new Room("Final Room", "Yay! You are outside, and got the cat with you! You did it! \nGAME OVER", true);
            world.ListOfRooms.Add(roomA);
            world.ListOfRooms.Add(roomB);
            world.ListOfRooms.Add(roomC);
            world.ListOfRooms.Add(finalRoom);

            Item map = new Item("An old map of the rooms in this enormous house", "MAP");
            Item key = new Item("A big golden key", "KEY");
            Item apple = new Item("A tasty red apple", "APPLE");
            Item knife = new Item("A rusty but sharp knife", "KNIFE");
            //Item hammer = new Item("Biggest tool ever seen", "HAMMER");
            Item toy = new Item("An old fashioned doll", "TOY");
            Item cat = new Item("A black cat", "CAT");
            roomA.RoomInventory.Add(key);
            roomA.RoomInventory.Add(map);
            roomB.RoomInventory.Add(toy);
            roomC.RoomInventory.Add(apple);
            roomC.RoomInventory.Add(cat);

            Door doorA = new Door(roomB, true, "FORWARD", "Old wooden door");
            Door doorBBackward = new Door(roomA, false, "BACKWARD", "The old wooden door");
            Door doorBForward = new Door(roomC, false, "FORWARD", "Black wooden door");
            Door doorCBackward = new Door(roomB, false, "BACKWARD", "The black wooden door");
            Door doorCForward = new Door(finalRoom, true, "FORWARD", "Exit");
            roomA.ListOfDoors.Add(doorA);
            roomB.ListOfDoors.Add(doorBBackward);
            roomB.ListOfDoors.Add(doorBForward);
            roomC.ListOfDoors.Add(doorCBackward);
            roomC.ListOfDoors.Add(doorCForward);

            world.Player = new Player("Catwoman", "Fast, smooth, smart", roomA, true);

            return world;

        }
    }
}
