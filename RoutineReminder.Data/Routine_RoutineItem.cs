using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Data
{
   public class Routine_RoutineItem
    {
        [Key]
        public int R_RI_Id { get; set; }

        public int RoutineId { get; set; }
        public virtual Routine Routine { get; set; }

        public int RoutineItemId { get; set; }
        public virtual RoutineItem RoutineItem { get; set; }
    }
}
