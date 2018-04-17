// ID: C6221
// Lab 1
// Due 9/20/2017 @ 11:59 pm
// CIS 200-01
// This program displays an array of invoices by part number, description, price, and quantity, and each part sorts the 
// information in different ways and calculates the totals
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class LinqTest
    {
        const int MIN_RANGE = 200;      // A constant minimum range of $200
        const int MAX_RANGE = 500;      // A constant maximum range of $500

        // Precondition: None
        // Postcondition: Output will display the invoices in a list of arrays
        public static void Main(string[] args)
        {
            // initialize array of invoices
            Invoice[] invoices = { 
                new Invoice( 83, "Electric sander", 7, 57.98M ), 
                new Invoice( 24, "Power saw", 18, 99.99M ), 
                new Invoice( 7, "Sledge hammer", 11, 21.5M ), 
                new Invoice( 77, "Hammer", 76, 11.99M ), 
                new Invoice( 39, "Lawn mower", 3, 79.5M ), 
                new Invoice( 68, "Screwdriver", 106, 6.99M ), 
                new Invoice( 56, "Jig saw", 21, 11M ), 
                new Invoice( 3, "Wrench", 34, 7.5M ) };

            // Display original array
            Console.WriteLine("Original Invoice Data\n");
            Console.WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            Console.WriteLine("----- -------------------- ----- ------");

            foreach (Invoice inv in invoices)
                Console.WriteLine(inv);

            // PART A
            // Use LINQ to sort invoice part descriptions
            var PartA =
                from i in invoices
                orderby i.PartDescription
                select i;

            // Display the invoices
            Console.WriteLine("\na) Sorted by description:\n");
            Console.WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            Console.WriteLine("----- -------------------- ----- ------");
            foreach (var element in PartA)
            {
                Console.WriteLine($"{element}");
            }

            // PART B
            // Use LINQ to sort invoice prices 
            var PartB =
                from i in invoices
                orderby i.Price
                select i;

            // Display the invoices
            Console.WriteLine("\nb) Sorted by price:\n");
            Console.WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            Console.WriteLine("----- -------------------- ----- ------");
            foreach (var element in PartB)
            {
                Console.WriteLine($"{element}");
            }

            // PART C
            // USE LINQ to select invoice part descriptions and quantities, and sort by quantities
            var PartC = 
                from i in invoices
                orderby i.Quantity
                select new { i.PartDescription, i.Quantity};

            // Display the invoices
            Console.WriteLine("\nc) Select description and quantity, sort by quantity:\n");
            foreach (var element in PartC)
            {
                Console.WriteLine($"{element}");
            }

            // PART D
            // USE LINQ to select invoice part descriptions and totals, and sort by totals
            var PartD =
                from i in invoices 
                let total = i.Price*i.Quantity
                orderby total
                select new { i.PartDescription, InvoiceTotal = total};

            // Display the invoices
            Console.WriteLine("\nd) Select description and invoice total, sort by invoice total:\n");
            foreach (var element in PartD)
            {
                Console.WriteLine($"{element}");
            }

            // PART E
            // Filter a range of invoice totals using && in a LINQ query
            var PartE =
                from d in PartD
                where (d.InvoiceTotal >= MIN_RANGE) && (d.InvoiceTotal <= MAX_RANGE)
                select d;

            // Display the invoices
            Console.WriteLine("\ne) Invoice totals between $200.00 and $500.00:\n");
            foreach (var element in PartE)
            {
                Console.WriteLine($"{element}");
            }
        }
    }
}
