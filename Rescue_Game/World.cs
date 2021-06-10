using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescue_Game
{
   public class World
    {
        public List<Room> ListOfRooms { get; set; }
        public Player Player { get; set; }
        public List<Door> ListOfDoors { get; set; } 
        public List<Item> RoomInventory { get; set; }

        

        public World()
        {
            ListOfRooms = new List<Room>();
            ListOfDoors = new List<Door>();
            RoomInventory = new List<Item>();

        }
    }
}
