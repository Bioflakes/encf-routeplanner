using System;
using System.Collections.Generic;
using System.Text;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class RouteRequestWatcher
    {
        public Dictionary<City, int> dict = new Dictionary<City, int>();
        public void LogRouteRequests(object sender, RouteRequestEventArgs eventArgs)
        {
            var city = eventArgs;

            if (city == null)
            {
                throw new ArgumentNullException("Null city element");
            }

            if (dict.ContainsKey(city.ToCity))
            {
                dict[city.ToCity]++;
            }
            else
            {
                dict.Add(city.ToCity, 1);
            }

            Console.WriteLine("Current Request State");
            Console.WriteLine("---------------------");
            foreach (var e in dict)
                Console.WriteLine($"ToCity: {e.Key.Name} has been requested {e.Value} times");
        }

        public int GetCityRequests(City city)
        {
            if (city == null)
            {
                throw new ArgumentNullException("Null city element");
            }

            int requests = 0;
            dict.TryGetValue(city, out requests);

            return requests;
        }
    }
}
