using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Ovn5
{
    internal class Handler : IHandler
    {
        //private Garage<Car>?
        //private Garage<Vehicle>?
        //private Garage<IVehicle>?

        //Hämtar fordon från IGarage/Garage
        //Skickar tillbaka till Manager klassen
        //Använd helst LINQ för smidighet annars foreach

        //● Lista samtliga parkerade fordon
        //● Lista fordonstyper och hur många av varje som står i garaget
        //● Lägga till och ta bort fordon ur garaget
        //● Sätta en kapacitet(antal parkeringsplatser) vid instansieringen av ett nytt garage
        //● Möjlighet att populera garaget med ett antal fordon från start.
        //● Hitta ett specifikt fordon via registreringsnumret. Det ska gå fungera med både
        //  ABC123 samt Abc123 eller AbC123.
        //● Söka efter fordon utifrån en egenskap eller flera (alla möjliga kombinationer från
        //  basklassen Vehicle ).
        //  Exempelvis:
        //○ Alla svarta fordon med fyra hjul.
        //○ Alla motorcyklar som är rosa och har 3 hjul.
        //○ Alla lastbilar
        //○ Alla röda fordon

        //● Användaren ska få feedback på att saker gått bra eller dåligt.Till exempel när vi
        //parkerat ett fordon vill vi få en bekräftelse på att fordonet är parkerat.Om det inte
        //går vill användaren få veta varför.


    }
}
