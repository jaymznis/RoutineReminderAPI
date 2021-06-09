using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Data
{
    public class RoutineItem
    {
        [Key]
        public int RoutineItemId { get; set; }

        [ForeignKey(nameof(Routine))]
        public int? RoutineId { get; set; }
        public virtual Routine Routine { get; set; }

        [Required]
        public string RoutineItemName { get; set; }

        public string RoutineItemDescription { get; set; }

        public TimeSpan RoutineItemTimeframe { get; set; }

        public virtual List<Routine_RoutineItem> Routines { get; set; }
     
    }
}
