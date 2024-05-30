using ConsumeAPI.ViewModel;
using Newtonsoft.Json;
using System.Text;

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

        public async Task<customResponse<string>> BookRoomAsync(BookingViewModel bookingRequest)
        {
            var jsonContent = JsonConvert.SerializeObject(bookingRequest);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_baseAddress + "/Hotel/BookRoom", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<customResponse<string>>(responseData);
            }
            else
            {
                return new customResponse<string>()
                {
                    Succeeded = false,
                    Message = "Failed to book room"
                };
            }
        }
    }
}
