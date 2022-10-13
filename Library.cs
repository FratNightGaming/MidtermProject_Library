using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Project
{
    public class Library
    {
        public List<Book> books { get; set; } = new List<Book>();
        public List<Book> booksCheckedOut { get; set; } = new List<Book>();
        public List<Book> booksAvailable { get; set; } = new List<Book>();

        public Library()
        {
            books.Add(new Book("Harry Potter", "JK Rowling", 250, Book.Genre.Fantasy, Book.Status.Available));
        }

        public void DisplayBooksAllInformation(List<Book> books)
        {
            Console.WriteLine("\nBooks On Display");
            
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i, -10} Title: {books[i].Title, 10}, Author: {books[i].Author, 10}, Genre: {books[i].genre, 10} Pages: {books[i].NumberOfPages,10}, Status: {books[i].status}\n");
                //DisplayIndividualBookInformation(books[i]);
            }

            //Continue function
        }

        public void SearchBookByAuthor(List<Book> books, string author)
        {
            int bookCount = 0;

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author == author)
                {
                    Console.WriteLine($"\n{author} found - List of books by {author}");
                    DisplayIndividualBookInformation(books[i]);
                    bookCount++;
                }
            }

            if (bookCount == 0)
            {
                Console.WriteLine("Author not found.");
            }

            //Continue function

        }

        public void SearchBookByTitle(List<Book> books, string title)
        {
            int bookCount = 0;

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author == title)
                {
                    Console.WriteLine($"\n{title} found:");
                    DisplayIndividualBookInformation(books[i]);
                    bookCount++;
                }

                //use linq to instantiate list based on criteria, then loop through each book found and display info
            }

            if (bookCount == 0)
            {
                Console.WriteLine($"{title} not found.");
            }
            //Continue function

        }

        public void SearchBookByGenre(List<Book> books, string title)
        {
            int bookCount = 0;

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author == title)
                {
                    Console.WriteLine($"\n{title} found:");
                    DisplayIndividualBookInformation(books[i]);
                    bookCount++;
                }

                //use linq to instantiate list based on criteria, then loop through each book found and display infor
            }

            if (bookCount == 0)
            {
                Console.WriteLine($"{title} not found.");
            }
            //Continue function

        }

        public void DisplayIndividualBookInformation(Book book)
        {
            Console.WriteLine($"\nTitle: {book.Title,10}\tAuthor: {book.Author,10}\tPages: {book.NumberOfPages}\tStatus: {book.status}\n");

            //Continue function

        }




		public static void DisplayBooks(List<Book> books)
		{
			foreach (Book book in books)
			{
				string status = "";
				if (book.Checked == Book.Status.checkedin)
				{
					status = "In Library";
				}
				else if (book.Checked == Book.Status.checkedout)
				{
					status = "Checked Out :(";
					// would like to add the date the book is out till
				}
				else if (book.Checked == Book.Status.hold)
				{
					status = $"On Hold (book.date)";
					// if we do use holds
				}
				Console.WriteLine($"{book.Title}\t{book.Author}\t{status}");
			}
			AskToCheckOut();
		}

		public static void AskToCheckOut()
		{
			string choice = GetUserInput("would you like to check any of these books out? y/n");
			if (choice == "y")
			{
				Console.WriteLine("!!!! unfunctional but this would call checkout()");
				// call checkout things
			} 
			else if (choice == "n")
			{
				Console.WriteLine("we hope you find another book you'd like!");
			}
		}
		public static string GetUserInput(string msg)
		{
			string input = null;
			try
			{
				Console.WriteLine(msg);
				input = Console.ReadLine();
			}
			catch (Exception)
			{
				Console.WriteLine("that wasnt't a valid input");
				GetUserInput(msg);

			}
			if (input == null)
			{
				Console.WriteLine("you didn't seem to type anything");
				GetUserInput(msg);
			}
			return input;
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