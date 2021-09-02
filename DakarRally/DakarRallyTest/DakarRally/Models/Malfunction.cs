using DakarRally.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DakarRally.Models
{
    public class Malfunction
    {
        public int TimeSinceMalfunction { get; private set; }
        public MalfunctionType Type { get; private set; }
        public bool IsFixed { get; private set; }

        public Malfunction()
        {

        }

        public Malfunction(MalfunctionType type)
        {
            TimeSinceMalfunction = 0;
            Type = type;
            IsFixed = false;
        }

        public void IncreaseTimeSinceMalfunction()
        {
            TimeSinceMalfunction++;
        }
        public void SetTimeSinceMalfunction(int time)
        {
            TimeSinceMalfunction = time;
        }
        public void SetType(MalfunctionType malfunctionStatus)
        {
            Type = malfunctionStatus;
        }
        public void SetIsFixed(bool isFixed)
        {
            IsFixed = isFixed;
        }
    }
}
