using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Model
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfPointsOfInterest { get
            {
                return PointsInterest.Count;

            } }


        public ICollection<PointOfInterestDto> PointsInterest { get; set; }
        = new List<PointOfInterestDto>();
    }
}
