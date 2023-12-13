namespace MySite
{
    public class City
    {
        public int Id { get; set; } 
        public string PrefixLocality { get; set; }
        public string NameLocality { get; set; }

        public List<Address> Addresses { get; set;} = new List<Address>();

        public string GetInfo =>
            PrefixLocality +" "+ NameLocality;
    }
}
