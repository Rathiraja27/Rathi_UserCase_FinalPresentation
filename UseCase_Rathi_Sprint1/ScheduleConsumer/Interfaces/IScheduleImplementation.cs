using Common;

namespace ScheduleConsumer.Interfaces
{
    public interface IScheduleImplementation
    {
        /// <summary>Adds the schedule details.</summary>
        /// <param name="scheduleView">The schedule details.</param>
        void AddSchedule(ScheduleEvent scheduleView);
    }
}
