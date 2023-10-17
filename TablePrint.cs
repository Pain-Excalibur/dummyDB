using dummyDB.templates.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace dummyDB
{
    internal class TablePrint
    {
        public static void PrintTable(List<Book> books, List<Student> students, List<Record> records)
        {
            int colMaxSizeCreator = GetColMaxSizeCreator(books),
            colMaxSizeTitle = GetColMaxSizeTitle(books),
            colMaxSizeStudent = GetColMaxSizeStudent(students, records),
            colMaxSizeDate = GetColMaxSizeDate(records);

            //writing titles
            Console.Write("|");

            //creator
            string columnElement = "Автор";
            writeColumnElement(colMaxSizeCreator, columnElement);

            //book title
            columnElement = "Название";
            writeColumnElement(colMaxSizeTitle, columnElement);

            //reader if exists
            columnElement = "Читает";
            writeColumnElement(colMaxSizeStudent, columnElement);

            //borrow date
            columnElement = "Взял";
            writeColumnElement(colMaxSizeDate, columnElement);

            //line end
            Console.WriteLine();

            //writing ---------
            Console.Write("|");
            for (int minus = 0; minus < colMaxSizeCreator + 2; minus++) 
            {
                Console.Write("-");
            }
            Console.Write("|");
            for (int minus = 0; minus < colMaxSizeTitle + 2; minus++) 
            {
                Console.Write("-");
            }
            Console.Write("|");
            for (int minus = 0; minus < colMaxSizeStudent + 2; minus++) 
            {
                Console.Write("-");
            }
            Console.Write("|");
            for (int minus = 0; minus < colMaxSizeDate + 2; minus++)
            {
                Console.Write("-");
            }

            //line end
            Console.WriteLine();

            //writing items
            foreach (Book book in books)
            {
                Console.Write("|");
                writeColumnElement(colMaxSizeCreator, book.Creator);
                writeColumnElement(colMaxSizeTitle, book.Title);

                string whoBorrowed = "";
                string whenBorrowed = "";

                foreach(Record record in records)
                {
                    if(record.Book==book.Id)
                    {
                        whenBorrowed = Convert.ToString(record.BorrowDate);

                        foreach (Student student in students)
                        {
                            if(record.Student==student.Id)
                            {
                                whoBorrowed = student.Name + " " + student.Surname[0] + ".";
                            }
                        }
                    }
                }
                writeColumnElement(colMaxSizeStudent, whoBorrowed);
                writeColumnElement(colMaxSizeDate, whenBorrowed);
                Console.WriteLine();
            }
        }

        private static void writeColumnElement(int columnMaxSize, string columnElement)
        {
            int columnSize = Math.Max(columnMaxSize, columnElement.Length);
            Console.Write(" " + columnElement);
            for (int i = 0; i < (columnSize - columnElement.Length); i++)
            {
                Console.Write(" ");
            }
            Console.Write(" |");
        }

        private static int GetColMaxSizeCreator(List<Book> books)
        {
            int columnMaxSize = 0;
            foreach (Book book in books)
            {
                if (book.Creator.Length > columnMaxSize)
                {
                    columnMaxSize = book.Creator.Length;
                }
            }
            return columnMaxSize;
        }

        private static int GetColMaxSizeTitle(List<Book> books)
        {
            int columnMaxSize = 0;
            foreach (Book book in books)
            {
                if (book.Title.Length > columnMaxSize)
                {
                    columnMaxSize = book.Title.Length;
                }
            }
            return columnMaxSize;
        }

        private static int GetColMaxSizeStudent(List<Student> students, List<Record> records)
        {
            int columnMaxSize = 0;
            foreach (Record record in records) 
            {
                foreach (Student student in students)
                {
                    if (record.Student == student.Id)
                    {
                        columnMaxSize = Math.Max(student.Name.Length + 3, columnMaxSize);
                    }
                }
            }
            return columnMaxSize;
        }

        private static int GetColMaxSizeDate(List<Record> records)
        {
            int columnMaxSize = 0;
            foreach (Record record in records)
            {
                columnMaxSize = Math.Max(columnMaxSize, Convert.ToString(record.BorrowDate).Length);
            }
            return columnMaxSize;
        }
    }
}
