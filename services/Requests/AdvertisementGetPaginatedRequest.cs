namespace services.Requests
{
    public class AdvertisementGetPaginatedRequest
    {
        public int PageNum { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
    }
}
