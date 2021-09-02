using System;
using System.Collections.Generic;
using System.Text;

namespace DakarRally.Models
{
    public class RaceTickInformation
    {
        public List<Vehicle> Vehicles { get; private set; }
        public DateTime RaceStartTime { get; private set; }

        public void SetRaceStartTime (DateTime startTime)
        {
            RaceStartTime = startTime;
        }
    }
}
