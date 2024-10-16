using System;
namespace Task2
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Customer(int customerId, string lastName, string firstName, string street, string city, string state, string zipCode, string phone, string email, string password)
        {
            CustomerId = customerId;
            LastName = lastName;
            FirstName = firstName;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Phone = phone;
            Email = email;
            Password = password;
        }
    }

    class CorporateCustomer : Customer
    {
        public string CompanyName { get; set; }
        public int FrequentFlyerPts { get; set; }
        public string BillingAccountNo { get; set; }

        public CorporateCustomer(int customerId, string lastName, string firstName, string street, string city, string state, string zipCode, string phone, string email, string password, string companyName, int frequentFlyerPts, string billingAccountNo) : base(customerId, lastName, firstName, street, city, state, zipCode, phone, email, password)
        {
            CompanyName = companyName;
            FrequentFlyerPts = frequentFlyerPts;
            BillingAccountNo = billingAccountNo;
        }
    }

    class RetailCustomer : Customer
    {
        public string CreditCardType { get; set; }
        public string CreditCardNo { get; set; }

        public RetailCustomer(int customerId, string lastName, string firstName, string street, string city, string state, string zipCode, string phone, string email, string password, string creditCardType, string creditCardNo) : base(customerId, lastName, firstName, street, city, state, zipCode, phone, email, password)
        {
            CreditCardType = creditCardType;
            CreditCardNo = creditCardNo;
        }
    }

    class Reservation
    {
        public int ReservationNo { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public Flight Flight { get; set; }

        public Reservation(int reservationNo, DateTime date, Customer customer, Flight flight)
        {
            ReservationNo = reservationNo;
            Date = date;
            Customer = customer;
            Flight = flight;
        }
    }

    class Seat
    {
        public int RowNo { get; set; }
        public int SeatNo { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public Seat(int rowNo, int seatNo, decimal price, string status)
        {
            RowNo = rowNo;
            SeatNo = seatNo;
            Price = price;
            Status = status;
        }
    }

    class Flight
    {
        public int FlightId { get; set; }
        public DateTime Date { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int SeatingCapacity { get; set; }
        public List<Seat> Seats { get; set; }

        public Flight(int flightId, DateTime date, string origin, string destination, DateTime departureTime, DateTime arrivalTime, int seatingCapacity)
        {
            FlightId = flightId;
            Date = date;
            Origin = origin;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            SeatingCapacity = seatingCapacity;
            Seats = new List<Seat>();
        }
        class Program
        {
            static void Main(string[] args)
            {
                CorporateCustomer corporateCustomer = new CorporateCustomer(1, "Doe", "John", "123 Main St", "Anytown", "CA", "12345", "555-1234", "john.doe@example.com", "password", "Acme Corp", 1000, "123456789");
                RetailCustomer retailCustomer = new RetailCustomer(2, "Smith", "Jane", "456 Main St", "Anytown", "CA", "54321", "555-5678", "jane.smith@example.com", "password", "Visa", "1234567890123456");

                Flight flight1 = new Flight(1, DateTime.Now.AddDays(1), "New York", "Los Angeles", DateTime.Now.AddDays(1).AddHours(10), DateTime.Now.AddDays(1).AddHours(15), 100);
                Flight flight2 = new Flight(2, DateTime.Now.AddDays(2), "Chicago", "Miami", DateTime.Now.AddDays(2).AddHours(8), DateTime.Now.AddDays(2).AddHours(12), 200);

                Reservation reservation1 = new Reservation(1, DateTime.Now, corporateCustomer, flight1);
                Reservation reservation2 = new Reservation(2, DateTime.Now, retailCustomer, flight2);

                reservation1.Flight.Seats.Add(new Seat(1, 1, 100.00m, "Available"));
                reservation1.Flight.Seats.Add(new Seat(1, 2, 100.00m, "Available"));
                reservation2.Flight.Seats.Add(new Seat(2, 1, 200.00m, "Available"));
                reservation2.Flight.Seats.Add(new Seat(2, 2, 200.00m, "Available"));

                Console.WriteLine("Corporate Customer:");
                Console.WriteLine($"Name: {corporateCustomer.FirstName} {corporateCustomer.LastName}");
                Console.WriteLine($"Company: {corporateCustomer.CompanyName}");
                Console.WriteLine($"Frequent Flyer Points: {corporateCustomer.FrequentFlyerPts}");

                Console.WriteLine("\nRetail Customer:");
                Console.WriteLine($"Name: {retailCustomer.FirstName} {retailCustomer.LastName}");
                Console.WriteLine($"Credit Card Type: {retailCustomer.CreditCardType}");

                Console.WriteLine("\nFlight 1:");
                Console.WriteLine($"Origin: {flight1.Origin}");
                Console.WriteLine($"Destination: {flight1.Destination}");
                Console.WriteLine($"Departure Time: {flight1.DepartureTime}");
                Console.WriteLine($"Arrival Time: {flight1.ArrivalTime}");

                Console.WriteLine("\nFlight 2:");
                Console.WriteLine($"Origin: {flight2.Origin}");
                Console.WriteLine($"Destination: {flight2.Destination}");
                Console.WriteLine($"Departure Time: {flight2.DepartureTime}");
                Console.WriteLine($"Arrival Time: {flight2.ArrivalTime}");

                Console.WriteLine("\nReservation 1:");
                Console.WriteLine($"Reservation No: {reservation1.ReservationNo}");
                Console.WriteLine($"Customer: {reservation1.Customer.FirstName} {reservation1.Customer.LastName}");
                Console.WriteLine($"Flight: {reservation1.Flight.Origin} to {reservation1.Flight.Destination}");

                Console.WriteLine("\nReservation 2:");
                Console.WriteLine($"Reservation No: {reservation2.ReservationNo}");
                Console.WriteLine($"Customer: {reservation2.Customer.FirstName} {reservation2.Customer.LastName}");
                Console.WriteLine($"Flight: {reservation2.Flight.Origin} to {reservation2.Flight.Destination}");
            }
        }
    }
}