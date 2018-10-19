namespace RentAWorld.Models.DTOs
{
    public class RentalDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal AskingPrice { get; set; }
        public bool Available { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        
        /* Not from entity */
        public string AuthorStamp { get; set; }

    }
}