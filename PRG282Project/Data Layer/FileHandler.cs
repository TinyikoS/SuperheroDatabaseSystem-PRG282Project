using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRG282Project.LogicLayer;
using System.IO;

namespace PRG282Project.Data_Layer
{
    internal class FileHandler
    {
        private string filepath = "superheroes.txt";

        public List<Hero> ReadAllHeroes()
        {
            List<Hero> heroes = new List<Hero>();

            if (!File.Exists(filepath))
            {
                return heroes;
            }

            string[] lines = File.ReadAllLines(filepath);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    heroes.Add(Hero.FromFileString(line));
                }
            }
            return heroes;

        }
        
        public bool UpdateHero(Hero updatedHero)
        {
            List<Hero> heroes = ReadAllHeroes();
            bool found = false;

            for (int i = 0; i < heroes.Count; i++)
            {
                if (heroes[i].HeroID == updatedHero.HeroID)
                {
                    heroes[i] = updatedHero;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                SaveAllHeroes(heroes);
            }
            return found;
        }

        private void SaveAllHeroes(List<Hero> heroes)
        {
            List<string> lines = new List<string>();
            foreach (Hero hero in heroes)
            {
                lines.Add(hero.ToFileString());
            }
            File.WriteAllLines(filepath, lines);
        }
    }
}
