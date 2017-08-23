using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.FlightCodingTest;

namespace BackEndTest.FlightRules
{
    public class FlightsWhereArrivalIsBeforeDeparture : FlightRulebase
    {
        public FlightsWhereArrivalIsBeforeDeparture(IList<Flight> flights):base(flights)
        {

        }
        public override IList<Flight> GetFlight()
        {
            
            var flightsDeparted = _flights.Where(a => a.Segments.Any(b => b.ArrivalDate < b.DepartureDate));

            return flightsDeparted.ToList();
        }
    }
}
