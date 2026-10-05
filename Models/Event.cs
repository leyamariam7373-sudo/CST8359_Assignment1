namespace CST8359_Assignment1.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string Location { get; set; } = string.Empty;

        public List<Attendee> Attendees { get; set; } = new List<Attendee>();
    }
}