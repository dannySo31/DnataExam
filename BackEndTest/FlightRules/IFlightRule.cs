using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.FlightCodingTest;

namespace BackEndTest.FlightRules
{
    public interface IFlightRule
    {
        IList<Flight> GetFlight();
    }
}
