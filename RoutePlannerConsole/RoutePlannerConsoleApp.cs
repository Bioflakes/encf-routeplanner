﻿using System;
using System.Reflection;
using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib;

namespace RoutePlannerConsole
{
    class RoutePlannerConsoleApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to RoutePlanner (Version {Assembly.GetExecutingAssembly().GetName().Version}");

            var wayPoint = new WayPoint("Windisch", 47.479319847061966, 8.212966918945312);
            Console.WriteLine(wayPoint.ToString());

            var tripolis = new WayPoint("Tripolis", 32.886680, 13.190567);
            var bern = new WayPoint("Bern", 46.947663, 7.447173);

            Console.WriteLine($"Distance between Bern and Tripolis: {tripolis.Distance(bern):F2}");
            Console.ReadKey();
        }
    }
}