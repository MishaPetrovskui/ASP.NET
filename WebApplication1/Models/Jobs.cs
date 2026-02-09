namespace WebApplication1.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string middle_name { get; set; } = string.Empty;
        public string brigade { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public DateTime birthday { get; set; }
        public int height { get; set; } = 0;
        public string position { get; set; } = string.Empty;
        public string department { get; set; } = string.Empty;
        public DateTime hired { get; set; }
        public decimal salary { get; set; }
        public int children { get; set; } = 0;
    }
}