namespace T_Car_Shop.Core.Shared
{
    public class PagedResult<T>
    {
        public IEnumerable<T>? Items { get; set; } 
        public int Count { get; set; }
        public int PageCount { get; set; }
    }
}
