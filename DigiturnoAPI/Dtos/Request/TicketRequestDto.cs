namespace DigiturnoAPI.Models
{
    public class TicketRequestDto
    {
        public string Name { get; set; }

        public int Document { get; set; }

        public bool Handicapped { get; set; }

        public string TypeService { get; set;}
    }
}