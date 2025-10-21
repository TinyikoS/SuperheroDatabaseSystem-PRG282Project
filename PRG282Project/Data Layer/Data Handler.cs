using System;
using System.Collections.Generic;
using System.IO;                   
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282Project.Data_Layer
{
    public class DataHandler
    {
        // file that stores superhero data
        string filePath = "superheroes.txt";

        // method to read all lines from the file
        public List<string> ReadAllHeroes()
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath).ToList();
            }
            else
            {
                throw new FileNotFoundException("superheroes.txt file not found.");
            }
        }

        // method to save all heroes back into the file
        public void SaveAllHeroes(List<string> heroes)
        {
            File.WriteAllLines(filePath, heroes);
        }
    }
}
