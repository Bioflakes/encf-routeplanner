using System;
using System.Reflection;
using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib;

namespace RoutePlannerConsole
{
    class RoutePlannerConsoleApp
    {
        public delegate void SaySomething<T>(T name);
        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to RoutePlanner (Version {Assembly.GetExecutingAssembly().GetName().Version}");

            Cities cities = new Cities();
            cities.ReadCities("../../../files/citiesTestDataLab2.txt");

            Links links = new Links(cities);
            links.ReadLinks("../../../files/linksTestDataLab3.txt");

            Console.ReadKey();
        }

        static void SayHello(string name)
        {
            Console.WriteLine($"Hello {name}");
        }

        static void SayFuck(string name)
        {
            Console.WriteLine($"Fuck {name} also im running some methods ");
            SayMethodRan();
        }

        static void SayMethodRan()
        {
            Console.WriteLine("Method ran");
        }

    }
}
