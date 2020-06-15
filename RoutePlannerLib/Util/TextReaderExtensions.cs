using System.Collections.Generic;
using System.IO;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.Util
{
    public static class TextReaderExtensions
    {
        public static IEnumerable<string[]> GetSplittedLines(this TextReader reader, char delimiter)
        {
            string line;

            while((line = reader.ReadLine()) != null)
            {
                yield return line.Split(delimiter);
            }
        }
    }
}
