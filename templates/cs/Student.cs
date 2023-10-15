using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummyDB.templates.cs
{
    public class Student
    {
        public required uint Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string? FathersName { get; set; }
    }
}
