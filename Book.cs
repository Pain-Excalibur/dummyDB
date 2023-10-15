using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummyDB
{
    public class Book
    {
        public required Guid Id { get; set; }
        public required string Creator {  get; set; }
        public required string Title { get; set; }
        public required DateOnly ReleaseDate { get; set; }
        public required int BookShelf { get; set; }
        public required int Shelf {  get; set; }
        
    }
}
