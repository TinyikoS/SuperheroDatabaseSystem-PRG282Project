using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282Project.Logic_Layer
{
    public class Superhero
    {
        // fields to store hero details
        private string heroID, name, superpower, rank, threatLevel;
        private int age, examScore;

        // properties to access or change the fields
        public string HeroID
        {
            get { return heroID; }
            set { heroID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Superpower
        {
            get { return superpower; }
            set { superpower = value; }
        }

        public int ExamScore
        {
            get { return examScore; }
            set
            {
                examScore = value;
                // update rank and threat level when score changes
                rank = GetRank(examScore);
                threatLevel = GetThreatLevel(rank);
            }
        }

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public string ThreatLevel
        {
            get { return threatLevel; }
            set { threatLevel = value; }
        }

        // empty constructor
        public Superhero()
        {
        }

        // constructor with all main details
        public Superhero(string heroID, string name, int age, string superpower, int examScore)
        {
            this.heroID = heroID;
            this.name = name;
            this.age = age;
            this.superpower = superpower;
            this.examScore = examScore;
            this.rank = GetRank(examScore);
            this.threatLevel = GetThreatLevel(rank);
        }

        // method to get rank from score
        public string GetRank(int score)
        {
            if (score >= 81)
                return "S-Rank";
            else if (score >= 61)
                return "A-Rank";
            else if (score >= 41)
                return "B-Rank";
            else
                return "C-Rank";
        }

        // method to get threat level from rank
        public string GetThreatLevel(string rank)
        {
            if (rank == "S-Rank")
                return "Finals Week";
            else if (rank == "A-Rank")
                return "Midterm Madness";
            else if (rank == "B-Rank")
                return "Group Project Gone Wrong";
            else
                return "Pop Quiz";
        }

        // make a line to save hero data in the file
        public string ToFileString()
        {
            return $"{heroID}|{name}|{age}|{superpower}|{examScore}|{rank}|{threatLevel}";
        }

        // make a hero object from a line in the file
        public static Superhero FromFileString(string line)
        {
            string[] parts = line.Split('|');

            if (parts.Length == 7)
            {
                Superhero hero = new Superhero
                {
                    HeroID = parts[0],
                    Name = parts[1],
                    Age = int.Parse(parts[2]),
                    Superpower = parts[3],
                    ExamScore = int.Parse(parts[4]),
                    Rank = parts[5],
                    ThreatLevel = parts[6]
                };
                return hero;
            }
            else
            {
                throw new Exception("Invalid hero data format.");
            }
        }
    }
}
