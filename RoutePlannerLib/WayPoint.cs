using System;
using System.Collections.Generic;
using System.Text;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class WayPoint
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public WayPoint(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Distance(WayPoint target)
        {
            double Radius = 6371;

            double TempResult = (Math.Sin(Latitude) * Math.Sin(target.Latitude)) + (Math.Cos(Latitude) * Math.Cos(target.Latitude) * Math.Cos(Longitude - target.Longitude));
            double Result = Radius * Math.Acos(TempResult);

            return Result;
        }

        public override string ToString()
        {
            string output = $"WayPoint: {(Name.Equals("") ? "" : Name) } {Latitude:F2}/{Longitude:F2}";
            return output;
        }

    }
}
