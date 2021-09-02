using System.Collections.Generic;

namespace DakarRally.Models
{
    public class RaceList
    {
        public List<Race> races { get; private set; }

        public RaceList()
        {
            races = new List<Race>();
        }
    }
}
