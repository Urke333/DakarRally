using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyApi.Dtos
{
    public class MalfunctionDto
    {
        public int TimeSinceMalfunction { get; set; }
        public string Type { get; set; }
        public bool IsFixed { get; set; }
    }
}
