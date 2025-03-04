using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [MinLength(3, ErrorMessage = "Min 3 caractères")]
        [ MaxLength(30, ErrorMessage = "Max 30 caractères")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
