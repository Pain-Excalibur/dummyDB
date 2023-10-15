using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummyDB.templates.cs
{
    public class Record
    {
        public required uint Id { get; set; }
        public required uint Student { get; set; }
        public required uint Book { get; set; }
        public required DateOnly BorrowDate { get; set; }
        public required DateOnly ReturnDate { get; set; }
    }
}
