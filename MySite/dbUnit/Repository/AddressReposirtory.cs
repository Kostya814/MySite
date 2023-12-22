
using Microsoft.EntityFrameworkCore;

namespace MySite.UnitOfWork.Repository
{
    public class AddressReposirtory : IRepository<Address>
    {
        private PostgresContext context;
        public AddressReposirtory(PostgresContext context) 
        {
            this.context = context;
        }
        public void Create(Address item)
        {
           context.Addresses.Add(item);
        }
        public void Delete(int id)
        {
            Address? address = context.Addresses.Find(id);
            if (address != null)            
                context.Addresses.Remove(address);
        }

        public void Edit(Address item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public Address? Get(int id) => context.Addresses.Find(id);

        public IEnumerable<Address> GetAll()
        {
            return context.Addresses;
        }
    }
}
