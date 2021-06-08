using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class RoutineItemEdit
    {
        public int RoutineItemId { get; set; }

        public int? RoutineId { get; set; }

        public string RoutineItemName { get; set; }

        public string RoutineItemDescription { get; set; }

        public TimeSpan RoutineItemTimeframe { get; set; }

    }
}
