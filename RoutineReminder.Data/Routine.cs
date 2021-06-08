using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Data
{
    public class Routine
    {
        [Key]
        public int RoutineId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string RoutineName { get; set; }
        [Required]
        public string RoutineDesc { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public TimeSpan Timeframe
        {
            get
            {
                TimeSpan timeframe = EndTime - StartTime;
                return timeframe;
            }
        }
    }
}
