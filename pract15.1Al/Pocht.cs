using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract15._1Al
{
    internal class Pocht
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Code { get; set; }
        public void ChangeAdres(string street, string city, string state, string postalCode)
        {
            Street = street;
            City = city;
            State = state;
            Code = postalCode;
        }
        public override string ToString()
        {
            return $"Улица: {Street}, Город: {City}, Область: {State}, Почтовый индес: {Code}";
        }
    }
}
