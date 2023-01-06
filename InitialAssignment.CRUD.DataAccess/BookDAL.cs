using InitialAssignment.CRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace InitialAssignment.CRUD.DataAccess
{
    public class BookDAL
    {
        public static async Task<int> CreateAsync(Book pBook)
        {
            int result = 0;
            using (var dbContext = new DBContext())
            {
                dbContext.Add(pBook);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EditAsync(Book pBook)
        {
            int result = 0;
            using (var dbContext = new DBContext())
            {
                var book = await dbContext.Book.FirstOrDefaultAsync(b => b.Id == pBook.Id);
                book.Author = pBook.Author;
                book.Classification = pBook.Classification;
                book.Edition = pBook.Edition;
                book.Editorial = pBook.Editorial;
                book.Title = pBook.Title;
                book.Price = pBook.Price;
                book.PublicationDate = pBook.PublicationDate;
                dbContext.Update(book);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> DeleteAsync(Book pBook)
        {
            int result = 0;
            using (var dbContext = new DBContext())
            {
                var book = await dbContext.Book.FirstOrDefaultAsync(b => b.Id == pBook.Id);
                dbContext.Remove(book);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Book> GetByIdAsync(Book pBook)
        {
            var books = new Book();
            using (var dbContext = new DBContext())
            {
                books = await dbContext.Book.FirstOrDefaultAsync(b => b.Id == pBook.Id);
            }
            return books;
        }

        public static async Task<List<Book>>GetAllAsync()
        {
            var books = new List<Book>();
            using (var dbContext = new DBContext())
            {
                books = await dbContext.Book.ToListAsync();
            }
            return books;
        }

        internal static IQueryable<Book>QuerySelect(IQueryable<Book> pQuery,Book pBook)
        {
            if (pBook.Id>0)
            {
                pQuery = pQuery.Where(b => b.Id == pBook.Id);
            }
            if (!string.IsNullOrWhiteSpace(pBook.Author))
            {
                pQuery = pQuery.Where(b => b.Author.Contains(pBook.Author));
            }
            if (!string.IsNullOrWhiteSpace(pBook.Classification))
            {
                pQuery = pQuery.Where(b => b.Classification.Contains(pBook.Classification));
            }
            if (pBook.Edition > 0)
            {
                pQuery = pQuery.Where(b => b.Edition == pBook.Edition);
            }
            if (!string.IsNullOrWhiteSpace(pBook.Editorial))
            {
                pQuery = pQuery.Where(b => b.Editorial.Contains(pBook.Editorial));
            }
            if (!string.IsNullOrWhiteSpace(pBook.Title))
            {
                pQuery = pQuery.Where(b => b.Title.Contains(pBook.Title));
            }
            if (pBook.Price > 0)
            {
                pQuery = pQuery.Where(b => b.Price == pBook.Price);
            }
            if (pBook.PublicationDate.Year > 1000)
            {
                DateTime dateInitial = new DateTime(pBook.PublicationDate.Year, pBook.PublicationDate.Month, pBook.PublicationDate.Day, 0, 0, 0);
                DateTime finalDate = dateInitial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(b => b.PublicationDate >= dateInitial && b.PublicationDate <= finalDate);
            }
            pQuery = pQuery.OrderByDescending(b => b.Id).AsQueryable();
            if (pBook.Top_Aux>0)
            {
                pQuery = pQuery.Take(pBook.Top_Aux).AsQueryable();    
            }
            return pQuery;
        }

        public static async Task<List<Book>> FindAsync(Book pBook)
        {
            var books = new List<Book>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.Book.AsQueryable();
                select = QuerySelect(select, pBook);
                books = await select.ToListAsync();
            }
            return books;
        }
    }
}
