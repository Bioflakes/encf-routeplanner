using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class RouteRequestWatcher
    {
        public Dictionary<City, int> dict = new Dictionary<City, int>();
        public virtual DateTime GetCurrentDate {  get { return DateTime.Now; } }
        private List<Tuple<City, DateTime>> cityRequestDate = new List<Tuple<City, DateTime>>();

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

            cityRequestDate.Add(new Tuple<City, DateTime>(city.ToCity, GetCurrentDate));

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

        public IEnumerable<City> GetThreeBiggestCityOnDay(DateTime day)
        {
            return
                cityRequestDate.Where(request => request.Item2.Date == day.Date)
                    .Select(request => request.Item1)
                    .Distinct()
                    .OrderByDescending(c => c.Population)
                    .Take(3);
        }

        public IEnumerable<City> GetThreeLongestCityNamesWithinPeriod(DateTime from, DateTime to)
        {
            return
                cityRequestDate.Where(request => request.Item2.Date >= from.Date && request.Item2.Date <= to.Date)
                .Select(request => request.Item1)
                .Distinct()
                .OrderByDescending(c => c.Name.Length)
                .Take(3);
        }

        public IEnumerable<City> GetNotRequestedCities(Cities cities)
        {
            return
                cities.cities.Where(a => cityRequestDate.Where(b => b.Item2 >= GetCurrentDate.AddDays(-14))
                .All(c => !c.Item1.Equals(a)));
        }
    }
}
