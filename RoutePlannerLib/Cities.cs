using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class Cities
    {
        public List<City> cities;
        public int Count 
        { 
            get { return cities.Count; }
        }

        public Cities()
        {
            cities = new List<City>();
        }

        public City this[int index]
        {
            get {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Index not in range.");
                }
                return cities[index]; }
            set { 
                if(index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Index not in range.");
                }
                cities[index] = value; }
        }


        public bool FindByCityName(City city)
        {
            return city.Name.Equals(cityToFind, StringComparison.InvariantCultureIgnoreCase);
        }
        private string cityToFind;

        public City this[string cityName]
        {
            get
            {

                if (string.IsNullOrEmpty(cityName))
                {
                    throw new ArgumentNullException("cityName is null");
                }

                cityToFind = cityName;
                var city = cities.Find(FindByCityName);

                if (city == null)
                {
                    throw new KeyNotFoundException();
                }

                return city;
            }
        }

        public int ReadCities(string filename)
        {

            int counter = 0;

            using (var reader = new StreamReader(filename))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    counter++;
                    string[] splitLine = line.Split("\t");

                    string name = splitLine[0];
                    string country = splitLine[1];
                    int population = int.Parse(splitLine[2]);
                    double latitude = double.Parse(splitLine[3]);
                    double longitude = double.Parse(splitLine[4]);

                    AddCity(new City(name, country, population, latitude, longitude));
                }
            }

            foreach (City c in cities)
            {
                Console.WriteLine("found " + c.Name);
            }

            return counter;
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
