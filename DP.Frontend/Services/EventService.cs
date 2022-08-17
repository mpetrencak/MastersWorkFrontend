using DP.Models.Event;

namespace DP.Frontend.Services
{
    public class EventService : IEventService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IAnonymousHttpClientService _anonymousHttpClientService;

        public EventService(IHttpClientService httpClientService, IAnonymousHttpClientService anonymousHttpClientService)
        {
            _httpClientService = httpClientService;
            _anonymousHttpClientService = anonymousHttpClientService;
        }

        public async Task CreateNewEventAsync(EventModel eventModel)
        {
            var request = new CreateEventRequest
            {
                Name = eventModel.Name,
                Venue = eventModel.Venue,
                StartTime = eventModel.StartTime,
                EndTime = eventModel.EndTime
            };
            await _httpClientService.PostJsonAsync("/api/Event/Create", request);
        }

        public async Task<List<EventModel>> GetAllEventsAsync()
        {
            var events = await _httpClientService.GetJsonAsync<List<EventResponse>>("/api/Event/GetAll");

            var mappedEvents = events.Select(ToEventModel).ToList();

            return mappedEvents;
        }

        public async Task<List<EventModel>> GetAllEventsAnonymousAsync()
        {
            var events = await _anonymousHttpClientService.GetJsonAsync<List<EventResponse>>("/api/Event/GetAll");

            var mappedEvents = events.Select(ToEventModel).ToList();

            return mappedEvents;
        }

        private static EventModel ToEventModel(EventResponse eventResponse)
        {
            var response = new EventModel
            {
                Id = eventResponse.Id,
                Name = eventResponse.Name,
                Venue = eventResponse.Venue,
                StartTime = eventResponse.StartTime,
                EndTime = eventResponse.EndTime,

            };
            return response;
        }
    }
}
