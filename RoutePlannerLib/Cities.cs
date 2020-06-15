using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

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

            int count = 0;
            try
            {
                using (TextReader reader = new StreamReader(filename))
                {
                    foreach (var lineSplit in reader.GetSplittedLines('\t'))
                    {
                        cities.Add(new City(
                            lineSplit[0],
                            lineSplit[1],
                            int.Parse(lineSplit[2]),
                            double.Parse(lineSplit[3], CultureInfo.InvariantCulture),
                            double.Parse(lineSplit[4], CultureInfo.InvariantCulture)));

                        count++;
                    }

                    return count;
                }
            }
            catch (Exception e)
            {
                throw new FileNotFoundException("Data File not found", e);
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
