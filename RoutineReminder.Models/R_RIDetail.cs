using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class R_RIDetail
    {
        public int R_RI_Id { get; set; }
        public int RoutineId { get; set; }
        public RoutineListItem Routine { get; set; }
        public int RoutineItemId { get; set; }
        public RoutineItemListItem RotuineItem { get; set; }
    }
}
