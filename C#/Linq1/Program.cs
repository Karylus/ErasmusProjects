using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

// LINQ Query Syntax examples

public class Program
{
    public static void Main()
    {
        // Countries collection
        List<Country> countriesList = new List<Country>() {
                new Country() { Name = "Spain", Area = 500000, Population = 45000000} ,
                new Country() { Name = "USA", Area = 10000000, Population = 331000000} ,
                new Country() { Name = "Poland", Area = 350000, Population = 38000000} ,
                new Country() { Name = "Rusia", Area = 17000000, Population = 143000000} ,
                new Country() { Name = "China", Area = 9500000, Population = 1400000000} ,
            };

        for (int i = 0; i < countriesList.Count(); i++)
        {
            double densidad = countriesList[i].Population / countriesList[i].Area;
            countriesList[i].Density = densidad;
        }

        List<string> lines = new List<string> { };

        lines.Add("----------------------------------------");
        lines.Add("Countries by Population Density:");
        //-----------------------------------

        var result2 = from c in countriesList
                      orderby c.Density, c.Area ascending
                      group c by c.Density;

        lines.Add("Name \t Area \t Population \t Density");
        //iterate each group        
        foreach (var density in result2)
        {
            foreach (Country c in density)
            { // Each group has inner collection

                string all = c.Name + " " + c.Area + " " + c.Population + "\t" + c.Density;
                lines.Add(all);
            }
        }

        using (StreamWriter outputFile = new StreamWriter("WriteLines.txt"))
        {
            foreach (string line in lines)
                outputFile.WriteLine(line);
        }

    }

    public class Country
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public int Population { get; set; }
        public double Density { get; set; }
    }
}

