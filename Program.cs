using dummyDB.templates.cs;
using System;
using System.Globalization;
using System.Reflection;

namespace dummyDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Book> books = Parser.Book(@"../../../data/Books.csv");
            List<Student> students = Parser.Student(@"../../../data/Students.csv");
            List<Record> records = Parser.Record(@"../../../data/Records.csv");
            
            foreach (Book book in books)
            {
                Console.Write("Название книги: " + book.Title);
                foreach (Record record in records)
                {
                    if(record.Book==book.Id)
                    {
                        foreach (Student student in students) 
                        { 
                            if (student.Id==record.Student)
                            {
                                Console.Write(" | Имя студента: " + student.Name + " | Дата: " + record.BorrowDate.ToString());
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
