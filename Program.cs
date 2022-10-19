using System.ComponentModel;

namespace Midterm_Project
{
    public class Program
    {
        static void Main()//create arrays to contain possible user inputs
        {
            Console.Write("Welcome to the Library!!! ");
            Library library1 = new Library();
            library1.ReadIO();
            // always loop to keep asking user what they want to do
            bool start = true;
            while (start == true)
            {
                string input = Library.GetUserInput("What would you like to do? (1)Display Books, (2)Sort List, (3)Search, (4)Check-in, (5)Donate a book, or (6) Exit: ");
                if (input == "1" || input == "display" || input == "display book" || input == "display books" || input == "d" || input == "db")
                {
                    Library.DisplayBooksAllInformation(library1.books);
                    library1.CheckOut(library1.books);
                }
                else if (input == "2" || input == "sort" || input == "list" || input == "sort list" || input == "sl")
                {
                    while (true)
                    {
			                string userInput2 = Library.GetUserInput("What would you like to sort by? (1)Title, (2)Author, (3)Page Length, (4)Status, (5)Genre, or (6)Year: ");
                            if (userInput2 == "1" || userInput2 == "title" || userInput2 == "t")
                            {
                                List<Book> booksByTitle = library1.SortBooksByTitle(library1.books);
                                Console.WriteLine();
                                library1.CheckOut(booksByTitle);
                                break;
                            }
                            else if (userInput2 == "2" || userInput2 == "author" || userInput2 == "a")
                            {
                                List<Book> booksByAuthor = library1.SortBooksByAuthor(library1.books);
                                Console.WriteLine();
                                library1.CheckOut(booksByAuthor);
                                break;
                            }
                            else if (userInput2 == "3" || userInput2 == "page" || userInput2 == "length" 
                                  || userInput2 == "page length" || userInput2 == "pagelength" || userInput2 == "p" || userInput2 == "pl")
                            {
                                List<Book> booksByPageLength = library1.SortBooksByPages(library1.books);
                                Console.WriteLine();
                                library1.CheckOut(booksByPageLength);
                                break;
                            }
                            else if (userInput2 == "4" || userInput2 == "status" || userInput2 == "s")
                            {
                                List<Book> booksByStatus = library1.SortBooksByStatus(library1.books);
                                Console.WriteLine();
                                library1.CheckOut(booksByStatus);
                                break;
                            }
                            else if (userInput2 == "5" || userInput2 == "genre" || userInput2 == "g")
                            {
                                List<Book> booksByGenre = library1.SortBooksByGenre(library1.books);
                                Console.WriteLine();
                                library1.CheckOut(booksByGenre);
                                break;
                            }
                            else if (userInput2 == "6" || userInput2 == "year" || userInput2 == "y")
                            {
                                List<Book> booksByYear = library1.SortBooksByYear(library1.books);
                                Console.WriteLine();
                                library1.CheckOut(booksByYear);
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Your input was not a valid number, please try again.");
                                Console.WriteLine();
                                break;
                            }
                        }
                    }

                else if (input == "3" || input == "search" || input == "search book" || input == "search books" || input == "s")
                {
                    while (true)
                    {

						input = Library.GetUserInput("What would you like to search by: (1)Title, (2)Author, or (3)Genre");
						if (input == "1" || input == "title")
                        {
                            library1.SearchBookByTitle(library1.books);
                            Console.WriteLine();
                            break;
                        }
                        else if (input == "2" || input == "author")
                        {
                            library1.SearchBookByAuthor(library1.books);
                            Console.WriteLine();
							break;
						}
                        else if (input == "3" || input == "genre")
                        {
                            library1.SearchBookByGenre(library1.books);
                            Console.WriteLine();
							break;
						}
						else
						{
							continue;
						}
					}
                }
                else if (input == "4" || input == "c" || input == "checkin" || input == "check-in" || input == "checkin books" || input == "search books")
                {
                    library1.ReturnBook();
				}
				else if (input == "burn")
				{
                    library1.Burn();
				}
                else if (input == "5" || input == "donate" || input == "add")
                {
                    library1.AddBook();
				}
				else if (input == "6" || input == "exit" || input == "e" || input == "esc")
				{
					if (start == library1.Repeat())
					{
						break;
					}
					else
					{
						continue;
					}
				}
				else
                {
                    Console.WriteLine($"Your input was not a valid number, please try again.");
                    Console.WriteLine();
                    continue;
                }
            }
        }

    }
}
