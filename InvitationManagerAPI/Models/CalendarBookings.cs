namespace InvitationManagerAPI.Models
{
    public class CalendarBookings
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set;}

    }
}
