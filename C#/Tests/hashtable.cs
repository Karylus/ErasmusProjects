using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Hashtable studentsTable = new Hashtable();
        Student stud1 = new Student(1, "OOP", 4);
        Student stud2 = new Student(2, "SC", 5);
        Student stud3 = new Student(3, "OS", 5);
        Student stud4 = new Student(4, "NOS", 5);
        Student stud5 = new Student(5, "CN", 5);


        studentsTable.Add(stud1.Id, stud1);
        studentsTable.Add(stud2.Id, stud2);
        studentsTable.Add(stud3.Id, stud3);
        studentsTable.Add(stud4.Id, stud4);
        studentsTable.Add(stud5.Id, stud5);

        Student storedStudent1 = (Student)studentsTable[1];
        Student storedStudent2 = (Student)studentsTable[2];
        Student storedStudent3 = (Student)studentsTable[3];
        Student storedStudent4 = (Student)studentsTable[4];
        Student storedStudent5 = (Student)studentsTable[5];

        Console.WriteLine("{0} {1}", storedStudent1.Name, storedStudent1.Grade);
        Console.WriteLine("{0} {1}", storedStudent2.Name, storedStudent2.Grade);
        Console.WriteLine("{0} {1}", storedStudent3.Name, storedStudent3.Grade);

        Console.WriteLine("--------------");

        foreach (DictionaryEntry entry in studentsTable)
        {
            Student temp = (Student)entry.Value;
            Console.WriteLine("{0} {1}", temp.Name, temp.Grade);
        }

        Console.WriteLine("--------------");

        foreach (Student entry in studentsTable.Values)
        {
            Console.WriteLine("{0} {1}", entry.Name, entry.Grade);
        }

        Console.WriteLine("--------------");

        double total = 0.0;

        foreach (Student entry in studentsTable.Values)
        {
            total += entry.Grade;
        }

        double average = total / studentsTable.Count;

        Console.WriteLine("Average is: {0}", average);

    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }

        public Student(int id, string name, int grade)
        {
            this.Id = id;
            this.Name = name;
            this.Grade = grade;
        }

    }

}

