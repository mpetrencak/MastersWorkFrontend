using System.ComponentModel.DataAnnotations;

namespace DP.Models.Event
{
    public class EventModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Event start time is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Event end time is required")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Event venue time is required")]
        public string Venue { get; set; }

    }
}
