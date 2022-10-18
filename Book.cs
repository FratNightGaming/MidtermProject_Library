using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Project
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int NumberOfPages { get; set; }
        public int YearOfPublication { get; set; }
        public Genre genre { get; set; }
        public DateTime DueDate { get; set; }
        public Status status { get; set; }

        public enum Status
        {
            available,
            checked_out,
            hold
        }
        public enum Genre
        {
            fantasy,
            mystery,
            horror,
            romance,
            biography,
            history,
            science_fiction,
            nonfiction,
            graphic_novel
        }

        public Book(string title, string author, int pages, int year, Genre genre, Status status, DateTime DueDate)
        {
            this.Title = title;
            this.Author = author;
            this.NumberOfPages = pages;
            this.YearOfPublication = year;
            this.genre = genre;
            this.status = status;
            this.DueDate = DueDate;
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