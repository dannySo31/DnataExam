using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.FlightCodingTest;

namespace BackEndTest.FlightRules
{
    public class FlightsWithTotalGapOfOver2Hours : FlightRulebase
    {
        public FlightsWithTotalGapOfOver2Hours(IList<Flight> flights) : base(flights)
        {
        }

        public override IList<Flight> GetFlight()
        {
            //get
            var flightsDeparted = _flights.Where(a => a.Segments.Count()>1);
            IList<Flight> list = new List<Flight>();
            

            foreach (var flight in flightsDeparted)
            {
                var segments = flight.Segments.OrderBy(a => a.DepartureDate).ToArray();
                int beg = 0;
                int end = 1;
                for(int i = 0; i < segments.Length; i++)
                {
                    beg = i;
                    end = i + 1;
                    if (end< segments.Length)
                    {
                        TimeSpan diff = segments[end].DepartureDate - segments[beg].ArrivalDate; 
                        if (diff.TotalHours > 2)
                        {
                            list.Add(flight);
                        }
                    }
                }

            }

            return list;
        }
    }
}
