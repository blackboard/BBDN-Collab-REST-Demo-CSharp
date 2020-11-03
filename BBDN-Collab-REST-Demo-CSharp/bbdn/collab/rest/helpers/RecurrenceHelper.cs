using CollabRestDemo.bbdn.collab.rest.models;

namespace CollabRestDemo.bbdn.collab.rest.helpers
{
    class RecurrenceHelper
    {
        public static RecurrenceRule GenerateObject()
        {
            RecurrenceRule recurrence = new RecurrenceRule();

            string[] daysOfTheWeek = new string[3];
            daysOfTheWeek[0] = "Mo";
            daysOfTheWeek[1] = "We";
            daysOfTheWeek[2] = "Fr";

            recurrence.daysOfTheWeek = daysOfTheWeek;
            recurrence.interval = 1;
            recurrence.numberOfOccurrences = 10;
            recurrence.recurrenceEndType = "after_occurrences_count";
            recurrence.recurrenceType = "weekly";

            return (recurrence);
        }

    }
}
