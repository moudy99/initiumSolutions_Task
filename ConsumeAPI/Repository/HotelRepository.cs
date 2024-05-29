using ConsumeAPI.ViewModel;
using Newtonsoft.Json;

namespace ConsumeAPI.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseAddress = new Uri("https://localhost:44324/api");

        public HotelRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<HotelViewModel>> GetBranchNamesAsync()
        {
            var list = new List<HotelViewModel>();
            var response = await _httpClient.GetAsync(_baseAddress + "/Hotel/GetBranchNames");

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;

                var customResponse = JsonConvert.DeserializeObject<customResponse<List<HotelViewModel>>>(responseData);

                if (customResponse.Succeeded)
                {
                    list = customResponse.Data;
                }
            }

            return list;
        }

        public Task<string> BookRoomAsync(BookingViewModel bookingRequest)
        {
            throw new NotImplementedException();
        }
    }
}
