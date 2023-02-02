using System;
using System.Collections.Generic;
using System.Linq;

class HelloWorld
{
    static void Main()
    {

        Languages[] languages = {
        new Languages(1, "OOP", 4),
        new Languages(2, "OS", 5),
        new Languages(3, "NOS", 5),
        new Languages(4, "SC", 5),
        new Languages(5, "CN", 5)};

        Dictionary<int, Languages> myDict = new Dictionary<int, Languages>();
        foreach (Languages lang in languages)
        {
            myDict.Add(lang.Id, lang);
        }

        int key = 1;
        if (myDict.ContainsKey(key))
        {
            Languages lang = myDict[key];
            Console.WriteLine("{0} {1}", lang.Name, lang.Grade);
        }
        else
        {
            Console.WriteLine("This key does not exist");
        }
        Console.WriteLine("--------------------------");


        Languages result = null;
        if (myDict.TryGetValue(2, out result))
        {
            Console.WriteLine("{0}  {1}", result.Name, result.Grade);
        }
        else
        {
            Console.WriteLine("This key does not exist");
        }

        Console.WriteLine("--------------------------");
        for (int i = 0; i < myDict.Count; i++)
        {
            KeyValuePair<int, Languages> keyValuePair = myDict.ElementAt(i);
            Languages lang = keyValuePair.Value;

            Console.WriteLine("{0} {1} {2}", lang.Id, lang.Name, lang.Grade);
        }

        //updating
        //key = 2;
        //if (myDict.ContainsKey(key))
        //{
        //    myDict[key] = new Languages(key, "Robert", 0);
        //    Languages lang = myDict[key];
        //    Console.WriteLine("{0} {1}", lang.Name, lang.Grade);
        //}

        double total = 0.0;

        Console.WriteLine("--------------------------");
        for (int i = 0; i < myDict.Count; i++)
        {
            KeyValuePair<int, Languages> keyValuePair = myDict.ElementAt(i);
            Languages lang = keyValuePair.Value;

            total += lang.Grade;
        }

        double average = total / 5.0;

        Console.WriteLine("Average is: {0}", average);

    } //main



    class Languages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }

        public Languages(int id, string name, int grade)
        {
            this.Id = id;
            this.Name = name;
            this.Grade = grade;
        }

    }

}





