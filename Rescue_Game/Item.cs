using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescue_Game
{
   public class Item
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }


        public Item(string itemDescription, string name)
        {

            ItemDescription = itemDescription;
            ItemName = name;
        }

        public int UseItem()
        {
            throw new NotImplementedException();
        }
    }
}
