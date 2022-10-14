using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Midterm_Project.Book;

namespace Midterm_Project
{
    public class Library
    {
        public List<Book> books { get; set; } = new List<Book>();
        public List<Book> booksCheckedOut { get; set; } = new List<Book>();
        public List<Book> booksAvailable { get; set; } = new List<Book>();
        public Book Selection { get; set; }


		public Library()
        {
            books.Add(new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", 223, 1997, Book.Genre.Fantasy, Book.Status.Available));
            books.Add(new Book("Harry Potter and the Chamber of Secrets", "J.K. Rowling", 251, 1998, Book.Genre.Fantasy, Book.Status.Checked_Out));
            books.Add(new Book("Harry Potter and the Prisoner of Azkaban", "J.K. Rowling", 371, 1999, Book.Genre.Fantasy, Book.Status.Available));
            books.Add(new Book("Harry Potter and the Goblet of Fire", "J.K. Rowling", 636, 2000, Book.Genre.Fantasy, Book.Status.Available));
            books.Add(new Book("Harry Potter and the Order of the Phoenix", "J.K. Rowling", 766, 2003, Book.Genre.Fantasy, Book.Status.Available));
            books.Add(new Book("Harry Potter and the Half-Blood Prince", "J.K. Rowling", 607, 2005, Book.Genre.Fantasy, Book.Status.Available));
            books.Add(new Book("Harry Potter and the Deathly Hallows", "J.K. Rowling", 607, 2007, Book.Genre.Fantasy, Book.Status.Available));
            books.Add(new Book("The Three-Body Problem", "Liu Cixin", 302, 2008, Book.Genre.Science_Fiction, Book.Status.Available));
            books.Add(new Book("The Silmarillion", "J.R.R. Tolkien", 365, 1977, Book.Genre.Fantasy, Book.Status.Checked_Out));
            books.Add(new Book("The Lord of The Rings: The Fellowship of the Ring", "J.R.R. Tolkien", 423, 1954, Book.Genre.Fantasy, Book.Status.Available));
            books.Add(new Book("The Lord of The Rings: The Two Towers", "J.R.R. Tolkien", 352, 1954, Book.Genre.Fantasy, Book.Status.Checked_Out));
            books.Add(new Book("The Lord of The Rings: The Return of the King", "J.R.R. Tolkien", 416, 1955, Book.Genre.Fantasy, Book.Status.Available));
            books.Add(new Book("Simulacra and Simulation", "Jean Baudrillard", 164, 1981, Book.Genre.Nonfiction, Book.Status.Available));
            books.Add(new Book("Countdown to Zero Day", "Kim Zetter", 406, 2014, Book.Genre.Nonfiction, Book.Status.Available));
            books.Add(new Book("The Sixth Extinction: An Unnatural History", "Elizabeth Kolbert", 316, 2014, Book.Genre.Nonfiction, Book.Status.Available));
            books.Add(new Book("Into Thin Air: A personal Account of the Mt. Everest Disaster", "John Krakauer", 416, 1997, Book.Genre.Nonfiction, Book.Status.Available));
            books.Add(new Book("In the Heart of the Sea: The Tragedy of the Whaleship Essex", "Nathaniel Philbrick", 320, 2000, Book.Genre.History, Book.Status.Available));
        }

        public void DisplayBooksAllInformation(List<Book> books)
        {
            Console.WriteLine("\nBooks On Display");

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1,-10} Title: {books[i].Title,10}, Author: {books[i].Author,10}, Genre: {books[i].genre,10} Pages: {books[i].NumberOfPages,10}, Status: {books[i].status}\n");
                //DisplayIndividualBookInformation(books[i]);
            }


        }

        public void SearchBookByAuthor(List<Book> books)
        {
            int bookCount = 0;


            string author = GetUserInput("which author are you looking for?");


            bool booksbyAuthor = books.Any(b => b.Author == author);

            if (booksbyAuthor)
            {
                Console.WriteLine($"\n{author.ToUpper()} found:");
            }

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

            AskToCheckOut();

        }

        public void SearchBookByTitle(List<Book> books)
        {
            int bookCount = 0;
            string title = GetUserInput("which title are you looking for?");


            bool booksbyTitle = books.Any(b => b.Title == title);
            if (booksbyTitle)
            {
                Console.WriteLine($"\n{title.ToUpper()} found:");
            }

            for (int i = 0; i < books.Count; i++)

            {
                if (books[i].Title == title)
                {
                    Console.WriteLine($"\n{title.ToUpper()} found:");
                    DisplayIndividualBookInformation(books[i]);
                    bookCount++;
                }

                //use linq to instantiate list based on criteria, then loop through each book found and display info
                List<Book> booksByTitle = books.Where(b => b.Title.Contains(title)).ToList();

                Console.WriteLine($"List of books by {title}");

                foreach (Book book in booksByTitle)
                {
                    DisplayIndividualBookInformation(book);
                }
            }

            if (bookCount == 0)
            {
                Console.WriteLine($"{title} not found.");
            }
            AskToCheckOut();

        }

        public void SearchBookByGenre(List<Book> books)
        {
            Genre genre = Book.Genre.Biography;
            bool getGenre = true;
            while(getGenre) {
                try
                {
                    genre = (Genre)Enum.Parse(typeof(Genre), GetUserInput("which genre would you like? we have "));
                    getGenre = false;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("thats not a valid genre! try again");
                }
            }
            int bookCount = 0;
			List<Book> booksByGenre = new List<Book>();

            if (books.Any(b => b.genre == genre))
            {
                Console.WriteLine($"\n{genre} found:");
            }

            /*bool booksbyGenre = books.Any(b => b.genre == genre);
            if (booksbyGenre)
            {
                Console.WriteLine($"\n{genre} found:");
            }*/


            /*			for (int i = 0; i < books.Count; i++)
						{
							if (books[i].genre == genre)
							{
								DisplayIndividualBookInformation(books[i]);
								bookCount++;
							}
						}*/

            //use linq to instantiate list based on criteria, then loop through each book found and display info
            booksByGenre = books.Where(b => b.genre == genre).ToList();
			foreach (Book book in booksByGenre)
			{
				DisplayIndividualBookInformation(book);
				bookCount++;
			}
			if (bookCount == 0)
			{
				Console.WriteLine($"{genre} not found.");
			}
			


            Console.WriteLine("before asktocheck");
            if (AskToCheckOut())
            {
                Console.WriteLine("in if");
				Selection = booksByGenre[GetUserInt("please enter the index of the book you'd like")-1];
				if (Selection.status == Book.Status.Checked_Out)
				{
					Console.WriteLine("This book is checked out! please be more careful");

				}
				else if (Selection.status == Book.Status.Hold)
				{
					Console.WriteLine("this book is on hold! please be more careful");
				}
				else if (Selection.status == Book.Status.Available)
				{
					// get date
				    DateTime current = DateTime.Today;
					current.AddDays(14);
					Selection.DueDate = current;
                    Selection.status = Status.Checked_Out;
					string formattedDate = Selection.DueDate.ToString();
					Console.WriteLine($"{Selection.Title} will be due back on {formattedDate}");
				}
			}
		}

        public void DisplayIndividualBookInformation(Book book)
        {
            Console.WriteLine($"Title: {book.Title,10}\tAuthor: {book.Author,10}\tPages: {book.NumberOfPages}\tStatus: {book.status}");
        }

        public static void CheckOutBook(Book book)
        {
            Console.WriteLine($"thanks for being interested in {book.Title}");


        }


		public static bool AskToCheckOut()
		{
			string choice = GetUserInput("would you like to check any of these books out? y/n").ToLower();
            if (choice == "y")
            {
                return true;
            }
            else if (choice == "n")
            {
                Console.WriteLine("we hope you find another book you'd like!");
                return false;
            }
            else
            {
              return AskToCheckOut();
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
        public static int GetUserInt(string msg)
        {
            int input = -1;
            try
            {
                Console.WriteLine(msg);
                input = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("that wasnt't a valid input");
                GetUserInput(msg);

            }
            if (input == -1)
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