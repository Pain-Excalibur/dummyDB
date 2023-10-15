using dummyDB.templates.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace dummyDB
{
    internal class Parser
    {
        public static List<Book> Book (string path)
        {
            List<Book> books = new List<Book>();
            int fileline = 0;
            foreach (string line in File.ReadLines(path))
            {
                fileline++;
                string[] elements = line.Split(";");
                
                if ( elements.Length < 6 ) 
                {
                    throw new ArgumentException("В файле " + path + " в строке " + fileline + " недостаточно элементов.");
                }
                else if ( elements.Length > 6 )
                {
                    throw new ArgumentException("В файле " + path + " в строке " + fileline + " слишком много элементов.");
                }

                int catchError = 0;
                if (!uint.TryParse(elements[0], out uint Id))
                {
                    catchError = 1;
                }
                string creator = elements[1];
                string title = elements[2];
                if (!DateOnly.TryParse(elements[3], out DateOnly releaseDate))
                {
                    catchError = 4;
                }
                if (!ushort.TryParse(elements[4], out ushort bookShelf))
                {
                    catchError = 5;
                }
                if (!ushort.TryParse(elements[5], out ushort shelf))
                {
                    catchError = 6;
                }
                if(catchError!=0)
                {
                    throw new ArgumentException("В файле " + path + " в строке " + fileline + " элемент " + catchError + " имеет неправильный тип.");
                }

                books.Add(new Book
                {
                    Id = Id,
                    Creator = creator,
                    Title = title,
                    ReleaseDate = releaseDate,
                    BookShelf = bookShelf,
                    Shelf = shelf
                });
            }
            return books;
        }
        public static List<Student> Student (string path)
        {
            List<Student> students = new List<Student>();
            int fileline = 0;
            foreach (string line in File.ReadLines(path))
            {
                fileline++;
                string[] elements = line.Split(";");

                if (elements.Length < 4)
                {
                    throw new ArgumentException("В файле " + path + " в строке " + fileline + " недостаточно элементов.");
                }
                else if (elements.Length > 4)
                {
                    throw new ArgumentException("В файле " + path + " в строке " + fileline + " слишком много элементов.");
                }

                int catchError = 0;
                if (!uint.TryParse(elements[0], out uint Id))
                {
                    catchError = 1;
                }
                string name = elements[1];
                string surname = elements[2];
                string fathersName = elements[3];

                if (catchError != 0)
                {
                    throw new ArgumentException("В файле " + path + " в строке " + fileline + " элемент " + catchError + " имеет неправильный тип.");
                }

                students.Add(new Student
                {
                    Id = Id,
                    Name = name,
                    Surname = surname,
                    FathersName = fathersName
                });
            }
            return students;
        }
        public static List<Record> Record (string path)
        {
            List<Record> records = new List<Record>();
            int fileline = 0;
            foreach (string line in File.ReadLines(path))
            {
                fileline++;
                string[] elements = line.Split(";");

                if (elements.Length < 5)
                {
                    throw new ArgumentException("В файле " + path + " в строке " + fileline + " недостаточно элементов.");
                }
                else if (elements.Length > 5)
                {
                    throw new ArgumentException("В файле " + path + " в строке " + fileline + " слишком много элементов.");
                }

                int catchError = 0;
                if (!uint.TryParse(elements[0], out uint Id))
                {
                    catchError = 1;
                }
                if (!uint.TryParse(elements[1], out uint student))
                {
                    catchError = 2;
                }
                if (!uint.TryParse(elements[2], out uint book))
                {
                    catchError = 3;
                }
                if (!DateOnly.TryParse(elements[3], out DateOnly borrowDate))
                {
                    catchError = 4;
                }
                if (!DateOnly.TryParse(elements[4], out DateOnly returnDate))
                {
                    catchError = 5;
                }
                
                if (catchError != 0)
                {
                    throw new ArgumentException("В файле " + path + " в строке " + fileline + " элемент " + catchError + " имеет неправильный тип.");
                }

                records.Add(new Record
                {
                    Id = Id,
                    Student = student,
                    Book = book,
                    BorrowDate = borrowDate,
                    ReturnDate = returnDate,
                });
            }
            return records;
        }
    }
}