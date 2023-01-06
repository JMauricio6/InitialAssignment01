using InitialAssignment.CRUD.DataAccess;
using InitialAssignment.CRUD.Entities;

namespace InitialAssignment.CRUD.BusinecLogic
{
    public class BookBL
    {
        public async Task<int> CreateAsync(Book pBook)
        {
            return await BookDAL.CreateAsync(pBook);
        }
        public async Task<int> EditAsync(Book pBook)
        {
            return await BookDAL.EditAsync(pBook);
        }
        public async Task<int> DeleteAsync(Book pBook)
        {
            return await BookDAL.DeleteAsync(pBook);
        }
        public async Task<Book> GetByIdAsync(Book pBook)
        {
            return await BookDAL.GetByIdAsync(pBook);
        }
        public async Task<List<Book>> GetAllAsync()
        {
            return await BookDAL.GetAllAsync();
        }
        public async Task<List<Book>> FindAsync(Book pBook)
        {
            return await BookDAL.FindAsync(pBook);
        }
    }
}
