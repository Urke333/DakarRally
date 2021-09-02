using DakarRally.Enumerations;
using System.Collections.Generic;
using System.Linq;

namespace DakarRally.Models
{
    public class MalfunctionList
    {
        private List<Malfunction> malfunctions;

        public MalfunctionList()
        {
            malfunctions = new List<Malfunction>();
        }

        public List<Malfunction> GetMalfunctions()
        {
            return malfunctions;
        }

        public void AddMalfunction(MalfunctionType malfunctionStatus)
        {
            malfunctions.Add(new Malfunction(malfunctionStatus));
        }

        public bool IsThereHeavyMalfunction()
        {
            return malfunctions.Any(o => o.Type == MalfunctionType.Heavy);
        }

        public Malfunction GetActiveMalfunction()
        {
            return malfunctions.LastOrDefault(o => o.Type == MalfunctionType.Light && !o.IsFixed);
        }

        public int GetMalfunctionCount()
        {
            return malfunctions.Count;
        }

        public void SetMalfunctionList(List<Malfunction> malfunctions)
        {
            malfunctions = malfunctions;
        }
    }
}
