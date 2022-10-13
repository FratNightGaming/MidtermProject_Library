using System.ComponentModel;

namespace Midterm_Project
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Library!!!");
            Library library1 = new Library();
            library1.DisplayBooksAllInformation(library1.books);
            
            // always loop to keep asking user what they want to do
            while(true)
            {
                string input = Library.GetUserInput("what would you like to do? (1)list books, (2)search, or (3)checkin");
                if (input == "1" || input == "list" || input == "list books")
                {
					// see list of books - calls display books
					// AskToCheckOut() will come when books are printed then will ask y/n - we want as much in method as possible
				}
				else if (input == "2" || input == "search")
                {
                    input = Library.GetUserInput("would you like to search by (1)title or (2)author");
                    if (input == "1" || input == "title")
                    {
                        // search method for titles - calls display books
                        // AskToCheckOut() will come for searches as well
                    } 
                    else if(input == "2" || input == "author")
                    {
                        // search method for authors
                        // asktocheckout again 
                    }
                    // love to do genres later
                }
                else if (input == "3" || input == "checkin")
                {
                    // checkin method
                }
            }
        }

        public static void DisplayBooksByTitle()
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