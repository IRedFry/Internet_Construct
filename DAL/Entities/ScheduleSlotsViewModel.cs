using System.ComponentModel.DataAnnotations;

namespace DAL
{
    /// <summary>
    /// Модель данных для слота записи
    /// </summary>
    public class ScheduleSlotsViewModel
    {
        [Required]
        [Display(Name = "Service")]
        public int ServiceId { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}
