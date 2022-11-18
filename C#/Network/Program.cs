using System;
using System.Collections.Generic;

class Computer
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
        //this.isOn = true ? this.ipAdress = ip : this.
        if (this.isOn)
        {
            this.ipAdress = "";
            this.isOn = false;
        }

        else
        {
            this.ipAdress = ip;
            this.isOn = true;
        }
    }
}

class Program
{
    static string RandomIP()
    {
        string ip;

        Random rand = new Random();
        int ip1 = rand.Next(0, 129);
        int ip2 = rand.Next(0, 245);

        string ip11 = ip1.ToString();
        string ip22 = ip2.ToString();

        ip = "10.0." + ip11 + "." + ip22;

        return ip;
    }
    
    static void Main()
    {
        Computer comp01 = new Computer("alfa", "Windows 11");
        Computer comp02 = new Computer("beta", "Windows Server");
        Computer comp03 = new Computer("sigma", "Ubuntu");
        //Computer comp04 = new Computer();

        comp01.SwitchOn(RandomIP());
        comp02.SwitchOn(RandomIP());
        comp03.SwitchOn(RandomIP());

        List<Computer> network = new List<Computer>();

        network.Add(comp01);
        network.Add(comp02);
        network.Add(comp03);

        for(int i = 0; i < network.Count; i++)
        {
            if(network[i].GetIsOn())
            {
                Console.WriteLine("The PC name is: " + network[i].GetName());
                Console.WriteLine("The IP is: " + network[i].GetipAdress() + "\n");
            } 
        }

        Console.WriteLine("There are {0} computers in the network.", Computer.CountComp());

        Console.WriteLine("-----------------------------------" + "\n");

        comp01.SwitchOn("");
        network.Remove(comp01);

        for (int i = 0; i < network.Count; i++)
        {
            if (network[i].GetIsOn())
            {
                Console.WriteLine("The PC name is: " + network[i].GetName());
                Console.WriteLine("The IP is: " + network[i].GetipAdress() + "\n");
            }
        }

        Console.WriteLine("There are {0} computers in the network.", Computer.CountComp());
    }
}