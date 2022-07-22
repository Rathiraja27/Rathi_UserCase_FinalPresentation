using Common;
using ScheduleConsumer.Interfaces;

namespace ScheduleConsumer.Consumer
{
    public class ScheduleServiceImplementation
    {
        #region Variable Declaration

        IScheduleImplementation _scheduleImplementation;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="ScheduleServiceImplementation" /> class.</summary>
        public ScheduleServiceImplementation()
        {
            _scheduleImplementation = new ScheduleImplementation();
        }

        #endregion

        #region Public Methods

        /// <summary>Adds the inventory details.</summary>
        /// <param name="scheduleView">The schedule view.</param>
        public void AddInventory(ScheduleEvent scheduleView)
        {

            if (scheduleView != null)
            {
                _scheduleImplementation.AddSchedule(scheduleView);
            }

        }

        #endregion
    }
}
