namespace Socialdashboard.Models
{
    public class ResponseVM
    {
        public string Message { get; set; }
        public object Data { get; set; }

        public int StatusCode { get; set; }
    }
}
