using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //annotation to make the passport number as a primary key 
        [Key]
        [StringLength(7)] //longueur du champ 7 
        public string PassportNumber { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [RegularExpression("^[0,9]{8}$")]
        public int TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public FullName FullName { get; set; }


        public override string? ToString()
        {
            return "FirstName:" + FullName.FirstName + "LastName:" + FullName.LastName;
        }
        //10-a
        public bool CheckProfile( string Fn , string Ln)
        {
            return FullName.FirstName == Fn && FullName.LastName == Ln;
        }
        //10-b
        public bool CheckProfile( string Fn , string Ln, string email=null) 
        {
            return FullName.LastName == Ln && EmailAddress== Fn && EmailAddress==email;
        }
        //10-c
        public bool CheckProfile2(string Fn, string Ln, string email)
        {
            if(email!=null) 
            return FullName.LastName == Ln && EmailAddress == Fn && EmailAddress == email;
            else return FullName.FirstName == Fn && FullName.LastName == Ln;
        }

        //Polymorphisme par héritage

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");
        }

    }
}
