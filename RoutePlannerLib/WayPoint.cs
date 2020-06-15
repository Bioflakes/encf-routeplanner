using System;
using System.Globalization;

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
            const double rho = 180.0 / Math.PI;
            const double earthRadius = 6371;

            return earthRadius * Math.Acos(
                       Math.Sin(Latitude / rho)
                       * Math.Sin(target.Latitude / rho)
                       + Math.Cos(Latitude / rho)
                       * Math.Cos(target.Latitude / rho)
                       * Math.Cos((Longitude - target.Longitude) / rho));

        }

        public override string ToString()
        {
            FormattableString outputTempalteString = $"WayPoint: {(string.IsNullOrWhiteSpace(Name) ? string.Empty : Name + " ")}{Latitude:F2}/{Longitude:F2}";
            return string.Format(
                CultureInfo.InvariantCulture,
                outputTempalteString.Format,
                outputTempalteString.GetArguments());
        }

        public static WayPoint operator+(WayPoint wp1, WayPoint wp2)
        {
            return new WayPoint(wp1.Name, wp1.Latitude + wp2.Latitude, wp1.Longitude + wp2.Longitude);
        }
        public static WayPoint operator -(WayPoint wp1, WayPoint wp2)
        {
            return new WayPoint(wp1.Name, wp1.Latitude - wp2.Latitude, wp1.Longitude - wp2.Longitude);
        }
    }
}
