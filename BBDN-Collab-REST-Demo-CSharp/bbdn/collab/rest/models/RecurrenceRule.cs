using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabRestDemo.bbdn.collab.rest.models
{
    class RecurrenceRule
    {
        public string [] daysOfTheWeek { get; set; }

        public string recurrenceEndType { get; set; }

        public string endDate { get; set; }

        public int numberOfOccurrences { get; set; }

        public int interval { get; set; }

        public string recurrenceType { get; set; }

        public override string ToString()
        {
            return ("{  \"daysOfTheWeek\" : \"" + daysOfTheWeek.ToString() + "\"," +
                        "\"recurrenceEndType\" : \"" + recurrenceEndType + "\"," +
                        "\"endDate\" : \"" + endDate + "\"," +
                        "\"numberOfOccurrences\" : \"" + numberOfOccurrences.ToString() + "\"," +
                        "\"interval\" : \"" + interval.ToString() + "\"," +
                        "\"recurrenceType\" : \"" + recurrenceType + "\"     }");

        }
    }
}
