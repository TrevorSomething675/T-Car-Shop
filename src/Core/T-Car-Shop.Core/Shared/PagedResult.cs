namespace T_Car_Shop.Core.Shared
{
    public class PagedResult<T> : Result<T>
    {
        public IEnumerable<T>? Items { get; set; } 
        public int Count { get; set; }
        public int PageCount { get; set; }
    }
}