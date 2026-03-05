namespace ServerManagement.Models
{
    public class ServerDto
    {
        public List<Server> Items { get; set; }
        public int TotalCount { get; set; }
        public ServerDto(List<Server> items, int totalCount)
        {
            this.Items = items;
            this.TotalCount = totalCount;
        }
    }
}
