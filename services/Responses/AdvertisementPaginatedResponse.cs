namespace services.Responses
{
    public class AdvertisementPaginatedResponse
    {
        public IEnumerable<AdvertisementResponse> Data { get; set; }
        public int Pages { get; set; }
    }
}
