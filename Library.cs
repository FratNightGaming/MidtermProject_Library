﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Midterm_Project.Book;//Ryan, is this how you access the "Genre" variable?

namespace Midterm_Project
{
    public class Library
    {
        public List<Book> books { get; set; } = new List<Book>();
        public List<Book> booksCheckedOut { get; set; } = new List<Book>();
        public List<Book> booksAvailable { get; set; } = new List<Book>();
        public static Book? CurrentBook { get; set; }

        public List<Book>? CurrentBookList { get; set; }


		public Library()//if else check to see if streamwriter file exists
        {
            books.Add(new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", 223, 1997, Book.Genre.fantasy, Book.Status.available));
            books.Add(new Book("Harry Potter and the Chamber of Secrets", "J.K. Rowling", 251, 1998, Book.Genre.fantasy, Book.Status.checked_out));
            books.Add(new Book("Harry Potter and the Prisoner of Azkaban", "J.K. Rowling", 371, 1999, Book.Genre.fantasy, Book.Status.available));
            books.Add(new Book("Harry Potter and the Goblet of Fire", "J.K. Rowling", 636, 2000, Book.Genre.fantasy, Book.Status.available));
            books.Add(new Book("Harry Potter and the Order of the Phoenix", "J.K. Rowling", 766, 2003, Book.Genre.fantasy, Book.Status.available));
            books.Add(new Book("Harry Potter and the Half-Blood Prince", "J.K. Rowling", 607, 2005, Book.Genre.fantasy, Book.Status.available));
            books.Add(new Book("Harry Potter and the Deathly Hallows", "J.K. Rowling", 607, 2007, Book.Genre.fantasy, Book.Status.available));
            books.Add(new Book("The Three-Body Problem", "Liu Cixin", 302, 2008, Book.Genre.science_fiction, Book.Status.available));
            books.Add(new Book("The Silmarillion", "J.R.R. Tolkien", 365, 1977, Book.Genre.fantasy, Book.Status.checked_out));
            books.Add(new Book("The Lord of The Rings: The Fellowship of the Ring", "J.R.R. Tolkien", 423, 1954, Book.Genre.fantasy, Book.Status.available));
            books.Add(new Book("The Lord of The Rings: The Two Towers", "J.R.R. Tolkien", 352, 1954, Book.Genre.fantasy, Book.Status.checked_out));
            books.Add(new Book("The Lord of The Rings: The Return of the King", "J.R.R. Tolkien", 416, 1955, Book.Genre.fantasy, Book.Status.available));
            books.Add(new Book("Simulacra and Simulation", "Jean Baudrillard", 164, 1981, Book.Genre.nonfiction, Book.Status.available));
            books.Add(new Book("Countdown to Zero Day", "Kim Zetter", 406, 2014, Book.Genre.nonfiction, Book.Status.available));
            books.Add(new Book("The Sixth Extinction: An Unnatural History", "Elizabeth Kolbert", 316, 2014, Book.Genre.nonfiction, Book.Status.available));
            books.Add(new Book("Into Thin Air: A personal Account of the Mt. Everest Disaster", "John Krakauer", 416, 1997, Book.Genre.nonfiction, Book.Status.available));
            books.Add(new Book("In the Heart of the Sea: The Tragedy of the Whaleship Essex", "Nathaniel Philbrick", 320, 2000, Book.Genre.history, Book.Status.available));
            books.Add(new Book("Red Dragon", "Thomas Harris", 348, 1981, Book.Genre.horror, Book.Status.available));

        }

        public static void DisplayBooksAllInformation(List<Book> books)
        {
            Console.WriteLine("\nBooks On Display\n");

            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-8} {5,-18} {6,0} \n", 
                          "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine("{0,-5} {1,-73} {2,-25} {3,-20} {4,-8} {5,-18} {6,0}",
                    i + 1,
                    books[i].Title,
                    books[i].Author,
                    books[i].genre,
                    books[i].NumberOfPages,
                    books[1].YearOfPublication,
                    books[i].status); 

                //Console.WriteLine(DisplayIndividualBookInformation(books[i]));
            }
            Console.WriteLine();
        }

        public void SearchBookByAuthor(List<Book> books)
        {
            //gets what the user wants to find
			string author = GetUserInput("Which author are you looking for?");

			// checks to see if there are going to be results
			int bookCount = 0;
			List<Book> booksByAuthor = new List<Book>();
			
            if (books.Any(b => b.Author.ToLower() == author))
			{
				Console.WriteLine($"\n{author} found:");
			}

			// brings all books found into a list and then prints them
			booksByAuthor = books.Where(b => b.Author.ToLower() == author).ToList();
			foreach (Book book in booksByAuthor)
			{
                Console.WriteLine(DisplayIndividualBookInformation(book));
				bookCount++;
			}

            // saying if theres no books or asks to checkout a book
            if (bookCount == 0)
            {
                Console.WriteLine("Author not found.");
            }

            else
            {
                CheckOut(booksByAuthor);
            }
		}

        public void SearchBookByTitle(List<Book> books)
        {
			// gets what the user wants to find
			string title = GetUserInput("Which book are you looking for?");

			// checks to see if there are going to be results
            //lets just do if (books.count == 0). no need for variable
			int bookCount = 0;

			if (books.Any(b => b.Title.ToLower() == title))
			{
				Console.WriteLine($"\n{title} found:");
			}

			// brings all books found into a list and then prints them
			List<Book> booksByTitle = books.Where(b => b.Title.ToLower() == title).ToList();
			
            foreach (Book book in booksByTitle)
			{
                Console.WriteLine(DisplayIndividualBookInformation(book));
				bookCount++;
			}

			// saying if theres no books or asks to checkout a book
			if (bookCount == 0)
            {
                Console.WriteLine($"{title} not found.");
            }
            
			else
			{
				CheckOut(booksByTitle);
			}
		}

        public void SearchBookByGenre(List<Book> books)
        {
            // gets what the user wants to find
            Genre genre = Book.Genre.biography;
            bool getGenre = true;
            while(getGenre) {
                try
                {
                    genre = (Genre)Enum.Parse(typeof(Genre), GetUserInput("Which genre would you like? or type genres for a list :)"));
					/*if (choice == "genre")
					{

						foreach (Genre genre in Enum.GetValues(typeof(Genre)))
						{
							Console.Write($"{genre}, ");
						}

						return AskToCheckOut();
					}*/
					getGenre = false;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("thats not a valid genre! try again");
                }
            }

			// checks to see if there are going to be results
			int bookCount = 0;
			List<Book> booksByGenre = new List<Book>();
			
            if (books.Any(b => b.genre == genre))
            {
              Console.WriteLine($"\n{genre} found:");
            }

            // brings all books found into a list and then prints them
            booksByGenre = books.Where(b => b.genre == genre).ToList();

            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-8} {5,-18} {6,0}  \n",
                           "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");

            foreach (Book book in booksByGenre)
			{
                bookCount++;
                Console.Write(bookCount);

                Console.WriteLine(DisplayIndividualBookInformation(book));
            }
            Console.WriteLine();

			if (bookCount == 0)
			{
				Console.WriteLine($"{genre} not found.");
			}

			// saying if theres no books or asks to checkout a book
			if (bookCount == 0)
            {
                Console.WriteLine($"{genre} not found.");
            }

            else 
            {
                CheckOut(booksByGenre);
			}
		}

        

        public List<Book> SortBooksByTitle(List<Book> books)
        {
            List<Book> booksByTitle = books.OrderBy(b => b.Title).ToList();
            int index = 1;
            foreach (Book book in booksByTitle)
            {
                Console.WriteLine(index + DisplayIndividualBookInformation(book));
                index++;
            }
            return booksByTitle;
        }

        public List<Book> SortBooksByAuthor(List<Book> books)
        {
            List<Book> booksByAuthor = books.OrderBy(b => b.Author).ThenBy(b => b.Title).ToList();
            int index = 1;
            foreach (Book book in booksByAuthor)
            {
                Console.WriteLine(index + DisplayIndividualBookInformation(book));
                index++;
            }
            return booksByAuthor;
        }

        public List<Book> SortBooksByPages(List<Book> books)
        {
            List<Book> booksByPages = books.OrderByDescending(b => b.NumberOfPages).ThenBy(b => b.Author).ThenBy(b => b.Title).ToList();
            int index = 1;
            foreach (Book book in booksByPages)
            {
                Console.WriteLine(index + DisplayIndividualBookInformation(book));
                index++;
            }
            return booksByPages;

        }

        public List <Book> SortBooksByStatus(List<Book> books)
        {
            List<Book> booksByStatus = books.OrderBy(b => b.status).ThenBy(b => b.Author).ThenBy(b => b.Title).ToList();
            int index = 1;
            foreach (Book book in booksByStatus)
            {
                Console.WriteLine(index + DisplayIndividualBookInformation(book));
                index++;
            }
            return booksByStatus;
        }

        public List<Book> SortBooksByGenre(List<Book> books)
        {
            List<Book> booksByGenre = books.OrderBy(b => b.genre).ThenBy(b => b.Title).ToList();
            int index = 1;
            foreach (Book book in booksByGenre)
            {
                Console.WriteLine(index + DisplayIndividualBookInformation(book));
                index++;
            }
            return booksByGenre;
        }

        public List<Book> SortBooksByYear(List<Book> books)
        {
            List<Book> booksByYear = books.OrderByDescending(b => b.YearOfPublication).ThenBy(b => b.Author).ThenBy(b => b.Title).ToList();
            int index = 1;
            foreach (Book book in booksByYear)
            {
                Console.WriteLine(index + DisplayIndividualBookInformation(book));
                index++;
            }
            return booksByYear;
        }
        public static string DisplayIndividualBookInformation(Book book)//do we want to add yearofpublication?
        {
            string bookInformation = ($"{null,-5} {book.Title,-73} {book.Author,-25} {book.genre,-20} {book.NumberOfPages,-10} {book.YearOfPublication, -18} {book.status, 0}");
            return bookInformation;
        }

        public static void CheckOutBook(Book book)
        {
            Console.WriteLine($"Thank you for checking out {book.Title}");
        }


		public static bool AskToCheckOut()
		{
			string choice = GetUserInput("Would you like to check out any of these books out? Y/N").ToUpper().Trim();
			
			if (choice == "Y" || choice == "YES")
            {
                return true;
            }

            else if (choice == "N" || choice == "NO")
            {
                Console.WriteLine("We hope you find another book you'd like!");
                return false;
            }

            else
            {
                Console.WriteLine("Input not recognized. Please try again.");
                return AskToCheckOut();
            }
        }

        public static void CheckOut(List<Book> orderedBookList)
        {
			if (AskToCheckOut())
			{
				CurrentBook = orderedBookList[GetUserInt("Please enter the index of the book you'd like:") - 1];

				if (CurrentBook.status == Book.Status.checked_out)
				{
					Console.WriteLine("This book is checked out! please be more careful");//display when due date is
				}

				else if (CurrentBook.status == Book.Status.hold)
				{
					Console.WriteLine("This book is on hold! please be more careful");//display when hold ends
				}

				else if (CurrentBook.status == Book.Status.available)
				{
					// get date
					DateTime current = DateTime.Today;
					DateTime dueDate = current.AddDays(14);
                    //DateTime current = DateTime.Today.AddDays(14);//testing code here. it is more concise than having two lines 
					CurrentBook.DueDate = dueDate;
					CurrentBook.status = Status.checked_out;
					string formattedDate = CurrentBook.DueDate.ToString("MMMM/d/yyyy");
					Console.WriteLine($"{CurrentBook.Title} will be due back on {formattedDate}");
					Console.WriteLine("Thank You!\n");
				}
			}
		}

       /* public static void CheckOutSingleBook(List<Book> orderedBookList)
        {
           string choice = GetUserInput("Would you like to check out this book out? Y/N").ToUpper().Trim();

            while (true)
            {
                if (choice == "Y" || choice == "YES")
                {
                    if (CurrentBook.status == Book.Status.checked_out)
                    {
                        Console.WriteLine("This book is checked out! please be more careful");//display when due date is
                    }

                    else if (CurrentBook.status == Book.Status.hold)
                    {
                        Console.WriteLine("This book is on hold! please be more careful");//display when hold ends
                    }

                    else if (CurrentBook.status == Book.Status.available)
                    {
                        // get date
                        DateTime current = DateTime.Today;
                        DateTime dueDate = current.AddDays(14);
                        //DateTime current = DateTime.Today.AddDays(14);//testing code here. it is more concise than having two lines 
                        CurrentBook.DueDate = dueDate;
                        CurrentBook.status = Status.checked_out;
                        string formattedDate = CurrentBook.DueDate.ToString("MMMM/d/yyyy");
                        Console.WriteLine($"{CurrentBook.Title} will be due back on {formattedDate}");
                        Console.WriteLine("Thank You!\n");
                    }
                }
                else if (choice == "N" || choice == "NO")
                {
                    Console.WriteLine("We hope you find another book you'd like!");
                    return;
                }
                else
                {
                    Console.WriteLine("Input not recognized. Please try again.");
                    return;
                }
            }
        }*/

        public static void ReturnBook(Book book)
        {
            book.status = Status.available;
            Console.Write($"{book.Title} successfully returned at {DateTime.Now.ToString("MM/dd/yyyy h:mm tt")}. Thank you!");
        }

        public static string GetUserInput(string message)//implement a throw into catch for input == null
        {
            string input = String.Empty;

            try
            {
                Console.WriteLine(message);
                input = Console.ReadLine().ToLower();
            }

            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please try again.");
                GetUserInput(message);//possibly return GetUserInput(message) - possible issue with call stack
            }

            if (input == null)
            {
                Console.WriteLine("No input was detected. Please try again.");
                GetUserInput(message);//possibly return GetUserInput(message) - possible issue with call stack
            }

            return input;
        }
        public static int GetUserInt(string message)
        {
            int input = -1;

            try
            {
                Console.WriteLine(message);
                input = int.Parse(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please try again.");
                GetUserInput(message);//possibly return GetUserInput(message) - possible issue with call stack

            }

            if (input == -1)
            {
                Console.WriteLine("No input was detected. Please try again.");
                GetUserInput(message);//possibly return GetUserInput(message) - possible issue with call stack
            }

            return input;
        }

        public void ReadAndWriteIO(List <Book> sortedBooks)//This should be used in place of display information. DisplayInformationIndividualBooks should be used to feed into this IO function

        //ORRRR I dont ever need to readstream. Just use displayfunction.
        //ORRR just make this a writeIO file and save results after each sort. make sure upon initialization of program, booklist = whats in the write io file
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            File.OpenWrite(currentDirectory);//creates a file in user's current directory
            Console.WriteLine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName);
            StreamWriter sw = new StreamWriter(currentDirectory, false);
            StreamReader sr = new StreamReader(currentDirectory);

            foreach (Book book in sortedBooks)//possibly Book book in categorized books
            {
                sw.WriteLine(DisplayIndividualBookInformation(book));
            }

            sw.Close();
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
            
            //File.OpenWrite(filePath3);
            //function below will take in a list parameter; add logic AFTER checking a book or returning a book OR sorting books list
            //step 1: Create File for user (File.OpenWrite(path)) //how do i ensure user has a compatible filepath?
            //step 2: streamWriter sw = new StreamWriter(path, false)
            //step 3: streamReader sr = new StreamReader(path)
            //step 4: for loop going through length of current list *Create prop called "CurrentList" and assign it after sorting books by category
            //step 5: sw.writeline(list[i].name, list[i].author, list[i].status, etc.)
            //step 6: sw.close
            //step 7: cw(sr.readtoend());
            //step 8: sr.close();
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