
using Microsoft.EntityFrameworkCore;

namespace MySite.UnitOfWork.Repository
{
    public class CityRepository:IRepository<MySite.City>
    {
        private PostgresContext context;
        public CityRepository(PostgresContext context) {
            this.context = context;
        }

        public void Create(MySite.City item)
        {
            context.Cities.Add(item);
        }

        public void Delete(int id)
        {
            MySite.City? book = context.Cities.Find(id);
            if (book != null)
                context.Cities.Remove(book);
        }

        public void Edit(MySite.City item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public MySite.City? Get(int id)
        {
            return context.Cities.Find(id);
        }

        public IEnumerable<MySite.City> GetAll()
        {
            return context.Cities;
        }
    }
}
