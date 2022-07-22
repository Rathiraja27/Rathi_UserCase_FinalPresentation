using Common;
using ScheduleConsumer.Interfaces;
using ScheduleConsumer.Models;

namespace ScheduleConsumer.Consumer
{
    public class ScheduleImplementation : IScheduleImplementation
    {
        #region Variable declaration

        FlightDbContext _db = new FlightDbContext();

        #endregion

        #region Public Methods

        /// <summary>Adds the schedule details.</summary>
        /// <param name="scheduleView">The schedule details.</param>
        public void AddSchedule(ScheduleEvent scheduleView)
        {
            try
            {
                Schedule schedule = new Schedule
                {
                    AirlineId = scheduleView.AirlineId,
                    BusinessClassSeats = scheduleView.BusinessClassSeats,
                    EndDateTime = scheduleView.EndDateTime,
                    FlightName = scheduleView.FlightName,
                    FromPlace = scheduleView.FromPlace,
                    InstrumentUsed = scheduleView.InstrumentUsed,
                    Meal = scheduleView.Meal,
                    NonBusinessClassSeats = scheduleView.NonBusinessClassSeats,
                    Rows = scheduleView.Rows,
                    SceduledDays = scheduleView.SceduledDays,
                    StartDateTime = scheduleView.StartDateTime,
                    TicketPrice = scheduleView.TicketPrice,
                    ToPlace = scheduleView.ToPlace
                };

                _db.Schedules.Add(schedule);
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        #endregion

    }
}
