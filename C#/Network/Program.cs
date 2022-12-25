using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerTest;

namespace Network
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

        static void ShutDownComp(List<Computer> network, string name)
        {
            for (int i = 0; i < network.Count; i++)
            {
                if (network[i].GetName() == name)
                {
                    network[i].SubComp();

                    network.RemoveAt(i);
                } 
            }
        }

        static void PrintNetwork(List<Computer> network)
        {
            for (int i = 0; i < network.Count; i++)
            {
                if (network[i].GetIsOn())
                {
                    Console.WriteLine("The PC name is: " + network[i].GetName());
                    Console.WriteLine("The IP is: " + network[i].GetipAdress() + "\n");

                    if (network[i] is Server)
                    {
                        //Console.WriteLine("The function of the server is: ", network[i].GetDestination());
                    }
                }
            }

            Console.WriteLine("There are {0} computers in the network.", Computer.CountComp());

            Console.WriteLine("----------------------------------------------------------" + "\n");
        }

        static void Main()
        {
            Random rand = new Random();

            Computer comp01 = new Computer("alfa", "Windows 11");
            Computer comp02 = new Computer("beta", "Windows Server");
            Computer comp03 = new Computer("sigma", "Ubuntu");

            comp01.SwitchOn(RandomIP(rand));
            comp02.SwitchOn(RandomIP(rand));
            comp03.SwitchOn(RandomIP(rand));

            List<Computer> network = new List<Computer>
            {
                comp01,
                comp02,
                comp03
            };

            PrintNetwork(network);

            ShutDownComp(network, "alfa");

            PrintNetwork(network);

            Server serv01 = new Server("Alpha Server", "adfsdafdsa", "Windows Server", false, "DNS");
            serv01.SwitchOn(RandomIP(rand));
            network.Add(serv01);

            PrintNetwork(network);
        }
    }
}
