// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using GradeBook;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Krishn's Grade Book");
            book.AddGrade(96.3);
            book.AddGrade(82.3);
            book.AddGrade(78.2);
            book.ShowStatistics();
            //:0.0 To have one digit after point.
            
        }
    }
}
