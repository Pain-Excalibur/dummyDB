using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummyDB.templates.cs
{
    public class Book
    {
        public required uint Id { get; set; }
        public required string Creator { get; set; }
        public required string Title { get; set; }
        public required DateOnly ReleaseDate { get; set; }
        public required ushort BookShelf { get; set; }
        public required ushort Shelf { get; set; }

    }
}
