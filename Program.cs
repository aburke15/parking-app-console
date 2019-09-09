using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingGarage
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer(2.6);
            var customer2 = new Customer(3.65);
            var customer3 = new Customer(21.25);
            var customer4 = new Customer(17.56);

            var parkingGarage = new ParkingGarage();

            customer1.ParkingCharge = parkingGarage
                .ChargeCustomerForParking(customer1.HoursParked);

            customer2.ParkingCharge = parkingGarage.
                ChargeCustomerForParking(customer2.HoursParked);

            customer3.ParkingCharge = parkingGarage
                .ChargeCustomerForParking(customer3.HoursParked);

            customer4.ParkingCharge = parkingGarage
                .ChargeCustomerForParking(customer4.HoursParked);

            var totalCharges = parkingGarage.RunningTotal;
        }
    }

    public class ParkingGarage
    {
        private const double MinimumFee = 2.00;
        private const double AdditionalFee = 0.50;
        private const double MaximumFee = 10.00;
        private const int MinimumHours = 3;
        private const int MaximumHours = 19;
        public double RunningTotal { get; private set; }

        public ParkingGarage() 
            => RunningTotal = 0.0;

        public double ChargeCustomerForParking(double hoursParked)
        {
            double hoursParkedCeiling = Math.Ceiling(hoursParked);

            if (hoursParkedCeiling <= MinimumHours)
            {
                RunningTotal += MinimumFee;
                return MinimumFee;
            }

            if (hoursParkedCeiling >= MaximumHours)
            {
                RunningTotal += MaximumFee;
                return MaximumFee;
            }

            double calculatedCharge = MinimumFee + ((hoursParkedCeiling - MinimumHours) * AdditionalFee);
            RunningTotal += calculatedCharge;

            return calculatedCharge;
        }
    }

    public class Customer
    {
        public Customer(double hoursParked) 
            => HoursParked = hoursParked;

        public double HoursParked { get; private set; }

        public double ParkingCharge { get; set; }
    }
}
