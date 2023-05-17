namespace AEPortal.Common.Models
{
    public class BaseSearchViewModel
    {
        public int? PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public bool SortDes { get; set; }
    }
}
