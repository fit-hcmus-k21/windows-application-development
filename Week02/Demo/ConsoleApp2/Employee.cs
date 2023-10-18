using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Circle
    {
        public float Radius { get; set; }

        public float Diameter => 2 * Radius;
        public float Area => float.Pi * Radius * Radius;
        public float Perimeter => float.Pi * Diameter;
    }
    public class Employee
    {
        public string FirstName { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }

        // Read only - getter // Derivative property
        public string Fullname => $"{FirstName} {Middle} {Last}";


        //private string _firstName;
        //private string _middlename;
        //private string _lastName;

        //public string FirstName
        //{
        //    get
        //    {
        //        return _firstName;
        //    }
        //    set
        //    {
        //        _firstName = value;
        //    }
        //}

        //public string Middlename { 
        //    get => _middlename; 
        //    set => _middlename = value; 
        //}
        //public string LastName { 
        //    get => _lastName; 
        //    set => _lastName = value; 
        //}
    }
}
