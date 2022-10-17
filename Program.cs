using System.ComponentModel;

namespace Midterm_Project
{
    public class Program
    {
        static void Main()//create arrays to contain possible user inputs
            //after display books (in display function), user should be able to press a key to sort by info, after which streamwriter will write that list to text file
        {
            Console.WriteLine("Welcome to the Library!!!");
            Library library1 = new Library();

            //library1.DisplayBooksAllInformation(library1.books);


            // always loop to keep asking user what they want to do
            while (true)
            {
                string input = Library.GetUserInput("What would you like to do? (1)Display Books, (2)Search, or (3)Check-in: ");

                if (input == "1" || input == "list" || input == "list books")
                {
                    Library.DisplayBooksAllInformation(library1.books);
                    // AskToCheckOut() will come when books are printed then will ask y/n - we want as much in method as possible

                    int userInput = -1;
                    while (userInput == -1)
                    {
                        try
                        {
                            Console.WriteLine($"Select the book you would like to check out from the list above. Enter 1-{library1.books.Count}");
                            userInput = int.Parse(Console.ReadLine());
                            if (userInput > 0 && userInput <= library1.books.Count)
                            {
                                Console.WriteLine("test here");
                                Console.WriteLine(Library.DisplayIndividualBookInformation(library1.books[userInput - 1]));
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

                else if (input == "2" || input == "search")
                {
                    input = Library.GetUserInput("would you like to search by (1)title, (2)author, or (3)genre");
                    if (input == "1" || input == "title")
                    {
                        library1.SearchBookByTitle(library1.books);
                        // AskToCheckOut() will come for searches as well
                    }
                    else if (input == "2" || input == "author")
                    {
                        library1.SearchBookByAuthor(library1.books);
                    }
                    // love to do genres later

                    // asktocheckout again 
                    else if (input == "3" || input == "genre")
                    {
                        library1.SearchBookByGenre(library1.books);
                    }
                }

                else if (input == "3" || input == "checkin")
                {
                    // checkin method for later
                }
            }
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