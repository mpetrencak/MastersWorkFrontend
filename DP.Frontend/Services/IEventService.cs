using DP.Models.Event;

namespace DP.Frontend.Services
{
    public interface IEventService
    {
        Task CreateNewEventAsync(EventModel eventModel);
        Task<List<EventModel>> GetAllEventsAsync();
        Task<List<EventModel>> GetAllEventsAnonymousAsync();
    }
}
