using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class Cities
    {
        public List<City> cities;
        public int Count { get; set; }

        public City this[int index]
        {
            get { 
                if(index >= Count)
                {
                    throw new ArgumentOutOfRangeException("Index not in range.");
                }
                return this.cities[index]; }
            set { 
                if(index >= Count)
                {
                    throw new ArgumentOutOfRangeException("Index not in range.");
                }
                this.cities[index] = value; }
        }

        public int ReadCities(string filename)
        {
            cities = new List<City>();
            int counter = 0;

            using (var reader = new StreamReader(filename))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    counter++;
                    string[] splitLine = line.Split("\t");

                    string name = splitLine[0];
                    string country = splitLine[1];
                    int population = int.Parse(splitLine[2]);
                    double latitude = double.Parse(splitLine[3]);
                    double longitude = double.Parse(splitLine[4]);

                    cities.Add(new City(name, country, population, latitude, longitude));
                }
                Count = counter;
                return counter;
            }
        }

        public int AddCity(City city)
        {
            if(city != null)
            {
                cities.Add(city);
            }
            return Count;
        }

        public IList<City> FindNeighbours(WayPoint location, double distance) {
            IList<City> neighbours = new List<City>();



            foreach(City c in cities)
            {
                if (location.Distance(c.Location) < distance)
                {
                    neighbours.Add(c);
                }
            }
            return neighbours;
        }
        
    }
}
