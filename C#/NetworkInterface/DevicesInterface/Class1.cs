using System;
using System.Collections.Generic;
using System.IO;

namespace DevicesInterface
{
    interface IDevice
    {
        void SwitchOn();
        void ShutDown();
        void ReportError(); 
    }

    public class Computer : IDevice
    {
        public Computer(string name, string make, string osystem, bool switched)
        {
            this.Name = name;
            this.Make = make;
            this.OperatingSystem = osystem;
            this.SwitchedOn = switched;
            compCounter++;
        }

        // private member variables
        protected string _name;
        protected string _make;
        protected string _ipAdress;
        protected bool _switchedOn;
        protected string _operatingSystem;

        protected static int compCounter = 0; //counts comps in the network
        protected static int switchedCounter = 0; //counts comps that are switched
        protected static int compInNet = 10; //the first comp in the network

        public static int CountComps()
        {
            return compCounter;
        }

        public static int CountSwitched()
        {
            return switchedCounter;
        }

        public virtual void SwitchOn()
        {
            this.SwitchedOn = true;
            switchedCounter++;
            this.Ipaddress = GetIpAddress();
            Console.WriteLine("The comp {0} is starting ...", this.Name);
        }

        public virtual void ShutDown()
        {
            this.SwitchedOn = false;
            switchedCounter--;
            Console.WriteLine("The comp {0} is shuting down !!!", this.Name);
        }

        public string IsSwitched()
        {
            if (this.SwitchedOn)
            { return "switched ON"; }
            else
            { return "switched OFF"; }
        }

        // public properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Ipaddress
        {
            get { return _ipAdress; }
            set { _ipAdress = value; }
        }
        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }
        public string OperatingSystem
        {
            get { return _operatingSystem; }
            set { _operatingSystem = value; }
        }
        public bool SwitchedOn
        {
            get { return _switchedOn; }
            set { _switchedOn = value; }
        }

        public static void ShowComputers(List<Computer> net)
        {
            foreach (Computer comp in net)
            {
                if (comp.SwitchedOn)
                {
                    Type type = comp.GetType();
                    string stringType = type.ToString();
                    Console.Write("{0}\t{1}\t{2}\t\t{3}", comp.Name, comp.Ipaddress, comp.OperatingSystem, comp.Make);
                    int pos = stringType.IndexOf('.');
                    //Console.Write(stringType.Substring(pos+1,4));

                    if (stringType.Substring(pos + 1, 4) == "Serv")
                    {
                        Server serv = (Server)comp;
                        System.Console.WriteLine("\t{0}", serv.Destination);
                    }
                    else
                        Console.WriteLine();
                }

            }
        } // end of ShowComputers

        public static void PingToComputer(List<Computer> net, Computer pingFrom, string pingTo)
        {
            Random rnd = new Random();
            double answer;
            Computer myComp = pingFrom;
            bool found = false;
            Console.WriteLine("\nTrying to ping from the machine {0} ({1}) to {2}.", myComp.Name, myComp.Ipaddress, pingTo);
            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Computer comp in net)
            {
                if ((pingTo == comp.Ipaddress) && (comp.SwitchedOn == true))
                {
                    found = true;
                    break;
                }
            } // the end of the loop

            if (found)
            {
                for (int i = 5; i < 15; i++)
                {
                    answer = (float)(rnd.Next(1, 100)) / 100;
                    Console.WriteLine("64 bytes from {0} icmp_seq={1} ttl=64 time={2} ms", myComp.Ipaddress, i.ToString(), answer.ToString());
                }
            }
            else
            {
                Console.WriteLine("Adress {0} not found !!! ", pingTo);
            }
        } //end of PingToComputer method

        public string GetIpAddress()
        {
            string address = "10.0.0." + (++compInNet).ToString();
            return address;
        }

        public string CreateError(string ip)
        {
            DateTime dateTime= DateTime.Now;

            return $"{dateTime} - There is an unknown error with {ip}";
        }

        public void ReportError()
        {
            List<string> lines = new List<string> { };

            lines.Add("----------------------------------------");
            lines.Add(CreateError(this.Ipaddress));
            //-----------------------------------

            using (StreamWriter outputFile = new StreamWriter("Log.txt"))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }
    } //end of the class Computer

    public class Server : Computer
    {
        public Server(string name, string make, string osystem, bool switched, string dest, string ip) : base(name, make, osystem, switched)
        {
            this.Destination = dest;
            this.Ipaddress = ip;
        }

        // private member variables
        private string _destination;

        // public properties
        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        public override void ShutDown()
        {
            Console.WriteLine("************* !!! **************** ");
            Console.Write("You want to shut dowm this server. Are you sure ? (YES/n): ");


            string confirm = Console.ReadLine();
            if (confirm == "YES")
            {
                this.SwitchedOn = false;
                switchedCounter--;
                Console.WriteLine("The comp {0} is shuting down !!!", this.Name);
            }

        }

        public override void SwitchOn()
        {
            this.SwitchedOn = true;
            switchedCounter++;
            Console.WriteLine("The comp {0} is starting ...", this.Name);
        }
    } //end of the class Server

}
