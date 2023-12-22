using MySite.UnitOfWork.Repository;

namespace MySite.UnitOfWork
{
    public class UnitOfWork
    {
        private PostgresContext context = new PostgresContext();
        private CityRepository cityRepository;
        private AddressReposirtory addressReposirtory;
        public CityRepository Cities
        {
            get 
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(context);
                return cityRepository;
            }
        }
        public AddressReposirtory Addresses
        {
            get
            { 
                if(addressReposirtory == null)
                    addressReposirtory = new AddressReposirtory(context);
                return addressReposirtory;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
