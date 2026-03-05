namespace ServerManagement.Models
{
    public class PageResult<T> where T : class
    {
        public PageResult(List<T> values, int counts) 
        { 
            Result = values;
            TotalCount = counts;
        }
        public List<T> Result { get; set; }
        public int TotalCount { get; set; }
    }
}
