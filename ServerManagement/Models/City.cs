namespace ServerManagement.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Server> Servers { get; set; }
    }
}
