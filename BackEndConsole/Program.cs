using BackEndTest.FlightRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.FlightCodingTest;

namespace BackEndConsole
{
    class Program  //01:10:00
    {
        static void Main(string[] args)
        {
            var flights = new FlightBuilder().GetFlights();

            //Get departures before the current datetime;
           
            Console.WriteLine("Getting previous flights departed:");
            Console.WriteLine("");
            Print(new FlightsDepartedBeforeCurrentDateTimeRule(flights));
            Console.WriteLine("");
            Console.WriteLine("Getting flights where arrival date before departure Date:");
            Console.WriteLine("");

            Print(new FlightsWhereArrivalIsBeforeDeparture(flights));
            Console.WriteLine("");
            Console.WriteLine("Getting flights with more that 2 hour gap:");
            Console.WriteLine("");
            Print(new FlightsWithTotalGapOfOver2Hours(flights));
            Console.ReadLine();


        }

        private static void Print(IFlightRule rule)
        {
            var flights = rule.GetFlight();
            foreach (var flight in flights)
            {
                Console.WriteLine("Flight");
                foreach (var seg in flight.Segments)
                {
                    Console.WriteLine("Departure: {0}, Arrival:{1}", seg.DepartureDate, seg.ArrivalDate);
                }
            }
        }
    }
}
