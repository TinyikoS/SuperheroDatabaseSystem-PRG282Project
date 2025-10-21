using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRG282Project.Data_Layer;    

namespace PRG282Project.Logic_Layer
{
    public class HeroManager
    {
        // create an object to use the data layer
        DataHandler dataHandler = new DataHandler();

        // this method deletes a hero using their ID
        public void DeleteHero(string heroId)
        {
            // get all heroes from the file
            List<string> lines = dataHandler.ReadAllHeroes();
            bool found = false;

            // go through each hero in the list
            for (int i = 0; i < lines.Count; i++)
            {
                // split the line into parts (each hero’s details)
                string[] parts = lines[i].Split('|'); // same symbol used when saving

                // check if the first part (Hero ID) matches the one we want to delete
                if (parts[0] == heroId)
                {
                    // remove that hero from the list
                    lines.RemoveAt(i);
                    found = true;
                    break;
                }
            }

            // if hero was found, save the updated list back into the file
            if (found)
            {
                dataHandler.SaveAllHeroes(lines);
            }
            else
            {
                // show an error if no hero with that ID exists
                throw new Exception("Hero ID not found.");
            }
        }
    }
}
