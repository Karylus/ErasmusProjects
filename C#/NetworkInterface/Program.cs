using System;
using System.Collections.Generic;
using DevicesInterface;

namespace NetworkInterface
{
    class Program
    {
        static string RandomIP(Random rand)
        {
            string ip;

            int ip1 = rand.Next(0, 129);
            int ip2 = rand.Next(0, 245);

            string ip11 = ip1.ToString();
            string ip22 = ip2.ToString();

            ip = "10.0." + ip11 + "." + ip22;

            return ip;
        }

        static void PrintNetwork(List<Computer> network)
        {
            for (int i = 0; i < network.Count; i++)
            {
                if (network[i].SwitchedOn)
                {
                    Console.WriteLine("The PC name is: " + network[i].Name);
                    Console.WriteLine("The IP is: " + network[i].Ipaddress + "\n");

                    if (network[i] is Server)
                    {
                        //Console.WriteLine("The function of the server is: ", network[i].GetDestination());
                    }
                }
            }

            Console.WriteLine("There are {0} computers in the network.", Computer.CountSwitched());

            Console.WriteLine("----------------------------------------------------------" + "\n");
        }

        public static void Main(string[] args)
        {
            List<Computer> network = new List<Computer>();

            //Creating the objects 
            Server zero = new Server("zero", "Dell", "Linux", false, "DHCP", "10.0.0.1");
            Server omega = new Server("omega", "IBM", "Linux", false, "WEB Server", "10.0.0.2");
            Server mysql = new Server("mysql", "IBM", "Linux", false, "MySql", "10.0.0.5");
            Computer alfa = new Computer("alfa", "Dell", "Windows", false);
            Computer beta = new Computer("beta", "Lenovo", "Linux", false);
            Computer gamma = new Computer("gamma", "HP", "Windows", false);
            Computer delta = new Computer("delta", "Dell", "Windows", false);

            //Adding objects Computer to the list network
            network.Add(zero);
            network.Add(omega);
            network.Add(mysql);
            network.Add(alfa);
            network.Add(beta);
            network.Add(gamma);
            network.Add(delta);

            int compsInNetwork = Computer.CountComps();
            Console.WriteLine("We have {0} computers in our network.\n", compsInNetwork);

            //"Swithing on the computers"
            for (int i = 0; i < network.Count; i++)
            {
                network[i].SwitchOn();
            }

            Console.WriteLine("We have {0} computers in our network that is switched ON\n", Computer.CountSwitched());
            Computer.ShowComputers(network);
            Console.WriteLine("\n--------------------------------------------------------------------");

            beta.ShutDown();
            Console.WriteLine("--------------------------------------------------------------------");

            Console.WriteLine("\nWe have {0} computers in our network that is switched ON\n", Computer.CountSwitched());
            Computer.ShowComputers(network);

            //Ping from alfa to 10.0.0.14
            Computer.PingToComputer(network, alfa, "10.0.0.14");

            //Log an error
            alfa.ReportError();
        }
    }
}
