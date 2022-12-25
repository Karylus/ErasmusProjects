using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerTest
{
    public class Computer
    {
        string name;
        string ipAdress;
        string os;
        bool isOn = false;

        static int counter = 0;

        public Computer()
        {
            counter++;
        }

        public Computer(string n, string os)
        {
            this.name = n;
            this.os = os;

            counter++;
        }

        public Computer(string n, string ip, string os, bool on = false)
        {
            this.name = n;
            this.ipAdress = ip;
            this.os = os;
            this.isOn = on;

            counter++;
        }

        public string GetName()
        {
            return name;
        }

        public string GetipAdress()
        {
            return ipAdress;
        }

        public string GetOS()
        {
            return os;
        }

        public bool GetIsOn()
        {
            return isOn;
        }

        public void SetName(string n)
        {
            name = n;
        }

        public void SetipAdress(string ip)
        {
            ipAdress = ip;
        }

        public void SetOS(string os)
        {
            this.os = os;
        }

        public static int CountComp()
        {
            return counter;
        }

        public void SwitchOn(string ip)
        {
            if (isOn)
            {
                ipAdress = "";
                isOn = false;
            }

            else
            {
                ipAdress = ip;
                isOn = true;
            }
        }
        public void SubComp()
        {
            counter--;
        }
    }

    public class Server : Computer
    {
        string destination;

        public Server(string name, string ipAdress, string os, bool isOn, string dest) : base(name, ipAdress, os, isOn)
        {
            destination = dest;
        }

        public string GetDestination()
        {
            return destination;
        }
    }
}
