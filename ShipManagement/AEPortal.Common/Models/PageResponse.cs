namespace AEPortal.Common.Models
{
    public class PageList<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
    }
}
