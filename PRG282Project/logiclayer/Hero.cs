using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRG282Project.Data_Layer;

namespace PRG282Project.LogicLayer
{
    internal class Hero
    {
        public string HeroID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Superpower { get; set; }
        public int ExamScore { get; set; }
        public string Rank { get; set; }
        public string ThreatLevel { get; set; }

        public Hero(string heroID, string fullName, int age, string superpower, int examScore)
        {
            HeroID = heroID;
            FullName = fullName;
            Age = age;
            Superpower = superpower;
            ExamScore = examScore;
            CalculateRankAndThreat();
        }

        public void CalculateRankAndThreat()
        {
            if (ExamScore >= 81 && ExamScore <= 100)
            {
                Rank = "S-Rank";
                ThreatLevel = "Finals Week";
            }
            else if (ExamScore >= 61 && ExamScore <= 80)
            {
                Rank = "A-Rank";
                ThreatLevel = "Midterm Madness";
            }
            else if (ExamScore >= 41 && ExamScore <= 60)
            {
                Rank = "B-Rank";
                ThreatLevel = "Group Project Gone Wrong";
            }
            else
            {
                Rank = "C-Rank";
                ThreatLevel = "Pop Quiz";
            }
        }

        public string ToFileString()
        {
            return $"{HeroID}, {FullName}, {Age}, {Superpower}, {ExamScore}, {Rank}, {ThreatLevel}";
        }

        public static Hero FromFileString(string line)
        {
            string[] parts = line.Split(',');
            Hero hero = new Hero(parts[0], parts[1], int.Parse(parts[2]), parts[3], int.Parse(parts[4]));
            return hero ;
        }
    }
}
