using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamLibrary
{
    public class Entertainment
    {
        public Entertainment(string name, string director, string genre, string date)
        {
            _name = name;
            _director = director;
            _genre = genre;
            _date = date;
        }

        protected string _name;
        protected string _director;
        protected string _genre;
        protected string _date;

        //Setters and getters
        public string Name 
        { 
            get { return _name; } 
            set { _name = value; }
        }
        public string Director
        {
            get { return _director; }
            set { _director = value; }
        }
        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        //Public methods
        public virtual void Show()
        {
            Console.WriteLine("---------------------------------");

            Console.WriteLine(" The name is: {0}\n\t The director is: {1}\n\t The genre is: {2}\n\t The date of production is: {3}", this.Name, this.Director, this.Genre, this.Date);

            Console.WriteLine("---------------------------------");
        }
    }

    public class Performance : Entertainment
    {
        public Performance (string name, string director, string genre, string date, string type, List<string> characters, double price) : base(name, director, genre, date)
        {
            _type = type;
            _characters = characters;
            _price = price;
        }

        public Performance(string name, string director, string genre, string date, string type, List<string> characters, string place, int time) : base(name, director, genre, date)
        {
            _type = type;
            _characters = characters;
            _place = place;
            _time = time;
        }

        protected string _type;
        protected List<string> _characters;
        protected double _price;
        protected string _place;
        protected int _time;

        //Setters and getters
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public List<string> Characters
        {
            get { return _characters; }
            set { _characters = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Place
        {
            get { return _place; }
            set { _place = value; }
        }
        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }

        //Public methods
        public override void Show()
        {
            if (this.Type == "Drama")
            {
                Console.WriteLine("---------------------------------");

                Console.WriteLine(" The name is: {0}\n\t The director is: {1}\n\t The genre is: {2}\n\t " +
                    "The date of production is: {3}\n\t The theatre is: {4}\n\t " +
                    "It lasts (minutes): {5}", this.Name, this.Director, this.Genre, this.Date, this.Place, this.Time);

                Console.WriteLine("---------------------------------");
            }
            else if (this.Type == "Film")
            {
                Console.WriteLine("---------------------------------");

                Console.WriteLine(" The name is: {0}\n\t The director is: {1}\n\t The genre is: {2}\n\t " +
                    "The date of production is: {3}\n\t The tickets price is: {4}\n\t " +
                    "", this.Name, this.Director, this.Genre, this.Date, this.Price);

                Console.WriteLine("---------------------------------");
            }
        }
    }

}
