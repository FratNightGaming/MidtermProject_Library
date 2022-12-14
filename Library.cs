using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Midterm_Project.Book;

namespace Midterm_Project
{
    public class Library
    {
        public List<Book> books { get; set; } = new List<Book>(); 
		public List<Book> booksFromFile { get; set; } = new List<Book>(); 
        // this is used to remake the database
		public List<Book> booksCheckedOut { get; set; } = new List<Book>();
        public List<Book> booksAvailable { get; set; } = new List<Book>();
        public static Book? CurrentBook { get; set; }

        public DateTime current = DateTime.Now;
        public static List<Book>? CurrentBookList { get; set; }

	public Library()//if else check to see if streamwriter file exists
        {
	    booksFromFile.Add(new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", 223, 1997, Book.Genre.fantasy, Book.Status.available, current));
	    booksFromFile.Add(new Book("Harry Potter and the Chamber of Secrets", "J.K. Rowling", 251, 1998, Book.Genre.fantasy, Book.Status.checked_out, current));
	    booksFromFile.Add(new Book("Harry Potter and the Prisoner of Azkaban", "J.K. Rowling", 371, 1999, Book.Genre.fantasy, Book.Status.available, current));
	    booksFromFile.Add(new Book("Harry Potter and the Goblet of Fire", "J.K. Rowling", 636, 2000, Book.Genre.fantasy, Book.Status.available, current));
	    booksFromFile.Add(new Book("Harry Potter and the Order of the Phoenix", "J.K. Rowling", 766, 2003, Book.Genre.fantasy, Book.Status.available, current));
	    booksFromFile.Add(new Book("Harry Potter and the Half-Blood Prince", "J.K. Rowling", 607, 2005, Book.Genre.fantasy, Book.Status.available, current));
	    booksFromFile.Add(new Book("Harry Potter and the Deathly Hallows", "J.K. Rowling", 607, 2007, Book.Genre.fantasy, Book.Status.available, current));
	    booksFromFile.Add(new Book("The Three-Body Problem", "Liu Cixin", 302, 2008, Book.Genre.science_fiction, Book.Status.available, current));
	    booksFromFile.Add(new Book("The Silmarillion", "J.R.R. Tolkien", 365, 1977, Book.Genre.fantasy, Book.Status.checked_out , current));
	    booksFromFile.Add(new Book("The Lord of The Rings: The Fellowship of the Ring", "J.R.R. Tolkien", 423, 1954, Book.Genre.fantasy, Book.Status.available, current));
	    booksFromFile.Add(new Book("The Lord of The Rings: The Two Towers", "J.R.R. Tolkien", 352, 1954, Book.Genre.fantasy, Book.Status.checked_out, current));
	    booksFromFile.Add(new Book("The Lord of The Rings: The Return of the King", "J.R.R. Tolkien", 416, 1955, Book.Genre.fantasy, Book.Status.available, current));
	    booksFromFile.Add(new Book("Simulacra and Simulation", "Jean Baudrillard", 164, 1981, Book.Genre.nonfiction, Book.Status.available, current));
	    booksFromFile.Add(new Book("Countdown to Zero Day", "Kim Zetter", 406, 2014, Book.Genre.nonfiction, Book.Status.available, current));
	    booksFromFile.Add(new Book("The Sixth Extinction: An Unnatural History", "Elizabeth Kolbert", 316, 2014, Book.Genre.nonfiction, Book.Status.available, current));
	    booksFromFile.Add(new Book("Into Thin Air: A personal Account of the Mt. Everest Disaster", "John Krakauer", 416, 1997, Book.Genre.nonfiction, Book.Status.available, current));
	    booksFromFile.Add(new Book("In the Heart of the Sea: The Tragedy of the Whaleship Essex", "Nathaniel Philbrick", 320, 2000, Book.Genre.history, Book.Status.available, current));
	    booksFromFile.Add(new Book("Red Dragon", "Thomas Harris", 348, 1981, Book.Genre.horror, Book.Status.available, current));
	    booksFromFile.Add(new Book("Calvin and Hobbs", "Bill Watterson", 3160, 1985, Book.Genre.graphic_novel, Book.Status.checked_out, current));
	    booksFromFile.Add(new Book("Peanuts", "Charles M. Schulz", 17897, 1950, Book.Genre.graphic_novel, Book.Status.available, current));
	    booksFromFile.Add(new Book("The Martian", "Andy Weir", 369, 2011, Book.Genre.science_fiction, Book.Status.available, current));
	    booksFromFile.Add(new Book("The Stormlight Archive - Book 1: The Way of Kings", "Brandon Sanderson", 1007, 2010, Book.Genre.fantasy, Book.Status.checked_out, current));
	    booksFromFile.Add(new Book("Salt: A World History", "Mark Kurlansky", 496, 2002, Book.Genre.history, Book.Status.checked_out, current));
	    booksFromFile.Add(new Book("Nonviolence: The History of a Dangerous Idea", "Mark Kurlansky", 244, 2006, Book.Genre.history, Book.Status.available, current));
	    booksFromFile.Add(new Book("SPQR: A History of Ancient Rome", "Mary Beard", 606, 2015, Book.Genre.history, Book.Status.available, current));
	    booksFromFile.Add(new Book("Romeo and Juliet", "Willian Shakespeare", 148, 1597, Book.Genre.romance, Book.Status.available, current));
	    booksFromFile.Add(new Book("Sherlock Holmes: A Study in Scarlet", "Sir Arthur Conan Doyle", 230, 1887, Book.Genre.mystery, Book.Status.checked_out, current));   
	    booksFromFile.Add(new Book("The Story of the Streets", "Mike Skinner", 304, 2012, Book.Genre.biography, Book.Status.available, current));
	    booksFromFile.Add(new Book("The King in Yellow", "Robert W. Chambers", 316, 1895, Book.Genre.horror, Book.Status.available, current));
	    booksFromFile.Add(new Book("Dune", "Frank Herbert", 412, 1965, Book.Genre.science_fiction, Book.Status.checked_out, current));
        }

        public static void DisplayBooksAllInformation(List<Book> books)
        {
            Console.WriteLine("\nBooks On Display\n");

            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0} \n", 
                          "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            
            for (int i = 0; i < books.Count; i++)
            {
                //spacing for each of the below values
                Console.WriteLine("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0}", 
                    i + 1, //number tracker for # of books listed
                    books[i].Title,
                    books[i].Author,
                    books[i].genre,
                    books[i].NumberOfPages,
                    books[i].YearOfPublication,
                    books[i].status); 
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
            if (books.Any(b => b.Author.ToLower().Contains(author)))
            //if any books have an author name that matches the user input.
			{
				Console.WriteLine($"{author} found:\n");
			}
			// brings all books found into a list and then prints them
			booksByAuthor = books.Where(b => b.Author.ToLower().Contains(author)).ToList();

            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0}  \n",
                           "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            int index = 1;
            foreach (Book book in booksByAuthor)
			{
                Console.WriteLine(index + DisplayIndividualBookInformation(book));
                index++;
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
            Console.WriteLine("Which book are you looking for?");
			string title = String.Empty;
            bool noTitle = true;
			while (noTitle)
            {
                try
                {
                    title = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    title = Console.ReadLine();
                }

                if (title == String.Empty)
                {
                    Console.WriteLine("No input was detected. Please try again.");
                    title = Console.ReadLine();
                }
                else
                {
					noTitle = false;
				}
				
			}
			// checks to see if there are going to be results
			int bookCount = 0;

			if (books.Any(b => b.Title.ToLower().Contains(title)))
			{
				Console.WriteLine($"{title} found:\n");
			}

			// brings all books found into a list and then prints them
			List<Book> booksByTitle = books.Where(b => b.Title.ToLower().Contains(title)).ToList();

            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0}  \n",
                           "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
			int index = 1;
			foreach (Book book in booksByTitle)
			{
                Console.WriteLine(index + DisplayIndividualBookInformation(book));
                index++;
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
            genre = getValidGenre();
            
			// checks to see if there are going to be results
			int bookCount = 0;
			List<Book> booksByGenre = new List<Book>();
			
            if (books.Any(b => b.genre.ToString().ToLower() == genre.ToString()))
            {
              Console.WriteLine($"{genre} found:\n");
            }

            // brings all books found into a list and then prints them
            booksByGenre = books.Where(b => b.genre.ToString().ToLower() == genre.ToString()).ToList();

            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0}  \n",
                           "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (Book book in booksByGenre)
			{
                bookCount++;
                Console.Write(bookCount);

                Console.WriteLine(DisplayIndividualBookInformation(book));
            }
            Console.WriteLine();

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
        public Genre getValidGenre()
        {
			Genre genre = Book.Genre.biography;
			bool getGenre = true;
			int runCount = 0;
			while (getGenre)
			{
				try
				{
					string choice = GetUserInput("Which genre would you like? or type genres for a list :)");
					if (choice == "genres" || choice == "genre" || choice == "g" || choice == "list")
					{
                        Console.WriteLine();
						foreach (Genre type in Enum.GetValues(typeof(Genre)))
						{
							int genreCount = Enum.GetNames(typeof(Genre)).Length - 1;
							runCount++;
							if (runCount > genreCount)
							{
								Console.Write($"{type}. \n");
								Console.WriteLine();
							}
							else
							{
								Console.Write($"{type}, ");
							}
							continue;
						}
					}
					else
					{
						genre = (Genre)Enum.Parse(typeof(Genre), choice);
						getGenre = false;
					}
				}
				catch (ArgumentException)
				{
					Console.WriteLine("thats not a valid genre! try again");
				}
			}
            return genre;
		}
        

        public List<Book> SortBooksByTitle(List<Book> books)
        {
            List<Book> booksByTitle = books.OrderBy(b => b.Title).ToList();
            int index = 1;
            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0}  \n",
                          "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
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
            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0}  \n",
                           "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
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
            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0}  \n",
                           "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
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
            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0}  \n",
                           "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
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
            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0}  \n",
                           "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
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
            Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0}  \n",
                           "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (Book book in booksByYear)
            {
                Console.WriteLine(index + DisplayIndividualBookInformation(book));
                index++;
            }
            return booksByYear;
        }

        public static string DisplayIndividualBookInformation(Book book)
        {
            // null is space to insert index if needed
            string bookInformation = ($"{null,-5} {book.Title,-73} {book.Author,-25} {book.genre,-20} {book.NumberOfPages,-10} {book.YearOfPublication, -18} {book.status, 0}");
            return bookInformation;
        }

		public static bool AskToCheckOut()
		{
			string choice = GetUserInput("Would you like to check out any of these books out? Y/N").ToUpper().Trim();
			// breaking some logic out to this method from the next one, CheckOut
			if (choice == "Y" || choice == "YES")
            {
                return true;
            }

            else if (choice == "N" || choice == "NO")
            {
                Console.WriteLine("We hope you find another book you'd like!\n");

                return false;
            }

            else
            {
                Console.WriteLine("Input not recognized. Please try again.\n");
                return AskToCheckOut();
            }
        }

        public void CheckOut(List<Book> orderedBookList)
        {
			if (AskToCheckOut())
			{
        // while loop just makes sure your selection is valid within the list provided
				while (true)
				{
					try
					{
                        int userInput = GetUserInt("Please enter the index of the book you'd like [1-" + orderedBookList.Count + "]:");
						CurrentBook = orderedBookList[userInput - 1];
						if (!(userInput > 0 && userInput <= orderedBookList.Count))
						{
							Console.WriteLine($"Your input was not a valid number, please try again. Enter a number between 1-{orderedBookList.Count}.\n");
							continue;
						}
                        else
                        {
							break;
						}
					}
					catch (Exception)
					{
						Console.WriteLine($"That wasn't an index in our system! Please enter a number between 1-{orderedBookList.Count}.\n");
						continue;
					}
				}

				if (CurrentBook.status == Book.Status.checked_out)
				{
					Console.WriteLine("This book is checked out! Please wait until it is returned.\n");
				}
				else if (CurrentBook.status == Book.Status.hold)
				{
					Console.WriteLine("This book is on hold! Thank you for being patient until it becomes available.\n");
				}
				else if (CurrentBook.status == Book.Status.available)
				{

					// get date and modifies it for checkin due date
					DateTime current = DateTime.Today;
					DateTime dueDate = current.AddDays(14);
          //DateTime current = DateTime.Today.AddDays(14);    //testing code here. it is more concise than having two lines 
          // sets the book's values
					books.Where(b => b.Title == CurrentBook.Title).First().DueDate = dueDate;
					books.Where(b => b.Title == CurrentBook.Title).First().status = Status.checked_out;
					string formattedDate = CurrentBook.DueDate.ToString("MMMM/d/yyyy");
					Console.WriteLine($"{CurrentBook.Title} will be due back on {formattedDate}");
					Console.WriteLine("Thank You!\n");
				}
			}
            // since we've modified our database, write our change to the file
            WriteIO(books);
		}

        public void ReturnBook()
        {
			List<Book> checkedOut = new List<Book>();
            Book toReturn = null;
			int index = 0;
			//print list of books with status checked out
			Console.Write("{0,-5} {1,-73} {2,-25} {3,-20} {4,-10} {5,-18} {6,0}  \n",
						   "Index", "Title", "Author", "Genre", "Pages", "Year Published", "Status");
			Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");

			foreach (Book book in books)
			{
				if (book.status == Book.Status.checked_out)
				{
					index++;
					checkedOut.Add(book);
					Console.WriteLine(index + " " + Library.DisplayIndividualBookInformation(book));
				}
			}
            // if theres books to check in we ask which one
			if (checkedOut.Count > 0)
			{
				//print list of books with status checked out
				int toParse = Library.GetUserInt("What book are you returning?") - 1;
                while (toParse+1 > index || toParse < 0)
                {
                    Console.WriteLine("That isn't an index!");
					toParse = Library.GetUserInt("What book are you returning?") - 1;
                    if (!(toParse + 1 > index || toParse < 0))
                    {
                        break;
                    }
				}
        // setting book's values
				toReturn = checkedOut.Where(b => b.Title == checkedOut[toParse].Title).First();
				toReturn.status = Status.available;
				Console.WriteLine($"{toReturn.Title} successfully returned at {DateTime.Now.ToString("MM/dd/yyyy h:mm tt")}. Thank you!");
			}
			else
			{
				Console.WriteLine("There are no books checked out!");
			}
			// since we've modified our database, write our change to the file
			WriteIO(books);
		}
        public static string GetUserInput(string message)
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

        public void WriteIO(List <Book> sortedBooks)
        {
            StreamWriter sw;

			string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
			string filePath = currentDirectory + @"\testlist4.txt";
            // loops through all our books in memory and writes them out as values with commas, 
			sw = new StreamWriter(filePath, false);
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
            // checks if you have a local database, if not it will make one by putting our internal backup into its memory and writing it
            bool fileExist = false;
            try
            {
                StreamReader srt = new StreamReader(filePath);
                fileExist = true;
                srt.Close();

			} catch (FileNotFoundException)
            {
                WriteIO(booksFromFile);
				Console.WriteLine("\nwriting to: " + filePath);
                // lets user know its placing the file on their pc
			}
      // use streamreader to count how many lines (books) in our file
			double entries = 0;
			using (StreamReader sr = new StreamReader(filePath))
			{
				while (sr.ReadLine() != null)
				{
					entries++;
				}
                Console.Write("we have " + entries + " books\n");
                // this write shows when starting the program your book count
                // then this loop goes for each line we counted earlier and parses the data to put into memory
				for (int i = 0; i < entries; i++)
				{
                    string line = File.ReadLines(filePath).Skip(i).Take(1).First(); //reading each line representing a book and its info, taking the first only to prevent mixing different book info.
				    string[] lineValues = line.Split(",");
                    books.Add(new Book(lineValues[0], lineValues[1], //title + author
                    int.Parse(lineValues[2]), int.Parse(lineValues[3]), // parsing year + page from int
					(Genre) Enum.Parse(typeof(Genre), lineValues[4]), // parse enum genre
                    (Status) Enum.Parse(typeof(Status), lineValues[5]), // parse status enum
                    DateTime.Parse(lineValues[6]))); // parse datetime
				}
                sr.Close();
			}
		}
        public void AddBook()
        {
            Console.WriteLine("thanks for looking into donating:");
            // gets data
            Console.Write("Title: ");
            string title = Console.ReadLine();
			Console.Write("Author: ");
			string author = Console.ReadLine();
            Console.Write("Year: ");
			int year = int.Parse(Console.ReadLine());
			Console.Write("Pages: ");
			int pages = int.Parse(Console.ReadLine());
            Genre genre = getValidGenre();
			//throws it into memory and writes it
			books.Add(new Book(title, author, pages, year, genre, Book.Status.available, current));
            WriteIO(books);
        }
        public void Burn()
        {
			string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;  //finding where the program directery is located on each individual machine.
            string filePath = currentDirectory + @"\testlist4.txt"; //finding where the txt file is located on each individual machine.
            StreamReader sr = new StreamReader(filePath);
            if(File.Exists(filePath)) // checking if txt file exists first
            {
                sr.Close(); // closes out sr, so the txt file can be deleted
                File.Delete(filePath);
                books.Clear(); //clearing all entries to the book list
            }  
            Console.WriteLine("Look at what you've done.\n"); //Good job. No futuristic steam engines for you.
		}

        public bool Repeat()
        {
            Console.Write("Do you want to watch exit the library? Y/N: ");
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.WriteLine("Goodbye!");
                    Console.WriteLine();
                    return true;
                }
                else if (input == "n")
                {
                    Console.WriteLine("Welcome back!");
                    Console.WriteLine();
                    return false;
                }
                else
                {
                    Console.WriteLine("Please only enter Y or N:");
                }
            }
        }

    }
}