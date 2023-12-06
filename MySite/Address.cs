namespace MySite
{
    public class Address
    {
        public int Id { get; set; } 
        public string PrefixLocality { get; set; }
        public string NameLocality { get; set; }
        public string PrefixStreet { get; set; }
        public string NameStreet { get; set; }
        public int NumberHouse { get; set; }
        public int NumberCase { get; set; }
        public int NumberApartments { get; set; }
        public int NumberRoom { get; set; }
        public string Description { get; set; }
        public string LeterHome { get; set; }
        
    }
}
