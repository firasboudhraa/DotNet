// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;


//Console.WriteLine("Hello, World!");
//Question7
//Plane plane = new Plane();

//plane.planeType =PlaneType.Airbus;
//plane.Capacity = 300;
//plane.ManuFactureDate = new DateTime(2001, 11, 10);


//Question8
//Plane plane2 = new Plane(200 , new DateTime(2001,11,10), PlaneType.Boing);

//Question9: Intiateur d'object sans constructeur 
Plane plane3 = new Plane {planeType =PlaneType.Airbus , Capacity = 200 , ManuFactureDate= new DateTime(2001,11,10)};

//Question11

Passenger passenger = new Passenger { FullName = new FullName { FirstName = "firas", LastName = "Boudhraa" }, EmailAddress="Firas.Boudhraa@esprit.tn" };
Console.WriteLine("La méthode checkpassenger");
Console.WriteLine(passenger.CheckProfile("firas", "Boudhraa"));
Console.WriteLine(passenger.CheckProfile2("firas","Boudhraa","Firas.Boudhraa@esprit.tn"));


Staff staff = new Staff {Function="Manager" };
Traveller traveller = new Traveller {Nationality="Tunisia" };
passenger.PassengerType();
staff.PassengerType();
traveller.PassengerType();

//Partie2 
//Question5
FlightMethods fn = new FlightMethods();
fn.Flights = TestData.listFlights;
Console.WriteLine("services");
Console.WriteLine("Get Flight Dates");
foreach (var f in fn.GetFlightDates("Lisbonne"))
{
    Console.WriteLine(f);
}

//Question8
Console.WriteLine("**************************************************************************************************");
FlightMethods flightService = new FlightMethods();
string filterType = "Destination";
string filterValue = "Paris";
flightService.Flights = TestData.listFlights;
Console.WriteLine($"Vols trouvés pour {filterType}={filterValue} : ");
foreach (var f in flightService.GetFlights(filterType,filterValue))
{
    Console.WriteLine(f);
}
//question10
Console.WriteLine("**********************************************************************************************************");
Console.WriteLine("show Flight Details");
fn.ShowFlightDetails(TestData.BoingPlane);
fn.ShowFlightDetails(TestData.Airbusplane);

//question11
Console.WriteLine("**********************************************************************************************************");
DateTime startDate = new DateTime(2022, 01, 31);
int nb = flightService.ProgrammedFlightNumber(startDate);
Console.WriteLine($"{nb}");

//question12
Console.WriteLine("**********************************************************************************************************");
float moy = flightService.DurationAverage("Paris");
Console.WriteLine($"{moy}");

//question13
Console.WriteLine("**********************************************************************************************************");
foreach ( var flight in flightService.OrderedDurationFlights())
{
    // Console.WriteLine($"Destination:{flight.Destination}, Duration : {flight.EstimateDuration} minutes");
    Console.WriteLine(flight);
}

//Question14
Console.WriteLine("**********************************************************************************************************");
Flight selectedFlight = flightService.Flights.First();
Console.WriteLine($"Top 3 oldest travellers on flight to {selectedFlight.Destination}: ");
/*foreach(var t in flightService.SeniorTravellers(selectedFlight))
{
    Console.WriteLine($"{t.FullName.FirstName} {t.FullName.LastName} , Born: {t.BirthDate.ToShortDateString()}");
}*/

//Question15 
Console.WriteLine("**********************************************************************************************************");
flightService.DestinationGroupedFlights();

/*foreach (var group in groupedFlights)
{
    Console.WriteLine(value: $"Destination: {group.Key}");
    foreach (var flight in group)
    {
        Console.WriteLine($"Décollage : {flight.FlightDate.ToString("dd/MM/yyyy HH:mm:ss")}");
    }
}*/

//Insertion dans la BD

AMContext ctx = new AMContext();
UnitOfWork uow = new UnitOfWork(ctx);
ServiceFlight sf = new ServiceFlight(uow);
ServicePlane sp = new ServicePlane(uow);

//Instanciation des objets

Plane plane1 = new Plane
{
    planeType = PlaneType.Airbus,
    Capacity = 150,
    ManuFactureDate = new DateTime(2015, 02, 03)
};

Flight f1 = new Flight()
{
    Departure = "Tunis",
    AirlineLogo = "Tunisair",
    FlightDate = new DateTime(2022, 02, 01, 21, 10, 10),
    Destination = "Paris",
    EffectiveArrival = new DateTime(2022, 02, 01, 23, 10, 10),
    EstimateDuration= 105,
    plane = plane1
};




Passenger p1 = new Passenger
{
    PassportNumber = "A123456",
    BirthDate = new DateTime(1995, 10, 20),
    EmailAddress = "Firas.Boudhraa@esprit.tn",
    TelNumber = 12345678,
    FullName = new FullName
    {
        FirstName = "Firas",
        LastName = "Boudhraa"
    },
    tickets = new List<Ticket>()
};
Passenger p2 = new Passenger
{
    PassportNumber = "A123457",
    BirthDate = new DateTime(1995, 10, 20),
    EmailAddress = "Firas.Boudhraa@esprit.tn",
    TelNumber = 12345678,
    FullName = new FullName
    {
        FirstName = "Firas",
        LastName = "Boudhraa"
    },
    tickets = new List<Ticket>()
};

Ticket t1 = new Ticket
{
    Prix = 100,
    Siege = "1A",
    VIP = true,
    PassengerFK = p1.PassportNumber,
    FlightFK = 1
};


//Ajouter des objets aux Dbset

//ctx.Planes.Add(TestData.Airbusplane);
//ctx.Planes.Add(TestData.BoingPlane);

//ctx.Flights.Add(f1);

//sp.Add(TestData.Airbusplane);
//sp.Add(TestData.BoingPlane);
//sp.Add(plane1);
//sf.Add(f1);

//sp.Commit(); //or sf.Commit()
//sf.Commit();
//ctx.Passengers.Add(p2);
ctx.Tickets.Add(t1);

//persister les données

ctx.SaveChanges();
Console.WriteLine("Ajout avec succées");

