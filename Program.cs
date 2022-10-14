﻿using System.ComponentModel;

namespace Midterm_Project
{
    public class Program
    {
        static void Main()
        {
            Library library1 = new Library();

            library1.DisplayBooksAllInformation(library1.books);


            int userInput = -1; ;
            while (userInput == -1)

            {
                try
                {
                    Console.WriteLine($"Select the book you would like to check out from the list above. Enter 1-{library1.books.Count}");
                    userInput = int.Parse(Console.ReadLine());
                    if (userInput > 0 && userInput <= library1.books.Count)
                    {
                        Console.WriteLine("test here");
                        library1.DisplayIndividualBookInformation(library1.books[userInput -1]);
                    }
                    else
                    {
                        Console.WriteLine($"Your input was not a valid number, please try again. Enter a number between 1-{library1.books.Count}.");
                        Console.WriteLine();
                        continue;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"That wasn't an index in our system! Please enter a number between 1-{library1.books.Count}.");
                    Console.WriteLine();
                    continue;
                }
            }


        }

        public static void DisplayBooksByTitle()
        {

        }


        public static void ReturnBook()
        {
            
        }
    }
}

/*Write a console program which allows a user to search a library catalog and check out books.
Your solution must include some kind of a book class with a title, author, status, and due date if checked out.
Status should be On Shelf or Checked Out (or other statuses you can imagine). 
12 items minimum; All stored in a list.
Allow the user to:
Display the entire list of books.  Format it nicely.
Search for a book by author.
Search for a book by title keyword.
Select a book from the list to check out.
If it’s already checked out, let them know.
If not, check it out to them and set the due date to 2 weeks from today.
Return a book.  (You can decide how that looks/what questions it asks.)

Optional enhancements:
(Moderate)When the user quits, save the current library book list (including due dates and statuses) to the text file so the next time the program runs, it remembers.
*/