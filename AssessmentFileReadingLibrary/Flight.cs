using System;
using System.Collections.Generic;
using System.Text;

namespace FileReadingLibrary
{
    public class Flight
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public double FuelRequired { get; set; }

        public Flight()
        {
            Departure = string.Empty;
            Destination = string.Empty;
            FuelRequired = 0.0;
        }

        public Flight(string departure, string destination, double fuelRequired)
        {
            Departure = departure;
            Destination = destination;
            FuelRequired = fuelRequired;
        }

        public override string ToString()
        {
            return $"Departure : {Departure} \n" +
                   $"Destination : {Destination} \n" +
                   $"Fuel Required : {FuelRequired} \n";
        }
    }
}
