namespace BakersRentals.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int Bedrooms { get; set; }
        public decimal Bathrooms { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RentalNotes { get; set; }
        public Rental()
        {
            
        }
    }
}
