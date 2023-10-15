using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummyDB
{
    public class Record
    {
        public required Guid Id {  get; set; }
        public required Guid Student { get; set; }
        public required Guid Book { get; set; }
        public required DateOnly BorrowDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
    }
}
