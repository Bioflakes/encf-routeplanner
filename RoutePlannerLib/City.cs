using System;
using System.Collections.Generic;
using System.Text;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class City
    {
        public string Name;
        public string Country;
        public int Population;
        public WayPoint Location;

        public City(string name, string country, int pop, double latitude, double longitude)
        {
            Name = name;
            Country = country;
            Population = pop;
            Location = new WayPoint(name, latitude, longitude);
        }
    }
}
