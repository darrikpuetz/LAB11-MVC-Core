using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class TimesPerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }
        /// <summary>
        /// Combo of help from KyungRae and Class.  Sorts the data from the file and input into a way to wrap it from cshtml.
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        public static List<TimesPerson> GetPersons(int startYear, int endYear)
        {
            string path = "./wwwroot/personOfTheYear.csv";
            string[] persons = File.ReadAllLines(path);
            List<TimesPerson> people = new List<TimesPerson>();
            for (int i = 1; i < persons.Length; i++)
            {
                var data = persons[i].Split(',');
                people.Add(new TimesPerson()
                {
                    Year = (data[0] == "") ? 0 : Convert.ToInt32(data[0]),
                    Honor = data[1],
                    Name = data[2],
                    Country = data[3],
                    BirthYear = (data[4] == "") ? 0 : Convert.ToInt32(data[4]),
                    DeathYear = (data[5] == "") ? 0 : Convert.ToInt32(data[5]),
                    Title = data[6],
                    Category = data[7],
                    Context = data[8]
                });
            }
            List<TimesPerson> peopleLeft = people.Where(p => p.Year >= startYear &&  p.Year <= endYear).ToList();
            return peopleLeft;
        }
    }
}
