using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.FlightCodingTest;

namespace BackEndTest.FlightRules
{
    public class FlightsDepartedBeforeCurrentDateTimeRule :FlightRulebase
    {


        

        public FlightsDepartedBeforeCurrentDateTimeRule(IList<Flight> flights):base(flights)
        {
            
        }

        public override IList<Flight> GetFlight()
        {
            var today = DateTime.Now;
            var flightsDeparted = _flights.Where(a => a.Segments.Any(b => today > b.DepartureDate));

            return flightsDeparted.ToList();
               
        }
    }
}
