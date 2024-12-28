using AutoMapper;
using GigGuide.Data.DTO;
using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace GigGuide.MAUI.Services
{
    public class RestService : IRestService
    {
        private HttpClient _client;
        private JsonSerializerOptions _serializerOptions;
        private IHttpsClientHandlerService _httpsClientHandlerService;
        private IMapper _mapper;

        public List<Concert>? Concerts { get; private set; }
        public List<Performance>? Performances { get; private set; }
        public List<Booking>? Bookings { get; private set; }
        public Customer? loggedInCustomer { get; set; }
        public RestService(IHttpsClientHandlerService service, IMapper mapper)
        {
            _mapper = mapper;
#if DEBUG
            _httpsClientHandlerService = service;
            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
            if (handler != null)
                _client = new HttpClient(handler);
            else
                _client = new HttpClient();
#else
            _client = new HttpClient();
#endif
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Concert>?> RefreshConcertDataAsync()
        {
            Concerts = new List<Concert>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, "Concert", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Concerts = _mapper.Map<List<Concert>>
                    (
                    JsonSerializer.Deserialize<List<ConcertDto>>(content, _serializerOptions)
                    );
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Concerts;
        }

        public async Task<List<Performance>?> RefreshPerformanceDataAsync(int? id)
        {
            Performances = new List<Performance>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, "Performance", id));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Performances = _mapper.Map<List<Performance>>
                    (
                    JsonSerializer.Deserialize<List<PerformanceDto>>(content, _serializerOptions)
                    );
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Performances;
        }
        public async Task<Customer?> GetCustomer(int customerId) // Temporary fix
        {
            if (loggedInCustomer == null)
            {
                Uri uri = new Uri(string.Format(Constants.RestUrl, "Customer", customerId));
                try
                {
                    HttpResponseMessage response = await _client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        loggedInCustomer = _mapper.Map<Customer>(
                            JsonSerializer.Deserialize<CustomerDto>(content, _serializerOptions)
                        );
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"\tERROR {0}", ex.Message);
                }
            }

            return loggedInCustomer;
        }

        public async Task<Customer?> AuthenticateCustomerAsync(string email, string password)
        {
           
            Uri uri = new Uri($"{Constants.RestUrl}/Customer/login?email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}");

            Customer? customer = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    customer = JsonSerializer.Deserialize<Customer>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return customer;
        }
        public async Task<Customer?> AuthenticateCustomerAsync2(string email, string password)
        {

            Uri uri = new Uri(string.Format(Constants.RestUrl, "Customer", $"Login/{email}/{password}"));

            Customer? customer = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    customer = JsonSerializer.Deserialize<Customer>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            loggedInCustomer = customer;
            return loggedInCustomer;
        }




        public async Task<Booking?> GetBookingByPerformanceAndCustomerAsync(int performanceId, int customerId)
        {
            Booking? booking = null;
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Booking", $"{performanceId}/{customerId}"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    booking = _mapper.Map<Booking>
                    (
                    JsonSerializer.Deserialize<BookingDto>(content, _serializerOptions)
                    );
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return booking;
        }

        public async Task<List<Booking>?> GetBookingsByCustomerAsync(int customerId)
        {
            Bookings = new List<Booking>();
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Booking", $"Customer/{customerId}"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Bookings = _mapper.Map<List<Booking>>
                    (
                    JsonSerializer.Deserialize<List<BookingDto>>(content, _serializerOptions)
                    );
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Bookings;
        }

        public async Task<Booking> SaveBookingAsync(Booking booking, bool isNewItem = false)
        {
            Booking savedBooking = null!;
            
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Booking", string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<BookingDto>(_mapper.Map<BookingDto>(booking), _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null!;
                if (isNewItem)
                {
                    // Use POST for new bookings
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    // Use PUT for updating existing bookings, include the booking ID in the URI if necessary
                    //uri = new Uri(string.Format(Constants.RestUrl, "Booking", booking.BookingId)); // Adjust if your API expects the ID in the URL
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    //Debug.WriteLine(@"\Booking successfully saved.");
                    string newContent = await response.Content.ReadAsStringAsync();
                    savedBooking = _mapper.Map<Booking>
                    (
                    JsonSerializer.Deserialize<BookingDto>(newContent, _serializerOptions)
                    );
                }
                else
                {
                    Debug.WriteLine($"\tERROR: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tERROR: {ex.Message}");
            }

            return savedBooking;
        }
        public async Task DeleteBookingAsync(int id)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Booking", id));
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tBooking successfully deleted.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
