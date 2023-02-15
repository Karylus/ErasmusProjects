using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamLibrary;

namespace Exam
{
    internal class Program
    {
        static void Main()
        {
            Entertainment show1 = new Entertainment("Inglourious Basterds", "Tarantino", "Action", "April 2009");
            Entertainment show2 = new Entertainment("The Shape of Water", "Del Toro", "Fantasy", "October 2017");
            Entertainment show3 = new Entertainment("The Fog", "Carpenter", "Terror", "April 1980");

            show1.Show();
            show3.Show();

            string char1 = "Geralt De Rivia";
            string char2 = "Joel";
            string char3 = "Kratos";

            List<string> characters = new List<string>
            {
                char1,
                char2,
                char3
            };

            Performance film1 = new Performance("Mulholland Drive", "Lynch", "Mistery", "January 2001", "Film", characters, 14.5);
            Performance film2 = new Performance("The Batman", "Reeves", "Action", "June 2022", "Film", characters, 6.75);

            Performance play = new Performance("The House of Bernarda Alba", "Lorca", "Romantic", "July 1945", "Drama", characters, "Royal Theatre", 185);

            film1.Show();
            play.Show();

            List<Entertainment> shows = new List<Entertainment> { show1, show2, show3 };
            List<Performance> performances = new List<Performance> { film1, film2, play };

            //*****************************************************************
            //Sorting and saving shows
            var result = from show in shows
                          orderby show.Name ascending
                          select show;

            List<string> lines = new List<string> { };

            lines.Add("----------------------------------------");
            lines.Add("Shows sorted by Name:\n");

            foreach (Entertainment show in result)
            {
                string all = "\t" + show.Name + " | " + show.Director;
                lines.Add(all);
            }

            lines.Add("----------------------------------------");

            using (StreamWriter outputFile = new StreamWriter("SortedShows.txt"))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
            //*****************************************************************

            //*****************************************************************
            //Saving and sorting performances
            var result2 = from performance in performances
                         orderby performance.Name ascending
                         select performance;

            List<string> lines2 = new List<string> { };

            lines2.Add("----------------------------------------");
            lines2.Add("Performances sorted by Name:\n");

            foreach (Performance performance in result2)
            {
                string all = "\t" + performance.Name + " | " + performance.Director + " | " + performance.Type;
                lines2.Add(all);
            }

            lines2.Add("----------------------------------------");

            using (StreamWriter outputFile = new StreamWriter("SortedPerformances.txt"))
            {
                foreach (string line in lines2)
                    outputFile.WriteLine(line);
            }
            //*****************************************************************
        }
    }
}
