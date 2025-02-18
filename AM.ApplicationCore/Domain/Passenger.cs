using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }


        public override string? ToString()
        {
            return "FirstName:" +FirstName+ "LastName:" +LastName;
        }
        //10-a
        public bool CheckProfile( string Fn , string Ln)
        {
            return FirstName== Fn && LastName== Ln;
        }
        //10-b
        public bool CheckProfile( string Fn , string Ln, string email=null) 
        {
            return LastName== Ln && EmailAddress== Fn && EmailAddress==email;
        }
        //10-c
        public bool CheckProfile2(string Fn, string Ln, string email)
        {
            if(email!=null) 
            return LastName == Ln && EmailAddress == Fn && EmailAddress == email;
            else return FirstName == Fn && LastName == Ln;
        }

        //Polymorphisme par héritage

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");
        }

    }
}
