using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Midterm_Project.Book;//Ryan, is this how you access the "Genre" variable?

namespace Midterm_Project
{
    public class Library
    {
        public List<Book> books { get; set; } = new List<Book>(); 
		public List<Book> booksFromFile { get; set; } = new List<Book>(); 
		public List<Book> booksCheckedOut { get; set; } = new List<Book>();
        public List<Book> booksAvailable { get; set; } = new List<Book>();
        public static Book? CurrentBook { get; set; }
        public DateTime current = DateTime.Now;
        public static List<Book>? CurrentBookList { get; set; }


		public Library()//if else check to see if streamwriter file exists
        {
			booksFromFile.Add(new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", 223, 1997, Book.Genre.Fantasy, Book.Status.Available, current));
			booksFromFile.Add(new Book("Harry Potter and the Chamber of Secrets", "J.K. Rowling", 251, 1998, Book.Genre.Fantasy, Book.Status.Checked_Out, current));
			booksFromFile.Add(new Book("Harry Potter and the Prisoner of Azkaban", "J.K. Rowling", 371, 1999, Book.Genre.Fantasy, Book.Status.Available, current));
			booksFromFile.Add(new Book("Harry Potter and the Goblet of Fire", "J.K. Rowling", 636, 2000, Book.Genre.Fantasy, Book.Status.Available, current));
			booksFromFile.Add(new Book("Harry Potter and the Order of the Phoenix", "J.K. Rowling", 766, 2003, Book.Genre.Fantasy, Book.Status.Available, current));
            booksFromFile.Add(new Book("Harry Potter and the Half-Blood Prince", "J.K. Rowling", 607, 2005, Book.Genre.Fantasy, Book.Status.Available, current));
            booksFromFile.Add(new Book("Harry Potter and the Deathly Hallows", "J.K. Rowling", 607, 2007, Book.Genre.Fantasy, Book.Status.Available, current));
            booksFromFile.Add(new Book("The Three-Body Problem", "Liu Cixin", 302, 2008, Book.Genre.Science_Fiction, Book.Status.Available, current));
            booksFromFile.Add(new Book("The Silmarillion", "J.R.R. Tolkien", 365, 1977, Book.Genre.Fantasy, Book.Status.Checked_Out , current));
            booksFromFile.Add(new Book("The Lord of The Rings: The Fellowship of the Ring", "J.R.R. Tolkien", 423, 1954, Book.Genre.Fantasy, Book.Status.Available, current));
            booksFromFile.Add(new Book("The Lord of The Rings: The Two Towers", "J.R.R. Tolkien", 352, 1954, Book.Genre.Fantasy, Book.Status.Checked_Out, current));
            booksFromFile.Add(new Book("The Lord of The Rings: The Return of the King", "J.R.R. Tolkien", 416, 1955, Book.Genre.Fantasy, Book.Status.Available, current));
            booksFromFile.Add(new Book("Simulacra and Simulation", "Jean Baudrillard", 164, 1981, Book.Genre.Nonfiction, Book.Status.Available, current));
            booksFromFile.Add(new Book("Countdown to Zero Day", "Kim Zetter", 406, 2014, Book.Genre.Nonfiction, Book.Status.Available, current));
            booksFromFile.Add(new Book("The Sixth Extinction: An Unnatural History", "Elizabeth Kolbert", 316, 2014, Book.Genre.Nonfiction, Book.Status.Available, current));
            booksFromFile.Add(new Book("Into Thin Air: A personal Account of the Mt. Everest Disaster", "John Krakauer", 416, 1997, Book.Genre.Nonfiction, Book.Status.Available, current));
			booksFromFile.Add(new Book("In the Heart of the Sea: The Tragedy of the Whaleship Essex", "Nathaniel Philbrick", 320, 2000, Book.Genre.History, Book.Status.Available, current));
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
			
            if (books.Any(b => b.Author == author))
			{
				Console.WriteLine($"\n{author} found:");
			}

			// brings all books found into a list and then prints them
			booksByAuthor = books.Where(b => b.Author == author).ToList();
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

			if (books.Any(b => b.Title == title))
			{
				Console.WriteLine($"\n{title} found:");
			}

			// brings all books found into a list and then prints them
			List<Book> booksByTitle = books.Where(b => b.Title == title).ToList();
			
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
                Console.Write($"{bookCount}");

                Console.WriteLine(DisplayIndividualBookInformation(book)); 
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
        public void SortBooksByTitle(List<Book> books)
        {
            List<Book> booksByTitle = books.OrderBy(b => b.Title).ToList();

            foreach (Book book in booksByTitle)
            {
                Console.WriteLine(DisplayIndividualBookInformation(book));
            }
        }

        public void SortBooksByAuthor(List<Book> books)
        {
            List<Book> booksByAuthor = books.OrderBy(b => b.Author).ThenBy(b => b.Title).ToList();

            foreach (Book book in booksByAuthor)
            {
                Console.WriteLine(DisplayIndividualBookInformation(book));
            }
        }

        public void SortBooksByPages(List<Book> books)
        {
            List<Book> booksByPages = books.OrderBy(b => b.genre).ThenBy(b => b.Author).ThenBy(b => b.Title).ToList();

            foreach (Book book in booksByPages)
            {
                Console.WriteLine(DisplayIndividualBookInformation(book));
            }
        }

        public void SortBooksByStatus(List<Book> books)
        {
            List<Book> booksByStatus = books.OrderBy(b => b.status).ThenBy(b => b.Author).ThenBy(b => b.Title).ToList();

            foreach (Book book in booksByStatus)
            {
                Console.WriteLine(DisplayIndividualBookInformation(book));
            }
        }

        public void SortBooksByGenre(List<Book> books)
        {
            List<Book> booksByAuthor = books.OrderBy(b => b.NumberOfPages).ThenBy(b => b.Title).ToList();

            foreach (Book book in booksByAuthor)
            {
                Console.WriteLine(DisplayIndividualBookInformation(book));
            }
        }

        public void SortBooksByYear(List<Book> books)
        {
            List<Book> booksByAuthor = books.OrderBy(b => b.YearOfPublication).ThenBy(b => b.Author).ThenBy(b => b.Title).ToList();

            foreach (Book book in booksByAuthor)
            {
                Console.WriteLine(DisplayIndividualBookInformation(book));
            }
        }
        public static string DisplayIndividualBookInformation(Book book)//do we want to add yearofpublication?
        {
            //will add in column alignment here for better visibility         
            string bookInformation = $"{book.Title, -73} {book.Author, -25} {book.genre, -20} {book.NumberOfPages, -10} {book.status}";
                
            return bookInformation;
            //DisplayIndividualBookInformation(books[i]);

           /* Console.WriteLine($"\nTitle: {book.Title,10}\n" +
                $"\tAuthor: {book.Author,10}\n" +
                $"\tPages: {book.NumberOfPages}\n" +
                $"\tStatus: {book.status}\n");*/
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

        public void CheckOut(List<Book> orderedBookList)
        {
			if (AskToCheckOut())
			{
				CurrentBook = orderedBookList[GetUserInt("Please enter the index of the book you'd like") - 1];

				if (CurrentBook.status == Book.Status.Checked_Out)
				{
					Console.WriteLine("This book is checked out! please be more careful");//display when due date is
				}

				else if (CurrentBook.status == Book.Status.Hold)
				{
					Console.WriteLine("This book is on hold! please be more careful");//display when hold ends
				}

				else if (CurrentBook.status == Book.Status.Available)
				{

					// get date
					DateTime current = DateTime.Today;
					DateTime dueDate = current.AddDays(14);
                    //DateTime current = DateTime.Today.AddDays(14);//testing code here. it is more concise than having two lines 
					books.Where(b => b.Title == CurrentBook.Title).First().DueDate = dueDate;
					books.Where(b => b.Title == CurrentBook.Title).First().status = Status.Checked_Out;
					string formattedDate = CurrentBook.DueDate.ToString("MMMM/d/yyyy");
					Console.WriteLine($"{CurrentBook.Title} will be due back on {formattedDate}");
					Console.WriteLine("Thank You!\n");
				}
			}

            WriteIO(books);

		}
        public void ReturnBook()
        {

			List<Book> checkedOut = new List<Book>();
            Book toReturn = null;
			int index = 0;
			foreach (Book book in books)
			{
				if (book.status == Book.Status.Checked_Out)
				{
					index++;
					checkedOut.Add(book);
					Console.WriteLine(index + " " + Library.DisplayIndividualBookInformation(book));
				}
			}
			if (checkedOut.Count > 0)
			{
				//print list of books with status checked out
				int toParse = Library.GetUserInt("what book are you returning?") - 1;

				// listofbookscheckedout
				toReturn = checkedOut.Where(b => b.Title == checkedOut[toParse].Title).First();
				toReturn.status = Status.Available;
				Console.WriteLine($"{toReturn.Title} successfully returned at {DateTime.Now.ToString("MM/dd/yyyy h:mm tt")}. Thank you!");
			}
			else
			{
				Console.WriteLine("theres no books checked out!");
			}
			WriteIO(books);
		}
        public static string GetUserInput(string message)//implement a throw into catch for input == null
        {
            string input = String.Empty;

            try
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
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

        public void WriteIO(List <Book> sortedBooks)//This should be used in place of display information. DisplayInformationIndividualBooks should be used to feed into this IO function

        //ORRRR I dont ever need to readstream. Just use displayfunction.
        //ORRR just make this a writeIO file and save results after each sort. make sure upon initialization of program, booklist = whats in the write io file
        {
            StreamWriter sw;

			string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
			string filePath = currentDirectory + @"\testlist4.txt";

			sw = new StreamWriter(filePath, false);
			Console.WriteLine("writing to: " + filePath);
			foreach (Book book in sortedBooks)
			{
				sw.WriteLine($"{book.Title},{book.Author},{book.NumberOfPages},{book.YearOfPublication},{book.genre},{book.status},{book.DueDate}");
			}
			sw.Close();
        }

        public void ReadIO()
        {
			string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
			string filePath = currentDirectory + @"\testlist4.txt";
            bool fileExist = false;
            try
            {
                StreamReader srt = new StreamReader(filePath);
                fileExist = true;
                srt.Close();

			} catch (FileNotFoundException)
            {
                WriteIO(booksFromFile);
            }
			double entries = 0;
			using (StreamReader sr = new StreamReader(filePath))
			{
				while (sr.ReadLine() != null)
				{
					entries++;
				}
				Console.Write("we have " + entries+" books\n");
				for (int i = 0; i < entries; i++)
				{
                    string line = File.ReadLines(filePath).Skip(i - 1).Take(1).First();
				    string[] lineValues = line.Split(",");
                    books.Add(new Book(lineValues[0], lineValues[1], //title / author
                    int.Parse(lineValues[2]), int.Parse(lineValues[3]), // parsing year / page from int
					(Genre) Enum.Parse(typeof(Genre), lineValues[4]), // parse enum genre
                    (Status) Enum.Parse(typeof(Status), lineValues[5]), // parse status enum
                    DateTime.Parse(lineValues[6]))); // parse datetime
					}
                sr.Close();
			}
		}

        /*public void Burn()
        {
			string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
			string filePath = currentDirectory + @"\testlist4.txt";
			StreamReader sr = new StreamReader(filePath);
			File.Delete(filePath);
			sr.Close();
            Console.WriteLine("look at what you've done.");
		}*/
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