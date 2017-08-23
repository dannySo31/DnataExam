using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.FlightCodingTest;

namespace BackEndTest.FlightRules
{
    public abstract class FlightRulebase : IFlightRule
    {
        public FlightRulebase(IList<Flight> flights)
        {
            _flights = flights;
        }

        protected IList<Flight> _flights;
        public abstract IList<Flight> GetFlight();

        
    }
}
