using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        public static Book Selection { get; set; }


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

        public static void DisplayBooksAllInformation(List<Book> books)
        {
            Console.WriteLine("\nBooks On Display\n");

            Console.Write("{0,-10} {1,-73} {2,-25} {3,-20} {4,-10} {5,-1} \n" , 
                          "Index", "Title", "Author", "Genre", "Pages", "Status");

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine("{0,-10} {1,-73} {2,-25} {3,-20} {4,-10} {5,-1}",
                    i+1, 
                    books[i].Title, 
                    books[i].Author, 
                    books[i].genre,
                    books[i].NumberOfPages,
                    books[i].status);

                //DisplayIndividualBookInformation(books[i]);
            }
            Console.WriteLine();


        }

        public void SearchBookByAuthor(List<Book> books)
        {
            //gets what the user wants to find
			string author = GetUserInput("which author are you looking for?");

			// checks to see if there are going to be results
			int bookCount = 0;
			List<Book> booksByAuthor = new List<Book>();
			if (books.Any(b => b.Author == author))
			{
				Console.WriteLine($"\n{author} found:");
			}

			// brings all books found into a list and then prints them
			booksByAuthor = books.Where(b => b.Author == author).ToList();
			foreach (Book book in booksByAuthor)
			{
				DisplayIndividualBookInformation(book);
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
			string title = GetUserInput("which title are you looking for?");

			// checks to see if there are going to be results
			int bookCount = 0;
			List<Book> booksByTitle = new List<Book>();
			if (books.Any(b => b.Title == title))
			{
				Console.WriteLine($"\n{title} found:");
			}

			// brings all books found into a list and then prints them
			booksByTitle = books.Where(b => b.Title == title).ToList();
			foreach (Book book in booksByTitle)
			{
				DisplayIndividualBookInformation(book);
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
            Genre genre = Book.Genre.Biography;
            bool getGenre = true;
            while(getGenre) {
                try
                {
                    genre = (Genre)Enum.Parse(typeof(Genre), GetUserInput("which genre would you like? or type genres for a list :)"));
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

            Console.Write("{0,-73} {1,-25} {2,-20} {3,-10} {4,-1} \n",
                           "Title", "Author", "Genre", "Pages", "Status");

            foreach (Book book in booksByGenre)
			{
                bookCount++;
                Console.Write($"{bookCount})");

                

                DisplayIndividualBookInformation(book);
            }
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

        public void DisplayIndividualBookInformation(Book book)
        {
            //will add in column alignment here for better visibility         

                Console.WriteLine("{0,-73} {1,-25} {2,-20} {3,-10} {4,-1}",
                   
                    book.Title,
                    book.Author,
                    book.genre,
                    book.NumberOfPages,
                    book.status);

                //DisplayIndividualBookInformation(books[i]);

           /* Console.WriteLine($"\nTitle: {book.Title,10}\n" +
                $"\tAuthor: {book.Author,10}\n" +
                $"\tPages: {book.NumberOfPages}\n" +
                $"\tStatus: {book.status}\n");*/
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
            Console.WriteLine("out of y/n if");
            return true;
            }

        }
        public static void CheckOut(List<Book> currentList)
        {
			if (AskToCheckOut())
			{
				Selection = currentList[GetUserInt("please enter the index of the book you'd like") - 1];
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
					current = current.AddDays(14);
					Selection.DueDate = current;
					Selection.status = Status.Checked_Out;
					string formattedDate = Selection.DueDate.ToString("MMMM/d/yyyy");
					Console.WriteLine($"{Selection.Title} will be due back on {formattedDate}");
					Console.WriteLine("Thank You!\n");
				}
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