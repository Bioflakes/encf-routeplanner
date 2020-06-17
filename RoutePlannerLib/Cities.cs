using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

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
            try
            {
                using (TextReader reader = new StreamReader(filename))
                {
                    var citiesAsString = reader.GetSplittedLines('\t')
                        .Select(i => new City(
                            i[0],
                            i[1],
                            int.Parse(i[2]),
                            double.Parse(i[3], CultureInfo.InvariantCulture),
                            double.Parse(i[4], CultureInfo.InvariantCulture)
                        )).ToArray();
                    cities.AddRange(citiesAsString);
                    return citiesAsString.Length;
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

        public IEnumerable<City> FindNeighbours(WayPoint location, double distance)
        {

            return cities.Where(c => location.Distance(c.Location) < distance).ToList();
        }
        
        public int GetPopulationOfShortestCityNames()
        {
            return cities.OrderBy(c => c.Name.Length).Take(3).Sum(c => c.Population);
        }
    }
}
