using System;
using System.Collections.Generic;
using System.Text;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class RouteRequestEventArgs : EventArgs
    {
        public City FromCity { get; }
        public City ToCity { get; }
        public TransportMode Mode { get; }
        public RouteRequestEventArgs(City fromCity, City toCity, TransportMode transportMode)
        {
            FromCity = fromCity;
            ToCity = toCity;
            Mode = transportMode;
        }


    }
}
