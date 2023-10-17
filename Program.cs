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

            TablePrint.PrintTable(books, students, records);
        }
    }
}
